using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = x turn, false= y turn
        int turnCounter=0;
        bool turnSwitch;
        int p1WinCounter = 0;
        int p2WinCounter = 0;

        string winner = "0:0";
        string player1Symbol = "X";
        string player2Symbol = "O";
        string computer = "Computer";
        List<Button> buttonList;
        string[,] board = new string[3, 3];


        public Form1()
        {
            newGameFormInitialization();
        }
        private void newGameFormInitialization()
        {
            this.Controls.Clear();
            this.InitializeComponent();
            buttonList = new List<Button>() { A1, A2, A3, B1, B2, B3, C1, C2, C3 };
            p1WinCounter = 0;
            p2WinCounter = 0;
            turnCounter = 0;
            turn = true;
            turnSwitch = turn;
            ButtonsToArray();
        }
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) //MenuStrip About
        {
            MessageBox.Show("By Senad", "Tic Tac Toe About");
        }
        private void optionToolStripMenuItem_Click(object sender, EventArgs e) //MenuStrip Exit
        {
            Application.Exit();
        }
        private void ButtonClick(object sender, EventArgs e) //Calls MakeMove() function when button is pressed
        {
            Button button = (Button)sender;
            MakeMove(button);
            ButtonsToArray();
            if (isMovesLeft(board) == true && label2.Text==computer)
                Computer();
        }
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) //MenuStrip NewGame 2 players
        {
            newGameFormInitialization();
        }
        private void newGameAgainstComputerToolStripMenuItem_Click(object sender, EventArgs e) //MenuStrip NewGame P1 vs C
        {
            newGameFormInitialization();
            label2.Text = computer;
            
        }
        private void button1_Click(object sender, EventArgs e) // Reset button, switches turn and set turnCounter to zero
        {
            turnSwitch = !turnSwitch;
            foreach (var bttn in buttonList)
            {
                bttn.Text = "";
                bttn.Enabled = true;
            }
            turnCounter = 0;
            turn =turnSwitch;
            if (turn == false && label2.Text == computer)
                Computer();
        }
        private void ButtonMouseEnter(object sender, EventArgs e) // Shows X or O when hovering mouse
        {
            Button button = (Button)sender;
            if (button.Enabled)
            {
                if (turn)
                {
                    button.Text = player1Symbol;
                }
                else
                {
                    button.Text = player2Symbol;
                }
            }
        } 
        private void ButtonMouseLeave(object sender, EventArgs e) // Shows X or O when hovering mouse
        {

            Button button = (Button)sender;
            if (button.Enabled)
                button.Text = "";

        }


        private void MakeMove(Button button) // As an input takes button and makes move, calls CheckWinner(), switches turns
        {
            if (turn)
            {
                button.Text = player1Symbol;
            }
            else
            {
                button.Text = player2Symbol;
            }

            CheckWinner();
            turn = !turn;
            button.Enabled = false;
            turnCounter++;
        }
        private bool CheckWinner() //Checks the winner and stops the game if finds one, throwing messagebox with message
        {
            var thereIsAWinner = false;

            if ((A1.Text==A2.Text && A3.Text==A2.Text) &&(A1.Text== player1Symbol || A1.Text == player2Symbol))
                thereIsAWinner = true;
            else if ((B1.Text == B2.Text && B3.Text == B2.Text) && (B1.Text == player1Symbol || B1.Text == player2Symbol))
                thereIsAWinner = true;
            else if ((C1.Text == C2.Text && C3.Text == C2.Text) && (C1.Text == player1Symbol || C1.Text == player2Symbol))
                thereIsAWinner = true;
            else if ((A1.Text == B1.Text && B1.Text == C1.Text) && (A1.Text == player1Symbol || A1.Text == player2Symbol))
                thereIsAWinner = true;
            else if ((A2.Text == B2.Text && B2.Text == C2.Text) && (A2.Text == player1Symbol || A2.Text == player2Symbol))
                thereIsAWinner = true;
            else if ((A3.Text == B3.Text && B3.Text == C3.Text) && (A3.Text == player1Symbol || A3.Text == player2Symbol))
                thereIsAWinner = true;
            else if ((A1.Text == B2.Text && B2.Text == C3.Text) && (A1.Text == player1Symbol || A1.Text == player2Symbol))
                thereIsAWinner = true;
            else if ((A3.Text == B2.Text && B2.Text == C1.Text) && (A3.Text == player1Symbol || A3.Text == player2Symbol))
                thereIsAWinner = true;

            if (thereIsAWinner)
            {
                if (turn)
                {
                    winner = label1.Text;
                    p1WinCounter++;
                }
                else
                {
                    winner = label2.Text;
                    p2WinCounter++;
                }
                DisableButtons();
                MessageBox.Show("Winner is: " + winner, "Yayy!");
                winner = p1WinCounter + ":" + p2WinCounter;
                label3.Text = winner;
            }
            else if (!thereIsAWinner && turnCounter == 8)
            {
                DisableButtons();
                MessageBox.Show("It's a draw", "Draw");
            }
            return thereIsAWinner;
        }
        private void DisableButtons()//Disables all buttons
        {
            foreach (var bttn in buttonList)
                bttn.Enabled = false;
        }
        private void ButtonsToArray()//Updates variable board(array type)
        {

            board[0, 0] = buttonList[0].Text;
            board[0, 1] = buttonList[1].Text;
            board[0, 2] = buttonList[2].Text;
            board[1, 0] = buttonList[3].Text;
            board[1, 1] = buttonList[4].Text;
            board[1, 2] = buttonList[5].Text;
            board[2, 0] = buttonList[6].Text;
            board[2, 1] = buttonList[7].Text;
            board[2, 2] = buttonList[8].Text;

        }
        private void ArrayToButtonList() //Updates board buttons from array board variable 
        {
            buttonList[0].Text = board[0, 0];
            buttonList[1].Text = board[0, 1];
            buttonList[2].Text = board[0, 2];
            buttonList[3].Text = board[1, 0];
            buttonList[4].Text = board[1, 1];
            buttonList[5].Text = board[1, 2];
            buttonList[6].Text = board[2, 0];
            buttonList[7].Text = board[2, 1];
            buttonList[8].Text = board[2, 2];
        }
        private int[] BestMove(string [,] b)
        {
            int bestVal = -1000;
            int [] bestMove = new int[2] {-1,-1};
            
            for (int i = 0; i < 3;i++)
            {
                for (int j=0; j < 3;j++)
                {
                    if (b[i,j] == "")
                    {
                        b[i, j] = player2Symbol;

                        int moveVal = MiniMax(b, 0, false);
                        
                        b[i, j] = "";

                        if (moveVal>bestVal)
                        {
                            bestMove[0] = i;
                            bestMove[1] = j;
                            bestVal=moveVal;
                        }
                    }
                }
            }
            
            
            
            return bestMove;
        }
        private int Evaluate(string[,] board) // takes in board as an input, returns evaluation of the board, 10 if computer win, p wins=>-10, draws=>0
        {
            // Check winner for horizontals and verticals
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] ==player1Symbol) || (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] ==player1Symbol))
                    return -10;

                if ((board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2] && board[i, 0] ==player2Symbol) || (board[0, i] == board[1, i] && board[1, i] == board[2, i] && board[0, i] ==player2Symbol))
                    return 10;
            }

            //Checking diagonals
            if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[1, 1] == player1Symbol) || (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[1, 1] == player1Symbol))
                return -10;

            if ((board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[1, 1] == player2Symbol) || (board[2, 0] == board[1, 1] && board[1, 1] == board[0, 2] && board[1, 1] == player2Symbol))
                return 10;

            return 0;
        }
        private int MiniMax(string[,] b, int depth, Boolean isMax)
        {
            int score = Evaluate(b);
            if (score == 10)
                return score;

            if (score == -10)
                return score;

            if (isMovesLeft(b) == false)
                return 0;


            if (isMax)
            {
                int best = -1000;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (b[i, j] == "")
                        {
                            b[i, j] = player2Symbol;

                            best = Math.Max(best, MiniMax(board, depth + 1, !isMax));

                            b[i, j] = "";
                        }


                    }
                }

                return best;

            }
            else
            {

                int best = 1000;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (b[i, j] == "")
                        {
                            b[i, j] = player1Symbol;

                            best = Math.Min(best, MiniMax(board, depth + 1, !isMax));

                            b[i, j] = "";
                        }


                    }
                }

                return best;

            }

        }

        private Button IndexToButton(int[] indexes)
        {


            if (indexes[0] == 0 && indexes[1] == 0)
                return A1;
            if (indexes[0] == 0 && indexes[1] == 1)
                return A2;
            if (indexes[0] == 0 && indexes[1] == 2)
                return A3;
            if (indexes[0] == 1 && indexes[1] == 0)
                return B1;
            if (indexes[0] == 1 && indexes[1] == 1)
                return B2;
            if (indexes[0] == 1 && indexes[1] == 2)
                return B3;
            if (indexes[0] == 2 && indexes[1] == 0)
                return C1;
            if (indexes[0] == 2 && indexes[1] == 1)
                return C2;
            else
                return C3;

        }

        private Boolean isMovesLeft(string[,] b)
        {
            for (int i = 0; i<3; i++)
            {
                for (int j=0; j<3; j++)
                {
                    if (b[i,j] =="")
                        return true;
                }
            }
            return false;
        }
        private void Computer() 
        {

            ButtonsToArray();
            Button bestButton = new Button();
            bestButton = IndexToButton(BestMove(board));
            MakeMove(bestButton);
            //Check if you can win, if so play that move
            //Check if opponent can win next turn
            //Check if 
        }

        
    }
}
