using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach
{
    internal class Spielbrett {
        public Figur[,] Brett = new Figur[8,8];
        public void Print(Figur[,] Brett) {
            for (int i = 0; i < 8; i++) {
                Console.Write("\n---------------------------------\n| ");
                for (int j = 0; j < 8; j++) {
                    Console.Write(Brett[i, j].ToString() + " | ");
                }
            }
            Console.WriteLine("\n---------------------------------");
        }

        public void Reset(Figur[,] Brett) {
            Reset(Brett);
        }
    }
}