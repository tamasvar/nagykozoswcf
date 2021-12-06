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
        public Felhasznalo FelhasznaloiAdatok(string bNev)
        {
            Felhasznalo user = new Felhasznalo();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"SELECT * FROM felhasznalok WHERE bNev='" + bNev + "'";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    user.Id = int.Parse(reader["id"].ToString());
                    user.BNev = bNev;
                    user.Jelszo = reader["jelszo"].ToString();
                    user.FNev = reader["fNev"].ToString();
                    user.Jog = int.Parse(reader["jog"].ToString());
                    user.Aktiv = int.Parse(reader["aktiv"].ToString());
                }
            }
            catch (Exception e)
            {
                ServiceFault serviceFault = new ServiceFault();
                serviceFault.Message = e.Message;
                serviceFault.Details = " Hiba történt az SQL adatbázishoz való csatlakozáskor.";
                throw new FaultException<ServiceFault>(serviceFault, e.ToString());
            }
            finally
            {
                connection.Close();
            }

            return user;
        }

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
            Felhasznalo user = record as Felhasznalo;
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"INSERT INTO felhasznalok (bNev,jelszo,fNev,jog,aktiv) VALUES (@bNev,@jelszo,@fNev,@jog,@aktiv);";
            command.Parameters.Add(new MySqlParameter("@bNev", MySqlDbType.VarChar)).Value = user.BNev;
            command.Parameters.Add(new MySqlParameter("@jelszo", MySqlDbType.VarChar)).Value = user.Jelszo;
            command.Parameters.Add(new MySqlParameter("@fNev", MySqlDbType.VarChar)).Value = user.FNev;
            command.Parameters.Add(new MySqlParameter("@jog", MySqlDbType.Int32)).Value = user.Jog;
            command.Parameters.Add(new MySqlParameter("@aktiv", MySqlDbType.Int32)).Value = user.Aktiv;
            int beszurtsorokSzama = 0;
            command.Connection = BaseDatabaseManager.connection;
            try
            {
                command.Connection.Open();
                try
                {
                    beszurtsorokSzama = command.ExecuteNonQuery();
                }
                catch
                {
                    
                }
            }
            catch(Exception e)
            {
                ServiceFault serviceFault = new ServiceFault();
                serviceFault.Message = e.Message;
                serviceFault.Details = "Hiba történt az SQL adatbázishoz való kapcsolódáskor.";
                throw new FaultException<ServiceFault>(serviceFault, e.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
            return beszurtsorokSzama;
        }

        public int Update(Record record)
        {
            Felhasznalo user = record as Felhasznalo;
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"UPDATE felhasznalok SET bNev=@bNev, jelszo=@jelszo, fNev=@fNev, jog=@jog, aktiv=@aktiv WHERE id=@id;";
            command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)).Value = user.Id;
            command.Parameters.Add(new MySqlParameter("@bNev", MySqlDbType.VarChar)).Value = user.BNev;
            command.Parameters.Add(new MySqlParameter("@jelszo", MySqlDbType.VarChar)).Value = user.Jelszo;
            command.Parameters.Add(new MySqlParameter("@fNev", MySqlDbType.VarChar)).Value = user.FNev;
            command.Parameters.Add(new MySqlParameter("@jog", MySqlDbType.Int32)).Value = user.Jog;
            command.Parameters.Add(new MySqlParameter("@aktiv", MySqlDbType.Int32)).Value = user.Aktiv;
            int modositottSorokSzama = 0;
            command.Connection = BaseDatabaseManager.connection;
            try
            {
                command.Connection.Open();
                try
                {
                    modositottSorokSzama = command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
            catch (Exception e)
            {
                ServiceFault serviceFault = new ServiceFault();
                serviceFault.Message = e.Message;
                serviceFault.Details = "Hiba történt az SQL adatbázishoz való kapcsolódáskor.";
                throw new FaultException<ServiceFault>(serviceFault, e.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
            return modositottSorokSzama;
        }

        public int Delete(int id)
        {
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = @"DELETE FROM felhasznalok WHERE id=@id ";
            command.Parameters.Add(new MySqlParameter("@id", MySqlDbType.Int32)).Value = id;
            int toroltsorokSzama = 0;
            command.Connection = BaseDatabaseManager.connection;
            try
            {
                command.Connection.Open();
                try
                {
                    toroltsorokSzama = command.ExecuteNonQuery();
                }
                catch
                {

                }
            }
            catch(Exception e)
            {
                ServiceFault serviceFault = new ServiceFault();
                serviceFault.Message = e.Message;
                serviceFault.Details = "Hiba történt az SQL adatbázishoz való kapcsolódáskor.";
                throw new FaultException<ServiceFault>(serviceFault, e.ToString());
            }
            finally
            {
                command.Connection.Close();
            }
            return toroltsorokSzama;
        }
    }
}