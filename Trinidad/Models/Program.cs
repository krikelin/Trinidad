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
        [XmlElement("time")]
        public DateTime Start;
        [XmlElement("duration")]
        public int Duration;
        [XmlElement("channel")]
        public Channel Channel;
        public Program(DateTime start, int duration, Channel channel)
        {
            this.Channel = channel;
            this.Duration = duration;
            this.Start = start;
        }
    }
}
