using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinidad.Controllers.Players
{
    /// <summary>
    /// A music player to control
    /// </summary>
    public interface IPlayer
    {
        /// <summary>
        /// Name
        /// </summary>
        String Name
        {
            get;
        }

        /// <summary>
        /// Pause
        /// </summary>
        void Pause();

        /// <summary>
        /// Play
        /// </summary>
        void Play();
        /// <summary>
        /// Fade in
        /// </summary>
        void FadeIn();

        /// <summary>
        /// Get set the volume
        /// </summary>
        int Volume { get; set; }

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
