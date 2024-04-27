using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class King: Figur {
        private static char _symbolBlack = '\u265A';
        private static char _symbolWhite = '\u2654';
        private bool _hasmoved = false;

        public King(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
            if (((currxpos - targetxpos)== 1 || (currxpos - targetxpos) == -1 || currxpos == targetxpos) &&
                ((currypos - targetypos)== 1 || (currypos - targetypos) == -1 || currypos == targetypos) &&
                ((currxpos - targetxpos)!= 0 || (currypos - targetypos) != 0)) {
                return true;
            }
            return false;
        }

        public bool CheckIfPathIsClear(int[] input, Spielbrett spielbrett)
        {
            bool pathIsClear = true;

            if (input[1] < input[3] && input[0] == input[2] && null != spielbrett.Brett[input[1] + 1, input[0]])//check if path one step up is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }
            else if (input[1] > input[3] && input[0] == input[2] && null != spielbrett.Brett[input[1] - 1, input[0]])//check if path one step down is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }
            else if (input[1] == input[3] && input[0] < input[2] && null != spielbrett.Brett[input[1], input[0] + 1])//check if path one step to the right is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }
            else if (input[1] == input[3] && input[0] > input[2] && null != spielbrett.Brett[input[1], input[0] - 1])//check if path one step to the left is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }
            else if (input[1] < input[3] && input[0] > input[2] && null != spielbrett.Brett[input[1] + 1, input[0] - 1])//check if path one step up and left is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }
            else if (input[1] < input[3] && input[0] < input[2] && null != spielbrett.Brett[input[1] + 1, input[0] + 1])//check if path one step up and right is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }
            else if (input[1] > input[3] && input[0] < input[2] && null != spielbrett.Brett[input[1] - 1, input[0] + 1])//check if path one step down and right is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }
            else if (input[1] > input[3] && input[0] > input[2] && null != spielbrett.Brett[input[1] - 1, input[0] - 1])//check if path one step down and left is clear 
            {
                pathIsClear = false;
                return pathIsClear;
            }

            return pathIsClear;
        }

    }
}