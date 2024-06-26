﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _029_Schach.Figuren {
    internal class Bishop : Figur {
        private static char _symbolBlack = '\u265D';
        private static char _symbolWhite = '\u2657';
        private static char savecharacter = 'B';

        public Bishop(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack,savecharacter) { }

        public override bool CheckIfMoveCorrect(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett, bool isFromMove) {
            if (Math.Abs(currxpos - targetxpos) == Math.Abs(currypos - targetypos)) {
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (currypos > targetypos && currxpos < targetxpos) {//check if pawn is moving right down
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the bishop has to go
                    if (null != spielbrett.Brett[currxpos + i, currypos - i]) {//check if something is the path of the bishop
                        if (currxpos + i == targetxpos && currypos - i == targetypos && currypos - i == targetypos && spielbrett.Brett[currxpos + i, currypos - i].IsWhite != spielbrett.Brett[currxpos,currypos].IsWhite)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            else if (currypos < targetypos && currxpos > targetxpos) {//check if pawn is moving left up
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the bishop has to go
                    if (null != spielbrett.Brett[currxpos - i, currypos + i]) {//check if something is the path of the bishop
                        if (currxpos - i == targetxpos && currypos + i == targetypos && spielbrett.Brett[currxpos - i, currypos + i].IsWhite != spielbrett.Brett[currxpos, currypos].IsWhite)
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            else if (currypos > targetypos && currxpos > targetxpos) {//check if pawn is moving left down
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the bishop has to go
                    if (null != spielbrett.Brett[currxpos - i, currypos - i]) { //check if something is the path of the bishop
                        if (currxpos - i == targetxpos && currypos - i == targetypos && spielbrett.Brett[currxpos - i, currypos - i].IsWhite != spielbrett.Brett[currxpos,currypos].IsWhite )
                        {
                            return true;
                        }
                        return false;
                    }
                }
            }
            else if (currypos < targetypos && currxpos < targetxpos) {//check if pawn is moving right up
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//calculates how many fields the bishop has to go
                    if (null != spielbrett.Brett[currxpos + i, currypos + i]) {//check if something is the path of the bishop
                        if (currxpos + i == targetxpos && currypos + i == targetypos && spielbrett.Brett[currxpos + i, currypos + i].IsWhite != spielbrett.Brett[currxpos,currypos].IsWhite)
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