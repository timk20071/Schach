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

        public bool Move(int currypos,int currxpos,int targetypos,int targetxpos,Figur[,]? Brett) {
            if (targetypos <= 7 && targetypos >= 0 && targetxpos <= 7 && targetxpos >= 0) { // Is position not out of range
                if (!( Brett[currxpos,currypos].CheckIfMoveCorrect(currxpos,currypos,targetxpos,targetypos) )) {
                    return false;
                }
                
                if (IsColliding(currypos,currxpos,Brett)) {
                    if(Brett[targetxpos,targetypos] != null) {
                        if (Brett[currxpos,currypos].IsWhite == Brett[targetxpos,targetypos].IsWhite){
                            return false;
                        }
                    }
                    Brett[targetxpos,targetypos] = Brett[currxpos,currypos];
                    Brett[currxpos,currypos] = null;

                    return true;
                }
                else {
                    Brett[targetxpos,targetypos] = Brett[currxpos,currypos];
                    Brett[currxpos,currypos] = null;

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