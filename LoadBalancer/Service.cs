using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    public class Service : IService
    {
        private ushort currentWorkerIndex=0;
        private static List<IWorkerService> workerChannels = new List<IWorkerService>();
        //Round Robin / circullar distribution of workload is employed 

        public string CreateUrl(string s)
        {
            currentWorkerIndex = (ushort)((currentWorkerIndex + 1) % workerChannels.Count);
            return workerChannels[currentWorkerIndex].CreateUrl(s);
        }

        public string GetUrl(string s)
        {
           
                currentWorkerIndex = (ushort)((currentWorkerIndex + 1) % workerChannels.Count);
                return workerChannels[currentWorkerIndex].GetUrl(s);
         
        }

        // workers have to call this method on startup so that the load balancer registers them
        public void RegisterWorker(string s)
        {
            var cf = new ChannelFactory<IWorkerService>(new WebHttpBinding(), s);

            cf.Endpoint.Behaviors.Add(new WebHttpBehavior());
            workerChannels.Add(cf.CreateChannel());

        }
    }
}
