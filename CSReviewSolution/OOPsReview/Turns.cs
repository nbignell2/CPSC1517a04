using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview
{
    public class Turn
    {
        public int Player1Roll { get; set; }
        public int Player2Roll { get; set; }

        //optionally for practice only add constructors
        //Default
        public Turn()
        {

        }

        //Greedy constructor
        public Turn(int player1, int player2)
        {
            Player1Roll = player1;
            Player2Roll = player2;
        }
    }
}
