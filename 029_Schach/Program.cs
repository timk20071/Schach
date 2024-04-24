namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {
          Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine('\u265E');

            Spielbrett Brett = new Spielbrett();
            Figur Spieler = new Figur(true, 'A');
            Figur[,] Bretter = new Figur[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Bretter[i, j] = Spieler;
                }
            }

            Brett.Print(Bretter);
            Console.ReadKey();
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
