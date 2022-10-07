using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.Metier
{
    public class Moniteur
    {
        private int idMnt;
        private string? nomMnt;
        private string? prenomMnt;
        private DateTime naissanceMnt;
        private DateTime embaucheMnt;
        private bool activiteMnt;

        public Moniteur()
        {

        }

        public Moniteur(int idMnt, string? nomMnt, string? prenomMnt, DateTime naissanceMnt, DateTime embaucheMnt, bool activiteMnt)
        {
            IdMnt = idMnt;
            NomMnt = nomMnt;
            PrenomMnt = prenomMnt;
            NaissanceMnt = naissanceMnt;
            EmbaucheMnt = embaucheMnt;
            ActiviteMnt = activiteMnt;
        }

        public int IdMnt { get { return idMnt; } set { idMnt = value; } }
        public string? NomMnt { get { return nomMnt; } set { nomMnt = value; } }
        public string? PrenomMnt { get { return prenomMnt; } set { prenomMnt = value; } }
        public DateTime NaissanceMnt { get { return naissanceMnt; } set { naissanceMnt = value; } }
        public DateTime EmbaucheMnt { get { return embaucheMnt; } set { embaucheMnt = value; } }
        public bool ActiviteMnt { get { return activiteMnt; } set { activiteMnt = value; } }
    }
}
