using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.ServiceModel;

namespace Server.DatabaseManagers
{
    public class UsersManager : BaseDatabaseManager, ISQL
    {

        public int UserID(string bNev, string jelszo)
        {
            int db = 0;
            int jog = 0;
            int aktiv = 0;
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM felhasznalok where bNev='" + bNev + "' and jelszo='" + jelszo + "'";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    db++;
                    jog = int.Parse(reader["jog"].ToString());
                    aktiv = int.Parse(reader["aktiv"].ToString());
                }
            }
            catch (Exception e)
            {
                /*ServiceFault serviceFault = new ServiceFault();
                serviceFault.Message = e.Message;
                serviceFault.Details = " Hiba történt az SQL adatbázishoz való csatlakozáskor.";
                throw new FaultException<ServiceFault>(serviceFault, e.ToString());*/
                return -3;
            }
            finally
            {
                connection.Close();
            }
            if (db == 0) return -1;//rossz vagy nem létező bejelenzkezési adatok
            if (db > 0 && aktiv == 1) return jog; /*jók az adatok*/ else return -2;//zárolt a felhasználó azaz inaktív
        }
        public List<Record> Select()
        {
            List<Record> records = new List<Record>();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM felhasznalok ORDER BY bNev";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Felhasznalo nextRecord = new Felhasznalo();
                    nextRecord.Id = int.Parse(reader["id"].ToString());
                    nextRecord.BNev = reader["bNev"].ToString();
                    nextRecord.Jelszo = reader["jelszo"].ToString();
                    nextRecord.FNev = reader["fNev"].ToString();
                    nextRecord.Jog = int.Parse(reader["jog"].ToString());
                    nextRecord.Aktiv = int.Parse(reader["aktiv"].ToString());
                    records.Add(nextRecord);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return records;
        }

        public int Insert(Record record)
        {
            throw new NotImplementedException();
        }

        public int Update(Record record)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}