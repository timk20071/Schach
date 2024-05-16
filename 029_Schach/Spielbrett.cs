using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using _029_Schach.Figuren;

namespace _029_Schach
{
    internal class Spielbrett {
        public Figur[,] Brett = new Figur[8, 8]; //[xpos,ypos]
        
        public Spielbrett() {
            Reset();
        }

        public byte[] PrintWhite() {
            string str = "";
            
            for (int i = 7; i >= 0; i--) {


                str += $"{Environment.NewLine}  ---------------------------------{Environment.NewLine}{i+1} | ";
                for (int j = 0; j < 8; j++) {
                    if (Brett[j,i] != null)
                        str += (Brett[j,i].Symbol + " | ");
                    else
                        str += "  | ";
                }
            }
            str += $"{Environment.NewLine}  ---------------------------------{Environment.NewLine}";
            str += $"{Environment.NewLine}    A   B   C   D   E   F   G   H{Environment.NewLine}";
            return Encoding.UTF8.GetBytes(str);
        }

        public byte[] PrintBlack() {
            string str = "";

            for (int i = 0; i <= 7; i++) {


                str += $"{Environment.NewLine}  ---------------------------------{Environment.NewLine}{i + 1} | ";
                for (int j = 0; j < 8; j++) {
                    if (Brett[j,i] != null)
                        str += ( Brett[j,i].Symbol + " | " );
                    else
                        str += "  | ";
                }
            }
            str += $"{Environment.NewLine}  ---------------------------------{Environment.NewLine}";
            str += $"{Environment.NewLine}    A   B   C   D   E   F   G   H{Environment.NewLine}";
            return Encoding.UTF8.GetBytes(str);                
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

        public int[] Input_MoveConsole() {
            char[] input = new char[5];
            Console.WriteLine("Eingabe: ");
            for (int i = 0; i < 5; i++) {
                input[i] = Convert.ToChar(Console.Read());
            }
            return ConvertInput(input, true, null, true); // null and true = placeholder
        }

        public int[] Input_MoveServer(bool turnforwhite, NetworkStream client) {
            byte[] inputbuffer = new byte[5];
            char[] input = new char[5];
            client.Write(Encoding.UTF8.GetBytes("Dein Zug (startpos+x+zielpos):"));
            client.Read(inputbuffer,0,5);
            for (int i = 0; i < 5; i++) {
                input[i] = (char)inputbuffer[i];
            }
            return ConvertInput(input, false, client, turnforwhite);
        }

        public int[] ConvertInput(char[] input, bool fromconsole, NetworkStream? client, bool turnforwhite) {
            int[] rtn = new int[4];
            Regex CheckFormat = new Regex(@"^[a-h][1-8]x[a-h][1-8]");


            
            if (CheckFormat.IsMatch(input)) {
                switch (input[0]) {

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

                switch (input[3]) { //converts the coordinates to int numbers
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
            else if(!CheckFormat.IsMatch(input) && fromconsole) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe!");
                Console.ResetColor();
                Input_MoveConsole();
            }
            else if (!CheckFormat.IsMatch(input) && !fromconsole) {
                client.Write(Encoding.UTF8.GetBytes("Falsche Eingabe!\n"));
                Input_MoveServer(turnforwhite, client);
            }
            return rtn;
        }
    }
}