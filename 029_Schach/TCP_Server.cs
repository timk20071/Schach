using System;
using System.Net;
using System.Net.Sockets;
using System.Text;


namespace _029_Schach {
    internal class TCP_Server {
        private TcpListener _tcplistener;
        
        private TcpClient client_w;
        private TcpClient client_b;
        private NetworkStream stream_w;
        private NetworkStream stream_b;
        private bool turnforwhite = true;
        private Spielbrett spielbrett;

        public TCP_Server(bool loadpreviousgame) {
            StartServer("127.0.0.1", 1111);
            ConnectClients();
            spielbrett = new Spielbrett(loadpreviousgame);
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

        private void OutputGameState() {
            stream_w.Write(spielbrett.PrintWhite());
            stream_b.Write(spielbrett.PrintBlack());
        }

        public void Move() {
            int[] input = new int[4];
            NetworkStream movingstream;
            bool movevalid;

            if (turnforwhite) {
                movingstream = stream_w;
            }
            else {
                movingstream = stream_b;
            } 
            
            do {
                input = spielbrett.Input_MoveServer(turnforwhite, movingstream);
                movevalid = spielbrett.Brett[input[0],input[1]].Tcp_Move(input[0],input[1],input[2],input[3], spielbrett, movingstream);
                Console.WriteLine(movevalid); // Console log if the move is valdi
            } while (!movevalid);
            turnforwhite = !turnforwhite;

            OutputGameState();
            spielbrett.Save();
        }
    }
}