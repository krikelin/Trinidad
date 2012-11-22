using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinidad.Controllers.Streamers
{
    /// <summary>
    /// Media Streamer
    /// </summary>
    public interface IMediaStreamer
    {
        /// <summary>
        /// Name of streaming provider
        /// </summary>
        String Name { get; }
        /// <summary>
        /// Play
        /// </summary>
        void Play();
        /// <summary>
        /// Stop
        /// </summary>
        void Stop();
        /// <summary>
        /// Load media
        /// </summary>
        /// <param name="URL"></param>
        void Load(String URL);
        /// <summary>
        /// Set volume
        /// </summary>
        /// <param name="vol"></param>
        void setVolume(int vol);
        /// <summary>
        /// URL
        /// </summary>
        String URL { get; set; }
    }
}
