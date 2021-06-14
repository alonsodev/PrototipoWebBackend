using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model
{
    public class Application
    {
        public string id { get; set; }
        public string displayName { get; set; }
    }

    public class CreatedBy
    {
        public Application application { get; set; }
    }

    public class LastModifiedBy
    {
        public Application application { get; set; }
    }

    public class ParentReference
    {
        public string driveId { get; set; }
        public string driveType { get; set; }
        public string id { get; set; }
        public string path { get; set; }
    }

    public class FileSystemInfo
    {
        public DateTime createdDateTime { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
    }

    public class CreatedFolder
    {
        public int childCount { get; set; }
    }

    public class SharepointCreateFolderResponse
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public DateTime createdDateTime { get; set; }
        public string eTag { get; set; }
        public string id { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public string name { get; set; }
        public string webUrl { get; set; }
        public string cTag { get; set; }
        public int size { get; set; }
        public CreatedBy createdBy { get; set; }
        public LastModifiedBy lastModifiedBy { get; set; }
        public ParentReference parentReference { get; set; }
        public FileSystemInfo fileSystemInfo { get; set; }
        public CreatedFolder folder { get; set; }
    }
}
