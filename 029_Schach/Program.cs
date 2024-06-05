using _029_Schach.Figuren;
using System;

namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {
            int i  = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Modus:");
            if (Convert.ToInt32(Console.ReadLine()) == 1) {
                TCP_Server tcp_tcpserver = new TCP_Server(false);
                while (true) {
                    tcp_tcpserver.Move();
                }
            }
            else {
                Spielbrett spielbrett = new Spielbrett(false);
                int[] inputData = new int[4];
                // console move
                while (true) {
                    /*if (i % 2 == 0){  //changes the sides of the board
                        Console.WriteLine(System.Text.Encoding.UTF8.GetString(spielbrett.PrintWhite()));
                    }
                    else{
                        Console.WriteLine(System.Text.Encoding.UTF8.GetString(spielbrett.PrintBlack()));
                    }
                    i++;*/

                    //Console.WriteLine(System.Text.Encoding.UTF8.GetString(spielbrett.PrintWhite()));
                    //inputData = spielbrett.Input_MoveConsole();
                    //spielbrett.Brett[inputData[0],inputData[1]].Console_Move(inputData[0],inputData[1],inputData[2],inputData[3],spielbrett, true);
                    List<char[,]> moves = spielbrett.WinRecognition(spielbrett);


                    for (int x = 0; x < 8; x++)
                    {
                        Console.Write("\n---------------------------------\n| ");
                        for (int j = 0; j < 8; j++)
                        {

                            Console.Write(moves[0][x, j].ToString() + " | ");
                        }

                    }
                    Console.Write("\n\n---------------------------------\n");
                    for (int x = 0; x < 8; x++)
                    {
                        Console.Write("\n---------------------------------\n| ");
                        for (int j = 0; j < 8; j++)
                        {

                            Console.Write(moves[1][x, j].ToString() + " | ");
                        }

                    }
                    Console.Write("\n---------------------------------\n");
                    Console.ReadLine();
                }
            }
            
        }
    }
}

