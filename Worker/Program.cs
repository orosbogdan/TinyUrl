using LoadBalancer;
using StackExchange.Redis;
using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;


namespace Worker
{
  

    class Program
    {
        public static ConnectionMultiplexer redis;
        public static IDatabase db = redis.GetDatabase();
        //args[0] - loadbalancer address
        //args[1] - worker address
        static void Main(string[] args)
        {
            redis = ConnectionMultiplexer.Connect(args[3]);

            WebServiceHost host = new WebServiceHost(typeof(WorkerService), new Uri(args[1]));

            ServiceEndpoint ep = host.AddServiceEndpoint(typeof(IWorkerService), new WebHttpBinding(), "");
            host.Open();


            ChannelFactory<IService> cf = new ChannelFactory<IService>(new WebHttpBinding(), args[0]);
            
            cf.Endpoint.Behaviors.Add(new WebHttpBehavior());

            IService channel = cf.CreateChannel();
            channel.RegisterWorker(args[1]);
                    

            Console.ReadLine();
            
        }
    }
}
