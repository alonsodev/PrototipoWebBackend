using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtoWeb.Domain.MainContext.Aggregates.ClienteAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.MainContext.Context.Mapping
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
        }
    }
}