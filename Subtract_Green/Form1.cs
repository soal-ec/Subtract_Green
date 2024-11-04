using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Subtract_green
{
    public partial class Form1 : Form
    {
        Bitmap greenImage, bgImage, subtracted;

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            greenImage = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = greenImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            bgImage = new Bitmap(openFileDialog2.FileName);
            pictureBox2.Image = bgImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            subtracted = new Bitmap(greenImage.Width, greenImage.Height);
            Color mgreen = Color.FromArgb(0, 0, 255);
            int greygreen = (mgreen.R + mgreen.G + mgreen.B) / 3;
            int threshold = 10;
            for (int x= 0; x < greenImage.Width; x++)
            {
                for (int y= 0; y < greenImage.Height; y++)
                {
                    Color pixel = greenImage.GetPixel(x, y);
                    Color bgpixel = bgImage.GetPixel(x, y);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);
                    if (subtractvalue > threshold)
                        subtracted.SetPixel(x, y, pixel);
                    else
                        subtracted.SetPixel(x, y, bgpixel);
                }
            }
            pictureBox3.Image = subtracted;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            subtracted.Save(saveFileDialog1.FileName);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
