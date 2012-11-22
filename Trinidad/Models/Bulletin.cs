using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trinidad.Models
{
    /// <summary>
    /// A bulletin
    /// </summary>
    [Serializable]
    public class Bulletin
    {
        [XmlElement("url")]
        public String Channel;
        [XmlElement("name")]
        public String Name;
        [XmlAttribute("duration")]
        public int Duration;
        [XmlElement("timing")]
        public Interval Timing;
        

        [Serializable]
        public class Interval
        {
            [XmlAttribute("type")]
            public String Type;
            [XmlAttribute("number")]
            public int Number;
            [XmlAttribute("range")]
            public int Range;
        }
    }
}
