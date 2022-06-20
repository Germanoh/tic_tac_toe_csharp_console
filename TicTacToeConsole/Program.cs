using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Tic Tac Toe - v1.0 (Console Application)
 * Author: Germano Henrique
 */

namespace TicTacToeConsole
{
    public enum Players { player1 = 1, player2 };
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TIC TAC TOE - V1.0\n");

            // instantiates player 1 and player 2
            Player player1 = new Player();
            Player player2 = new Player();
            Board board = new Board();

            // stores player 1 name 
            Console.Write("Player 1 name: ");
            player1.SetName(Console.ReadLine());
            string player1Name = player1.GetName();

            // stores player 2 name
            Console.Write("Player 2 name: ");
            player2.SetName(Console.ReadLine());
            string player2Name = player2.GetName();

            Console.WriteLine("\nPlayer 1 name: " + player1Name);

            Console.WriteLine("Player 2 name: " + player2Name);

            // main game loop
            // asks for players which positions they gonna play
            player1.SetIsPlaying(true); // the player1 starts playing

            // for now there is only 9 tries, prototype purposes
            // for each player, it will be the position they want to put pieces,
            // after this, their position map will be updated and sent to the board
            int currentPosition;
            int[] finalPositionMap = new int[9];
            int isGameOver = 0; // 0 it means the game is still active, 1 means winner, 2 means draw
            Players playerId = Players.player1;

            // draws the board for the first time
            board.SetPositions(finalPositionMap);
            board.DrawBoard();

            while (isGameOver == 0)
            {
                // player's 1 time 
                if (player1.GetIsPlaying())
                {
                    Console.WriteLine("Player1 : " + player1Name);
                    Console.Write("Choose a position between 1 and 9: ");
                    currentPosition = Convert.ToInt32(Console.ReadLine());

                    // checks to see if the current place chosed by the player is already occupied
                    if (!(board.EmptyPlace(currentPosition)))
                    {
                        Console.WriteLine("Position occupied, chose another!\n");
                        continue;
                    }

                    // sets player1 to not playing and player2 to playing
                    player1.SetIsPlaying(false);
                    player2.SetIsPlaying(true);
                    playerId = Players.player1;

                    // updates the map position of player1
                    player1.SetPositionMap(currentPosition, playerId);

                    player1.GetPositionMap();
                }
                else 
                {
                    Console.WriteLine("Player2: " + player2Name);
                    Console.Write("Choose a position between 1 and 9: ");
                    currentPosition = Convert.ToInt32(Console.ReadLine());

                    // checks to see if the current place chosed by the player is already occupied
                    if (!(board.EmptyPlace(currentPosition)))
                    {
                        Console.WriteLine("Position occupied, chose another!\n");
                        continue;
                    }

                    // sets player1 to not playing and player2 to playing
                    player2.SetIsPlaying(false);
                    player1.SetIsPlaying(true);
                    playerId = Players.player2;

                    // updates the map position of player1l
                    player2.SetPositionMap(currentPosition, playerId);

                    player2.GetPositionMap();
                }

                // adds the position maps of player1 and player2 to update the board
                finalPositionMap = AddPositionMaps(player1.GetPositionMap(), player2.GetPositionMap());
                board.SetPositions(finalPositionMap);
                board.DrawBoard();

                // checks if there is a winner or there is a draw
                isGameOver = board.CheckWinner();
                //foreach (int item in finalPositionMap)
                //{
                //    Console.Write(item + " ");
                //}
            }


            // displays if there is a winner or it's a draw
            if (isGameOver == 2)
                Console.WriteLine("The game was a draw.");
            else
            {
                if (playerId == Players.player1)
                    Console.WriteLine("The winner is: " + player1Name);
                else
                    Console.WriteLine("The winner is: " + player2Name);

            }
        }

        // adds the position maps for player1 and player2, whatever position a player1 is
        // the positionMap will store 1 and whatever position the player 2 is,
        // positionMap will store 2
        static int[] AddPositionMaps(int[] positionMapPlayer1, int[] positionMapPlayer2)
        {
            int[] positionMap = new int[9];

            for (int i = 0; i < 9; ++i)
            {
                if (positionMapPlayer1[i] != 0)
                    positionMap[i] = positionMapPlayer1[i];
                else if (positionMapPlayer2[i] != 0)
                    positionMap[i] = positionMapPlayer2[i];
            }

            return positionMap;
        }
    }
}
