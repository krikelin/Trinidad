using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trinidad.Models
{
    /// <summary>
    /// A channel is a channel file
    /// </summary>
    [Serializable]
    [XmlRoot("Channel", Namespace="http://segurify.com/TR/2012/Channel")]
    public class Channel
    {
        [XmlElement("name")]
        public String Name;
        [XmlElement("url")]
        public String URL;
        [XmlElement("playlist")]
        public Playlist Playlist;
        public Channel(String name, String url)
        {
            this.Playlist = new Playlist();
            this.Name = name;
            this.URL = url;
        }
    }
}
