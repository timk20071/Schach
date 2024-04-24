using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Knight : Figur{
        private static char _symbolBlack = '\u265E';
        private static char _symbolWhite = '\u2658';

        public Knight(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
            if (currxpos == ( targetxpos + 2 ) && currypos == ( targetypos + 1 ) ||
                currxpos == ( targetxpos - 2 ) && currypos == ( targetypos + 1 ) ||
                currxpos == ( targetxpos + 2 ) && currypos == ( targetypos - 1 ) ||
                currxpos == ( targetxpos - 2 ) && currypos == ( targetypos - 1 ) ||
                currxpos == ( targetxpos + 1 ) && currypos == ( targetypos + 2 ) ||
                currxpos == ( targetxpos - 1 ) && currypos == ( targetypos + 2 ) ||
                currxpos == ( targetxpos + 1 ) && currypos == ( targetypos - 2 ) ||
                currxpos == ( targetxpos - 1 ) && currypos == ( targetypos - 2 ) ){
                return true;
            }
            return false;
        }
    }
}