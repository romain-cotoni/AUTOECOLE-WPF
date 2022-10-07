using AutoEcole.LogiqueMetier;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AutoEcole.AccesDonnees
{
    internal class EleveAD
    {
        Connexion connexion = new Connexion();
        SqlCommand? sqlCmd;
        SqlDataReader? reader;

        public HashSet<Eleve> findAll()
        {
            HashSet<Eleve> eleves = new HashSet<Eleve>();
            Eleve eleve;
            sqlCmd = new SqlCommand("SELECT * FROM ELEVE", connexion.openConnection());

            using (reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    eleve = new Eleve();
                    eleve.IdElv = reader.GetInt32(0);
                    eleve.NomElv = reader.GetString(1);
                    eleve.PrenomElv = reader.GetString(2);
                    eleve.CodeElv = reader.GetBoolean(3);
                    eleve.ConduiteElv = reader.GetBoolean(4);
                    eleve.NaissanceElv = reader.GetDateTime(5);
                    eleves.Add(eleve);
                }
            }
            connexion.closeConnection();

            return eleves;
        }

        public Eleve findById(int id)
        {
            Eleve eleve = new Eleve();

            sqlCmd = new SqlCommand("SELECT * FROM eleve WHERE [id élève]=@ID", connexion.openConnection());
            sqlCmd.Parameters.Add("@ID", SqlDbType.Int);
            sqlCmd.Parameters["@ID"].Value = id;

            try
            {
                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eleve.IdElv = reader.GetInt32(0);
                        eleve.NomElv = reader.GetString(1);
                        eleve.PrenomElv = reader.GetString(2);
                        eleve.CodeElv = reader.GetBoolean(3);
                        eleve.ConduiteElv = reader.GetBoolean(4);
                        eleve.NaissanceElv = reader.GetDateTime(5);
                    }
                    connexion.closeConnection();

                    return eleve;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction findById dans la classe EleveAD : " + exception);
            }
        }

        public void create(Eleve eleve)
        {
            try
            {
                sqlCmd = new SqlCommand("INSERT INTO ELEVE ([id élève], [nom élève], [prénom élève], [code], [conduite], [date naissance]) " +
                                        "VALUES(@ID,@NOM,@PRENOM,@CODE,@CONDUITE,@NAISSANCE)", connexion.openConnection());

                sqlCmd.Parameters.Add("@ID", SqlDbType.Int);
                sqlCmd.Parameters.Add("@NOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@PRENOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@CODE", SqlDbType.Bit);
                sqlCmd.Parameters.Add("@CONDUITE", SqlDbType.Bit);
                sqlCmd.Parameters.Add("@NAISSANCE", SqlDbType.Date);

                sqlCmd.Parameters["@ID"].Value = eleve.IdElv;
                sqlCmd.Parameters["@NOM"].Value = eleve.NomElv;
                sqlCmd.Parameters["@PRENOM"].Value = eleve.PrenomElv;
                sqlCmd.Parameters["@CODE"].Value = eleve.CodeElv;
                sqlCmd.Parameters["@CONDUITE"].Value = eleve.ConduiteElv;
                sqlCmd.Parameters["@NAISSANCE"].Value = eleve.NaissanceElv;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction create dans la classe EleveAD : " + exception);
            }
        }

        public Eleve update(Eleve eleve)
        {
            try
            {
                sqlCmd = new SqlCommand("UPDATE ELEVE SET [nom élève]=@NOM, [prénom élève]=@PRENOM, [code]=@CODE, [conduite]=@CONDUITE, [date naissance]=@NAISSANCE WHERE [id élève]=@ID", connexion.openConnection());

                sqlCmd.Parameters.Add("@ID", SqlDbType.Int);
                sqlCmd.Parameters.Add("@NOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@PRENOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@CODE", SqlDbType.Bit);
                sqlCmd.Parameters.Add("@CONDUITE", SqlDbType.Bit);
                sqlCmd.Parameters.Add("@NAISSANCE", SqlDbType.Date);

                sqlCmd.Parameters["@ID"].Value = eleve.IdElv;
                sqlCmd.Parameters["@NOM"].Value = eleve.NomElv;
                sqlCmd.Parameters["@PRENOM"].Value = eleve.PrenomElv;
                sqlCmd.Parameters["@CODE"].Value = eleve.CodeElv;
                sqlCmd.Parameters["@CONDUITE"].Value = eleve.ConduiteElv;
                sqlCmd.Parameters["@NAISSANCE"].Value = eleve.NaissanceElv;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();

                return eleve;
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction update dans la classe EleveAD : " + exception);
            }
        }
        public void delete(int id)
        {
            try
            {
                Eleve eleve = new Eleve();
                sqlCmd = new SqlCommand("DELETE FROM ELEVE WHERE [id élève]=@ID", connexion.openConnection());
                sqlCmd.Parameters.Add("@ID", SqlDbType.Int);
                sqlCmd.Parameters["@ID"].Value = id;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction delete dans la classe EleveAD : " + exception);
            }
        }


        public int getNextId()
        {
            int lastId = 0;
            try
            {   //IDENT_CURRENT()                    
                sqlCmd = new SqlCommand("SELECT MAX([id élève]) FROM ELEVE", connexion.openConnection());
                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            lastId = reader.GetInt32(0)+1;//ajouter 1 au dernier id                            
                        }
                    }
                    connexion.closeConnection();
                    return lastId;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction getNextId dans la classe EleveAD : " + exception);
            }
        }

        public int findByName(string? prenomElv, string? nomElv)
        {
            try
            {
                int idEleve = -1;
                sqlCmd = new SqlCommand("SELECT [id élève] FROM ELEVE " +
                                        "WHERE [prénom élève]=@PRENOM AND [nom élève]=@NOM", connexion.openConnection());
                sqlCmd.Parameters.Add("@PRENOM", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@NOM", SqlDbType.VarChar);
                sqlCmd.Parameters["@PRENOM"].Value = prenomElv;
                sqlCmd.Parameters["@NOM"].Value = nomElv;

                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        idEleve = reader.GetInt32(0);                        
                    }
                    connexion.closeConnection();

                    return idEleve;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction findById dans la classe EleveAD : " + exception);
            }
        }
        public HashSet<Eleve>? rechercher(string? nom)
        {
            try
            {
                HashSet<Eleve>? eleves = new HashSet<Eleve>();
                Eleve? eleve = null;
                sqlCmd = new SqlCommand("SELECT * FROM ELEVE WHERE [nom élève]=@NOM", connexion.openConnection());
                sqlCmd.Parameters.Add("@NOM", SqlDbType.VarChar);
                sqlCmd.Parameters["@NOM"].Value = nom;

                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        eleve = new Eleve();
                        eleve.IdElv        = reader.GetInt32(0);
                        eleve.NomElv       = reader.GetString(1);
                        eleve.PrenomElv    = reader.GetString(2);
                        eleve.CodeElv      = reader.GetBoolean(3);
                        eleve.ConduiteElv  = reader.GetBoolean(4);
                        eleve.NaissanceElv = reader.GetDateTime(5);
                        eleves.Add(eleve);
                    }
                }
                connexion.closeConnection();

                return eleves;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction rechercher dans la classe EleveAD : " + exception);
                return null;
            }
        }
    }
}
