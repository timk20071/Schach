using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Figur {
        public bool IsWhite { get; set; }
        public char Symbol { get; set; }
        public Figur(bool iswhite,char symblowhite,char symbolblack) {
            IsWhite = iswhite;
            if (IsWhite) {
                Symbol = symblowhite;
            }
            else {
                Symbol = symbolblack;
            }
        }
        /*
        public void Move(int currxpos,int currypos,int targetxpos,int targetypos,Spielbrett spielbrett,bool fromconsole) {
            try {
                if (!( spielbrett.Brett[currxpos,currypos].CheckIfMoveCorrect(currxpos,currypos,targetxpos,targetypos,spielbrett) )) {
                    throw new Exception("Der von Ihnen einegebener Zug ist führ diese Figur nicht zulässig! Bitte geben Sie erneut ein");
                }

                if (!spielbrett.Brett[currxpos,currypos].CheckIfPathIsClear(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                    if (spielbrett.Brett[currxpos,currypos].CheckCollision(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                        Capture(currxpos,currypos,targetxpos,targetypos,spielbrett);
                        return;
                    }
                    else {
                        throw new Exception("Der von Ihnen einegebener Zug ist nicht zulässig! Bitte geben Sie erneut ein");
                    }
                }

                spielbrett.Brett[targetxpos,targetypos] = spielbrett.Brett[currxpos,currypos];
                spielbrett.Brett[currxpos,currypos] = null;

            }
            catch (Exception e) {
                int[] inputData = new int[4];
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ResetColor();
                inputData = spielbrett.Input_MoveConsole();
                currxpos = inputData[0];
                currypos = inputData[1];
                targetxpos = inputData[2];
                targetypos = inputData[3];
                spielbrett.Brett[currxpos,currypos].Move(currxpos,currypos,targetxpos,targetypos,spielbrett,fromconsole);
            }
        }
        */
        public bool Move(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett, bool fromconsole) {///////////////////////////////////////////////////////////

            if (spielbrett.Brett[currxpos,currypos].CheckIfMoveCorrect(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                if (spielbrett.Brett[currxpos,currypos].CheckIfPathIsClear(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                    if (spielbrett.Brett[currxpos,currypos].CheckCollision(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                        Capture(currxpos,currypos,targetxpos,targetypos,spielbrett);
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckCollision(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) { // If Player can move there returns true
            //checks if the collision is at the end of the target and the piece has an other color as the moving one

            bool checkColliding = false;
           
            if (Math.Abs(currypos - targetypos) == 1 && Math.Abs(currxpos - targetxpos) == 0 && null != spielbrett.Brett[targetxpos, targetypos]) {
                return false;
            }

            if (spielbrett.Brett[targetxpos, targetypos] != null && spielbrett.Brett[currxpos,currypos].IsWhite != spielbrett.Brett[targetxpos,targetypos].IsWhite) {
                checkColliding = true;
            }

            return checkColliding;
        }

        public virtual bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett) {
            return false;
        }

        public virtual bool CheckIfPathIsClear(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            return true;
        }

        private void Capture(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) {
            spielbrett.Brett[targetxpos, targetypos] = spielbrett.Brett[currxpos, currypos];
            spielbrett.Brett[currxpos, currypos] = null;
        }
    }
}