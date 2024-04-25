using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using _029_Schach.Figuren;

namespace _029_Schach
{
    internal class Spielbrett {
        public Figur[,] Brett = new Figur[8, 8]; // [ypos,xpos]
        
        public Spielbrett() {
            Reset();
        }

        public void Print() {
            Console.Write("\n  A   B   C   D   E   F   G   H  ");
            for (int i = 7; i >= 0; i--) {

                    
                Console.Write("\n---------------------------------\n| ");
                for (int j = 0; j < 8; j++)
                {
                    if (Brett[j, i] != null)
                        Console.Write(Brett[j, i].Symbol + " | ");
                    else
                        Console.Write("  | ");
                }
                Console.Write(i+1);
            }
            Console.WriteLine("\n---------------------------------");
        }
        /*     White | Black
         * Pawn:   P | p
         * King:   K | k
         * Queen:  Q | q
         * Rook:   R | r
         * Bishop: B | b
         * Knight: N | n 
         * Empty:  e
          
         r n b q k b n r
         p p p p p p p p
         e e e e e e e e
         e e e e e e e e
         e e e e e e e e
         e e e e e e e e
         P P P P P P P P
         R N B Q K B N R
        */
        public void Reset() {
            string[,] data = ReadFile();
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++){
                    switch (data[j,i]) {
                        // Black pieces
                        case "p":
                            Brett[j,i] = new Pawn(false);
                            break;
                        case "k":
                            Brett[j,i] = new King(false);
                            break;
                        case "q":
                            Brett[j,i] = new Queen(false);
                            break;
                        case "r":
                            Brett[j,i] = new Rook(false);
                            break;
                        case "b":
                            Brett[j,i] = new Bishop(false);
                            break;
                        case "n":
                            Brett[j,i] = new Knight(false);
                            break;
                        // White pieces
                        case "P":
                            Brett[j,i] = new Pawn(true);
                            break;
                        case "K":
                            Brett[j,i] = new King(true);
                            break;
                        case "Q":
                            Brett[j,i] = new Queen(true);
                            break;
                        case "R":
                            Brett[j,i] = new Rook(true);
                            break;
                        case "B":
                            Brett[j,i] = new Bishop(true);
                            break;
                        case "N":
                            Brett[j,i] = new Knight(true);
                            break;
                        default:
                            Brett[j,i] = null;
                            break;
                    }
                }
            }
        }

        private string[,] ReadFile() {
            string temp;
            string[,] datatext = new string[8,8];
        
            FileStream fs = new FileStream("../../../init_defaultbrett.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            for (int i = 0; i < 8; i++) {
                temp = sr.ReadLine();
                for (int j = 0; j < 8; j++) {
                    datatext[j,i] = temp.Trim().Split(' ')[j];
                }
            }
            fs.Close();
            return datatext;
        }

        public int[] Input()
        {
            int[] rtn = new int[4];
            char[] input = new char[5];
            Regex CheckFormat = new Regex(@"^[a-h][1-8]x[a-h][1-8]");

            Console.WriteLine("Eingabe: ");
            for (int i = 0; i < 5; i++)
            {
                input[i] = Convert.ToChar(Console.Read());
            }
            
            
            if (CheckFormat.IsMatch(input)) 
            {
                switch (input[0]) 
                {
                    case 'a':
                        rtn[0] = 0; break;
                    case 'b':
                        rtn[0] = 1; break;
                    case 'c':
                        rtn[0] = 2; break;
                    case 'd':
                        rtn[0] = 3; break;
                    case 'e':
                        rtn[0] = 4; break;
                    case 'f':
                        rtn[0] = 5; break;
                    case 'g':
                        rtn[0] = 6; break;
                    case 'h':
                        rtn[0] = 7; break;   
                }

                rtn[1] = input[1] - '0' - 1;

                switch (input[3]) 
                {
                    case 'a':
                        rtn[2] = 0; break;
                    case 'b':
                        rtn[2] = 1; break;
                    case 'c':
                        rtn[2] = 2; break;
                    case 'd':
                        rtn[2] = 3; break;
                    case 'e':
                        rtn[2] = 4; break;
                    case 'f':
                        rtn[2] = 5; break;
                    case 'g':
                        rtn[2] = 6; break;
                    case 'h':
                        rtn[2] = 7; break;
                }

                rtn[3] = input[4] - '0' - 1;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe!");
                Console.ResetColor();
                Input();
            }
            return rtn;
        }

    }
}