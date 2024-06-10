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
        private static char savecharacter = 'K';


        public King(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack,savecharacter) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett, bool isFromMove) {
            if (((Math.Abs(currxpos - targetxpos) == 1 || currxpos == targetxpos) &&
                (Math.Abs(currypos - targetypos) == 1 || currypos == targetypos)) 
                //||(currxpos - targetxpos) != 0 || (currypos - targetypos) != 0
                ) {
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (spielbrett.Brett[targetxpos,targetypos] == null) return true;
            if (spielbrett.Brett[currxpos,currypos].IsWhite != spielbrett.Brett[targetxpos,targetypos].IsWhite) return true;

            return false;   
        }
    }
}