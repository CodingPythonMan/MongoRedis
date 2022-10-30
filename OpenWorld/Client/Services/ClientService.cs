using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    public class ClientService
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("I'm Client!");
                Task.Delay(1000).Wait();
            }
        }
    }
}
