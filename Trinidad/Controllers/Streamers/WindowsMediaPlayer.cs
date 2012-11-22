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

        public void setVolume(int vol)
        {
            mplayer.volume = vol;
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
    }
}

