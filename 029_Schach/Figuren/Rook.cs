using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Rook : Figur {
        private static char _symbolBlack = '\u265C';
        private static char _symbolWhite = '\u2656';
        private bool _hasmoved = false;

        public Rook(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
            if (currxpos == targetxpos || currypos == targetypos) { 
                return true;
            }
            return false;
        }

        public bool CheckIfPathIsClear(int[] input, Spielbrett spielbrett)
        {
            bool pathIsClear = true;

            if (input[0] != input[2])//ckeck if rook is going down or up
            {
                if (input[0] < input[2])//check if rook is going up 
                {
                    for (int i = 0; i < (input[2] - input[0]); i++)//goes thrue all the way up
                    {
                        if (null != spielbrett.Brett[input[1] + i, input[0]])//check if the path is free
                        {
                            pathIsClear = false;
                            return pathIsClear;
                        }
                    }
                }
                else if (input[0] > input[2])//check if rook is going down
                {
                    for (int i = 0; i < (input[0] - input[2]); i++)//goes thrue all the way up
                    {
                        if (null != spielbrett.Brett[input[1] - i, input[0]])//check if the path is free
                        {
                            pathIsClear = false;
                            return pathIsClear;
                        }
                    }
                }

            }
            else if (input[1] != input[3])//check if rook is going right or left
            {
                if (input[1] < input[3])//check if rook is going right 
                {
                    for (int i = 0; i < (input[3] - input[1]); i++)//goes thrue all the way to the right
                    {
                        if (null != spielbrett.Brett[input[1], input[0] + i])//check if the path is free
                        {
                            pathIsClear = false;
                            return pathIsClear;
                        }
                    }
                }
                else if (input[1] > input[3])//check if rook is going left
                {
                    for (int i = 0; i < (input[0] - input[2]); i++)//goes thrue all the way to the left
                    {
                        if (null != spielbrett.Brett[input[1], input[0] - i])//check if the path is free
                        {
                            pathIsClear = false;
                            return pathIsClear;
                        }
                    }
                }
            }

            return pathIsClear;
        }
    }
}