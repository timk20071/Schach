using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace _029_Schach.Figuren {
    internal class Figur {
        public bool IsWhite { get;}
        public char Symbol { get;}
        public char Savecharacter { get;}
        public Figur(bool iswhite,char symblowhite,char symbolblack,char savecharacter) {
            IsWhite = iswhite;
            if (IsWhite) {
                Symbol = symblowhite;
                Savecharacter = Convert.ToChar(savecharacter);
            }
            else {
                Symbol = symbolblack;
                Savecharacter = Convert.ToChar((int)savecharacter + 32);
            }
        }

        public void Console_Move(int currxpos,int currypos,int targetxpos,int targetypos,Spielbrett spielbrett,bool fromconsole) {
            try {
                if (!( spielbrett.Brett[currxpos,currypos].CheckIfMoveCorrect(currxpos,currypos,targetxpos,targetypos,spielbrett) )) {
                    throw new Exception("Der von Ihnen einegebener Zug ist führ diese Figur nicht zulässig! Bitte geben Sie erneut ein");
                }

                if (!spielbrett.Brett[currxpos,currypos].CheckIfPathIsClear(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                    if (!spielbrett.Brett[currxpos,currypos].CheckCollision(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                        throw new Exception("Der von Ihnen einegebener Zug ist nicht zulässig! Bitte geben Sie erneut ein");
                    }
                }
                Capture(currxpos,currypos,targetxpos,targetypos, spielbrett);
                CheckPawnPromotion(targetxpos,targetypos,spielbrett.Brett, true, null);
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
                spielbrett.Brett[currxpos,currypos].Console_Move(currxpos,currypos,targetxpos,targetypos,spielbrett,fromconsole);
            }
        }
        
        public bool Tcp_Move(int currxpos,int currypos,int targetxpos,int targetypos, Spielbrett spielbrett, NetworkStream clientStream) {

            if (spielbrett.Brett[currxpos,currypos].CheckIfMoveCorrect(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                if (spielbrett.Brett[currxpos,currypos].CheckIfPathIsClear(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                    if (spielbrett.Brett[currxpos,currypos].CheckCollision(currxpos,currypos,targetxpos,targetypos,spielbrett)) {
                        Capture(currxpos,currypos,targetxpos,targetypos,spielbrett);
                        CheckPawnPromotion(targetxpos,targetypos,spielbrett.Brett, false, clientStream);
                        return true;
                    }
                }
            }
            return false;
        }

        protected virtual bool CheckCollision(int currxpos, int currypos, int targetxpos, int targetypos, Spielbrett spielbrett) { // If Player can move there returns true
            if (spielbrett.Brett[targetxpos, targetypos] == null) {
                return true;
            }
            else if (spielbrett.Brett[targetxpos,targetypos] != null && spielbrett.Brett[currxpos,currypos].IsWhite != spielbrett.Brett[targetxpos,targetypos].IsWhite) {
                return true;
            }
            return false;
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

        private void CheckPawnPromotion(int targetxpos, int targetypos, Figur[,] Brett,bool fromconsole, NetworkStream client) {
            if (!(Savecharacter == 'P')) return; // Wenn die Figur kein Bauer ist --> verlassen

            if((IsWhite && targetypos == 7 || !IsWhite && targetypos == 0) && fromconsole) {
                Console_Promote(targetxpos,targetypos,Brett);
            }
            else if(( IsWhite && targetypos == 7 || !IsWhite && targetypos == 0 ) && fromconsole) {
                Tcp_Promote(targetxpos, targetypos, Brett, client);
            }
        }

        private void Console_Promote(int targetxpos, int targetypos, Figur[,] Brett) {
            string input;
            bool inputvalid;
            Console.Write("Dein Bauer ist auf dem Letzten Feld, zu welcher Figur möchtest du in verwandeln?");
            
            do {
                inputvalid = true; // so muss die variable nicht bei jedem Case gesetzt werden
                input = Console.ReadLine();
                
                if (input == "Springer") {
                    Brett[targetxpos, targetypos] = new Knight(IsWhite);
                }
                else if (input == "Läufer") {
                    Brett[targetxpos,targetypos] = new Bishop(IsWhite);
                }
                else if (input == "Dame") {
                    Brett[targetxpos,targetypos] = new Queen(IsWhite);
                }
                else {
                    inputvalid = false;
                    Console.Write("Falsche Eingabe, gib nochmal ein: ");
                }
            } while(!inputvalid);
        }

        private void Tcp_Promote(int targetxpos,int targetypos,Figur[,] Brett, NetworkStream clientStream) {
            byte[] inputbuffer = new byte[100];
            int inputproblem = 0;
            char[] charinput = new char[100];
            string strinput;
            bool inputvalid;
            int i = 0;
            clientStream.Write(Encoding.UTF8.GetBytes("Dein Bauer ist auf dem Letzten Feld, zu welcher Figur möchtest du in verwandeln?"));
            
            do {
                inputvalid = true; // so muss die variable nicht bei jedem Case gesetzt werden
                
                clientStream.Read(inputbuffer, 0, 100);

                while (inputbuffer[inputproblem] == '\r') {
                inputproblem += 2;
                }

                while (inputbuffer[i + inputproblem] != 0) {
                charinput[i] = (char) inputbuffer[i + inputproblem];
                i++;
                }
                
                strinput = Convert.ToString(charinput);

                if (strinput == "Springer") {
                    Brett[targetxpos,targetypos] = new Knight(IsWhite);
                }
                else if (strinput == "Läufer") {
                    Brett[targetxpos,targetypos] = new Bishop(IsWhite);
                }
                else if (strinput == "Dame") {
                    Brett[targetxpos,targetypos] = new Queen(IsWhite);
                }
                else {
                    inputvalid = false;
                    clientStream.Write(Encoding.UTF8.GetBytes("Falsche Eingabe, gib nochmal ein: "));
                }
            } while (!inputvalid);
        }
    }
}