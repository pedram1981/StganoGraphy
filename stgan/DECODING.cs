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
    public partial class DECODING : Form
    {
        public DECODING()
        {
            InitializeComponent();
        }
        public void Encoding_()
        {
            int[] number_ = new int[9999];
            int count = 0;
            Bitmap bitmap = new Bitmap(@textBox2.Text);
            int h = bitmap.Size.Width;
            int w = bitmap.Size.Height;
            int red1 = 0, blue1 = 0, green1 = 0;
            string s = "";
            for (int j1 = 0; j1 < 10; j1 = j1 + 3)
            {
                byte red = bitmap.GetPixel(0, j1).R;
                byte blue = bitmap.GetPixel(0, j1).B;
                byte green = bitmap.GetPixel(0, j1).G;
                red1 = (int)red;
                blue1 = (int)blue;
                green1 = (int)green;
                string b = blue1.ToString();
                if (blue1.ToString().Length == 1)
                {
                    s = s + b.ToString();
                }
                if (blue1.ToString().Length == 2)
                {
                    s = s + b[1].ToString();

                }
                if (blue1.ToString().Length == 3)
                {
                    s = s + b[2].ToString();
                }
            }
            int counter = int.Parse(s);
            for (int i = 1; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    if (count < counter)
                    {
                        byte red = bitmap.GetPixel(i, j).R;
                        byte blue = bitmap.GetPixel(i, j).B;
                        byte green = bitmap.GetPixel(i, j).G;
                        red1 = (int)red;
                        blue1 = (int)blue;
                        green1 = (int)green;
                        string b = blue1.ToString();
                        string n = "";
                        if (blue1.ToString().Length == 1)
                        {
                            number_[count] = int.Parse(b);
                        }
                        if (blue1.ToString().Length == 2)
                        {
                            number_[count] = int.Parse(b[1].ToString());

                        }
                        if (blue1.ToString().Length == 3)
                        {
                            number_[count] = int.Parse(b[2].ToString());
                        }
                        count++;
                    }
                    else
                        break;
                }
            }
            char u;
            int f = 0;
            string s3 = "", s2 = "";
            for (int i = 0; i < counter; i++)
            {
                s3 = "";
                for (int j1 = 0; j1 < 4; j1++)
                {
                    s3 = s3 + number_[f].ToString();
                    f++;
                }
                u = (char)int.Parse(s3);
                s2 = s2 + u.ToString();
            }
            textBox1.Text = s2;
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            Encoding_();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPG Files (*.jpg)|*.jpg|JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = openFileDialog1.FileName;
                pictureBox1.ImageLocation = @textBox2.Text;
            }
        }

        private void DECODING_Load(object sender, EventArgs e)
        {

        }
    }
}
