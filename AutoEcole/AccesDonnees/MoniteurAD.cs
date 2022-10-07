using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using AutoEcole.Metier;
using AutoEcole.LogiqueMetier;

namespace AutoEcole.AccesDonnees
{
    internal class MoniteurAD
    {
        Connexion connexion = new Connexion();
        SqlCommand? sqlCmd;
        SqlDataReader? reader;

        public HashSet<Moniteur> findAll()
        {
            HashSet<Moniteur> moniteurs = new HashSet<Moniteur>();
            Moniteur moniteur;
            sqlCmd = new SqlCommand("SELECT * FROM MONITEUR", connexion.openConnection());

            using (reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    moniteur = new Moniteur();
                    moniteur.IdMnt = reader.GetInt32(0);
                    moniteur.NomMnt = reader.GetString(1);
                    moniteur.PrenomMnt = reader.GetString(2);
                    moniteur.NaissanceMnt = reader.GetDateTime(3);
                    moniteur.EmbaucheMnt = reader.GetDateTime(4);
                    moniteur.ActiviteMnt = reader.GetBoolean(5);
                    moniteurs.Add(moniteur);
                }
            }
            connexion.closeConnection();

            return moniteurs;
        }

        public int findByName(string? prenomMnt, string? nomMnt)
        {
            int idMoniteur = -1;
            sqlCmd = new SqlCommand("SELECT [id moniteur] FROM MONITEUR " +
                                    "WHERE [prénom moniteur]=@PRENOM AND [nom moniteur]=@NOM", connexion.openConnection());
            sqlCmd.Parameters.Add("@PRENOM", SqlDbType.VarChar);
            sqlCmd.Parameters.Add("@NOM", SqlDbType.VarChar);
            sqlCmd.Parameters["@PRENOM"].Value = prenomMnt;
            sqlCmd.Parameters["@NOM"].Value = nomMnt;

            try
            {
                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idMoniteur = reader.GetInt32(0);
                    }
                    connexion.closeConnection();

                    return idMoniteur;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction findById dans la classe EleveAD : " + exception);
            }
        }

        public void create(Moniteur moniteur)
        {
            try
            {
                sqlCmd = new SqlCommand("INSERT INTO MONITEUR ([id moniteur], [nom moniteur], [prénom moniteur], [date naissance], [date embauche], [activité]) " +
                                        "VALUES(@ID,@NOM,@PRENOM,@NAISSANCE,@EMBAUCHE,@ACTIVITE)", connexion.openConnection());

                sqlCmd.Parameters.Add("@ID", SqlDbType.Int);
                sqlCmd.Parameters.Add("@NOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@PRENOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@NAISSANCE", SqlDbType.Date);
                sqlCmd.Parameters.Add("@EMBAUCHE", SqlDbType.Date);
                sqlCmd.Parameters.Add("@ACTIVITE", SqlDbType.Bit);

                sqlCmd.Parameters["@ID"].Value = moniteur.IdMnt;
                sqlCmd.Parameters["@NOM"].Value = moniteur.NomMnt;
                sqlCmd.Parameters["@PRENOM"].Value = moniteur.PrenomMnt;
                sqlCmd.Parameters["@NAISSANCE"].Value = moniteur.NaissanceMnt;
                sqlCmd.Parameters["@EMBAUCHE"].Value = moniteur.EmbaucheMnt;
                sqlCmd.Parameters["@ACTIVITE"].Value = moniteur.ActiviteMnt;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction create dans la classe MoniteurAD : " + exception);
            }
        }

        public void delete(int id)
        {
            try
            {
                Moniteur moniteur = new Moniteur();
                sqlCmd = new SqlCommand("DELETE FROM MONITEUR WHERE [id moniteur]=@ID", connexion.openConnection());
                sqlCmd.Parameters.Add("@ID", SqlDbType.Int);
                sqlCmd.Parameters["@ID"].Value = id;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction delete dans la classe MoniteurAD : " + exception);
            }
        }

        public Moniteur update(Moniteur moniteur)
        {
            try
            {
                sqlCmd = new SqlCommand("UPDATE MONITEUR SET [nom moniteur]=@NOM, [prénom moniteur]=@PRENOM, [date naissance]=@NAISSANCE, [date embauche]=@EMBAUCHE, [activité]=@ACTIVITE WHERE [id moniteur]=@ID", connexion.openConnection());

                sqlCmd.Parameters.Add("@ID", SqlDbType.Int);
                sqlCmd.Parameters.Add("@NOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@PRENOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@NAISSANCE", SqlDbType.Date);
                sqlCmd.Parameters.Add("@EMBAUCHE", SqlDbType.Date);
                sqlCmd.Parameters.Add("@ACTIVITE", SqlDbType.Bit);

                sqlCmd.Parameters["@ID"].Value = moniteur.IdMnt;
                sqlCmd.Parameters["@NOM"].Value = moniteur.NomMnt;
                sqlCmd.Parameters["@PRENOM"].Value = moniteur.PrenomMnt;
                sqlCmd.Parameters["@NAISSANCE"].Value = moniteur.NaissanceMnt;
                sqlCmd.Parameters["@EMBAUCHE"].Value = moniteur.EmbaucheMnt;
                sqlCmd.Parameters["@ACTIVITE"].Value = moniteur.ActiviteMnt;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();

                return moniteur;
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction update dans la classe MoniteurAD : " + exception);
            }
        }

        public int getNextId()
        {
            int lastId = 0;
            try
            {                 
                sqlCmd = new SqlCommand("SELECT MAX([id moniteur]) FROM MONITEUR", connexion.openConnection());
                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            lastId = reader.GetInt32(0) + 1;//ajouter 1 au dernier id                            
                        }
                    }
                    connexion.closeConnection();
                    return lastId;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction getNextId dans la classe MoniteurAD : " + exception);
            }
        }
    }
}
