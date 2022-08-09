using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int[,] map = new int[15, 15]
        { { 0,0,0,0,0,0,0,3,0,0,0,0,0,0,0},
          { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
          { 0,1,0,0,0,0,0,1,0,0,0,0,0,1,0},
          { 0,1,0,0,0,0,0,1,0,0,0,0,0,1,0},
          { 0,1,0,0,1,1,1,1,1,1,1,0,0,1,0},
          { 0,1,0,0,1,0,0,1,0,0,1,0,0,1,0},
          { 0,1,0,0,1,0,0,1,0,0,1,0,0,1,0},
          { 5,1,1,1,1,1,1,1,1,1,1,1,1,1,6},
          { 0,1,0,0,1,0,0,1,0,0,1,0,0,1,0},
          { 0,1,0,0,1,0,0,1,0,0,1,0,0,1,0},
          { 0,1,0,0,1,1,1,1,1,1,1,0,0,1,0},
          { 0,1,0,0,0,0,0,1,0,0,0,0,0,1,0},
          { 0,1,0,0,0,0,0,1,0,0,0,0,0,1,0},
          { 0,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
          { 0,0,0,0,0,0,0,4,0,0,0,0,0,0,0},
        };
        Random a = new Random();
        int time = 0;
        int time1 = 0;
        int gx1=1, gy1=1;
        int gx2=1, gy2=1;
        int gx3, gy3;
        int new_direct = 0, direct = 0;
        int px = 1, py = 1;
        int dx = 20, dy = 20;
        int coin = 89;
        Image stree, block, stree2;
        Bitmap bmp;
        Graphics g;
        int ghostmove1 = 0, h1 = 0;
        int ghostmove2 = 0, h2 = 0;
        int ghostmove3 = 0, h3 = 0;

        private void Timer3_Tick(object sender, EventArgs e)
        {
            gx3 = pictureBox5.Location.X / 20; gy3 = pictureBox5.Location.Y / 20;
            if (h3 == 0)
                ghostmove3++;

            switch (ghostmove3)
            {
                case 1:
                    if ((map[gy3 + 1, gx3] == 0) || (map[gy3 + 1, gx3] == 3))
                        return;
                    if (py > gy3)
                        pictureBox5.Top += 20;
                    break;

                case 2:
                    if ((map[gy3 - 1, gx3] == 0) || (map[gy3 - 1, gx3] == 4))
                        return;
                    if (py < gy3)
                        pictureBox5.Top -= 20;
                    break;
                case 3:
                    if ((map[gy3, gx3 + 1] == 0) || (map[gy3, gx3 + 1] == 6))
                        return;
                    if (px > gx3)
                        pictureBox5.Left += 20;
                    break;
                case 4:
                    if ((map[gy3, gx3 - 1] == 0) || (map[gy3, gx3 - 1] == 5))
                        return;
                    if (px < gx3)
                        pictureBox5.Left -= 20;
                    break;
            }
            if (ghostmove3 > 4)
                ghostmove3 = 0;
            if ((gy3 == py) && (gx3 == px))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                MessageBox.Show("you are loser like yor life");
            }
        }
        
        private void Timer2_Tick(object sender, EventArgs e)
        {
            if (h2 == 0)
            {
                ghostmove2 = a.Next(0, 4);
            }
            gx2 = pictureBox4.Location.X / 20; gy2 = pictureBox4.Location.Y / 20;
            time1++; 
            switch (ghostmove2)
            {
                case 0:
                    {
                        if (time1 < 2)
                        {
                            if ((map[gy2 - 1, gx2] == 0) || (map[gy2 - 1, gx2] == 3))
                                return;
                            
                            pictureBox4.Top -= 20;                         
                        }

                        else
                        {
                            ghostmove2 = a.Next(0, 4);
                            time1 = 0;
                        }
                        break;
                    }
                case 1:
                    {
                        if (time1 < 2)
                        {
                            if ((map[gy2 + 1, gx2] == 0) || (map[gy2 + 1, gx2] == 4))
                                return;
                            pictureBox4.Top += 20;
                        }

                        else
                        {
                            ghostmove2 = a.Next(0, 4);
                            time1 = 0;
                        }
                        break;
                    }
                case 2:
                    {
                        if (time1 < 2)
                        {
                            if ((map[gy2, gx2 - 1] == 0) || (map[gy2, gx2 - 1] == 5))
                                return;
                            pictureBox4.Left -= 20;
                        }

                        else
                        {
                            ghostmove2 = a.Next(0, 4);
                            time1 = 0;
                        }
                        break;
                    }
                case 3:
                    {
                        if (time1 < 2)
                        {
                            if ((map[gy2, gx2 + 1] == 0) || (map[gy2, gx2 + 1] == 6))
                                return;
                            pictureBox4.Left += 20;
                        }

                        else
                        {
                            ghostmove2 = a.Next(0, 4);
                            time1 = 0;
                        }
                        break;
                    }
            }

            if ((gy2==py) && (gx2==px))                 
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                MessageBox.Show("you are loser like yor life");               
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (h1 == 0)
            {
                ghostmove1 = a.Next(0, 4);
            }

            gx1 = pictureBox3.Location.X / 20; gy1 = pictureBox3.Location.Y / 20;

            time++;

            switch (ghostmove1)
            {
                case 0:
                    {
                        if (time < 3)
                        {
                            if ((map[gy1 - 1, gx1] == 0) || (map[gy1 - 1, gx1] == 3))
                                return;
                            pictureBox3.Top -= 20;
                        }

                        else
                            ghostmove1 = a.Next(0, 4);
                        break;
                    }
                case 1:
                    {
                        if (time < 3)
                        {
                            if ((map[gy1 + 1, gx1] == 0) || (map[gy1 + 1, gx1] == 4))
                                return;
                            pictureBox3.Top += 20;
                        }

                        else
                            ghostmove1 = a.Next(0, 4);
                        break;
                    }
                case 2:
                    {
                        if (time < 3)
                        {
                            if ((map[gy1, gx1 - 1] == 0) || (map[gy1, gx1 - 1] == 5))
                                return;
                            pictureBox3.Left -= 20;
                        }

                        else
                            ghostmove1 = a.Next(0, 4);
                            
                        break;
                    }
                case 3:
                    {
                        if (time < 3)
                        {
                            if ((map[gy1, gx1 + 1] == 0) || (map[gy1, gx1 + 1] == 6))
                                return;
                            pictureBox3.Left += 20;
                        }

                        else
                            ghostmove1 = a.Next(0, 4);
                        break;
                    }
            }
            if (time > 3)
                time = 0;

            if ((gy1 == py) && (gx1 == px))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;
                timer3.Enabled = false;
                MessageBox.Show("you are loser like yor life");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.play(); //播放
        }

        private void button3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.pause(); //暫停
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = "bgm.mp3"; //加入歌曲
            axWindowsMediaPlayer1.Ctlcontrols.play(); //播放
            axWindowsMediaPlayer1.settings.volume = 35;
            axWindowsMediaPlayer2.settings.volume = 20;
            for (int y = 0; y < 15; y++)
            {
                for (int x = 0; x < 15; x++)
                {
                    if (map[y, x] == 0)
                        g.DrawImage(block, x * dx, y * dy);
                    if (map[y, x] == 3 || map[y, x] == 4 || map[y, x] == 5 || map[y, x] == 6)
                        g.DrawImage(stree2, x * dx, y * dy);
                    if (map[y, x] == 1)
                        g.DrawImage(stree, x * dx, y * dy);
                }
            }
            pictureBox1.Image = bmp;
            timer1.Enabled = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    {
                        if (map[py, px] == 5)
                        {
                            py = 7;
                            px = 15;
                        }
                        if (map[py, px - 1] == 0)                     
                            return;

                        px--;
                        new_direct = 2;
                        break;
                    }
                case Keys.D:
                    {
                        if (map[py, px] == 6)
                        {
                            py = 7;
                            px = -1;
                        }
                        if (map[py, px + 1] == 0)
                            return;

                        px++;
                        new_direct = 4;
                        break;
                    }
                case Keys.W:
                    {
                        if (map[py, px] == 3)
                        {
                            py = 15;
                            px = 7;
                        }
                        if (map[py - 1, px] == 0)
                            return;
                        
                        py--;
                        new_direct = 1;
                        break;
                    }
                case Keys.S:
                    {
                  
                        if (map[py, px] == 4)
                        {
                            py = -1;
                            px = 7;
                        }
                        if (map[py + 1, px] == 0)
                            return;

                        py++;
                        new_direct = 3;
                        break;
                    }
            }

            if (map[py, px] == 1)
            {
                map[py, px] = 2;
                g.DrawImage(stree2, px * dx, py * dy);
                axWindowsMediaPlayer2.URL = "eat.mp3";
                coin--;
            }

            if (direct != new_direct)
            {
                direct = new_direct;
                pictureBox2.Image = Image.FromFile("pc" + direct.ToString() + ".png");
            }

            pictureBox2.Left = px * dx;
            pictureBox2.Top = py * dy;

            if (coin == 0)
            {
                timer2.Enabled = false;
                timer1.Enabled = false;
                timer3.Enabled = false;
                MessageBox.Show("勝利");
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            block = Image.FromFile("block.png");
            stree = Image.FromFile("stree.png");
            stree2 = Image.FromFile("stree2.png");
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox4.Location = new Point(dx * 4, dy * 4);
            pictureBox5.Location = new Point(dx * 7, dy * 4);
            pictureBox3.Location = new Point(dx * 10, dy * 4);
            pictureBox2.Location = new Point(dx * 1, dy * 1);
        }
    }
}
