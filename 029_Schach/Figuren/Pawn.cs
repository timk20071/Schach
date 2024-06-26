﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Pawn : Figur {

        private static char _symbolBlack = '\u265F';
        private static char _symbolWhite = '\u2659';
        private static char savecharacter = 'P';
        private bool _hasmoved = false;
        
        public Pawn(bool iswhite) : base(iswhite,_symbolWhite,_symbolBlack,savecharacter) { }

        public override bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett, bool isFromMove) {
            if (spielbrett.Brett[currxpos, currypos].IsWhite == false && currypos - targetypos == 2 && currxpos == targetxpos && _hasmoved == false)//checks if white pawn is moving two steps up
            {
                if (isFromMove) _hasmoved = true;             
                return true;
            }
            else if (spielbrett.Brett[currxpos, currypos].IsWhite == false && currypos - targetypos == 1 && currxpos == targetxpos)//checks if white pawn is moving one step up
            {
                if (isFromMove) _hasmoved = true;
                return true;
            }
            else if (spielbrett.Brett[currxpos, currypos].IsWhite == false && currypos - targetypos == 1 && Math.Abs(currxpos - targetxpos) == 1 && null != spielbrett.Brett[targetxpos, targetypos])//checks if white pawn is capturing
            {
                if (isFromMove) _hasmoved = true;
                return true;
            }else if (spielbrett.Brett[currxpos, currypos].IsWhite == true && currypos - targetypos == -2 && currxpos == targetxpos && _hasmoved == false)//checks if black pawn is moving two steps down
            {
                if (isFromMove) _hasmoved = true;
                return true;
            }
            else if (spielbrett.Brett[currxpos, currypos].IsWhite == true && currypos - targetypos == -1 && currxpos == targetxpos)//checks if black pawn is moving one step down
            {
                if (isFromMove) _hasmoved = true;
                return true;
            }
            else if (spielbrett.Brett[currxpos, currypos].IsWhite == true && currypos - targetypos == -1 && Math.Abs(currxpos - targetxpos) == 1 && null != spielbrett.Brett[targetxpos, targetypos])//checks if black pawn is capturing
            {
                if (isFromMove) _hasmoved = true;
                return true;
            }
            return false;
        }

        public override bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            if (currypos > targetypos && currxpos == targetxpos) {//check if pawn is moving up  
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//moves forward
                    if (spielbrett.Brett[currxpos, currypos - i] != null) {//check if something is infront of the pawn
                        if(!CheckCollision(currxpos, currypos, targetxpos, targetypos, spielbrett))
                        {
                        return false; 
                        }
                    }
                }
            }
            else if (currypos < targetypos && currxpos == targetxpos) {//check if pawn is moving down  
                for (int i = 1; i <= Math.Abs(currypos - targetypos); i++) {//moves downwards
                    if (null != spielbrett.Brett[currxpos, currypos + i]) {//check if something is infront of the pawn
                        if (!CheckCollision(currxpos, currypos, targetxpos, targetypos, spielbrett))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
         }

        private bool CheckCollision(int currxpos,int currypos,int targetxpos,int targetypos,Spielbrett spielbrett) { // If Player can move there returns true
            //checks if the collision is at the end of the target and the piece has an other color as the moving one
            if (Math.Abs(currypos - targetypos) == 1 && Math.Abs(currxpos - targetxpos) == 0 && spielbrett.Brett[targetxpos,targetypos] != null) { // Bauer kann nicht nach vorne schlagen!!!
                return false;
            }
            if (spielbrett.Brett[targetxpos,targetypos] == null) {
                return true;
            }
            else if (spielbrett.Brett[targetxpos,targetypos] != null && spielbrett.Brett[currxpos,currypos].IsWhite != spielbrett.Brett[targetxpos,targetypos].IsWhite) {
                return true;
            }
            return false;
        }
    }
}