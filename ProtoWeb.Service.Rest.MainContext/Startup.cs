
using ProtoWeb.Application.MainContext.Commands.Get;
using ProtoWeb.Application.MainContext.Commands.GetList;
using ProtoWeb.Application.MainContext.Commands.Register;
using ProtoWeb.Application.MainContext.Commands.Update;
using ProtoWeb.Application.MainContext.Commands.Delete;
using ProtoWeb.Domain.Core;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;

using ProtoWeb.Infra.CrossCutting.Adapter;
using ProtoWeb.Infra.CrossCutting.Net.Adapter;
using ProtoWeb.Infra.CrossCutting.Traceability;
using ProtoWeb.Infra.CrossCutting.Net.Traceability;
using ProtoWeb.Infra.Data.MainContext.Context;
using ProtoWeb.Infra.Data.MainContext.Repositories;
using ProtoWeb.Service.Rest.MainContext.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using ProtoWeb.Infra.Data.Agent.FileUploadAgent;
using Okta.AspNetCore;
using ProtoWeb.Infra.Data.Agent.OktaAgent;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using ProtoWeb.Service.Rest.MainContext.Util;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using ProtoWeb.Infra.Data.Agent.MailSender;
using ProtoWeb.Infra.Data.Agent.PdfAgent;
using ProtoWeb.Infra.CrossCutting.Net.Word;
using ProtoWeb.Infra.CrossCutting.Net.Cryptography;
using ProtoWeb.Infra.CrossCutting.Net.Excel;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProtoWeb.Service.Rest.MainContext
{
    public class Startup
    {
        const string corsPolicy = "AllowOrigin";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Seguridad
            services.AddHttpContextAccessor();
            
           
            services.AddCors(o => o.AddPolicy(corsPolicy, builder =>
            {
                builder.WithOrigins("*")
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
            
            #endregion

            #region Server max input
            services.Configure<IISServerOptions>(options =>
            {
                options.MaxRequestBodySize = long.MaxValue;
            });
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue;
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = long.MaxValue;
            });
            #endregion

            services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.IgnoreNullValues = true;
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            AddSwagger(services);

            var autoMapperAdapterFactory = new AutoMapperTypeAdapterFactory();
            services.AddSingleton(autoMapperAdapterFactory);
            TypeAdapterFactory.SetCurrent(autoMapperAdapterFactory);

            var reflectionTraceabilityFactory = new ReflectionTraceabilityFactory();
            services.AddSingleton(reflectionTraceabilityFactory);
            EntityTraceabilityFactory.SetCurrent(reflectionTraceabilityFactory);

            var sqlConnectionString = Configuration.GetConnectionString("ProtoWebDBConnection");
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
                opt.UseSqlServer(sqlConnectionString);
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IGetCliente, GetCliente>();
            services.AddScoped<IDeleteCliente, DeleteCliente>();
            services.AddScoped<IGetListCliente, GetListCliente>();
            services.AddScoped<IRegisterCliente, RegisterCliente>();
            services.AddScoped<IUpdateCliente, UpdateCliente>();
            services.AddScoped<IClienteReadOnlyRepository, ClienteRepository>();
            services.AddScoped<IClienteWriteOnlyRepository, ClienteRepository>();


            var encryptionKey = Configuration["Encriptado:Key"];
            var encryptionIV = Configuration["Encriptado:IV"];
            services.AddScoped<ICryptography>(provider => new Cryptography(encryptionKey, encryptionIV));

            services.AddScoped<IFileUploadAgent>(x =>
                new FileUploadAgent(Configuration["FileServer"]));

            services.AddScoped<IWordHelper>(x =>
                new WordHelper(Configuration["FileServer"],
                Configuration.GetValue<string>(WebHostDefaults.ContentRootKey)));

            services.AddScoped<IExcelHelper>(x =>
                new ExcelHelper(Configuration.GetValue<string>(WebHostDefaults.ContentRootKey)));

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ExceptionFilter));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
            .AddControllersAsServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext db)
        {
            if (env.IsDevelopment())
            {                
                app.UseDeveloperExceptionPage();                
            }

            db.Database.EnsureCreated();

            Console.WriteLine("MIGRATION START: TEST BASE DE DATOS");
            // var script = db.Database.GenerateCreateScript();
            // db.Database.GetAppliedMigrations().ForAll(x => Console.WriteLine(x));
            // db.Database.Migrate();
            Console.WriteLine("MIGRATION END: TEST BASE DE DATOS");

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "Engie API V1");
            });
            app.UseCors(corsPolicy);

            app.UseRouting();

            // app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";
                
                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"ProtoWeb API {groupName}",
                    Version = groupName,
                    Description = "ProtoWeb API",
                    Contact = new OpenApiContact
                    {
                        Name = "ProtoWeb",
                        Email = string.Empty,
                        Url = new Uri("http://localhost:4200/Seguridad/Login"),
                    }
                });
                /*
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authentication: Coloque el token sin el prefijo bearer",
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                     {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        },
                        Array.Empty<string>()
                     }
                });
                */
            });
        }
    }
}
