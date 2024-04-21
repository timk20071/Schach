using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach {
    internal class Knight : Figur{
        private char _symbolBlack = '\u265E';
        private char _symbolWhite = '\u2658';

        public Knight(bool iswhite) : base(iswhite,symblowhite: _symbolWhite,symbolblack: _symbolBlack) { }

        public bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {

            if (currxpos == currypos + 2) { }
            return true;
        }
    }
}

