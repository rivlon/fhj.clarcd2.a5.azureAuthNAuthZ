using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesAzureStorageWebApp.Models
{
    public class AzureStorageConfig
    {
        public string AccountName { get; set; }
        public string ContainerName { get; set; }
        public string ConnectionString { get; set; }
    }
}
