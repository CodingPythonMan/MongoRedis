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
            TcpClient[] client = new TcpClient[10];

            for (int i=0; i<10; i++)
            {
                Console.WriteLine("I'm {0} Client!", i);

                client[i] = new TcpClient();

                client[i].Connect("127.0.0.1", 9483);
            }

            byte[] buffer = Encoding.Default.GetBytes("Hi! Server! I'm Client!");

            int count = 0;
            while (true)
            {
                if(count > 5)
                {
                    break;
                }
                count++;
                client[count].GetStream().Write(buffer, 0, buffer.Length);    
                Task.Delay(1000).Wait();
            }

            for(int i=0; i<10; i++)
            {
                client[i].Close();
            }
        }
    }
}
