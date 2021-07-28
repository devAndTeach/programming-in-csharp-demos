using BinarySerializationConsoleApp.Models;
using Json.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace BinarySerializationConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the object you want to serialize.
            ServiceConfiguration config = ServiceConfiguration.Default;
            // Create the formatter you want to use to serialize the object.
            IFormatter formatter = new BinaryFormatter();
            // Create the stream that the serialized data will be buffered to.
            FileStream buffer = File.Create($@"{System.Environment.CurrentDirectory}\config_without_interface.txt");
            // Invoke the Serialize method.
            formatter.Serialize(buffer, config);
            // Close the stream.
            buffer.Close();

            Console.WriteLine("ServiceConfiguration instance serialized....");

            var data = JsonNet.Serialize(config);
            File.WriteAllText($@"{System.Environment.CurrentDirectory}\serviceconfiguration.json",data);

            Console.WriteLine("ServiceConfiguration instance as JSON....");


        }
    }
}
