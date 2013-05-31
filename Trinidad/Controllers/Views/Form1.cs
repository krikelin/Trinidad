﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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

        public Form1()
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
            listView1.Items.Clear();
            if(File.Exists("channels.xml"))
            using (StreamReader sr = new StreamReader("channels.xml"))
            {
                String data = sr.ReadToEnd();
                String[] lines = data.Split('\n');
                foreach (String line in lines)
                {
                    String[] it = line.Split(';');
                    ListViewItem item = this.listView1.Items.Add(it[0]);
                    item.Tag = it[1];
                }
            }
          //  Scrobbler = new Application.Scrobbler("config.xml");
            tbDateTime.Text = Scrobbler.DebugTime.ToString(DateTimeOffsetFormatString);
            LoadConfig();
           
          
                
           
           
            
            
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
            try
            {


                Scrobbler.DebugTime = DateTime.Parse(tbDateTime.Text);
            }
            catch (System.FormatException fe)
            {
                MessageBox.Show("Format errro");
            }
             Scrobbler.Go(this);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cbDebug_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                Scrobbler.Debug = cbDebug.Checked;
            }
            catch (Exception ex)
            {
            }
        }

        private void tbDateTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
            if (this.listView1.SelectedItems.Count > 0)
            {
                foreach (ListViewItem _item in this.listView1.Items)
                {
                    _item.BackColor = Color.Transparent;
                    _item.ForeColor = SystemColors.WindowText;
                }
                ListViewItem item = this.listView1.SelectedItems[0];
                String channel = (String)item.Tag;
                item.BackColor = Color.Black;
                item.ForeColor = Color.LightGreen;
                Scrobbler = new Application.Scrobbler(channel);
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Instance";
                comboBox1.DataSource = Scrobbler.Players;
                Scrobbler.mplayer = new Streamers.WindowsMediaPlayer();
            }
        }
    }
}
