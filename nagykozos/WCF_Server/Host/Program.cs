using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:3000");
            BasicHttpBinding basicHttpBinding = new BasicHttpBinding();
            WebHttpBinding binding = new WebHttpBinding();
            using (ServiceHost host = new ServiceHost(
                typeof(Server.Service1), uri))
            {
                ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(Server.IService1), binding, "");
                endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
                ServiceEndpoint endpoint1 = host.AddServiceEndpoint(typeof(Server.IService1), basicHttpBinding, "soap");
                host.Open();
                Console.WriteLine("A szerver elindult.. {0}", DateTime.Now);
                Console.ReadKey();
                host.Close();
            }
        }
    }
}
