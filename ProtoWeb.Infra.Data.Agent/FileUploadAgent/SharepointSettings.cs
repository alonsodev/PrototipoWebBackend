using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ProtoWeb.Infra.Data.Agent.FileUploadAgent
{
    public class SharepointSettings
    {
        public string Instance { get; set; } = "https://login.microsoftonline.com/{0}";
        public string ApiUrl { get; set; } = "https://graph.microsoft.com/";
        public string ClientId { get; set; }
        public string SecretId { get; set; }
        public string ClientSecret { get; set; }
        public string SiteUrl { get; set; }
        public string SiteName { get; set; }
        public string TenantId { get; set; }
        public string ListName { get; set; }

        public string Authority
        {
            get
            {
                return string.Format(CultureInfo.InvariantCulture, Instance, TenantId);
            }
        }
    }
}
