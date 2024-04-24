using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}