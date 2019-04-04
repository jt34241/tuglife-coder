using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_Simulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool WinCheck(string[,] game)
        {
            if (game[0,0] != null && game[0, 0] == game[0, 1] && game[0, 0] == game[0, 2])
            {
                gameOutcomeLabel.Text = game[0,0] + " has won";
                return true;
            } else if (game[1, 0] != null && game[1, 0] == game[1, 1] && game[1, 0] == game[1, 2])
            {
                gameOutcomeLabel.Text = game[1, 0] + " has won";
                return true;
            }
            else if (game[2, 0] != null && game[2, 0] == game[2, 1] && game[2, 0] == game[2, 2])
            {
                gameOutcomeLabel.Text = game[2, 0] + " has won";
                return true;
            }
            else if (game[0, 0] != null && game[0, 0] == game[1, 0] && game[0, 0] == game[2, 0])
            {
                gameOutcomeLabel.Text = game[0, 0] + " has won";
                return true;
            }
            else if (game[0, 1] != null && game[0, 1] == game[1, 1] && game[0, 1] == game[2, 1])
            {
                gameOutcomeLabel.Text = game[0, 1] + " has won";
                return true;
            }
            else if (game[0, 2] != null && game[0, 2] == game[1, 2] && game[0, 2] == game[2, 2])
            {
                gameOutcomeLabel.Text = game[0, 2] + " has won";
                return true;
            }
            else if (game[0, 0] != null && game[0, 0] == game[1, 1] && game[0, 0] == game[2, 2])
            {
                gameOutcomeLabel.Text = game[0, 0] + " has won";
                return true;
            }
            else if (game[0, 2] != null && game[0, 2] == game[1, 1] && game[0, 2] == game[2, 0])
            {
                gameOutcomeLabel.Text = game[0, 2] + " has won";
                return true;
            } else
            {
                gameOutcomeLabel.Text = "It was a tie";
            }

            return false;
        }
        private void newGameButton_Click(object sender, EventArgs e)
        {
            //Create a Random object.
            Random rand = new Random();

            //Create an array for the game board.
            const int ROWS = 3;
            const int COLS = 3;
            string[,] game = new string[ROWS, COLS];
            int temp1, temp2;
            bool check = true;
            string output;
            int count = 0;

            while (true)
            {
                temp1 = rand.Next(3);
                temp2 = rand.Next(3);
                if (game[temp1, temp2] != "O" && game[temp1, temp2] != "X")
                {
                    if (check)
                    {
                        // game[temp1, temp2] = 0;
                        check = false;
                        output = "O";
                    }
                    else
                    {
                        // game[temp1, temp2] = 1;
                        check = true;
                        output = "X";
                    }
                    game[temp1, temp2] = output;
                }

                if(WinCheck(game))
                {
                    break;
                }

                foreach (string str in game)
                {
                    if (str != null)
                    {
                        ++count;
                    }
                }

                if (count == 9)
                {
                    break;
                } else
                {
                    count = 0;
                }
            }


            //Display the array contents in each label as X or O.
            for (int row = 0; row < ROWS; row++)
            {
                for (int col = 0; col < COLS; col++)
                {
                    if (row == 0)
                    {
                        label1.Text = game[row, 0];
                        label2.Text = game[row, 1];
                        label3.Text = game[row, 2];
                    }

                    else if (row == 1)
                    {
                        label4.Text = game[row, 0];
                        label5.Text = game[row, 1];
                        label6.Text = game[row, 2];
                    } else
                    {
                        label7.Text = game[row, 0];
                        label8.Text = game[row, 1];
                        label9.Text = game[row, 2];
                    }
                }
            }

        

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
