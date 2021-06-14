using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model
{ 
    public class SharepointCreateUploadSessionRequestItem
    {
        public string name { get; set; }
    }

    public class SharepointCreateUploadSessionRequest
    {
        public SharepointCreateUploadSessionRequestItem item { get; set; }
    }
}
