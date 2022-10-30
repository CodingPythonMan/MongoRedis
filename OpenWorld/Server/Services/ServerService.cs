using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Services
{
    public class ServerService
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("I'm Server!");
                Task.Delay(1000).Wait();
            }
        }
    }
}
