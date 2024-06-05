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
            if (((currxpos - targetxpos)== 1 || (currxpos - targetxpos) == -1 || currxpos == targetxpos) &&
                ((currypos - targetypos)== 1 || (currypos - targetypos) == -1 || currypos == targetypos) &&
                ((currxpos - targetxpos)!= 0 || (currypos - targetypos) != 0)) {
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (currypos < targetypos && currxpos == targetxpos && spielbrett.Brett[currxpos, currxpos - 1] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step up is clear
                return false;
            }
            else if (currypos < targetypos && currxpos == targetxpos && spielbrett.Brett[currxpos,currypos + 1] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step down is clear
                return false;
            }
            else if (currypos == targetypos && currxpos < targetxpos && spielbrett.Brett[currxpos + 1, currypos] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step to the right is clear
                return false;
            }
            else if (currypos == targetypos && currxpos > targetxpos && spielbrett.Brett[currxpos - 1,currypos] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step to the left is clear
                return false;
            }
            else if (currypos > targetypos && currxpos > targetxpos && spielbrett.Brett[currxpos - 1,currypos - 1] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step up and left is clear
                return false;
            }
            else if (currypos > targetypos && currxpos < targetxpos && spielbrett.Brett[currxpos + 1,currypos - 1] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step up and right is clear
                return false;
            }
            else if (currypos > targetypos && currxpos < targetxpos && spielbrett.Brett[currxpos + 1, currypos + 1] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step down and right is clear
                return false;
            }
            else if (currypos > targetypos && currxpos > targetxpos && spielbrett.Brett[currxpos - 1, currypos + 1] != null || spielbrett.Brett[currxpos, currypos].IsWhite != spielbrett.Brett[targetxpos, targetypos].IsWhite) {//check if path one step down and left is clear
                return false;
            }
            return true;
        }
    }
}