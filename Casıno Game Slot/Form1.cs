using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Casıno_Game_Slot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random odun = new Random();
        int r1, r2, r3, move;
        int a;
        int b;

        public void button1_Click(object sender, EventArgs e)
        {
            b++;//5. oynamada kazandırmak için
            if (textBox1.Text == null || textBox1.Text == string.Empty)
            {
                MessageBox.Show("You Can't Play Games Without Deposit");
            }
            else
            {
                a = Convert.ToInt32(lbl_balance.Text);

                a += int.Parse(textBox1.Text);
                lbl_balance.Text = a.ToString();
                textBox1.Clear();
                if (int.Parse(lbl_balance.Text) > 0)
                {
                    string konum = Application.StartupPath + "\\song.wav";
                    gazıno.SoundLocation = konum;
                    gazıno.Play();
                    timer1.Start();
                }
                else
                {
                    MessageBox.Show("Yetersiz Bakiye");
                }
            }








        }
        void Kazanıldı()
        {
            //if (pictureBox1 == pictureBox2 || pictureBox2 == pictureBox3 || pictureBox3 == pictureBox1)
            //{
            //    MessageBox.Show("Kazandınız");
            //}

            if (r1 == r2 && r3 == r2)
            {
                a = a * 2;
               
                label5.Text=(a.ToString() + " TL You Win");
                lbl_balance.Text = "0";


            }
            else
            {
                label5.Text =("You Lost");
                a -= a;
            }
            lbl_balance.Text = a.ToString();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.BackColor = Color.Transparent;
        }



        SoundPlayer gazıno = new SoundPlayer();

        private void timer1_Tick(object sender, EventArgs e)
        {
            move++;

            if (move < 30)
            {
                if (b == 5 && move == 29)
                {
                    r1 = odun.Next(0, 1);
                    r2 = odun.Next(0, 1);
                    r3 = odun.Next(0, 1);
                }
                else
                {
                    r1 = odun.Next(0, 3);
                    r2 = odun.Next(0, 3);
                    r3 = odun.Next(0, 3);
                }


                switch (r1)
                {
                    case 0:
                        pictureBox1.Image = Properties.Resources.mango;
                        break;
                    case 1:
                        pictureBox1.Image = Properties.Resources.artfruit_banner_incir_00_1;
                        break;
                    case 2:
                        pictureBox1.Image = Properties.Resources.ejder;
                        break;
                }
                switch (r2)
                {
                    case 0:
                        pictureBox2.Image = Properties.Resources.mango;
                        break;
                    case 1:
                        pictureBox2.Image = Properties.Resources.artfruit_banner_incir_00_1;
                        break;
                    case 2:
                        pictureBox2.Image = Properties.Resources.ejder;
                        break;
                }
                switch (r3)
                {
                    case 0:
                        pictureBox3.Image = Properties.Resources.mango;
                        break;
                    case 1:
                        pictureBox3.Image = Properties.Resources.artfruit_banner_incir_00_1;
                        break;
                    case 2:
                        pictureBox3.Image = Properties.Resources.ejder;
                        break;
                }


            }
            else
            {
                gazıno.Stop();
                timer1.Stop();
                move = 0;
                Kazanıldı();
            }

        }
    }
}
