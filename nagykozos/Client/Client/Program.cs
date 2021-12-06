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
            kliens =new ServiceReference1.Service1Client();
            string uid = null;
            try
            {
                uid = kliens.Login("admin", CreateMD5("admin"));
            }
            catch (FaultException<ServiceReference1.ServiceFault> e)
            {
                Console.WriteLine(e.Detail.Details);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
            }
            Felhasznalo masikFelhasznalo = new Felhasznalo { BNev = "Józsi", Jelszo = CreateMD5("Kankalin"), FNev = "Józsi bácsi", Jog = 4, Aktiv = 0 };
            try
            {
                Console.WriteLine(kliens.InsertUser(uid, masikFelhasznalo));
                //Console.WriteLine(kliens.DeleteUser(uid, "Józsi"));
            }
            
            catch (FaultException<ServiceReference1.ServiceFault> e)
            {
                Console.WriteLine(e.Detail.Details);
            }
            try
            {
                List<Felhasznalo> felhasznalok = new List<Felhasznalo>(kliens.FelhasznaloiLista(uid));
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
            catch(Exception e)
            {
                Console.WriteLine("Nem szerver, nem adatbázis hiba üzi jön ide!");
                Console.WriteLine(e.Message);
            }
            
            Felhasznalo harmadikFelhasznalo = new Felhasznalo();
            harmadikFelhasznalo.Jelszo = "kfnsdlkfjsdnlkjg";
            Console.WriteLine(masikFelhasznalo.BNev);
            
            Console.WriteLine(kliens.LoginAsync("admin", CreateMD5("admin")));
            System.Threading.Tasks.Task<string> loginAsync = kliens.LoginAsync("admin", CreateMD5("admin"));
            Console.WriteLine(loginAsync.Status);
            string asyncUid = loginAsync.Result;
            Console.WriteLine(loginAsync.Status);
            Console.WriteLine(asyncUid);
            Felhasznalo[] lista2;
            lista2 = kliens.FelhasznaloiLista(uid);
            List<Felhasznalo> felhasznalok2 = new List<Felhasznalo>(kliens.FelhasznaloiLista(uid));
            System.Threading.Tasks.Task<Felhasznalo[]> FlAsync = kliens.FelhasznaloiListaAsync(uid);
            Felhasznalo[] ft=FlAsync.Result;

            

            Console.ReadKey();
        }
    }
}
