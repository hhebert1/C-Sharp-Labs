using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    class GameEngine
    {
        public CellSelection[,] grid;
        public bool computerTurn;
        public bool finished;
        public bool started;

        //variables to show correct message after paint event happens
        public bool Xwin;
        public bool Owin;
        public bool Draw;

        public GameEngine()
        {
            computerTurn = false;
            finished = false;
            grid = new CellSelection[3, 3];
            started = false;

            //variables to show correct message after paint event happens
            Xwin = false;
            Owin = false;
            Draw = false;
        }

        public void updateGame(int i, int j)
        {

            if (isWinner()) //don't allow user to add any more X's
            {
                finished = true;
                return;
            }
            if (grid[i, j] != CellSelection.N)
            {
                MessageBox.Show("Invalid Move");
                return;
            }

            if(!computerTurn) //if it is the player's turn, set X value to cell, increment turn, and have computer make a move
            {
                grid[i, j] = CellSelection.X;
                started = true;//bool to keep track if game has started or not

                if(isWinner()) // if there is a winner, finish game. 
                {
                    finished = true;
                    return;
                }
                else //if there is not a winner, have computer play a move
                {
                    computerTurn = true;
                    computerPlay();
                    if(isWinner())
                    {
                        finished = true;
                        return;
                    }
                }
            }
            

        }
        public bool isWinner()
        {
            //*********** you win *******************

            //row 1
            if (grid[0, 0] == CellSelection.X && grid[1, 0] == CellSelection.X && grid[2, 0] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }
            //row 2
            if (grid[0, 1] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 1] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }
            //row 3
            if (grid[0, 2] == CellSelection.X && grid[1, 2] == CellSelection.X && grid[2, 2] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }
            //column 1
            if (grid[0, 0] == CellSelection.X && grid[0, 1] == CellSelection.X && grid[0,2] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }
            //column 2
            if (grid[1, 0] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[1, 2] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }
            //column 3
            if (grid[2, 0] == CellSelection.X && grid[2, 1] == CellSelection.X && grid[2, 2] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }
            //diagnal 1
            if (grid[0, 0] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 2] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }
            //diagnal 2
            if (grid[0, 2] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 0] == CellSelection.X)
            {
                Xwin = true;
                return Xwin;
            }

            //*********** computer wins *******************

            //row 1
            if (grid[0, 0] == CellSelection.O && grid[1, 0] == CellSelection.O && grid[2, 0] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }
            //row 2
            if (grid[0, 1] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 1] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }
            //row 3
            if (grid[0, 2] == CellSelection.O && grid[1, 2] == CellSelection.O && grid[2, 2] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }
            //column 1
            if (grid[0, 0] == CellSelection.O && grid[0, 1] == CellSelection.O && grid[0, 2] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }
            //column 2
            if (grid[1, 0] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[1, 2] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }
            //column 3
            if (grid[2, 0] == CellSelection.O && grid[2, 1] == CellSelection.O && grid[2, 2] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }
            //diagnal 1
            if (grid[0, 0] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 2] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }
            //diagnal 2
            if (grid[0, 2] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 0] == CellSelection.O)
            {
                Owin = true;
                return Owin;
            }

            //*********** draw *******************
            int filled_boxes = 0;
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (grid[i, j] != CellSelection.N) //keep track of filled boxes
                    {
                        filled_boxes++;
                        if(filled_boxes  == 9)//if all boxes are filled, there is a draw
                        {
                            Draw = true;
                            return Draw;
                        }
                    }
                }
            }

            return false; //if no winner/draw, there is no winner and game continues
        }

        public void displayMessage() //function to use so X or O is displayed before message box
        {
            if(finished)
            {
                if (Xwin)
                    MessageBox.Show("You Won!");
                if (Owin)
                    MessageBox.Show("You Lost!");
                if (Draw)
                    MessageBox.Show("Draw!");
            }
        }

        public void computerPlay()
        {

            //**************play move to win***************************

            for(int i = 0; i < 3; ++i) //for all rows
            {
                //case: last column needs to be filled
                if(grid[i,0] == CellSelection.O && grid[i,1] == CellSelection.O && grid[i,2] == CellSelection.N)
                {
                    grid[i, 2] = CellSelection.O;
                    computerTurn = false;                 
                    return;
                }
                //case: middle column needs to be filled
                if (grid[i, 0] == CellSelection.O && grid[i, 1] == CellSelection.N && grid[i, 2] == CellSelection.O)
                {
                    grid[i, 1] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
                //case: first column needs to be filled
                if (grid[i, 0] == CellSelection.N && grid[i, 1] == CellSelection.O && grid[i, 2] == CellSelection.O)
                {
                    grid[i, 2] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
            }

            for(int j = 0; j < 3; ++j) //for all columns
            {
                //case: last row in column needs to be filled
                if(grid[0,j] == CellSelection.O && grid[1,j] == CellSelection.O && grid[2,j] == CellSelection.N)
                {
                    grid[2, j] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
                //case: middle row in column needs to be filled
                if (grid[0, j] == CellSelection.O && grid[1, j] == CellSelection.N && grid[2, j] == CellSelection.O)
                {
                    grid[1, j] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
                //case: first row in column needs to be filled
                if (grid[0, j] == CellSelection.N && grid[1, j] == CellSelection.O && grid[2, j] == CellSelection.O)
                {
                    grid[0, j] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
            }

            //diagonal cases
            if(grid[0,0] == CellSelection.N && grid[1,1]== CellSelection.O && grid[2,2]==CellSelection.O)
            {
                grid[0, 0] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0,0] == CellSelection.O && grid[1, 1] == CellSelection.N && grid[2, 2] == CellSelection.O)
            {
                grid[1,1] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 0] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 2] == CellSelection.N)
            {
                grid[2, 2] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 2] == CellSelection.N && grid[1, 1] == CellSelection.O && grid[2, 0] == CellSelection.O)
            {
                grid[0,2] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 2] == CellSelection.O && grid[1, 1] == CellSelection.N && grid[2, 0] == CellSelection.O)
            {
                grid[1,1] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 2] == CellSelection.O && grid[1, 1] == CellSelection.O && grid[2, 0] == CellSelection.N)
            {
                grid[2,0] = CellSelection.O;
                computerTurn = false;
                return;
            }

            //************ play move to block **********************
            for (int i = 0; i < 3; ++i) //for all rows
            {
                //case: last column needs to be filled
                if (grid[i, 0] == CellSelection.X && grid[i, 1] == CellSelection.X && grid[i, 2] == CellSelection.N)
                {
                    grid[i, 2] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
                //case: middle column needs to be filled
                if (grid[i, 0] == CellSelection.X && grid[i, 1] == CellSelection.N && grid[i, 2] == CellSelection.X)
                {
                    grid[i, 1] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
                //case: first column needs to be filled
                if (grid[i, 0] == CellSelection.N && grid[i, 1] == CellSelection.X && grid[i, 2] == CellSelection.X)
                {
                    grid[i, 0] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
            }

            for (int j = 0; j < 3; ++j) //for all columns
            {
                //case: last row in column needs to be filled
                if (grid[0, j] == CellSelection.X && grid[1, j] == CellSelection.X && grid[2, j] == CellSelection.N)
                {
                    grid[2, j] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
                //case: middle row in column needs to be filled
                if (grid[0, j] == CellSelection.X && grid[1, j] == CellSelection.N && grid[2, j] == CellSelection.X)
                {
                    grid[1, j] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
                //case: first row in column needs to be filled
                if (grid[0, j] == CellSelection.N && grid[1, j] == CellSelection.X && grid[2, j] == CellSelection.X)
                {
                    grid[0, j] = CellSelection.O;
                    computerTurn = false;
                    return;
                }
            }

            //diagonal cases
            if (grid[0, 0] == CellSelection.N && grid[1, 1] == CellSelection.X && grid[2, 2] == CellSelection.X)
            {
                grid[0, 0] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 0] == CellSelection.X && grid[1, 1] == CellSelection.N && grid[2, 2] == CellSelection.X)
            {
                grid[1, 1] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 0] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 2] == CellSelection.N)
            {
                grid[2, 2] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 2] == CellSelection.N && grid[1, 1] == CellSelection.X && grid[2, 0] == CellSelection.X)
            {
                grid[0, 2] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 2] == CellSelection.X && grid[1, 1] == CellSelection.N && grid[2, 0] == CellSelection.X)
            {
                grid[1, 1] = CellSelection.O;
                computerTurn = false;
                return;
            }
            if (grid[0, 2] == CellSelection.X && grid[1, 1] == CellSelection.X && grid[2, 0] == CellSelection.N)
            {
                grid[2, 0] = CellSelection.O;
                computerTurn = false;
                return;
            }

            //*****************default computer move*******************
            for(int i=0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[i, j] == CellSelection.N)
                    {
                        grid[i, j] = CellSelection.O;
                        computerTurn = false;
                        return;
                    }
                }
            }
        }
    }

    }

