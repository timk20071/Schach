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
        public Figur[,] Brett = new Figur[8, 8]; //[xpos,ypos]
        
        public Spielbrett() {
            Reset();
        }

        public void Print() {
            
            for (int i = 7; i >= 0; i--) {
                Console.Write("\n ---------------------------------\n" + (i + 1) +"| ");          
                for (int j = 0; j < 8; j++)
                {
                    if (Brett[j, i] != null)
                        Console.Write(Brett[j, i].Symbol + " | ");
                    else
                        Console.Write("  | ");
                }
                
            }
            Console.Write("\n ---------------------------------");
            Console.WriteLine("\n   A   B   C   D   E   F   G   H  ");
        }
        /*     White | Black
         * Pawn:   P | p
         * King:   K | k
         * Queen:  Q | q
         * Rook:   R | r
         * Bishop: B | b
         * Knight: N | n 
         * Empty:    e
          
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
                    switch (data[i,j]) {
                        // Black pieces
                        case "p":
                            Brett[i,j] = new Pawn(false);
                            break;
                        case "k":
                            Brett[i,j] = new King(false);
                            break;
                        case "q":
                            Brett[i, j] = new Queen(false);
                            break;
                        case "r":
                            Brett[i, j] = new Rook(false);
                            break;
                        case "b":
                            Brett[i, j] = new Bishop(false);
                            break;
                        case "n":
                            Brett[i, j] = new Knight(false);
                            break;
                        // White pieces
                        case "P":
                            Brett[i, j] = new Pawn(true);
                            break;
                        case "K":
                            Brett[i, j] = new King(true);
                            break;
                        case "Q":
                            Brett[i, j] = new Queen(true);
                            break;
                        case "R":
                            Brett[i, j] = new Rook(true);
                            break;
                        case "B":
                            Brett[i, j] = new Bishop(true);
                            break;
                        case "N":
                            Brett[i, j] = new Knight(true);
                            break;
                        case "e":
                            Brett[i, j] = null;
                            break;
                        default:
                            Brett[i, j] = null;
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
            int i = 0;
            int[] rtn = new int[4];
            char[] input = new char[5];
            Regex CheckFormat = new Regex(@"^[a-hA-H][1-8]x[a-hA-H][1-8]");

            Console.WriteLine("Eingabe: ");
            string inputString = Console.ReadLine();


            if (CheckFormat.IsMatch(inputString)) 
            {
                foreach (char c in inputString)
                {
                    input[i] = c;
                    i++;
                }

                switch (input[0]) //converts the coordinates to int numbers
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

                switch (input[3]) //converts the coordinates to int numbers
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


        public void WinRecognition(Spielbrett spielbrett)
        {
            char[,] possibleMoves = new char[8,8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    possibleMoves[x, y] = 'o';
                }
            }


            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    if (Brett[x, y] != null)
                    {
                        Brett[x, y].CheckAllPossibleMoves(possibleMoves, x, y, spielbrett);
                    }
                    
                }
            }
        }
    }
}