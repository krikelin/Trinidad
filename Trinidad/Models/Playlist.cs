using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trinidad.Models
{
    [Serializable]
    [XmlRoot("Channel", Namespace="http://segurify.com/TR/2012/Channel")]
    public class Playlist
    {
        [XmlElement("Channel")]
        public Channel Channel;
        [XmlArray("Program")]
        public List<Program> Programs;
        [XmlElement("name")]
        public String Name;
    }
}
