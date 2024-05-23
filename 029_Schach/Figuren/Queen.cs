using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Queen : Figur {
        private static char _symbolBlack = '\u265B';
        private static char _symbolWhite = '\u2655';
        private bool _hasmoved = false;

        public Queen(bool iswhite) : base(iswhite, _symbolWhite, _symbolBlack) { }

        public override bool CheckIfMoveCorrect(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (Math.Abs(currxpos - targetxpos) == Math.Abs(currypos - targetypos) || (currxpos == targetxpos || currypos == targetypos)) {
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett)
        {
            bool pathIsClear = true;
            int[] input = { currxpos, currypos, targetxpos, targetypos };


            if (input[1] < input[3] && input[0] == input[2])//check if queen is going up 
            {
                for (int i = 1; i <= (input[3] - input[1]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0], input[1] + i])//check if the path is free
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] > input[3] && input[0] == input[2])//check if queen is going down
            {
                for (int i = 1; i <= (input[1] - input[3]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0] - i, input[1]])//check if the path is free
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            } else if (input[1] == input[3] && input[0] < input[2])//check if queen is going right 
            {
                for (int i = 1; i <= (input[2] - input[0]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0], input[1] + i])//check if the path is free
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] == input[3] && input[0] > input[2])//check if queen is going left
            {
                for (int i = 1; i <= (input[0] - input[2]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0] - i, input[1]])//check if the path is free
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            } else if (input[1] < input[3] && input[0] < input[2])//check if queen is moving right up
            {
                for (int i = 1; i <= Math.Abs(input[1] - input[3]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0] + i, input[1] + i])//check if the path is free
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] < input[3] && input[0] > input[2])//check if queen is moving left up
            {
                for (int i = 1; i <= Math.Abs(input[1] - input[3]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0] + i, input[1] - i])//check if the path is free
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] > input[3] && input[0] > input[2])//check if queen is moving left down
            {
                for (int i = 1; i <= Math.Abs(input[1] - input[3]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0] - i + 1, input[1] - i + 1])//check if the path is free
                    {
                        pathIsClear = false;
                        return pathIsClear;
                    }
                }
            }
            else if (input[1] > input[3] && input[0] < input[2])//check if queen is moving right down
            {
                for (int i = 1; i <= Math.Abs(input[1] - input[3]); i++)//calculates how many fields the queen has to go
                {
                    if (null != spielbrett.Brett[input[0] - i, input[1] + i])//check if the path is free
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