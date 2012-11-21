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
            listView1.AutoResizeColumns( ColumnHeaderAutoResizeStyle.ColumnContent);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
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
        Program currentProgram = null;
        private void Scrobble(DateTime time)
        {
            foreach (Models.Program program in currentPlaylist.Programs)
            {
                TimeSpan subtract = time.Subtract(program.Start);
                if (subtract.TotalSeconds <= 60 && subtract.TotalSeconds > 0)
                {

                    if (Player != null)
                    {
                        Player.Pause();
                        axWindowsMediaPlayer1.URL = cbURL.Text;
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                }
                
            }
           

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btnStop.Enabled = timer1.Enabled;
            btnStart.Enabled = !timer1.Enabled;

        }
    }
}
