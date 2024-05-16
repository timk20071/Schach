using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace _029_Schach {
    internal class TCP_Server {
        private TcpListener _tcplistener;
        private bool isFinished = false;
        bool turnforwhite = true;
        int counter = 0;
        Spielbrett spielbrett;
        TcpClient client_w;
        TcpClient client_b;
        NetworkStream stream_w;
        NetworkStream stream_b;

        byte[] buffer_w = new byte[1024]; // speichert Daten für client
        byte[] buffer_b = new byte[1024];


        public TCP_Server(bool loadpreviousgame) {
            StartServer("127.0.0.1", 1111);
            ConnectClients();
            StartOrLoadGame(loadpreviousgame);
            OutputGameState();
            
        }
        
        private void StartServer(string ip, int port) {
            _tcplistener = new TcpListener(IPAddress.Parse(ip), port); // Tcp Server
            _tcplistener.Start();
            Console.WriteLine($"Listening at {ip} on port {port}");
            
        }

        private void ConnectClients() {
            client_w = _tcplistener.AcceptTcpClient(); // Wartet so lange, bis weißer client auf server joint
            client_b = _tcplistener.AcceptTcpClient(); // Wartet so lange, bis schwarzer client auf server joint
            stream_w = client_w.GetStream();
            stream_b = client_b.GetStream();
        }

        private void StartOrLoadGame(bool loadpreviousgame) {
            if (loadpreviousgame) {
                // Wenn Spielstand vorhanden && eingabe mit welcher Spielstand gespielt werden sollte
            }
            else {
                spielbrett = new Spielbrett();
            }
        }

        public void OutputGameState() {
            stream_w.Write(spielbrett.PrintWhite());
            stream_b.Write(spielbrett.PrintBlack());
        }

        public void Move() {
            int[] input = new int[4];
            NetworkStream movingstream;
            NetworkStream notmovingstream;
            if (turnforwhite) {
                movingstream = stream_w;
                notmovingstream = stream_b;
            }
            else {
                movingstream = stream_b;
                notmovingstream = stream_w;
            }
            input = spielbrett.Input_MoveServer(turnforwhite, movingstream);

            turnforwhite = !turnforwhite;

            Console.WriteLine(spielbrett.Brett[0,0].Move(input[0],input[1],input[2],input[3], spielbrett.Brett));

            OutputGameState();
        }
    }
}

//Example code:
/*
NetworkStream TCPStream = client.GetStream(); // liest inputstream ein

while (TCPStream.Read(buffer, 0, buffer.Length) != 0) { // falls nichts geschrieben wurde, scheife auslassen
    string recievedmessage = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
    byte[] data = Encoding.UTF8.GetBytes("Connected");
    Console.Write(recievedmessage); // schreibt input aus
    buffer = new byte[buffer.Length];
    TCPStream.Write(data); // gibt connected zum client weiter, wenn er verbunde ist / eine Nachricht gesendet wird


}
*/