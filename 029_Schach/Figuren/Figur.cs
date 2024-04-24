using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _029_Schach.Figuren {
    internal class Figur {
        public bool IsWhite { get; set; }
        public char Symbol { get; set; }
        public Figur(bool iswhite,char symblowhite,char symbolblack) {
            IsWhite = iswhite;
            if (IsWhite) {
                Symbol = symblowhite;
            }
            else {
                Symbol = symbolblack;
            }
        }

        public bool Move(int currxpos,int currypos,int targetxpos,int targetypos,Figur[,] Brett) {
            if (targetxpos <= 7 && targetxpos > 0 && targetypos <= 7 && targetypos > 0) { // Is position not out of range
                Brett[currypos,currxpos].CheckIfMoveCorrect(currxpos,currypos,targetxpos,targetypos);
                if (IsColliding(currxpos,currypos,Brett)) {
                    if (Brett[currypos,currxpos].IsWhite != Brett[targetypos,targetxpos].IsWhite) {
                        Brett[targetypos,targetxpos] = Brett[currypos,currxpos];
                        Brett[currypos,currxpos] = null;
                        return true;
                    }
                }
                else {
                    Brett[targetypos,targetxpos] = Brett[currypos,currxpos];
                    Brett[currypos,currxpos] = null;
                    return true;
                }
            }

            return false;
        }

        public bool IsColliding(int xpos,int ypos,Figur[,] Brett) {
            if (Brett[ypos,xpos] == null) {
                return false;
            }
            return true;
        }

        public virtual bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
            return false;
        }
    }
}