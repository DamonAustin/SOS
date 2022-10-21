using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOS.GameLogic
{
    public class Game
    {
        private int boardSize = 3;

        public bool setBoardSize(int n){
            if (n < 3) return false;
            boardSize = n;
            return true;
        }
        
        public int getBoardSize(){
            return boardSize;
        }
    }
}
