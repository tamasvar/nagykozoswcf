using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Server
{
    public class Service1 : IService1
    {
        static Dictionary<string, string> bejelentkezettek = new Dictionary<string, string>();

        public string Logout(string uid)
        {
            lock (bejelentkezettek)
            {
                Console.WriteLine("{0} nevű felhasználó kijelentkezett", bejelentkezettek[uid]);
                bejelentkezettek.Remove(uid);
            }
            return "Kijelentkezve....";
        }
        public string Login(string bNev, string jelszo)
        {
            if (bejelentkezettek.ContainsValue(bNev))
            {
                Console.WriteLine("Ez a felhasználó már be van jelentkezve egy másik gépen.");
                string kulcs = null;
                foreach (var adat in bejelentkezettek)
                {
                    if (adat.Value == bNev)
                    {
                        kulcs = adat.Key;
                    }
                }
                if (kulcs != null)
                {
                    lock (bejelentkezettek)
                    {
                        bejelentkezettek.Remove(kulcs);
                    }
                }
                Console.WriteLine("Ez a felhasználó be volt jelentkezve egy másik gépen. :-)");
            }
            string uid = "";
            DatabaseManagers.UsersManager tblUserManager =
                new DatabaseManagers.UsersManager();
            int jog = tblUserManager.UserID(bNev, jelszo);
            switch (jog)
            {
                case -1:
                    {
                        uid = "Hibás név vagy jelszó!";
                        break;
                    }
                case -2:
                    {
                        uid = "A felhasználó nem aktív!";
                        break;
                    }
                case -3:
                    {
                        uid = "Hiba az SQL szerverhez történő csatlakozáskor.";
                        break;
                    }
                default:
                    Console.WriteLine("{0} felhasználó bejelentkezett. {1}", bNev, DateTime.Now.ToString());
                    uid = jog.ToString() + "-" + Guid.NewGuid().ToString();
                    lock (bejelentkezettek)
                    {
                        bejelentkezettek.Add(uid, bNev);
                    }
                    break;
            }
            return uid;
        }
        public List<Felhasznalo> FelhasznaloiLista(string uid)
        {
            Console.WriteLine("itt vok");
            List<Felhasznalo> felhasznalok = new List<Felhasznalo>();
            DatabaseManagers.ISQL tblUsersManager = new DatabaseManagers.UsersManager();
            List<Record> records = tblUsersManager.Select();
            foreach (Record egyRekord in records)
            {
                if (egyRekord is Felhasznalo)
                {
                    felhasznalok.Add(egyRekord as Felhasznalo);
                }
            }
            Console.WriteLine("ittt is wok");
            return felhasznalok;
        }
    }
}
