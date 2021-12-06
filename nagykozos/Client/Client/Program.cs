using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using Client.ServiceReference1;

namespace Client
{
    class Program
    {
        public static ServiceReference1.Service1Client kliens;

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
        static void Main(string[] args)
        {
            kliens=new ServiceReference1.Service1Client();
            try
            {
                List<Felhasznalo> felhasznalok = new List<Felhasznalo>(kliens.FelhasznaloiLista());
                foreach (Felhasznalo egyFelhasznalo in felhasznalok)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5}", egyFelhasznalo.Id, egyFelhasznalo.BNev, egyFelhasznalo.Jelszo, egyFelhasznalo.FNev, egyFelhasznalo.Jog, egyFelhasznalo.Aktiv);
                }
            }
            catch(EndpointNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (FaultException<ServiceReference1.ServiceFault> e)
            {
                Console.WriteLine(e.Detail.Details);
            }
            catch (Exception e)
            {
                Console.WriteLine("Nem szerver ,nem adatbázis hiba");
                Console.WriteLine(e.Message);
            }
            Felhasznalo masikFelhasznalo = new Felhasznalo { Id = 2, BNev = "Józsi", Jelszo = "Kankalin", FNev = "Józsi bácsi", Jog = 4, Aktiv = 0 };
            Felhasznalo harmadikFelhasznalo = new Felhasznalo();
            harmadikFelhasznalo.Jelszo = "kfnsdlkfjsdnlkjg";
            Console.WriteLine(masikFelhasznalo.BNev);
            try
            {
                Console.WriteLine(kliens.Login("Robi", CreateMD5("Robi")));
            }
            catch (FaultException <ServiceReference1.ServiceFault> e)
            {
                Console.WriteLine(e.Detail.Details);
            }
            catch (Exception e)
            {
               // Console.WriteLine("");
            }
            Console.WriteLine(kliens.LoginAsync("Robi", CreateMD5("Robi")));
            System.Threading.Tasks.Task<string> loginAsync = kliens.LoginAsync("Robi", CreateMD5("Robi"));
            Console.WriteLine(loginAsync.Status);
            string asyncUid = loginAsync.Result;
            Console.WriteLine(loginAsync.Status);
            Console.WriteLine(asyncUid);
            Felhasznalo[] lista2;
            lista2 = kliens.FelhasznaloiLista();
            List<Felhasznalo> felhasznalok2 = new List<Felhasznalo>(kliens.FelhasznaloiLista());
            System.Threading.Tasks.Task<Felhasznalo[]> FlAsync = kliens.FelhasznaloiListaAsync();
            Felhasznalo[] ft=FlAsync.Result;
            Console.ReadKey();
        }
    }
}
