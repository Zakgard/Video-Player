using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Проигрыватель
{
    public partial class Form1 : Form
    {
        private int _seconds;
        private int _hours;
        private int _minutes;
        private int _videoOrderNumber=0;

        private string _filePath;
        public static string[] playList= new string[1];

        Form2 form2 = new Form2(playList);


        OpenFileDialog openFileDialogForSinglehoice = new OpenFileDialog()
        {
            
            Multiselect = false,
            ValidateNames = true,
        };

        OpenFileDialog openFileDialogForMultiplyChoice = new OpenFileDialog()
        {
            
            Multiselect = true,
            ValidateNames = true,
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Value = 50;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialogForSinglehoice.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialogForSinglehoice.FileName;
                playList[_videoOrderNumber]=_filePath;
                WMP.URL = playList[_videoOrderNumber];
                _videoOrderNumber++;
                Array.Resize(ref playList, playList.Length+1);
            }else
                return;
            
        }

        private void WMP_Enter(object sender, EventArgs e)
        {

        }

        private void WMP_Enter_1(object sender, EventArgs e)
        {

        }

        private void WMP_Enter_2(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.play();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.pause();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            WMP.settings.volume = trackBar1.Value;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void WMP_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            timer1.Enabled = true;
            timer1.Interval = 1000;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            trackBar2.Maximum = Convert.ToInt32(WMP.currentMedia.duration);
            trackBar2.Value = Convert.ToInt32(WMP.Ctlcontrols.currentPosition);
            if (WMP != null)
            {
                _seconds=(int)WMP.Ctlcontrols.currentPosition;
                _hours = _seconds / 3600;
                _minutes = (_seconds-(_hours*3600))/60;
                _seconds -= _hours*3600+_minutes*60;
                label2.Text = String.Format("{0:D}:{1:D2}:{2:D2}", _hours, _minutes, _seconds);
            }
            else
            {
                label2.Text = "0:00:00";
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            WMP.Ctlcontrols.currentPosition = trackBar2.Value;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            while (openFileDialogForMultiplyChoice.ShowDialog() == DialogResult.OK)
            {
                _filePath = openFileDialogForSinglehoice.FileName;
                playList[_videoOrderNumber] = _filePath;


            }
            
              
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }
    }
}
