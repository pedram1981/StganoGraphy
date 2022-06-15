using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace stgan
{
    public partial class set_image : Form
    {
        public set_image()
        {
            InitializeComponent();
        }
        int pulse=0;
        int[,] needle_position=new int[7,2];
        int[,] needle_color=new int[7,3];
        int row = 0;
        int col = 0;
        int step = 1;
        public void set_info()
        {
            StreamReader s = new StreamReader("pulse.dat");
            pulse= int.Parse(s.ReadLine());
            StreamReader s2 = new StreamReader("color.dat");
            pulse = int.Parse(s.ReadLine());
            for (int i = 0; i < 7; i++)
            {
                needle_color[i, 0] = int.Parse(s2.ReadLine());
                needle_color[i, 1] = int.Parse(s2.ReadLine());
                needle_color[i, 2] = int.Parse(s2.ReadLine());
                needle_position[i, 0] = row;
                needle_position[i, 1] = col;
                col = col - pulse;
            }
        }
        public void coding()
        {
            if (textBox2.Text.Length != 0)
            {
                Bitmap bitmap = new Bitmap(@textBox2.Text);
                int h = bitmap.Size.Width;
                int w = bitmap.Size.Height;
                Bitmap BM = new Bitmap(h, w);//, PixelFormat.Format24bppRgb);
                int red1 = 0, blue1 = 0, green1 = 0;
                try
                {
                    int i, j;
                    for (i = 0; i < h; i++)
                    {
                        for (j = 0; j < w; j++)
                        {
                            byte red = bitmap.GetPixel(i, j).R;
                            byte blue = bitmap.GetPixel(i, j).B;
                            byte green = bitmap.GetPixel(i, j).G;
                            red1 = (int)red;
                            blue1 = (int)blue;
                            green1 = (int)green;
                        }
                        for (int i1 = 0; i1 < 7; i1++)
                        {
                            if (red1 == needle_color[i1, 0] && blue1 == needle_color[i1, 1] && green1 == needle_color[i1, 2] && needle_position[i1, 0]==i && needle_position[i1, 1]==j)
                                serialPort1.WriteLine(i.ToString());
                            Thread.Sleep(100);
                            needle_position[i, 1] = step + needle_position[i, 1];
                        }
                        serialPort1.WriteLine("100");//move
                        //BM.SetPixel(i, j, Color.FromArgb(red1, green1, blue1));
                    }
                }
                catch
                {

                }
                //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                //saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
                //saveFileDialog1.Title = "Save an Image File";
                //saveFileDialog1.ShowDialog();
                //if (saveFileDialog1.FileName != "")
                {
                    BM.Save("print.jpg");//(@saveFileDialog1.FileName);
                }
            }
            else
                MessageBox.Show("WRITE MESSAGE");
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
        
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
          OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text=openFileDialog1.FileName;
                pictureBox1.ImageLocation = @textBox2.Text;
            }
        }

        private void set_image_Load(object sender, EventArgs e)
        {
            serialPort1.Open();
        }
            
        }
       

    }

