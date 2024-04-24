namespace _029_Schach {
    internal class Program {
        static void Main(string[] args) {

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