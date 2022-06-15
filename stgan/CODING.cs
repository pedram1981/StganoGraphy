using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stgan
{
    public partial class CODING : Form
    {
        public CODING()
        {
            InitializeComponent();
        }
        public void coding()
        {   ////////////////////////
            if (textBox2.Text.Length != 0)
            {
                if (textBox1.Text.Length != 0)
                {
                    string s = textBox1.Text;
                    int[] c = new int[9999];
                    int number_, count = 0;
                    string s1 = "", s2 = "";
                    for (int i = 0; i < textBox1.Text.Length; i++)
                    {
                        number_ = s[i];
                        s1 = "";
                        for (int i1 = 0; i1 < 4 - number_.ToString().Length; i1++)
                        {
                            s1 = s1 + "0";
                        }
                        s2 = s1 + number_.ToString();
                        for (int i2 = 0; i2 < 4; i2++)
                        {
                            c[count] = int.Parse(s2[i2].ToString());
                            count++;
                        }
                    }
                    /////////////////////////

                    Bitmap bitmap = new Bitmap(@textBox2.Text);
                    int h = bitmap.Size.Width;
                    int w = bitmap.Size.Height;
                    Bitmap BM = new Bitmap(h, w);//, PixelFormat.Format24bppRgb);
                    int red1 = 0, blue1 = 0, green1 = 0;
                    s1 = "";
                    for (int i1 = 0; i1 < 4 - count.ToString().Length; i1++)
                    {
                        s1 = s1 + "0";
                    }
                    string count_ = s1 + count.ToString();
                    bool flag = true;
                    int counter = 0;
                    try
                    {
                        for (int i = 0; i < h; i++)
                        {
                            for (int j = 0; j < w; j++)
                            {
                                byte red = bitmap.GetPixel(i, j).R;
                                byte blue = bitmap.GetPixel(i, j).B;
                                byte green = bitmap.GetPixel(i, j).G;
                                red1 = (int)red;
                                blue1 = (int)blue;
                                green1 = (int)green;
                                string b = blue1.ToString();
                                string n = "";
                                if (flag == false && counter < count)
                                {
                                    if (blue1.ToString().Length == 1)
                                    {
                                        blue1 = c[counter];
                                    }
                                    else if (blue1.ToString().Length == 2)
                                    {
                                        n = b[0].ToString();
                                        n = n + c[counter];
                                        blue1 = int.Parse(n);
                                    }
                                    else if (blue1.ToString().Length == 3)
                                    {
                                        n = b[0].ToString() + b[1].ToString();
                                        n = n + c[counter];
                                        blue1 = int.Parse(n);
                                    }
                                    counter++;
                                }

                                BM.SetPixel(i, j, Color.FromArgb(red1, green1, blue1));
                            }
                            if (flag)
                            {
                                flag = false;
                                int l = 0;
                                for (int j1 = 0; j1 < 10; j1 = j1 + 3)
                                {
                                    byte red = bitmap.GetPixel(0, j1).R;
                                    byte blue = bitmap.GetPixel(0, j1).B;
                                    byte green = bitmap.GetPixel(0, j1).G;
                                    red1 = (int)red;
                                    blue1 = (int)blue;
                                    green1 = (int)green;

                                    string b = blue1.ToString();
                                    string n = "";
                                    if (blue1.ToString().Length == 1)
                                    {
                                        blue1 = count_[l];
                                    }
                                    else if (blue1.ToString().Length == 2)
                                    {
                                        n = b[0].ToString();
                                        n = n + count_[l];
                                        blue1 = int.Parse(n);
                                    }
                                    else if (blue1.ToString().Length == 3)
                                    {
                                        n = b[0].ToString() + b[1].ToString();
                                        n = n + count_[l];
                                        blue1 = int.Parse(n);
                                    }
                                    l++;
                                    BM.SetPixel(0, j1, Color.FromArgb(red1, green1, blue1));

                                }
                            }
                        }
                    }
                    catch
                    {

                    }
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
                    saveFileDialog1.Title = "Save an Image File";
                    saveFileDialog1.ShowDialog();
                    if (saveFileDialog1.FileName != "")
                    {
                        BM.Save(@saveFileDialog1.FileName);
                        MessageBox.Show("<<<Coding successful>>>");
                    }
                }
                else
                {
                    MessageBox.Show("WRITE MESSAGE");
                }
            }
            else
                MessageBox.Show("SELECT PICTURE");
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            coding();
           
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

        private void CODING_Load(object sender, EventArgs e)
        {
            
        }
    }
}
