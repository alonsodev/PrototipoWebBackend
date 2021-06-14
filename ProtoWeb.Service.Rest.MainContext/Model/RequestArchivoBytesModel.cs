
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProtoWeb.Service.Rest.MainContext.Model
{
    public class RequestArchivoBytesModel<T>
    {
        public T CuerpoRequest { get; set; }
        public IFormFile File { get; set; }
        public IFormFile File2 { get; set; }
    }
}
