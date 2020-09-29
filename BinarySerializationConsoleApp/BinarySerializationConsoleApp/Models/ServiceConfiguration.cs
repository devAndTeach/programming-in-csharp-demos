using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerializationConsoleApp.Models
{   
    [Serializable]
    public class ServiceConfiguration : ISerializable
    {

        [NonSerialized]
        private Guid _internalId;
        public string ConfigName { get; set; }
        public string DatabaseHostName { get; set; }
        public string ApplicationDataPath { get; set; }

        public ServiceConfiguration()
        {
        }
        public ServiceConfiguration(SerializationInfo info, StreamingContext ctxt)
        {
            this.ConfigName
               = info.GetValue("ConfigName", typeof(string)).ToString();
            this.DatabaseHostName
               = info.GetValue("DatabaseHostName", typeof(string)).ToString();
            this.ApplicationDataPath
               = info.GetValue("ApplicationDataPath", typeof(string)).ToString();
        }
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ConfigName", this.ConfigName);
            info.AddValue("DatabaseHostName", this.DatabaseHostName);
            info.AddValue("ApplicationDataPath", this.ApplicationDataPath);
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

