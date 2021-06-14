using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model
{
    public class SiteCollection
    {
        public string hostname { get; set; }
    }

    public class Value
    {
        public DateTime createdDateTime { get; set; }
        public string id { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public string name { get; set; }
        public string webUrl { get; set; }
        public string displayName { get; set; }
        public SiteCollection siteCollection { get; set; }
    }

    public class SharepointSiteByNameResult
    {
        [JsonProperty("@odata.context")]
        public string OdataContext { get; set; }
        public List<Value> value { get; set; }
    }
}
