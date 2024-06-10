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

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett, bool isFromMove) {
            if (currxpos == targetxpos || currypos == targetypos) { 
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (currypos > targetypos && currxpos == targetxpos) {//check if rook is going up 
                for (int i = 1; i <= Math.Abs(targetypos - currypos); i++) {//calculates how many fields the rook has to go
                    if (spielbrett.Brett[currxpos,currypos - i] != null) {//check if the path is free
                        if (currypos - i == targetypos && spielbrett.Brett[currxpos, currypos - i].IsWhite != spielbrett.Brett[currxpos,currypos].IsWhite)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            else if (currypos < targetypos && currxpos == targetxpos) {//check if rook is going down
            
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the rook has to go
                
                    if (spielbrett.Brett[currxpos,currypos + i] != null) {//check if the path is free
                        
                        if (currypos + i == targetypos && spielbrett.Brett[currxpos, currypos + i].IsWhite != spielbrett.Brett[currxpos,currypos].IsWhite)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            else if (currypos == targetypos && currxpos < targetxpos) {//check if rook is going right 
            
                for (int i = 1; i <= Math.Abs(targetxpos - currxpos); i++) {//calculates how many fields the rook has to go
                
                    if (spielbrett.Brett[currxpos + i,currypos] != null) {//check if the path is free
                        if (currxpos + i == targetxpos && spielbrett.Brett[currxpos + i, currypos].IsWhite != spielbrett.Brett[currxpos,currypos].IsWhite)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            else if (currypos == targetypos && currxpos > targetxpos) {//check if rook is going left
            
                for (int i = 1; i <= Math.Abs(currxpos - targetxpos); i++) {//calculates how many fields the rook has to go
                
                    if (spielbrett.Brett[currxpos - 1,currypos] != null) {//check if the path is free
                        if (currxpos - i == targetxpos && spielbrett.Brett[currxpos - 1, currypos].IsWhite != spielbrett.Brett[currxpos,currypos].IsWhite)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }

            return true;
        }
    }
}