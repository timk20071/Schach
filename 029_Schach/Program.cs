using _029_Schach.Figuren;

namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            if(Convert.ToInt32(Console.ReadLine()) == 1) {
                TCP_Server tcp_tcpserver = new TCP_Server(false);
                while (true) {
                    tcp_tcpserver.Move();
                }
            }
            else {
                Spielbrett spielbrett = new Spielbrett(false);
                int[] inputData = new int[4];
                // console move
                while (true) {
                    Console.WriteLine(System.Text.Encoding.UTF8.GetString(spielbrett.PrintWhite()));
                    inputData = spielbrett.Input_MoveConsole();
                    spielbrett.Brett[inputData[0],inputData[1]].Console_Move(inputData[0],inputData[1],inputData[2],inputData[3],spielbrett, true);
                }
            }
            
        }
    }
}
            /*
            
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
