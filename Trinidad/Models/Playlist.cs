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
        
        [XmlArray("programs")]
        [XmlArrayItem("program")]
        public Program[] Programs;
        [XmlArray("bulletins")]
        [XmlArrayItem("bulletin")]
        public Bulletin[] Bulletins;
        [XmlElement("name")]
        public String Name;
    }
}
