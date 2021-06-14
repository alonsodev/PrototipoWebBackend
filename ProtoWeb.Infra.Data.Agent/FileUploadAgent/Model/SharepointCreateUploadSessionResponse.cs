using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model
{
    public class SharepointCreateUploadSessionResponse
    {
        public string uploadUrl { get; set; }
        public DateTime expirationDateTime { get; set; }
    }


}
