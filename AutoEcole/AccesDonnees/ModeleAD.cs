using AutoEcole.LogiqueMetier;
using AutoEcole.Metier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.AccesDonnees
{
    internal class ModeleAD
    {
        Connexion connexion = new Connexion();
        SqlCommand? sqlCmd;
        SqlDataReader? reader;
        public HashSet<Modele> findAll()
        {
            HashSet<Modele> modeles = new HashSet<Modele>();
            Modele modele;
            sqlCmd = new SqlCommand("SELECT * FROM MODELE", connexion.openConnection());

            using (reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    modele = new Modele();
                    modele.ModelMdl     = reader.GetString(0);
                    modele.MarqueMdl    = reader.GetString(1);
                    modele.AnneMdl      = reader.GetString(2);
                    modele.DateAchatMdl = reader.GetDateTime(3);
                    modeles.Add(modele);
                }
            }
            connexion.closeConnection();

            return modeles;
        }

        public void create(Modele modele)
        {
            try
            {
                sqlCmd = new SqlCommand("INSERT INTO MODELE ([modèle véhicule],[marque],[année],[date achat]) " +
                                        "VALUES(@MDL,@MARQUE,@ANNEE,@ACHAT)", connexion.openConnection());

                sqlCmd.Parameters.Add("@MDL"   , SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@MARQUE", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@ANNEE" , SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@ACHAT" , SqlDbType.Date);

                sqlCmd.Parameters["@MDL"].Value    = modele.ModelMdl;
                sqlCmd.Parameters["@MARQUE"].Value = modele.MarqueMdl;
                sqlCmd.Parameters["@ANNEE"].Value  = modele.AnneMdl;
                sqlCmd.Parameters["@ACHAT"].Value  = modele.DateAchatMdl;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction create dans la classe ModeleAD : " + exception);
            }
        }

        public void delete(string mdl)
        {
            try
            {
                Modele modele = new Modele();
                sqlCmd = new SqlCommand("DELETE FROM MODELE WHERE [modèle véhicule]=@MDL", connexion.openConnection());
                sqlCmd.Parameters.Add("@MDL", SqlDbType.VarChar);
                sqlCmd.Parameters["@MDL"].Value = mdl;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction delete dans la classe ModeleAD : " + exception);
            }
        }

        public Modele update(Modele modele)
        {
            try
            {
                sqlCmd = new SqlCommand("UPDATE MODELE SET [marque]=@MARQUE,[année]=@ANNEE,[date achat]=@ACHAT WHERE [modèle véhicule]=@MDL", connexion.openConnection());

                sqlCmd.Parameters.Add("@MARQUE", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@ANNEE" , SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@ACHAT" , SqlDbType.Date);
                sqlCmd.Parameters.Add("@MDL"   , SqlDbType.VarChar);

                sqlCmd.Parameters["@MARQUE"].Value = modele.MarqueMdl;
                sqlCmd.Parameters["@ANNEE"].Value  = modele.AnneMdl;
                sqlCmd.Parameters["@ACHAT"].Value  = modele.DateAchatMdl;
                sqlCmd.Parameters["@MDL"].Value    = modele.ModelMdl;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();

                return modele;
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction update dans la classe ModeleAD : " + exception);
            }
        }

        public bool checkIfModelExist(string? mdl)
        {
            try
            {
                string? modele = null;
                sqlCmd = new SqlCommand("SELECT [modèle véhicule] FROM MODELE WHERE [modèle véhicule]=@MDL", connexion.openConnection());
                sqlCmd.Parameters.Add("@MDL", SqlDbType.VarChar);
                sqlCmd.Parameters["@MDL"].Value = mdl;
                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        modele = reader.GetString(0);
                    }
                    if (modele != null) return true;
                }
                connexion.closeConnection();

                return false;
            }
            catch(Exception except)
            {
                throw new Exception("Erreur avec la fonction checkIfDateExist dans la classe CalendrierAD : " + except);
            }
        }
    }
}
