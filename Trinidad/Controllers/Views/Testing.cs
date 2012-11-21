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

namespace Trinidad
{
    public partial class Form1 : Form
    {
        
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
        private List<PlayerInstance> Players = new List<PlayerInstance>();
        private void Form1_Load(object sender, EventArgs e)
        {
          
          
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

        private void button2_Click(object sender, EventArgs e)
        {

        }
      
        private void btnStart_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = timer1.Enabled;
            btnStart.Enabled = !timer1.Enabled;
        }
        private void Scrobble()
        {
            if (Player != null)
            {
                Player.Pause();
                axWindowsMediaPlayer1.URL = cbURL.Text;
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
