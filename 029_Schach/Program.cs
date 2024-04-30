using _029_Schach.Figuren;

namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {
          Console.OutputEncoding = System.Text.Encoding.UTF8;
            TCP_Server tcpserver = new TCP_Server();
            /*
            Spielbrett spielbrett = new Spielbrett();
            spielbrett.Print();

            Console.WriteLine(spielbrett.Brett[1,1].Move(1,2,3,2,spielbrett.Brett));
            spielbrett.Print();
            Console.WriteLine(spielbrett.Brett[1,1].Move(3,2,5,2,spielbrett.Brett));



            spielbrett.Print();

            Console.ReadKey();
            */
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
