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

        public void Move(int currxpos,int currypos,int targetxpos,int targetypos,Figur figur, Spielbrett spielbrett) {
            try
            {
                if (!(figur.CheckIfMoveCorrect(currxpos, currypos, targetxpos, targetypos, spielbrett)))
                {
                    throw new Exception("Der von Ihnen einegebener Zug ist führ diese Figur nicht zulässig! Bitte geben Sie erneut ein");
                }

                if (!figur.CheckIfPathIsClear(currxpos, currypos, targetxpos, targetypos, spielbrett))
                {
                    if (figur.CheckCollision(currxpos, currypos, targetxpos, targetypos, figur, spielbrett))
                    {
                        Capture(currxpos, currypos, targetxpos, targetypos, spielbrett);
                        return;
                    }
                    else
                    {
                        throw new Exception("Der von Ihnen einegebener Zug ist nicht zulässig! Bitte geben Sie erneut ein");
                    }
                }

                spielbrett.Brett[targetxpos, targetypos] = spielbrett.Brett[currxpos, currypos];
                spielbrett.Brett[currxpos, currypos] = null;

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
                figur.Move(inputData[0], inputData[1], inputData[2], inputData[3], spielbrett.Brett[inputData[0], inputData[1]], spielbrett);
            }
        }

        private bool CheckCollision(int currxpos, int currypos, int targetxpos, int targetypos, Figur figur, Spielbrett spielbrett) {
            //checks if the collision is at the end of the target and the piece has an other color as the moving one

            bool CheckColliding = false;
           
            if (Math.Abs(currypos - targetypos) == 1 && Math.Abs(currxpos - targetxpos) == 0 && null != spielbrett.Brett[targetxpos, targetypos])
            {
                return false;
            }

            if (null != spielbrett.Brett[targetxpos, targetypos] && figur.IsWhite != spielbrett.Brett[targetxpos,targetypos].IsWhite)
            {
                CheckColliding = true;
            }

            return CheckColliding;
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