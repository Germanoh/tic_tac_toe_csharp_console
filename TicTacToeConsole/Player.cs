using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToeConsole
{
    internal class Player
    {
        private string name;
        private bool isPlaying;
        private int[] positionMap = new int[9];

        // a player must have a name
        //public Player(string name)
        //{
        //    this.name = name;
        //}

        // sets the name of the player
        public void SetName(string name)
        {
            this.name = name;
        }

        // gets the name of the player
        public string GetName()
        {
            return name;
        }

        // sets if it's the current player
        public void SetIsPlaying(bool isPlaying)
        {
            this.isPlaying = isPlaying;
        }

        // gets if it's the time of the current player
        public bool GetIsPlaying()
        {
            return isPlaying;
        }

        // sets the position map for each player
        // where the player has pieces, player1 will have a playerId of 1
        // player2 will have a playerId of 2, then the position map will store 
        // values of 0, for free positions, 1 for player1 positions and 2 for 
        // player2 positions
        public void SetPositionMap(int position, Players PlayerId)
        { 
            positionMap[position - 1] = (int)PlayerId;  // the index must be position - 1 because starts at 0
        }

        // gets the current player map position
        // where the player has pieces
        public int[] GetPositionMap()
        {
            //foreach (int position in positionMap)
            //{
            //    Console.Write(position + " ");
            //}

            return positionMap;
        }
    }
}
