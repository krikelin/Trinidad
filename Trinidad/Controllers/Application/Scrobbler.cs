using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trinidad.Controllers.Players;
using Trinidad.Models;

namespace Trinidad.Controllers.Application
{
    /// <summary>
    /// Controller for scrobbler
    /// </summary>
    public class Scrobbler
    {
        public bool Debug {get;set;}
        public DateTime DebugTime = DateTime.Now;
        public Scrobbler(String fileName)
        {
            
            this.Players.Add(new PlayerInstance("Spotify", new Controllers.Players.Spotify()));
            this.Streamers.Add(new Streamers.WindowsMediaPlayer());
            
            Timer = new System.Timers.Timer();
            Timer.Elapsed += Timer_Elapsed;
            LoadConfiguration(fileName);
        }

        void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Go(sender);
        }
        public void Start() {

            Timer.Start();
        
        }
        public void Stop()
        {
            Timer.Stop();
        }
        
        public bool Enabled
        {
            get
            {
                return this.Timer.Enabled;
            }
 
        }
        public void Go(object target)
        {
            if (Debug)
            {
                Scrobble(DebugTime);
            }
            else
            {
                Scrobble(DateTime.Now);
            }
        }
                
        /// <summary>
        /// Plaer instance
        /// </summary>
        public class PlayerInstance
        {
            public String Name;
            public IPlayer Instance;
            public PlayerInstance(String name, IPlayer instance)
            {
                this.Instance = instance;
                this.Name = name;
            }
        }
        public bool Fade { get; set; }
        public IPlayer Player;
        public Configuration config;
        private List<PlayerInstance> players = new List<PlayerInstance>();
        private List<Controllers.Streamers.IMediaStreamer> streamers = new List<Streamers.IMediaStreamer>();
        public List<PlayerInstance> Players
        {
            get
            {
                return players;
            }
        }
        public List<Controllers.Streamers.IMediaStreamer> Streamers
        {
            get
            {
                return streamers;
            }
        }
        System.Timers.Timer Timer;
        Controllers.Loaders.XmlLoader xmlLoader = new Controllers.Loaders.XmlLoader();
        public Playlist currentPlaylist;
        Models.Program currentProgram = null;
        public Streamers.IMediaStreamer mplayer;
        public Streamers.IMediaStreamer Radio
        {
            get
            {
                return mplayer;
            }
            set
            {
                mplayer = value;
            }
        }
        
        public void LoadConfiguration(String configuration)
        {

            config = xmlLoader.LoadConfiguration(configuration);
            currentPlaylist = config.Playlists[0];
        }
        public void PlayProgram(Models.Program program)
        {
            if (Fade)
            {
                mplayer.Volume = (0);
                
            }
            if (Player != null)
            {
                Player.Pause();
                mplayer.URL = program.Channel;
                
                currentProgram = program;
                mplayer.Play();
              
                return;
            }
        }

        /// <summary>
        /// Stop program
        /// </summary>
        public void StopProgram()
        {
            mplayer.Stop();
            Player.Play();
        }

        /// <summary>
        /// Scrobble
        /// </summary>
        /// <param name="time"></param>
        public void Scrobble(DateTime time)
        {

            foreach (Models.Program program in currentPlaylist.Programs)
            {
                TimeSpan subtract = time.Subtract(program.Start);

                if (subtract.TotalSeconds <= 60 && subtract.TotalSeconds > 0)
                {

                    PlayProgram(program);
                    return;
                }
                // Check if program has ended, then resume the playback
                if (currentProgram != null)
                {
                    TimeSpan minutesLeft = currentProgram.End.Subtract(time);
                    if (minutesLeft.TotalMinutes <= 1 && minutesLeft.TotalMinutes >= -1)
                    {
                        // Stop and go back
                        StopProgram();
                    }

                }

            }
            foreach (Models.Bulletin bulletin in currentPlaylist.Bulletins)
            {
                if (bulletin.Timing.Type == "hour")
                {
                    if (time.Minute == bulletin.Timing.Number && time.Hour % bulletin.Timing.Range == 0)
                    {
                        Models.Program temporaryProgram = new Models.Program(time, bulletin.Duration, bulletin.Channel);
                        currentProgram = temporaryProgram;
                        PlayProgram(temporaryProgram);
                        return;
                    }
                }

            }
        }
    }
}
