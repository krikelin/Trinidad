using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trinidad.Models
{
    [Serializable]
    [XmlRoot("configuration", Namespace="http://segurify.com/TR/2012/Channel")]
    public class Configuration
    {
        [XmlArrayItem("playlist")]
        [XmlArray("playlists")]
        public List<Playlist> Playlists = new List<Playlist>();
    }
}
