using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model
{
    public class SharepointUploadSmallFileResponse
    {
        public string id { get; set; }
        public string name { get; set; }
        public int size { get; set; }
        public SharepointUploadSmallFileResponseFile file { get; set; }
    }

    public class SharepointUploadSmallFileResponseFile
    {
    }
}
