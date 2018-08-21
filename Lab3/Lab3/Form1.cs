using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Lab3
{
    public partial class Form1 : Form
    {
        public class PointDetails
        {
            public PointDetails(int x_in,int y_in, bool color_in)
            {
                X = x_in;
                Y = y_in;
                colorChange = color_in;
            }
            public int X { get; set; }
            public int Y { get; set; }
            public bool colorChange { get; set; } //red = flase, black = true

        }
        private ArrayList coordinates = new ArrayList();
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            this.coordinates.Clear();
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            const int WIDTH = 20;
            const int HEIGHT = 20;

            Graphics g = e.Graphics;
            foreach (PointDetails p in this.coordinates)
            {
                String pLabel = "(" + p.X + ", " + p.Y + ")";
                if (!p.colorChange)
                {
                    g.FillEllipse(Brushes.Red, p.X - WIDTH / 2, p.Y - WIDTH / 2, WIDTH, HEIGHT);
                    //g.DrawString(pLabel, Font, Brushes.Orchid, p.X + WIDTH / 2, p.Y - WIDTH / 4);
                }
                if (p.colorChange)
                {
                    g.FillEllipse(Brushes.Black, p.X - WIDTH / 2, p.Y - WIDTH / 2, WIDTH, HEIGHT);
                    //g.DrawString(pLabel, Font, Brushes.DarkCyan, p.X + WIDTH / 2, p.Y - WIDTH / 4);
                }            
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                PointDetails p = new PointDetails(e.X, e.Y,true);
                this.coordinates.Add(p);
                this.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                bool circleClick = false;
                int coordinatesLength = coordinates.Count - 1; //max index of coordinates array
                for (int i = coordinatesLength; i >= 0; i--) //backwards for loop to delete multiple objects @ once without error
                {
                    PointDetails p = (PointDetails)coordinates[i];
                    if((Math.Abs(p.X-e.X) < 10) && (Math.Abs(p.Y - e.Y) <10))  //check bounds of mouse click
                    {
                        if (p.colorChange)//if black, change to red
                        {
                            p.colorChange = false;
                            circleClick = true;
                            this.Invalidate();
                        }
                        else if (!p.colorChange)//if red, delete
                        {
                            circleClick = true;
                            coordinates.RemoveAt(i);
                            this.Invalidate();
                        }       
                    }
                }
                if(!circleClick) //clear all if right click outside of a circle
                {
                    this.coordinates.Clear();
                    this.Invalidate();
                }

            }
        }
    }
}
