﻿using _029_Schach.Figuren;

namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {
          Console.OutputEncoding = System.Text.Encoding.UTF8;

            Spielbrett spielbrett = new Spielbrett();
            int[] inputData = new int[4]; 
            


            while (true) 
            {
                spielbrett.Print();
                inputData = spielbrett.Input();
                spielbrett.Brett[inputData[1], inputData[0]].Move(inputData[0], inputData[1], inputData[2], inputData[3], spielbrett.Brett[inputData[0], inputData[1]], spielbrett); ;
            }

        }

  
    }
}
           
/*
private string SymbolBlack { get; set; } = "\u265E";
private string SymbolWhite { get; set; } = "\u2658";


public Springer(bool iswhite,char symbol) : base(iswhite,symbol) {

}

public override string ToString() {
    if (base.IsWhite) {
        return SymbolWhite;
    }
    return SymbolBlack;
}

public bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
    if (IsColliding(targetxpos,targetypos)) {
        return false;
    }
    if (currxpos == currypos + 2) { }

}
    }
        private string SymbolBlack { get; set; } = "\u265E";
private string SymbolWhite { get; set; } = "\u2658";


public Springer(bool iswhite,char symbol) : base(iswhite,symbol) {

}

public override string ToString() {
    if (base.IsWhite) {
        return SymbolWhite;
    }
    return SymbolBlack;
}

public bool CheckIfMoveCorrect(int currxpos,int currypos,int targetxpos,int targetypos) {
    if (IsColliding(targetxpos,targetypos)) {
        return false;
    }
    if (currxpos == currypos + 2) { }

}
    }
*/
