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

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett) {
            if ((Math.Abs(currypos - targetypos) == 2 && currxpos == targetxpos && _hasmoved == false))
            {
                _hasmoved = true;
                return true;
            }
            else if (Math.Abs(currypos - targetypos) == 1 && currxpos == targetxpos)
            {
                _hasmoved = true;
                return true;
            }
            else if (Math.Abs(currypos - targetypos) == 1 && Math.Abs(currxpos - targetxpos) == 1 && null != spielbrett.Brett[targetxpos, targetypos])
            {
                _hasmoved = true;
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (currypos < targetypos && currxpos == targetxpos && spielbrett.Brett[currxpos, currypos].IsWhite) {//check if pawn is moving up  //// iswhite abfrage als letztes geändert (falls Fehler auftreten
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//moves forward
                    if (spielbrett.Brett[currxpos, currypos + i] != null) {//check if something is infront of the pawn
                        return false;
                    }
                }
            }
            else if (currypos > targetypos && currxpos == targetxpos && !spielbrett.Brett[currxpos,currypos].IsWhite) {//check if pawn is moving down  //// iswhite abfrage als letztes geändert (falls Fehler auftreten
                for (int i = 1; i <= (currypos - targetypos); i++) {//moves downwards
                    if (null != spielbrett.Brett[currxpos, currypos - i]) {//check if something is infront of the pawn
                        return false;
                    }
                }
            }
            return true;
        }
    }
}