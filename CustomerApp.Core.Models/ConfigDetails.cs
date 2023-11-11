using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Core.Models
{
    public class ConfigDetails
    {
        public int id { get; set; }
        public string Type { get; set; }

        public string DatabaseName { get; set; }

        public string ContainerName { get; set; }

        public string DatabaseConn { get; set; }

        public string ObservabilityConn { get; set; }
    }
}
