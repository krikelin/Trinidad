using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trinidad.Models.RSS
{
    [Serializable]
    public class Channel 
    {
        [XmlElement("title")]
        public String Title;
        [XmlElement("enclosure")]
        public String Enclosure;
        [XmlArrayItem("item")]
        public List<Item> Items;
    }
    public class Enclosure
    {
        [XmlAttribute("url")]
        public String URL;
       
    }
    [Serializable]
    public class Item
    {
        [XmlElement("title")]
        public String Title;
        [XmlElement("description")]
        public String Description;
        [XmlElement("enclosure")]
        public Enclosure Enclosure;
        [XmlElement("link")]
        public String Link;
        [XmlElement("pubDate")]
        public String Date;
    }
    /// <summary>
    /// RSS
    /// </summary>
    [Serializable]
    [XmlRoot("rss")]
    public class RSS
    {
        [XmlElement("channel")]
        public Channel Channel;

    }
}
