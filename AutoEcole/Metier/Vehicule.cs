using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.Metier
{
    public class Vehicule
    {
        //private int idVcl;
        private string? immatVcl;
        private bool etatVcl;
        private string? modelVcl;

        public Vehicule()
        {

        }

        public Vehicule(/*int idVcl,*/ string? immatVcl, string? modelVcl,bool etatVcl)
        {
            //IdVcl = idVcl;
            ImmatVcl = immatVcl;
            ModelVcl = modelVcl;
            EtatVcl = etatVcl;
        }

        //public int IdVcl { get { return idVcl; } set { idVcl = value; } }
        public string? ImmatVcl { get { return immatVcl; } set { immatVcl = value; } }
        public bool EtatVcl { get { return etatVcl; } set { etatVcl = value; } }
        public string? ModelVcl { get { return modelVcl; } set { modelVcl = value; } }
    }
}
