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
    }
}
