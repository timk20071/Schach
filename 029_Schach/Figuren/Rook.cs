using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Rook : Figur {
        private static char _symbolBlack = '\u265C';
        private static char _symbolWhite = '\u2656';
        private static char savecharacter = 'R';

        public Rook(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack,savecharacter) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett) {
            if (currxpos == targetxpos || currypos == targetypos) { 
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (currypos < targetypos && currxpos == targetxpos) {//check if rook is going up 
                for (int i = 1; i <= (targetypos - currypos); i++) {//calculates how many fields the rook has to go
                    if (spielbrett.Brett[currxpos,currypos + i] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos > targetypos && currxpos == targetxpos) {//check if rook is going down
            
                for (int i = 1; i <= (currypos - targetypos); i++) {//calculates how many fields the rook has to go
                
                    if (spielbrett.Brett[currxpos,currypos - i] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos == targetypos && currxpos < targetxpos) {//check if rook is going right 
            
                for (int i = 1; i <= (targetxpos - currxpos); i++) {//calculates how many fields the rook has to go
                
                    if (spielbrett.Brett[currxpos + i,currypos] != null) {//check if the path is free
                        return false;
                    }
                }
            }
            else if (currypos == targetypos && currxpos > targetxpos) {//check if rook is going left
            
                for (int i = 1; i <= (currxpos - targetxpos); i++) {//calculates how many fields the rook has to go
                
                    if (spielbrett.Brett[currxpos - 1,currypos] != null) {//check if the path is free
                        return false;
                    }
                }
            }

            return true;
        }
    }
}