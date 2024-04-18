using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach
{
    internal class Spielbrett
    {
        Figur[][] Brett = new Figur[8][8];

        public void Print(Figur[][] Brett)
        {
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; i <= 8; j++)
                {
                    Console.WriteLine(Brett[i][j]);
                }
                Console.WriteLine("---------------------------------");
            }    
        }
    }
}
