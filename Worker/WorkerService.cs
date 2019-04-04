using System;
using System.Linq;
using Worker;

namespace LoadBalancer
{
    class WorkerService : IWorkerService
    {           
  
        public string CreateUrl(string s)
        {
          
            string shortUrl = null;
            string result = null;

            // pattern used in order to avoid overwrites from other workers
            do
            {
                shortUrl = new string(s.Base64Randomize().Take(6).ToArray());
                Program.db.StringSet(shortUrl, s, new TimeSpan(24, 0, 0));
                result = Program.db.StringGet(shortUrl);
            } while (result != s);

            return shortUrl;
        }

        public string GetUrl(string s)
        {
            
                string result = Program.db.StringGet(s);

                if (result == null)
                    throw new Exception("No matching found");
                else
                    return result;
            
           
        }
    }
}
