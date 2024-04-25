using _029_Schach.Figuren;

namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {
          Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine('\u265E');

            Spielbrett spielbrett = new Spielbrett();
            /*spielbrett.Print();

            Console.WriteLine(spielbrett.Brett[1,1].Move(1,1,3,1, spielbrett.Brett));

            spielbrett.Print();

            Console.ReadKey();*/
            foreach (int i in spielbrett.Input())
            {
                Console.WriteLine(i);
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
