using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model
{
    public class SharepointGetFileResponseUser
    {
        public string id { get; set; }
        public string displayName { get; set; }
    }

    public class SharepointGetFileResponseCreatedBy
    {
        public SharepointGetFileResponseUser user { get; set; }
    }

    public class SharepointGetFileResponseFolder
    {
        public int childCount { get; set; }
    }

    public class SharepointGetFileResponseLastModifiedBy
    {
        public SharepointGetFileResponseUser user { get; set; }
    }

    public class SharepointGetFileResponse
    {
        public SharepointGetFileResponseCreatedBy createdBy { get; set; }
        public DateTime createdDateTime { get; set; }
        public string cTag { get; set; }
        public string eTag { get; set; }
        public SharepointGetFileResponseFolder folder { get; set; }
        public string id { get; set; }
        public SharepointGetFileResponseLastModifiedBy lastModifiedBy { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public string name { get; set; }
        public object root { get; set; }
        public int size { get; set; }
        public string webUrl { get; set; }
    }
}
