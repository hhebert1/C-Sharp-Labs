using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        private int numQueen = 0;
        private bool[,] queenLocation = new bool[8, 8];

        private bool updateBoard(int x, int y)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    //mark column invalid
                    if (queenLocation[x, j])
                    {
                        return false;
                    }
                }
                //mark row invalid
                if (queenLocation[i, y])
                {
                    return false;
                }
            }

            //loop through for diagonals
            int n = x;//diag reference index
            for (int i = y; ((n >= 0) && (i >= 0)) && ((n < 8) && (i < 8)); i++) //upper right
            {
                if (queenLocation[x, i])
                {
                    return false;
                }
                n--;
            }

            n = x;//reset n reference index
            for (int i = y; ((n >= 0) && (n >= 0)) && ((n < 8) && (i < 8)); i++) //upper left
            {
                if (queenLocation[x, i])
                {
                    return false;
                }
                n--;
            }

            n = x;//reset n reference index
            for (int i = y; ((n >= 0) && (i >= 0)) && ((n < 8) && (i < 8)); i--) //bottom left diag
            {
                if (queenLocation[n, i])
                {
                    return false;
                }
                n--;
            }

            n = x;//reset n reference index
            for (int i = y; ((n >= 0) && (i >= 0)) && ((n < 8) && (i < 8)); i--) //bottom right diag
            {
                if (queenLocation[x, i])
                {
                    return false;
                }
                n--;
            }
            return true;
        }

        private void Hints_CheckedChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            numQueen = 0;
            queenLocation = new bool[8, 8];
            Invalidate();
        }
        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            //draw board
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Hints.Checked && !updateBoard(i, j)) //color squares red if no queen can go there and hint box is checked
                    {
                        g.FillRectangle(Brushes.Red, 100 + (i * 50), 100 + (j * 50), 50, 50);
                    }
                    else if ((i + j) % 2 != 0)//odd squares color black
                    {
                        g.FillRectangle(Brushes.Black, 100 + (i * 50), 100 + (j * 50), 50, 50);
                    }
                    else//color white-even
                    {
                        g.FillRectangle(Brushes.White, 100 + (i * 50), 100 + (j * 50), 50, 50);
                    }

                    //color boarders around rectangles
                    g.DrawRectangle(Pens.Black, 100 + (i * 50), 100 + (j * 50), 50, 50);

                    Font qFont = new Font("Arial", 30f, FontStyle.Bold);
                    Font mFont = new Font("Arial", 8f, FontStyle.Regular);
                    //draw Qs
                    if (queenLocation[i, j])
                    {
                        int x = 50 * i + 100;
                        int y = 50 * j + 100;

                        //to center the Qs
                        StringFormat sFormat = new StringFormat();
                        sFormat.LineAlignment = StringAlignment.Center;
                        sFormat.Alignment = StringAlignment.Center;
                        Rectangle bounds = new Rectangle(x, y, 50, 50);

                        //draw Q according to color of rectangle
                        if ((i + j) % 2 == 0 && !Hints.Checked)//even squares color black Q
                        {
                            g.DrawString("Q", qFont, Brushes.Black, bounds, sFormat);
                        }
                        else if ((i + j) % 2 != 0 && !Hints.Checked)//odd squares color white Q
                        {
                            g.DrawString("Q", qFont, Brushes.White, bounds, sFormat);
                        }
                        else if (Hints.Checked) //if hints are checked,always draw Q black
                        {
                            g.DrawString("Q", qFont, Brushes.Black, bounds, sFormat);
                        }

                    }

                    g.DrawString("You have " + numQueen + " queens on the board.", mFont, Brushes.Black, 210, 25);
                }
            }

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            //check if click on board
            if (((e.X >= 100) && (e.Y >= 100)) && ((e.X <= 500) && (e.Y <= 500)))
            {
                //coordinates of upper left hand corner in matrix
                int xIndex = (e.X - 100) / 50; //row-i
                int yIndex = (e.Y - 100) / 50;  //column-j

                //on left click place Qs
                if (e.Button == MouseButtons.Left)
                {
                    if (updateBoard(xIndex, yIndex))
                    {
                        queenLocation[xIndex, yIndex] = true;
                        numQueen++;
                        if (numQueen == 8)
                        {
                            MessageBox.Show("Congratulations! You did it!");
                        }

                        this.Invalidate();
                    }
                    else
                    {
                        System.Media.SystemSounds.Beep.Play(); //play invalid sound if not valid placd to put queen
                    }
                }

                //remove Qs on right click 
                else if ((e.Button == MouseButtons.Right) && queenLocation[xIndex, yIndex])
                {
                    numQueen--;
                    queenLocation[xIndex, yIndex] = false;
                    this.Invalidate();
                }
            }
            else
            {
                System.Media.SystemSounds.Beep.Play(); //play invalid sound if not clicking on board
            }
        }
    }
}

