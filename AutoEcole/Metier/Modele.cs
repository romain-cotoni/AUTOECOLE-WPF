using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.Metier
{
    public class Modele
    {
        private string? modelMdl;
        private string? marqueMdl;
        private string? anneeMdl;
        private DateTime dateAchatMdl;

        public Modele()
        {

        }

        public Modele(string modelMdl, string marqueMdl, string anneMdl, DateTime dateAchatMdl)
        {
            ModelMdl = modelMdl;
            MarqueMdl = marqueMdl;
            AnneMdl = anneMdl;
            DateAchatMdl = dateAchatMdl;
        }

        public string? ModelMdl { get { return modelMdl; } set { modelMdl = value; } }
        public string? MarqueMdl { get { return marqueMdl; } set { marqueMdl = value; } }
        public string? AnneMdl { get { return anneeMdl; } set { anneeMdl = value; } }
        public DateTime DateAchatMdl { get { return dateAchatMdl; } set { dateAchatMdl = value; } }
    }
}
