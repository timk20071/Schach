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
    }
}