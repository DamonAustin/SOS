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
        private char[,] board = null;
        private char moveType = 'S';

        
        public string makeMove(int[] selectedPoints)
        {
            if ((selectedPoints[0]  > boardSize-1 || selectedPoints[1] > boardSize-1) || (selectedPoints[0] < 0 || selectedPoints[1] < 0)){
                return "Invalid Board Location";
            }

            if ((board[selectedPoints[0], selectedPoints[1]] == 'S') || board[selectedPoints[0], selectedPoints[1]] == 'O')
            {
                return "Space Already Occupied";
            }

            board[selectedPoints[0], selectedPoints[1]] = moveType;
            return "Valid Move Made";
        }
        public void setMoveType(char move){ moveType = move;}
        public char getMoveType() { return this.moveType; }

        public bool setBoardSize(int n) {
            if (n < 3) return false;
            boardSize = n;
            return true;
        }

        public int getBoardSize() {
            return boardSize;
        }

        private void createBoard(){
            board = new char[boardSize, boardSize];
        }

        public void setGameMode(bool input){
            gameMode = input;
        }

        public string getGameMode(){
            if (!gameMode) return "Simple";
            return "General";
        }

        public void start()
        {
            createBoard();
        }

        public char[,] getBoard()
        {
            return board;   
        }
    }
}
