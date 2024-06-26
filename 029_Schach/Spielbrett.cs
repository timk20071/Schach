using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using _029_Schach.Figuren;

namespace _029_Schach {
    internal class Spielbrett {
        public Figur[,] Brett = new Figur[8, 8]; //[xpos,ypos]
        
        public Spielbrett(bool loadpreviousgame) {
            Reset(loadpreviousgame);
        }

        public byte[] PrintWhite() {
            string str = "";
            
            for (int i = 7; i >= 0; i--) {

                str += $"{Environment.NewLine}  ---------------------------------{Environment.NewLine}{i+1} | ";
                for (int j = 0; j < 8; j++) {
                    if (Brett[j,i] != null) {
                        str += (Brett[j, i].Symbol + " | ");
                    }    
                    else {
                        str += "  | ";
                    }
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
                    {
                        str += (Brett[j, i].Symbol + " | ");
                    }
                    else
                    {
                        str += "  | ";
                    }                       
                }
            }
            str += $"{Environment.NewLine}  ---------------------------------{Environment.NewLine}";
            str += $"{Environment.NewLine}    A   B   C   D   E   F   G   H{Environment.NewLine}";
            return Encoding.UTF8.GetBytes(str);                
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
        private void Reset(bool loadpreviousgame) {
            string[,] data = StartGame(loadpreviousgame);
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

        private string[,] StartGame(bool loadpreviousgame) {
            string temp;
            string[,] datatext = new string[8,8];
            string path = "../../../init_defaultbrett.txt";
            if(loadpreviousgame) path = "../../../savegame.txt";
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            for (int i = 7; i >= 0; i--) {
                temp = sr.ReadLine();
                for (int j = 0; j < 8; j++) {
                    datatext[j,i] = temp.Trim().Split(' ')[j];
                }
            }
            fs.Close();
            return datatext;
        }
        public void Save() {
            FileStream fs = new FileStream("../../../savegame.txt",FileMode.Open,FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);

            for (int i = 7; i >= 0; i--) {
                for (int j = 0; j < 8; j++) {
                    if (Brett[j,i] == null)
                        sr.Write("e ");
                    else
                        sr.Write($"{Convert.ToChar(Brett[j,i].Savecharacter)} ");
                }
                sr.WriteLine();
            }
            sr.Close();
            fs.Close();
        }

        public int[] Input_MoveConsole(bool turnforwhite) {
            char[] input = new char[5];
            Console.WriteLine("Eingabe: ");
            string strinput = Console.ReadLine();
            for (int i = 0; i < 5; i++) {
                input[i] = strinput[i];
            }
            return ConvertInput(input, true, null, turnforwhite); // null and true = placeholder f�r tcp version
        }

        public int[] Input_MoveServer(bool turnforwhite, NetworkStream client) {
            byte[] inputbuffer = new byte[100];
            char[] input = new char[5];
            int inputproblem = 0;
            client.Write(Encoding.UTF8.GetBytes("Dein Zug (startpos+x+zielpos):"));

            client.Read(inputbuffer, 0, 100);
            if (inputbuffer[0] == 13) client.Read(inputbuffer,0,100);
            while (inputbuffer[inputproblem] == '\r') {
                inputproblem += 2;
            }
           
            for (int i = 0; i < 5; i++) {
                input[i] = (char)inputbuffer[i + inputproblem];
            }
            return ConvertInput(input, false, client, turnforwhite);
        }

        private int[] ConvertInput(char[] input, bool fromconsole, NetworkStream? client, bool turnforwhite) {
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
            
            if((!CheckFormat.IsMatch(input) && fromconsole) || Brett[rtn[0],rtn[1]] == null) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Falsche Eingabe!");
                Console.ResetColor();
                Input_MoveConsole(turnforwhite);
            }
            else if ((!CheckFormat.IsMatch(input) && !fromconsole) || Brett[rtn[0],rtn[1]] == null) {
                client.Write(Encoding.UTF8.GetBytes("Falsche Eingabe!\n\r"));
                Input_MoveServer(turnforwhite, client);
            }

            if (Brett[rtn[0],rtn[1]].IsWhite != turnforwhite && fromconsole) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Du darfst nur deine eigenen Figuren bewegen!");
                Console.ResetColor();
                Input_MoveConsole(turnforwhite);
            }
            else if (Brett[rtn[0],rtn[1]].IsWhite != turnforwhite && !fromconsole) {
                client.Write(Encoding.UTF8.GetBytes("Du darfst nur deine eigenen Figuren bewegen!\n\r"));
                Input_MoveServer(turnforwhite,client);
            }
            return rtn;
        }
    }
}