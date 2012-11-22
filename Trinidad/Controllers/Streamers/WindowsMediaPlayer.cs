using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trinidad.Controllers.Streamers
{
    public class WindowsMediaPlayer : IMediaStreamer
    {
        WMPLib.WindowsMediaPlayerClass mplayer = new WMPLib.WindowsMediaPlayerClass();
    
        public string Name  
        {
	        get { throw new NotImplementedException(); }
        }

        public void Play()
        {
            mplayer.URL = url;
        }

        public void Stop()
        {
            mplayer.stop();
        }
        
        public void Load(string URL)
        {
            this.url = URL;
        }

        public int Volume
        {
            get
            {
                return this.mplayer.volume;
            }
            set
            {
                this.mplayer.volume = value;
            }
        }
        private String url;
        public string URL
        {
	          get 
	        {
                return this.url;
	        }
	          set 
	        {
                this.url = value;
	        }
        }
        private const int FPS = 10;
        System.Timers.Timer fadeInTimer;
        public void FadeIn()
        {
            fadeInTimer = new System.Timers.Timer(FPS);
            fadeInTimer.Elapsed += fadeInTimer_Elapsed;
        }
        public int MaxVolume
        {
            get
            {
                return 100;
            }
        }
        void fadeInTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(Volume < MaxVolume)
            Volume += FPS;
        }

        public void FadeOut()
        {
            if (Volume > 0)
                Volume -= FPS;
        }
    }
}

