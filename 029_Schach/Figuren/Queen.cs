using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Queen : Figur{
        private static char _symbolBlack = '\u265A';
        private static char _symbolWhite = '\u2654';
        private bool _hasmoved = false;

        public Queen(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
            if (Math.Abs(currxpos - targetxpos) == Math.Abs(currypos - targetypos) || (currxpos == targetxpos || currypos == targetypos)) {
                return true;
            }
            return false;
        }
    }
}