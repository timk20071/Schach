using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Pawn : Figur {

        private static char _symbolBlack = '\u265F';
        private static char _symbolWhite = '\u2659';
        private bool _hasmoved = false;

        public Pawn(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
            if ((Math.Abs(currypos - targetypos) == 2 && currxpos == targetxpos && _hasmoved == false)) {
                _hasmoved = true;
                return true;
            }
            else if(Math.Abs(currypos - targetypos) == 1 && currxpos == targetxpos) {
                _hasmoved = true;
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett)
        {
            bool pathIsClear = true;
            int[] input = { currxpos, currypos, targetxpos, targetypos};

            if (input[1] < input[3] && input[0] == input[2])//check if pawn is moving up
            {
                for (int i = 0; i < (input[3] - input[1]); i++)//moves forward
                {
                    if (null != spielbrett.Brett[input[1] + i, input[0]])//check if something is infront of the pawn
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }else if (input[1] > input[3] && input[0] == input[2])//check if pawn is moving down
            {
                for (int i = 0; i < (input[1] - input[3]); i++)//moves downwards
                {
                    if (null != spielbrett.Brett[input[1] - i, input[0]])//check if something is infront of the pawn
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }

            return pathIsClear;
        }
    }
}
