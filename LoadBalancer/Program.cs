using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoadBalancer
{
    class Program
    {
   
        //args[0] -- self address
        static void Main(string[] args)
        {
           
            WebServiceHost host = new WebServiceHost(typeof(Service), new Uri(args[1]));

            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IService), new WebHttpBinding(), "");
            host.Open();
            Console.WriteLine("Open");
            Console.Read();
        }
    }
    
}
