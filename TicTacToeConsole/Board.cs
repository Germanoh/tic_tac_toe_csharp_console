using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    internal class Board
    {
        private int[] positions;
        private string[] playersLogo = new string[] { " ", "x", "o" }; 
        public void SetPositions(int[] positions)
        {
            this.positions = positions;
        }
        public void DrawBoard()
        {
            for (int i = 1; i <= 9; ++i)
            {
                //Console.WriteLine("i: " + i);
                Console.Write(playersLogo[positions[i - 1]] + " | ");

                if (i % 3 == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("----------");
                }
            }
        }

        // checks if the current position that a player chose is empty or not
        // it checks if the index of the current (position - 1) is different than 0
        public bool EmptyPlace(int currentPosition)
        {
            if (positions[currentPosition - 1] != 0)
                return false;

            return true;
        }

        // checks if there is a winner or it is a draw, it will check all the combinations of 
        // positions to see if there is a line or diagonal equal, if there is it will return 1.
        // if it's a draw it will return a 0.
        public int CheckWinner()
        {
            // winner
            if ((positions[0] == positions[1] && positions[1] == positions[2] && positions[2] != 0) ||  // first row
                (positions[3] == positions[4] && positions[4] == positions[5] && positions[5] != 0) ||  // second row
                (positions[6] == positions[7] && positions[7] == positions[8] && positions[8] != 0) ||  // third row
                (positions[0] == positions[3] && positions[3] == positions[6] && positions[6] != 0) ||  // first column 
                (positions[1] == positions[4] && positions[4] == positions[7] && positions[7] != 0) ||  // second column
                (positions[2] == positions[5] && positions[5] == positions[8] && positions[8] != 0) ||  // third column
                (positions[0] == positions[4] && positions[4] == positions[8] && positions[8] != 0) ||  // first diagonal
                (positions[2] == positions[4] && positions[4] == positions[6] && positions[6] != 0))    // second diagonal
                return 1;

            // draw
            else
            {
                foreach (int item in positions)
                {
                    if (item == 0)
                        return 0;
                }

                return 2;
            }
        }
    }
}
