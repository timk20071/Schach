using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace _029_Schach {
    internal class TCP_Server {
        private TcpListener _tcplistener;
        private bool isFinished = false;
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
            StartGame(loadpreviousgame);
            
        }
        
        public void StartServer(string ip, int port) {
            _tcplistener = new TcpListener(IPAddress.Parse(ip), port); // Tcp Server
            _tcplistener.Start();
            Console.WriteLine($"Listening at {ip} on port {port}");
            
        }

        public void ConnectClients() {
            client_w = _tcplistener.AcceptTcpClient(); // Wartet so lange, bis weißer client auf server joint
            client_b = _tcplistener.AcceptTcpClient(); // Wartet so lange, bis schwarzer client auf server joint
        }

        public void StartGame(bool loadpreviousgame) {
            if (loadpreviousgame) {
                // Wenn Spielstand vorhanden && eingabe mit welcher Spielstand gespielt werden sollte
            }
            else {
                spielbrett = new Spielbrett();
            }
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