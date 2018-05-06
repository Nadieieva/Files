using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Files
{
    class Program
    {
        static void Main(string[] args)
        {
            var xmlClientBadNamingSerializer = new XmlSerializer(typeof(ClientBadNaming));
            ClientInfo clientInfo;
            ClientAddress HomeAddress;
            ClientAddress WorkAddress;

            using (var reader = new StreamReader("clientinfo_input.xml"))
            {
                ClientBadNaming ClientBad = (ClientBadNaming)xmlClientBadNamingSerializer.Deserialize(reader);
                clientInfo = new ClientInfo
                {
                    Name = ClientBad.fn,
                    LastName = ClientBad.ln,
                    MiddleName = ClientBad.mn,
                    Phone = ClientBad.p,
                    Email = ClientBad.e,
                    Birthday = new DateTime(ClientBad.by, ClientBad.bm, ClientBad.bd)
                };

                HomeAddress = new ClientAddress
                {
                    Address = ClientBad.hl1,
                    City = ClientBad.hc,
                    State = ClientBad.hs,
                    Zip = ClientBad.hz
                };

                WorkAddress = new ClientAddress
                {
                    Address = ClientBad.wl1,
                    City = ClientBad.wc,
                    State = ClientBad.ws,
                    Zip = ClientBad.wz
                };
            }

            var xmlClientInfoSerializer = new XmlSerializer(typeof(ClientInfo));
        
            using (var writer = new StreamWriter("clientinfo_output.xml"))
            {
                xmlClientInfoSerializer.Serialize(writer, clientInfo);
            }

            using (var writer = new StreamWriter("clientinfo_output.json"))
            {
                writer.WriteLine(JsonConvert.SerializeObject(clientInfo));
            }

            var xmlClientAddressSerializer = new XmlSerializer(typeof(ClientAddress));
            using (var writer = new StreamWriter("workaddress_output.xml"))
            {
                xmlClientAddressSerializer.Serialize(writer, WorkAddress);
            }

            using (var writer = new StreamWriter("homeaddress_output.json"))
            {
                writer.WriteLine(JsonConvert.SerializeObject(HomeAddress));
            }

        }
    }
}
