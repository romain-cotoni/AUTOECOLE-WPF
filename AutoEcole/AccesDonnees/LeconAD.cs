using AutoEcole.LogiqueMetier;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoEcole.AccesDonnees
{
    internal class LeconAD
    {
        Connexion connexion = new Connexion();
        SqlCommand? sqlCmd;
        SqlDataReader? reader;

        public HashSet<Lecon> findAll()
        {
            HashSet<Lecon> lecons = new HashSet<Lecon>();
            Lecon lecon;
            sqlCmd = new SqlCommand("SELECT l.*,e.[prénom élève],e.[nom élève],mo.[prénom moniteur],mo.[nom moniteur] FROM LECON AS  l " +
                                    "INNER JOIN ELEVE      AS  e ON  e.[id élève]        = l.[id élève] " +
                                    "INNER JOIN MONITEUR   AS mo ON mo.[id moniteur]     = l.[id moniteur] "
                                    , connexion.openConnection());

            using (reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lecon = new Lecon();
                    lecon.ModelLec = reader.GetString(0);
                    lecon.DateLec = reader.GetDateTime(1);
                    lecon.IdEleveLec = reader.GetInt32(2);
                    lecon.IdMoniteurLec = reader.GetInt32(3);
                    lecon.DureeLec = reader.GetInt32(4);
                    lecon.PrenomElv = reader.GetString(5);
                    lecon.NomElv = reader.GetString(6);
                    lecon.PrenomMnt = reader.GetString(7);
                    lecon.NomMnt = reader.GetString(8);
                    lecons.Add(lecon);
                }
            }
            connexion.closeConnection();

            return lecons;
        }
        
        public void create(Lecon lecon)
        {
            try
            {
                sqlCmd = new SqlCommand("INSERT INTO LECON ([modèle véhicule], [date heure], [id élève], [id moniteur], [durée]) " +
                                        "VALUES(@MDL,@DH,@IDELV,@IDMNT,@DUREE)", connexion.openConnection());
             

                sqlCmd.Parameters.Add("@MDL", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@DH",  SqlDbType.Date);
                sqlCmd.Parameters.Add("@IDELV", SqlDbType.Int);
                sqlCmd.Parameters.Add("@IDMNT", SqlDbType.Int);
                sqlCmd.Parameters.Add("@DUREE", SqlDbType.Int);

                sqlCmd.Parameters["@MDL"].Value   = lecon.ModelLec;
                sqlCmd.Parameters["@DH"].Value    = lecon.DateLec;
                sqlCmd.Parameters["@IDELV"].Value = lecon.IdEleveLec;
                sqlCmd.Parameters["@IDMNT"].Value = lecon.IdMoniteurLec;
                sqlCmd.Parameters["@DUREE"].Value = lecon.DureeLec;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction create dans la classe EleveAD : " + exception);
            }
        }

        public void delete(Lecon lecon)
        {
            try
            {
                sqlCmd = new SqlCommand("DELETE FROM LECON " +
                                        "WHERE [modèle véhicule]=@MDL " +
                                        "AND   [date heure]=@DH " +
                                        "AND   [id élève]=@IDELV " +
                                        "AND   [id moniteur]=@IDMNT", connexion.openConnection());
                sqlCmd.Parameters.Add("@MDL", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@DH", SqlDbType.Date);
                sqlCmd.Parameters.Add("@IDELV", SqlDbType.Int);
                sqlCmd.Parameters.Add("@IDMNT", SqlDbType.Int);

                sqlCmd.Parameters["@MDL"].Value   = lecon.ModelLec;
                sqlCmd.Parameters["@DH"].Value    = lecon.DateLec;
                sqlCmd.Parameters["@IDELV"].Value = lecon.IdEleveLec;
                sqlCmd.Parameters["@IDMNT"].Value = lecon.IdMoniteurLec;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction delete dans la classe LeconAD : " + exception);
            }
        }

        public void update()
        {
            //TODO
            throw new NotImplementedException();
        }

        public HashSet<Lecon>? rechercherDate(DateTime datetime)
        {
            try
            {
                HashSet<Lecon> lecons = new HashSet<Lecon>();
                Lecon lecon;
                sqlCmd = new SqlCommand("SELECT l.*,e.[prénom élève],e.[nom élève],mo.[prénom moniteur],mo.[nom moniteur] FROM LECON AS  l " +                                        
                                        "INNER JOIN ELEVE    AS  e ON  e.[id élève]    = l.[id élève] "    +
                                        "INNER JOIN MONITEUR AS mo ON mo.[id moniteur] = l.[id moniteur] " +
                                        "WHERE l.[date heure] = @DT ", connexion.openConnection());

                sqlCmd.Parameters.Add("@DT", SqlDbType.DateTime);
                sqlCmd.Parameters["@DT"].Value = datetime;

                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lecon = new Lecon();
                        lecon.ModelLec = reader.GetString(0);
                        lecon.DateLec = reader.GetDateTime(1);
                        lecon.IdEleveLec = reader.GetInt32(2);
                        lecon.IdMoniteurLec = reader.GetInt32(3);
                        lecon.DureeLec = reader.GetInt32(4);
                        lecon.PrenomElv = reader.GetString(5);
                        lecon.NomElv = reader.GetString(6);
                        lecon.PrenomMnt = reader.GetString(7);
                        lecon.NomMnt = reader.GetString(8);
                        lecons.Add(lecon);
                    }
                }
                connexion.closeConnection();

                return lecons;
            }
            catch(Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction rechercherDate dans la classe LeconAD : " + except);
                return null;
            }
        }

        public HashSet<Lecon>? rechercherEleveOrMoniteur(string text)
        {
            try
            {
                HashSet<Lecon> lecons = new HashSet<Lecon>();
                Lecon lecon;
                sqlCmd = new SqlCommand("SELECT l.*,e.[prénom élève],e.[nom élève],mo.[prénom moniteur],mo.[nom moniteur] FROM LECON AS  l " +
                                        "INNER JOIN ELEVE    AS  e ON  e.[id élève]    = l.[id élève] " +
                                        "INNER JOIN MONITEUR AS mo ON mo.[id moniteur] = l.[id moniteur] " +
                                        "WHERE e.[nom élève] = @TEXT OR mo.[nom moniteur] = @TEXT", connexion.openConnection());

                sqlCmd.Parameters.Add("@TEXT", SqlDbType.VarChar);
                sqlCmd.Parameters["@TEXT"].Value = text;

                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lecon = new Lecon();
                        lecon.ModelLec = reader.GetString(0);
                        lecon.DateLec = reader.GetDateTime(1);
                        lecon.IdEleveLec = reader.GetInt32(2);
                        lecon.IdMoniteurLec = reader.GetInt32(3);
                        lecon.DureeLec = reader.GetInt32(4);
                        lecon.PrenomElv = reader.GetString(5);
                        lecon.NomElv = reader.GetString(6);
                        lecon.PrenomMnt = reader.GetString(7);
                        lecon.NomMnt = reader.GetString(8);
                        lecons.Add(lecon);
                    }
                }
                connexion.closeConnection();

                return lecons;
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction rechercherEleveOrMoniteur dans la classe LeconAD : " + except);
                return null;
            }
        }
    }
}
