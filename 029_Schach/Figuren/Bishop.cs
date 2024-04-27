using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _029_Schach.Figuren {
    internal class Bishop : Figur {
        private static char _symbolBlack = '\u265D';
        private static char _symbolWhite = '\u2657';
        

        public Bishop(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
            if (Math.Abs(currxpos - targetxpos) == Math.Abs(currypos - targetypos)) {
                return true;
            }
            return false;
        }

        public bool CheckIfPathIsClear(int[] input, Spielbrett spielbrett)
        {
            bool pathIsClear = true;

            if (input[1] < input[3] && input[0] < input[2])//check if pawn is moving right up
            {
                for (int i = 0; i < Math.Abs(input[1] - input[3]); i++)//calculates how many fields the bishop has to go
                {
                    if (null != spielbrett.Brett[input[1] + i, input[0] + i])//check if something is the path of the bishop
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] < input[3] && input[0] > input[2])//check if pawn is moving left up
            {
                for (int i = 0; i < Math.Abs(input[1] - input[3]); i++)//calculates how many fields the bishop has to go
                {
                    if (null != spielbrett.Brett[input[1] + i, input[0] - i])//check if something is the path of the bishop
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] > input[3] && input[0] > input[2])//check if pawn is moving left down
            {
                for (int i = 0; i < Math.Abs(input[1] - input[3]); i++)//calculates how many fields the bishop has to go
                {
                    if (null != spielbrett.Brett[input[1] - i, input[0] - i])//check if something is the path of the bishop
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] > input[3] && input[0] < input[2])//check if pawn is moving right down
            {
                for (int i = 0; i < Math.Abs(input[1] - input[3]); i++)//calculates how many fields the bishop has to go
                {
                    if (null != spielbrett.Brett[input[1] - i, input[0] + i])//check if something is the path of the bishop
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