using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach {
    internal class Figur {
        public bool IsWhite {get; set;}
        public char Symbol {get; set;}
        public Figur(bool iswhite, char symbol) {
            IsWhite = iswhite;
            Symbol = symbol;
        }

        public bool IsColliding(int xpos, int ypos) {
            if (Brett[ypos, xpos] == null) {
                return true;
            }
            return false;
        }
        

    }
}
