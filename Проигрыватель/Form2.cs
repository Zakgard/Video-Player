using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Проигрыватель
{
    public partial class Form2 : Form
    {

        private static string[] videoPlayList = new string[arrayLenght];
        private static int arrayLenght;
        public Form2(string[]playList)
        {
            InitializeComponent();
            dataGridView1 = new DataGridView();
            arrayLenght=playList.Length;
            videoPlayList = playList;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            for (int i=0; i< videoPlayList.Length-1; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = videoPlayList[i];
                dataGridView1.Rows[i].Cells[1].Value = i + 1;

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
