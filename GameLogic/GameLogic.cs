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
        private bool gameMode = false;
        private int[,] board = null;

        public bool setBoardSize(int n) {
            if (n < 3) return false;
            boardSize = n;
            return true;
        }

        public int getBoardSize() {
            return boardSize;
        }

        private void createBoard(){
            board = new int[boardSize, boardSize];
        }

        public void setGameMode(bool input){
            gameMode = input;
        }

        public string getGameMode(){
            if (!gameMode) return "Simple";
            return "General";
        }
    }
}
