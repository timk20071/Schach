using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Queen : Figur {
        private static char _symbolBlack = '\u265B';
        private static char _symbolWhite = '\u2655';
        private static char savecharacter = 'Q';        

        public Queen(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack,savecharacter) { }

        public override bool CheckIfMoveCorrect(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (Math.Abs(currxpos - targetxpos) == Math.Abs(currypos - targetypos) || (currxpos == targetxpos || currypos == targetypos)) {
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (currypos < targetypos && currxpos == targetxpos) {//check if queen is going up 
                for (int i = 1; i <= (targetypos - currypos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos, currypos + i] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos > targetypos && currxpos == targetxpos) {//check if queen is going down
                for (int i = 1; i <= (currypos - targetypos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos - i,currypos] != null) {//check if the path is free
                        return false;
                    }
                }
            } 
            else if (currypos == targetypos && currxpos < targetxpos) {//check if queen is going right 
                for (int i = 1; i <= (targetxpos - currxpos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos,currypos + i] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos == targetypos && currxpos > targetxpos) {//check if queen is going left
                for (int i = 1; i <= (currxpos - targetxpos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos,currypos - i] != null) {//check if the path is free
                        return false;
                    }
                }
            } 
            else if (currypos < targetypos && currxpos < targetxpos) {//check if queen is moving right up
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos + i,currypos + i] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos < targetypos && currxpos > targetxpos) {//check if queen is moving left up
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos + i,currypos - i] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos > targetypos && currxpos > targetxpos) {//check if queen is moving left down
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos - i + 1,currypos - i + 1] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos > targetypos && currxpos < targetxpos) {//check if queen is moving right down
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the queen has to go
                    if (spielbrett.Brett[currxpos - i,currypos + i] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            return true;
        }
    }
}