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

        public string UpdateUserWeb(string uid, int id, string bNev, string jelszo, string fNev, int jog, int aktiv)
        {

            return UpdateUser(uid, new Felhasznalo {Id=id, BNev=bNev,Jelszo=jelszo,FNev=fNev,Jog=jog,Aktiv=aktiv });
        }

        public string UpdateUser(string uid, Felhasznalo user)
        {
            if (bejelentkezettek.ContainsKey(uid) && uid[0] == '9')
            {
                DatabaseManagers.UsersManager tblUserManager = new DatabaseManagers.UsersManager();
                if (tblUserManager.Update(user) > 0)
                {
                    return "A felhasználó adatai sikeresen módosítva.";
                }
                else
                {
                    return "A felhasználó módosítása sikertelen.";
                }
            }
            else
            {
                return "Csak bejelentkezett és 9-es jogosultságú felhasználó módosíthat adatot.";
            }
        }

        public string DeleteUserId(string uid, int id)
        {
            if (bejelentkezettek.ContainsKey(uid) && uid[0] == '9')
            {
                DatabaseManagers.UsersManager tblUserManager = new DatabaseManagers.UsersManager();
                if(tblUserManager.Delete(id)> 0)
                {
                    return "A felhasználó sikeresen törölve.";
                }
                else
                {
                    return "A felhasználó törlése sikertelen.";
                }
            }
            else
            {
                return "Csak bejelentkezett és 9-es jogosultságú felhasználó törölhet adatot.";
            }
        }

        public string DeleteUser(string uid, string bNev)
        {
            if (bejelentkezettek.ContainsKey(uid) && uid[0] == '9')
            {
                DatabaseManagers.UsersManager tblUserManager = new DatabaseManagers.UsersManager();
                Felhasznalo user =  tblUserManager.FelhasznaloiAdatok(bNev);
                
                if (user.Id != null)
                {
                    return DeleteUserId(uid, (int)user.Id);
                }
                else
                {
                    return "A felhasználó törlése sikertelen. (nincs ilyen nevű felhasználó (bNev))";
                }
            }
            else
            {
                return "Csak bejelentkezett és 9-es jogosultságú felhasználó törölhet adatot.";
            }
        }

        public string InsertUserWeb(string uid, string bNev, string jelszo, string fNev, int jog, int aktiv)
        {
            return InsertUser(uid, new Felhasznalo(bNev, jelszo, fNev, jog, aktiv));
        }

        public string InsertUser(string uid, Felhasznalo user)
        {
            if(bejelentkezettek.ContainsKey(uid) && uid[0] == '9')
            {
                DatabaseManagers.UsersManager tblUserManager = new DatabaseManagers.UsersManager();
                if(tblUserManager.Insert(user)>0)
                {
                    return "A felhasnáló sikeresen felvéve az adatbázisba.";
                }
                else
                {
                    return "A felhasználó felvétele sikertelen. (már van ilyen nevű felhasználó (bNev))";
                }
            }
            else
            {
                return "Csak bejelentkezett és 9-es jogosultságú felhasználó vehet fel adatot.";
            }
        }

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
            List<Felhasznalo> felhasznalok = new List<Felhasznalo>();
            if(bejelentkezettek.ContainsKey(uid) && uid[0] == 9)
            {
                DatabaseManagers.ISQL tblUsersManager = new DatabaseManagers.UsersManager();
                List<Record> records = tblUsersManager.Select();
                foreach (Record egyRekord in records)
                {
                    if (egyRekord is Felhasznalo)
                    {
                        felhasznalok.Add(egyRekord as Felhasznalo);
                    }
                }
            }
            return felhasznalok;
        }
        
    }
}
