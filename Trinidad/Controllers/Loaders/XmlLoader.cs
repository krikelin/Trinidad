using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Trinidad.Models;

namespace Trinidad.Controllers.Loaders
{
    /// <summary>
    /// Load playlists from XML
    /// </summary>
    class XmlLoader : ILoader
    {
        public Models.Configuration LoadConfiguration(string adress)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Models.Configuration));
                Stream inputStream = null;
                if (adress.StartsWith("http:"))
                {
                    WebClient wc = new WebClient();
                    inputStream = new MemoryStream(wc.DownloadData(adress));
                }
                else
                {
                    inputStream = new FileStream(adress, FileMode.Open);
                }
                Configuration configuration = (Configuration)serializer.Deserialize(new XmlTextReader(inputStream));
                return configuration;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
