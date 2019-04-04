using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LoadBalancer
{
    [ServiceContract]
    interface IWorkerService
    {
        [OperationContract]
        string CreateUrl(string s);

        [OperationContract]
        string GetUrl(string s);


    }
}
