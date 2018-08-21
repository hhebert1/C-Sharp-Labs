using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form1 : Form
    {
        ArrayList objectsDrawn = new ArrayList();
        private Point pt1;
        private Point pt2;
        private Pen pen;
        private Brush brush;
        private int width;
    
        private bool shouldDraw = true; //checks if click should draw or not

        public Form1()
        {
            InitializeComponent();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            objectsDrawn.Clear(); //restarts arraylist
            DrawingPanel.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close(); //closes window
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(objectsDrawn.Count != 0)
            {
                objectsDrawn.RemoveAt(objectsDrawn.Count - 1);//removes last object added to myDrawings
            }
   
            DrawingPanel.Invalidate(); //redraw accordingly
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void OutlineCheckbox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void DrawingPanel_MouseClick(object sender, MouseEventArgs e)
        {
            shouldDraw = !shouldDraw; //toggle mouseclick condition--first so first drawing is not drawn
            if (!shouldDraw) //if you shouldnt draw, record pt1
            {
                pt1.X = e.X;
                pt1.Y = e.Y;
            }
            else //record pt2 and draw
            {
                pt2.X = e.X;
                pt2.Y = e.Y;
            }

            //width selection
            width = PenWidth.SelectedIndex + 1;

            //pen selection choice
            switch (PenColorListBox.SelectedIndex)
            {
                case 0:
                    pen = new Pen(Brushes.Black, width);
                    break;
                case 1:
                    pen = new Pen(Brushes.Red, width);
                    break;
                case 2:
                    pen = new Pen(Brushes.Blue, width);
                    break;
                case 3:
                    pen = new Pen(Brushes.Green, width);
                    break;
            }

            //brush selection
            switch (FillColorListBox.SelectedIndex)
            {
                case 0:
                    brush = Brushes.White;
                    break;
                case 1:
                    brush = Brushes.Black;
                    break;
                case 2:
                    brush = Brushes.Red;
                    break;
                case 3:
                    brush = Brushes.Blue;
                    break;
                case 4:
                    brush = Brushes.Green;
                    break;
            }

            //adding objects to listarray
            if (shouldDraw)
            {
                if (Line.Checked)
                {
                    objectsDrawn.Add(new lineObject(pt1, pt2, pen));
                }
                else if (Rectangle.Checked)
                {
                    if (!OutlineCheckbox.Checked) //if outline box is not marked, set pen color to fill color
                    {
                        pen = null;
                    }
                    if (!FillCheckbox.Checked) //if fill box is not marked, don't fill in rect with brush
                    {
                        brush = null;
                    }
                    if (FillCheckbox.Checked || OutlineCheckbox.Checked)
                    {
                        objectsDrawn.Add(new rectObject(pt1, pt2, pen, brush));
                    }
                }
                else if (Ellipse.Checked)
                {
                    if (!OutlineCheckbox.Checked) //if outline box is not marked, set pen color to fill color
                    {
                        pen = null;
                    }
                    if (!FillCheckbox.Checked) //if fill box is not marked, don't fill in rect with brush
                    {
                        brush = null;
                    }
                    if (FillCheckbox.Checked || OutlineCheckbox.Checked) //only add to array list if one of the boxes is checked
                    {
                        objectsDrawn.Add(new ellipseObject(pt1, pt2, pen, brush));
                    }
                }
                else if (Textrb.Checked)
                {
                    objectsDrawn.Add(new textObject(pt1, pt2, pen.Brush, textBox1.Text, Font));
                }
            }

            DrawingPanel.Invalidate();
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (graphicObject o in objectsDrawn) //draws all objects in arraylist
            {
                o.Draw(g);
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

        }
        private class graphicObject
        {
            public virtual void Draw(Graphics g) { } //method to be inherited
        }

        //derived classes of graphicObject: line, rect, ellipse, text

        private class lineObject : graphicObject//line
        {
            private Point pt1;
            private Point pt2;
            private Pen pen;
            public lineObject(Point pt1_in, Point pt2_in, Pen pen_in)
            {
                pt1 = pt1_in;
                pt2 = pt2_in;
                pen = pen_in;
            }
            public override void Draw(Graphics g)
            {
                g.DrawLine(pen, pt1, pt2);
            }
        }

        private class rectObject : graphicObject //rectangle
        {
            private Pen pen;
            private Rectangle rect;
            private Brush brush;

            public rectObject(Point pt1_in,Point pt2_in, Pen pen_in, Brush brush_in)
            {
                int x = Math.Min(pt1_in.X, pt2_in.X);
                int y = Math.Min(pt1_in.Y, pt2_in.Y);
                int width = Math.Abs(pt2_in.X - pt1_in.X);
                int height = Math.Abs(pt1_in.Y- pt2_in.Y);

                rect = new Rectangle(x, y, width, height);
                pen = pen_in;
                brush = brush_in;

            }
            public override void Draw(Graphics g)
            {
                if(brush != null)
                {
                    g.FillRectangle(brush, rect);
                }
                if(pen != null)
                {
                    g.DrawRectangle(pen, rect);
                }
            }
        }
        private class ellipseObject : graphicObject //ellipse
        {
            private Pen pen;
            private Rectangle ellipseBounds;
            private Brush brush;

            public ellipseObject(Point pt1_in, Point pt2_in, Pen pen_in, Brush brush_in)
            {
                int x = Math.Min(pt1_in.X, pt2_in.X);
                int y = Math.Min(pt1_in.Y, pt2_in.Y);
                int width = Math.Abs(pt2_in.X - pt1_in.X);
                int height = Math.Abs(pt1_in.Y - pt2_in.Y);

                ellipseBounds = new Rectangle(x,y,width,height);
                pen = pen_in;
                brush = brush_in;

            }
            public override void Draw(Graphics g)
            {
                if (brush != null)
                {
                    g.FillEllipse(brush, ellipseBounds);
                }
                if (pen != null)
                {
                    g.DrawEllipse(pen, ellipseBounds);
                }
            }
        }

        private class textObject : graphicObject //text
        {
            private Rectangle textBounds;
            private Brush brush;
            private String s;
            private Font font;
            public textObject(Point pt1_in, Point pt2_in, Brush brush_in, String s_in, Font font_in )
            {
                int x = Math.Min(pt1_in.X, pt2_in.X);
                int y = Math.Min(pt1_in.Y, pt2_in.Y);
                int width = Math.Abs(pt2_in.X - pt1_in.X);
                int height = Math.Abs(pt1_in.Y - pt2_in.Y);

                textBounds = new Rectangle(x, y, width, height);
                brush = brush_in;
                s = s_in;
                font = font_in;

            }
            public override void Draw(Graphics g)
            {
                g.DrawString(s, font, brush, textBounds);
            }
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PenColorListBox.SelectedIndex = 0;
            PenWidth.SelectedIndex = 0;
            FillColorListBox.SelectedIndex = 0;
        }
    }
}
