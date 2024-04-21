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
        
        public bool Move(int startxpos, int startypos, int destxpos, int destypos) {
            // MoveValid()
            if(IsColliding(startxpos, startypos)) {
                if (Brett[startypos, startxpos].IsWhite != Brett[destypos,destxpos].IsWhite) {
                    Brett[destypos,destxpos] = Brett[startypos,startxpos];
                    Brett[startypos,startxpos] = null;
                    return true;
                }
            }
            else {
                Brett[destypos,destxpos] = Brett[startypos,startxpos];
                Brett[startypos,startxpos] = null;
                return true;
            }
            return false;
        }
        
        public bool IsColliding(int xpos, int ypos) {
            if (Brett[ypos, xpos] == null) {
                return false;
            }
            return true;
        }

    }
}