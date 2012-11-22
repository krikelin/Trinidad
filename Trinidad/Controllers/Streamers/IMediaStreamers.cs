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

        int Volume { get; set; }
        /// <summary>
        /// URL
        /// </summary>
        String URL { get; set; }

        /// <summary>
        /// Fade in
        /// </summary>
        void FadeIn();

        /// <summary>
        /// Max Volume
        /// </summary>
        int MaxVolume { get; }

        /// <summary>
        /// Fade out
        /// </summary>
        void FadeOut();
    }
}
