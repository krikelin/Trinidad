using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Trinidad.Models
{
    /// <summary>
    /// A radio program
    /// </summary>
    [Serializable]
    [XmlRoot("program", Namespace="http://segurify.com/TR/2012/Channel")]
    public class Program
    {
        private const string DateTimeOffsetFormatString = "yyyy-MM-ddTHH:mm:sszzz";
        public DateTime Start;
        [XmlElement("time")]
        public String Time
        {
            get
            {
                return Start.ToString(DateTimeOffsetFormatString);
            }
            set
            {
                Start = DateTime.Parse(value);
            }
        }
        [XmlElement("duration")]
        public int Duration;
        [XmlElement("url")]
        public String Channel;
        [XmlElement("title")]
        public String Title;
        public Program()
        {
        }
        public Program(DateTime start, int duration, String channel)
        {
            this.Channel = channel;
            this.Duration = duration;
            this.Start = start;
        }
    }
}
