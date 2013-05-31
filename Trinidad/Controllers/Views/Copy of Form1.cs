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
    public partial class Forms1 : Form
    {
        private const string DateTimeOffsetFormatString = "yyyy-MM-ddTHH:mm:sszzz";

        public Forms1()
        {
            InitializeComponent();
        }
        public Controllers.Application.Scrobbler Scrobbler;
        public void LoadConfig() 
        {
        
            
            foreach (Models.Program program in Scrobbler.currentPlaylist.Programs)
            {

                var item = listView1.Items.Add(program.Title);
                item.SubItems.Add(program.Start.ToShortTimeString());
                item.SubItems.Add(program.Channel);
            }
            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            Scrobbler = new Application.Scrobbler("config.xml");
            tbDateTime.Text = Scrobbler.DebugTime.ToString(DateTimeOffsetFormatString);
            LoadConfig();
           
          
                
           
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Instance";
            comboBox1.DataSource = Scrobbler.Players;
            Scrobbler.mplayer = new Streamers.WindowsMediaPlayer();
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                Scrobbler.Player = ((Trinidad.Controllers.Application.Scrobbler.PlayerInstance)comboBox1.SelectedItem).Instance;
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
            Scrobbler.Start();
            btnStop.Enabled = Scrobbler.Enabled;
            btnStart.Enabled = !Scrobbler.Enabled;
        }
        Models.Program currentProgram = null;
        

        

        void mplayer_MediaError(object pMediaObject)
        {
        }
        

        private void btnStop_Click(object sender, EventArgs e)
        {

            btnStop.Enabled = Scrobbler.Enabled;
            btnStart.Enabled = !Scrobbler.Enabled;

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void btnInvoke_Click(object sender, EventArgs e)
        {
            Scrobbler.DebugTime = DateTime.Parse(tbDateTime.Text);
             Scrobbler.Go(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            Scrobbler.Debug = cbDebug.Checked;
        }

        private void tbDateTime_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
