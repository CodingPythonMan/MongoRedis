using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ServerService
    {
        public void Start()
        {
            OpenServerSession();
        }

        public void OpenServerSession()
        {
            // TcpListener 생성자에 붙는 매개변수는 
            // 첫번째는 IP를 두번째는 port 번호입니다.
            TcpListener server = new TcpListener(IPAddress.Any, 9483);

            // 서버를 시작합니다.
            server.Start();

            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("클라이언트가 접속하였습니다!");

            while (true)
            {
                if (client.Available > 0)
                {
                    byte[] byteData = new byte[1024];

                    client.GetStream().Read(byteData, 0, byteData.Length);
                    Console.WriteLine(Encoding.Default.GetString(byteData));
                }
                Task.Delay(1000).Wait();
            }
        }
    }
}
