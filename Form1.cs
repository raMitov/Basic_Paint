using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoePaint
{
    public partial class Form1 : Form
    {
        bool fileIsOpen = false;
        public Form1()
        {
            InitializeComponent();
        }
      
        Bitmap bitm = new Bitmap(1000, 1000);
        Pen p = new Pen(Color.Black, 5);
        bool drawing = false;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Jpeg Image|*.jpg";
            openFileDialog1.Title = "Open a File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
                fileIsOpen = true;
            }
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                drawing = false;
            }
            else
            {
                drawing = true;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
            {
                Graphics g;
                if (!fileIsOpen)
                {
                     g = Graphics.FromImage(bitm);
                    g.DrawEllipse(p, e.X, e.Y, 3, 3);
                    pictureBox1.Image = bitm;
                }
                else
                {
                    g = Graphics.FromImage(pictureBox1.Image);
                    g.DrawEllipse(p, e.X, e.Y, 3, 3);
                    pictureBox1.Image = pictureBox1.Image;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            p.Color = Color.Red;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            p.Color = Color.Orange;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            p.Color = Color.Yellow;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            p.Color = Color.Lime;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            p.Color = Color.Aqua;
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            p.Color = Color.Blue;
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            p.Color = Color.Magenta;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            p.Color = Color.White;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Image|*.jpg";
            saveFileDialog1.Title = "Save an Image";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1 != null)
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                this.pictureBox1.Image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
        }

        private void Erasor_Click(object sender, EventArgs e)
        {
            p.Color = Color.Black;
        }

       
    }
}
