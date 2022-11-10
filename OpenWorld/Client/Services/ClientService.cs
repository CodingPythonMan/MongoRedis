using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ClientService
    {
        public void Start()
        {
            Console.WriteLine("I'm Client!");

            TcpClient client = new TcpClient();

            client.Connect("127.0.0.1", 9483);

            byte[] buffer = Encoding.Default.GetBytes("Hi! Server! I'm Client!");

            int i = 0;
            while (true)
            {
                if(i > 5)
                {
                    break;
                }
                i++;
                client.GetStream().Write(buffer, 0, buffer.Length);    
                Task.Delay(1000).Wait();
            }

            client.Close();
        }
    }
}
