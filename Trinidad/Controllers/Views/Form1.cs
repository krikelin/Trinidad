using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trinidad.Controllers.Players;
using Trinidad.Models;

namespace Trinidad.Controllers.Views
{
    public partial class Form1 : Form
    {
        private const string DateTimeOffsetFormatString = "yyyy-MM-ddTHH:mm:sszzz";
        public IPlayer Player;
        public Form1()
        {
            InitializeComponent();
        }
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
        private Configuration config;
        private List<PlayerInstance> Players = new List<PlayerInstance>();
        Controllers.Loaders.XmlLoader xmlLoader = new Controllers.Loaders.XmlLoader();
        private Playlist currentPlaylist;
        private void LoadConfig()
        {
            config = xmlLoader.LoadConfiguration("config.xml");
            currentPlaylist  = config.Playlists[0];
            foreach (Models.Program program in currentPlaylist.Programs)
            {

                var item = listView1.Items.Add(program.Title);
                item.SubItems.Add(program.Start.ToShortTimeString());
                item.SubItems.Add(program.Channel);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        WMPLib.WindowsMediaPlayerClass mplayer;
        private void Form1_Load(object sender, EventArgs e)
        {
            mplayer = new WMPLib.WindowsMediaPlayerClass();
            tbDateTime.Text = DateTime.Now.ToString(DateTimeOffsetFormatString);
            LoadConfig();
           
          
                Players.Add( new PlayerInstance("Spotify", new Controllers.Players.Spotify()));
           
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Instance";
            comboBox1.DataSource = Players;
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.Player = ((PlayerInstance)comboBox1.SelectedItem).Instance;
            }
            catch (Exception ex)
            {
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            cbURL.Enabled = radioButton1.Checked;
            listView1.Enabled = radioButton2.Checked;
        }

        
      
        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            btnStop.Enabled = timer1.Enabled;
            btnStart.Enabled = !timer1.Enabled;
        }
        Models.Program currentProgram = null;
        private void PlayProgram(Models.Program program)
        {
            if (Player != null)
            {
                Player.Pause();
                mplayer.URL = program.Channel;
                mplayer.MediaError += mplayer_MediaError;
                currentProgram = program;
                mplayer.play();
                //axWindowsMediaPlayer1.Ctlcontrols.play();
                return;
            }
        }
        private void Scrobble(DateTime time)
        {
            foreach (Models.Bulletin bulletin in currentPlaylist.Bulletins)
            {
                if(bulletin.Timing.Type == "hour") 
                {
                    if (time.Minute == bulletin.Timing.Number && time.Hour % bulletin.Timing.Range == 0)
                    {
                        Models.Program temporaryProgram = new Models.Program(DateTime.Now, bulletin.Duration, bulletin.Channel);
                        currentProgram = temporaryProgram;
                        PlayProgram(temporaryProgram);
                        return;
                    }
                }

            }
            foreach (Models.Program program in currentPlaylist.Programs)
            {
                TimeSpan subtract = time.Subtract(program.Start);

                if (subtract.TotalSeconds <= 60 && subtract.TotalSeconds > 0)
                {

                    PlayProgram(program);
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
           

        }

        private void StopProgram()
        {
            mplayer.stop();
            Player.Play();
        }

        void mplayer_MediaError(object pMediaObject)
        {
            throw new NotImplementedException();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Scrobble(DateTime.Now);

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnStop.Enabled = timer1.Enabled;
            btnStart.Enabled = !timer1.Enabled;

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            Scrobble(DateTime.Parse(tbDateTime.Text));
        }
    }
}
