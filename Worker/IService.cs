using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace LoadBalancer
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string CreateUrl(string s);

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string GetUrl(string s);

        [OperationContract]

        void RegisterWorker(string s);

    }
}
