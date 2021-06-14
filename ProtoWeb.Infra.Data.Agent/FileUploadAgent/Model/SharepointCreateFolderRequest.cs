using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent.Model
{
    public class SharepointCreateFolderRequest
    {
        public string name { get; set; }
        public Folder folder { get; set; }

        [JsonProperty("@microsoft.graph.conflictBehavior")]
        public string MicrosoftGraphConflictBehavior { get; set; }
    }

    public class Folder
    {
    }
}
