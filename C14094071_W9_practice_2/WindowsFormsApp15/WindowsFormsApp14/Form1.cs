using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp14
{
    public partial class Form1 : Form
    {
        public MusicPlayer mp = new MusicPlayer();
        public static GroupBox groupbox2;
        public static RadioButton[] rb;
        public static string playsong_name="";
        public static string[] files = new string[1] {"0"};
        public int count = 0;
        public Font font;
        public Color color;
        public Form1()
        {
            
            InitializeComponent();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            files = mp.SelectWavFiles();
            if (MusicPlayer.selectfiles == true)
            {
                groupbox2.Controls.Clear();
                

                Count();

                int i = 0;
                foreach (var itmes in files)
                {

                    rb[i] = new RadioButton();
                    rb[i].Size = new Size(500, 40);
                    rb[i].Text = itmes;
                    rb[i].Left = 20;
                    rb[i].Top = i * 40 + 20;
                    rb[0].Top = 20;
                    rb[i].CheckedChanged += rb_CheckedChanged;
                    rb[i].AutoSize = true;
                    rb[i].ForeColor = color;
                    rb[i].Font = font;
                    groupbox2.Controls.Add(rb[i]);
                    i++;

                }
            }
            MusicPlayer.selectfiles = false;
            
        }
        public void Count()
        {
            foreach (var itmes in files)
            {
                count++;
            }
            Console.WriteLine("@@{0}@@", count);
            rb = new RadioButton[count];
            count = 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            set_groupbox2();
            font = checkBox1.Font;
            color = checkBox1.ForeColor;
            

        }
        public void set_groupbox2()
        {
            groupBox1.Hide();
            groupbox2 = new GroupBox();
            groupbox2.Size = groupBox1.Size;
            groupbox2.Left = groupBox1.Left;
            groupbox2.Top = groupBox1.Top;
            groupbox2.Text = "Playlist";
            this.Controls.Add(groupbox2);
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton btn_touch = (RadioButton)sender;
            if(btn_touch.Checked == true)
            {
                //Console.WriteLine(btn_touch.Text);
                playsong_name = btn_touch.Text;
            }
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

            mp.new_player();
            mp.play();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                MusicPlayer.repeat_bool = true;
            }
            else
            {
                MusicPlayer.repeat_bool = false;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mp.stop();
           

        }

        private void saveToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if(files[0] != "0")
                {
                    StreamWriter sw = new StreamWriter(@"..\..\新文字文件.txt");
                    foreach (var items in files)
                    {

                        sw.Write(items + "\r");
                    }

                    sw.Close();
                }
                else
                {
                    MessageBox.Show("請先確立撥放清單");
                }
                
            }
            catch
            {
                MessageBox.Show("請先確立撥放清單");
            }
                
            
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                OpenFileDialog loadfiles = new OpenFileDialog();
                string path = "";
                if (loadfiles.ShowDialog() == DialogResult.OK)
                {
                    path = loadfiles.FileName;
                    MusicPlayer.selectfiles = true;
                }
                if(MusicPlayer.selectfiles == true)
                {
                    groupbox2.Controls.Clear();
                    StreamReader sr = new StreamReader(path);
                    foreach (string line in File.ReadLines(path))
                    {
                        count++;

                    }
                    rb = new RadioButton[count];
                    count = 0;
                    int i = 0;
                    foreach (string line in File.ReadLines(path))
                    {

                        rb[i] = new RadioButton();
                        rb[i].Size = new Size(500, 40);
                        rb[i].Text = line;
                        rb[i].Left = 20;
                        rb[i].Top = i * 40 + 20;
                        rb[0].Top = 20;
                        rb[i].CheckedChanged += rb_CheckedChanged;
                        rb[i].AutoSize = true;
                        rb[i].ForeColor = color;
                        rb[i].Font = font;
                        groupbox2.Controls.Add(rb[i]);
                        i++;

                    }
                    sr.Close();
                }
                MusicPlayer.selectfiles = false;
            }
            catch { }
            
            
            

        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                foreach (var items in groupbox2.Controls.OfType<RadioButton>())
                {
                    items.ForeColor = cd.Color;
                    color = items.ForeColor;
                }

            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                foreach(var items in groupbox2.Controls.OfType<RadioButton>())
                {
                    items.Font = fd.Font;
                    font = items.Font;
                }

            }
        }
    }
    public class MusicPlayer : SoundPlayer
    {
        public bool Loop = false;
        public string[] Playlist;
        public SoundPlayer player;
        public static bool player_bool = false, repeat_bool = false,play_finish=false;
        public Thread thread;
        public static Form2 f2 = null;
        public static bool selectfiles = false;

        public string[] SelectWavFiles()
        {
            OpenFileDialog openfiles = new OpenFileDialog();
            openfiles.Multiselect = true;
            
            openfiles.Filter = "Text files (*.wav)|*.wav";
            openfiles.FilterIndex = 4;
            string[] files1 = { };
            if (openfiles.ShowDialog() == DialogResult.OK)
            {
                int h = 0;
                foreach(var items in openfiles.FileNames.Take(4))
                {
                   
                    Array.Resize(ref files1, files1.Length + 1);
                    files1[h] = items;
                    h++;
                }
                
                selectfiles = true;
            }

            return files1;
        }

        public void new_player()
        {
            if (Form1.playsong_name != "")
            {
                player = new SoundPlayer(Form1.playsong_name);
              
                player_bool = true;
            }
            
        }
        public void play()
        {
            
            if (Form1.playsong_name != "")
            {
                try
                {
                    f2.Hide();
                }
                catch { }
                if (repeat_bool == true)
                {
                    player.PlayLooping();
                    if (f2 == null)
                    {
                        f2 = new Form2();

                    }
                    f2.Show();
                }
                else
                {
             
                    player.Play();
                  
                }
                

            }



        }

    

        public void stop()
        {
            try
            {
                f2.Hide();
            }
            catch { }
            try
            {
                player.Stop();
            }
            catch
            {
                Console.WriteLine("!!");
            }
            
        }

    }
}
