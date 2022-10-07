using AutoEcole.LogiqueMetier;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.AccesDonnees
{
    internal class VehiculeAD
    {
        Connexion connexion = new Connexion();
        SqlCommand? sqlCmd;
        SqlDataReader? reader;

        public HashSet<Vehicule> findAll()
        {
            HashSet<Vehicule> vehicules = new HashSet<Vehicule>();
            Vehicule vehicule;
            sqlCmd = new SqlCommand("SELECT * FROM VEHICULE", connexion.openConnection());

            using (reader = sqlCmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    vehicule = new Vehicule();
                    vehicule.ImmatVcl = reader.GetString(0);
                    vehicule.ModelVcl = reader.GetString(1);
                    vehicule.EtatVcl  = reader.GetBoolean(2);
                    vehicules.Add(vehicule);
                }
            }
            connexion.closeConnection();

            return vehicules;
        }

        public void create(Vehicule vehicule)
        {
            try
            {
                sqlCmd = new SqlCommand("INSERT INTO VEHICULE ([n°immatriculation],[modèle véhicule],[état]) " +
                                        "VALUES(@IMMAT,@MDL,@ETAT)", connexion.openConnection());

                sqlCmd.Parameters.Add("@IMMAT", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@MDL"  , SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@ETAT" , SqlDbType.Bit);

                sqlCmd.Parameters["@IMMAT"].Value = vehicule.ImmatVcl;
                sqlCmd.Parameters["@MDL"].Value   = vehicule.ModelVcl;
                sqlCmd.Parameters["@ETAT"].Value  = vehicule.EtatVcl;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction create dans la classe VehiculeAD : " + exception);
            }
        }

        public void delete(string immat)
        {
            try
            {
                Eleve eleve = new Eleve();
                sqlCmd = new SqlCommand("DELETE FROM VEHICULE WHERE [n°immatriculation]=@IMMAT", connexion.openConnection());
                sqlCmd.Parameters.Add("@IMMAT", SqlDbType.VarChar);
                sqlCmd.Parameters["@IMMAT"].Value = immat;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction delete dans la classe VehiculeAD : " + exception);
            }
        }

        public void update(Vehicule vehicule)
        {
            try
            {
                sqlCmd = new SqlCommand("UPDATE VEHICULE SET [modèle véhicule]=@MDL, [état]=@ETAT WHERE [n°immatriculation]=@IMMAT", connexion.openConnection());
                
                sqlCmd.Parameters.Add("@MDL", SqlDbType.VarChar);
                sqlCmd.Parameters.Add("@ETAT", SqlDbType.Bit);
                sqlCmd.Parameters.Add("@IMMAT", SqlDbType.VarChar);

                sqlCmd.Parameters["@MDL"].Value = vehicule.ModelVcl;
                sqlCmd.Parameters["@ETAT"].Value = vehicule.EtatVcl;
                sqlCmd.Parameters["@IMMAT"].Value = vehicule.ImmatVcl;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction update dans la classe VehiculeAD : " + exception);
            }
        }
    }
}
