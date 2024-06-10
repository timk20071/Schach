﻿using _029_Schach.Figuren;
using System;

namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {
            int i  = 0;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int breite = (Console.BufferWidth / 2) - 4;
            Console.SetCursorPosition(breite, 0);
            Console.WriteLine("________");
            Console.SetCursorPosition(breite,1);
            Console.WriteLine("|Schach|");
            Console.SetCursorPosition(breite,2);
            Console.WriteLine("");
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
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(spielbrett.PrintWhite()));
                    inputData = spielbrett.Input_MoveConsole();
                    spielbrett.Brett[inputData[0],inputData[1]].Console_Move(inputData[0],inputData[1],inputData[2],inputData[3],spielbrett, true);

                }
            }
            
        }
    }
}