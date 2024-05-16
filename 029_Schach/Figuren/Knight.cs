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

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett) {
            if (Math.Abs(currxpos - currypos) == 2 && Math.Abs(targetypos - currypos) == 1 ||
                Math.Abs(currxpos - currypos) == 1 && Math.Abs(targetypos - currypos) == 2){
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (spielbrett.Brett[targetxpos,targetypos] != null || spielbrett.Brett[targetxpos, targetypos].IsWhite != spielbrett.Brett[currxpos, currypos].IsWhite) { // Wenn Feld nicht belegt oder die Farben unterscheiden sich: true
                return true;
            }
            return false;
        }
    }
}