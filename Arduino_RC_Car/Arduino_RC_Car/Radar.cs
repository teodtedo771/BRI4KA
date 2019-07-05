using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arduino_RC_Car
{
    public partial class Radar : UserControl
    {
        public Radar()
        {
            InitializeComponent();
        }
        
        Timer t = new Timer();

        int WIDTH = 300, HEIGHT = 300, HAND = 150;

        int u;  //in degree
        int cx, cy;     //center of the circle
        int x, y;       //HAND coordinate

        int tx, ty, lim = 20;

        Bitmap bmp;
        Pen p;
        Graphics g;

        private void Form1_Load(object sender, EventArgs e)
        {
            //create Bitmap
            bmp = new Bitmap(WIDTH + 1, HEIGHT / 2 + 1); //Width + 1 and height + 1 for full circle

            //background color
            this.BackColor = Color.FromArgb(33,34,36);

            //center
            cx = WIDTH / 2;
            cy = HEIGHT / 2;

            //initial degree of HAND
            u = -90;

            //timer
            t.Interval = 5; //in millisecond
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }

        private void t_Tick(object sender, EventArgs e)
        {
            //pen
            p = new Pen(Color.Green, 1f);

            //graphics
            g = Graphics.FromImage(bmp);

            //calculate x, y coordinate of HAND
            int tu = (u - lim) % 360;

            if (u >= 0 && u <= 90)
            {
                //right half
                //u in degree is converted into radian.

                x = cx + (int)(HAND * Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }
            else
            {
                x = cx - (int)(HAND * -Math.Sin(Math.PI * u / 180));
                y = cy - (int)(HAND * Math.Cos(Math.PI * u / 180));
            }

            if (tu >= 0 && tu <= 180)
            {
                //right half
                //tu in degree is converted into radian.

                tx = cx + (int)(HAND * Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }
            else
            {
                tx = cx - (int)(HAND * -Math.Sin(Math.PI * tu / 180));
                ty = cy - (int)(HAND * Math.Cos(Math.PI * tu / 180));
            }

            //draw circle
            g.DrawEllipse(p, 0, 0, WIDTH, HEIGHT);  //bigger circle
            g.DrawEllipse(p, 80, 80, WIDTH - 160, HEIGHT - 160);    //smaller circle

            //draw perpendicular line
            g.DrawLine(p, new Point(cx, 0), new Point(cx, HEIGHT)); // UP-DOWN
            g.DrawLine(p, new Point(0, cy), new Point(WIDTH, cy)); //LEFT-RIGHT

            //draw HAND
            g.DrawLine(new Pen(Color.FromArgb(33, 34, 36), 1f), new Point(cx, cy), new Point(tx, ty));
            g.DrawLine(new Pen(Color.Green, 1f), new Point(cx, cy), new Point(x, y));

            //load bitmap in picturebox1
            pictureBox1.Image = bmp;

            //dispose
            p.Dispose();
            g.Dispose();

            //update
            u++;
            if (u == 180)
            {
                u = -90;
            }
        }
    }
}

