using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                Configuration configuration = (Configuration)serializer.Deserialize(new XmlTextReader(new FileStream(adress, FileMode.Open)));
                return configuration;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
