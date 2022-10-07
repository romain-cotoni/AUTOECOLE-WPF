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
    internal class CalendrierAD
    {
        Connexion connexion = new Connexion();
        SqlCommand? sqlCmd;
        SqlDataReader? reader;


        public bool checkIfDateExist(DateTime datetime)
        {
            try
            {
                DateTime? dt = null;
                sqlCmd = new SqlCommand("SELECT * FROM CALENDRIER WHERE [date heure]=@DH", connexion.openConnection());                
                sqlCmd.Parameters.Add("@DH", SqlDbType.DateTime);
                sqlCmd.Parameters["@DH"].Value = datetime;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();

                using (reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt = reader.GetDateTime(0);
                    }
                    connexion.closeConnection();

                    if (dt != null) return true;
                    else return false;
                }
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction checkIfDateExist dans la classe CalendrierAD : " + exception);
            }
        }

        public void create(DateTime datetime)
        {
            try
            {
                sqlCmd = new SqlCommand("INSERT INTO CALENDRIER ([date heure]) VALUES(@DH)", connexion.openConnection());

                sqlCmd.Parameters.Add("@DH", SqlDbType.DateTime);

                sqlCmd.Parameters["@DH"].Value = datetime;
                sqlCmd.ExecuteNonQuery();
                connexion.closeConnection();
            }
            catch (Exception exception)
            {
                throw new Exception("Erreur avec la fonction create dans la classe CalendrierAD : " + exception);
            }
        }
    }
}
