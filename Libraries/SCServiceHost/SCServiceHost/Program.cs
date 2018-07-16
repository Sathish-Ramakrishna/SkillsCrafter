using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using SkillsCrafter.SCService.Implementations;

namespace SkillsCrafter.SCServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(SCService.Implementations.SCService)))
            {
                host.Open();
                Console.WriteLine("SCServiceHost Started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
