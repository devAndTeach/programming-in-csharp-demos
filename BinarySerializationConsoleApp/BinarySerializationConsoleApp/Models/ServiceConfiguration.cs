using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerializationConsoleApp.Models
{   
    [Serializable]
    public class ServiceConfiguration 
    {

        [NonSerialized]
        private Guid _internalId;

        public string DatabaseHostName { get; set; }
        public string ApplicationDataPath { get; set; }
        public string ConfigName { get; set; }
      

        public ServiceConfiguration()
        {
        }
       



        public static ServiceConfiguration Default
        {
            get
            {
                return new ServiceConfiguration()
                {
                    ConfigName = "Development",
                    DatabaseHostName = "dev.db.server",
                    ApplicationDataPath = "C://path/to/app/data"
                };
            }
        }

    }

}

