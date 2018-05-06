using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Operations
{
    class Program
    {
        public static void Main(string[] args)
        {
            var operationFiles = Directory.GetFiles("operations");
            var xmlOperationSerializer = new XmlSerializer(typeof(Operation));
            var operations = new Operation[operationFiles.Length];
            Operation maxOperation = null;
            foreach (var file in operationFiles)
            {
                try
                {
                    using (var reader = new StreamReader(file))
                    {
                        Operation newOperation = null;
                        var ext = Path.GetExtension(file);
                        if (ext == ".json")
                        {
                            newOperation = JsonConvert.DeserializeObject<Operation>(reader.ReadToEnd());
                        }
                        else if (ext == ".xml")
                        {
                            newOperation = (Operation)xmlOperationSerializer.Deserialize(reader);
                        }

                        if (newOperation != null && (maxOperation == null || maxOperation.Amount < newOperation.Amount))
                        {
                            maxOperation = newOperation;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("File {0} is incorrect", file);
                }
            }
            Console.WriteLine();
            Console.WriteLine("Type: {0}; Amount: {1}; Date: {2}", maxOperation.OperationType, maxOperation.Amount, maxOperation.Date);
        }
    }
}
