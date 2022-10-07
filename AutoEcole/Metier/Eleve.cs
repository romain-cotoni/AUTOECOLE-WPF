using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoEcole.Metier
{
    public class Eleve
    {
        private int idElv;
        private string? nomElv;
        private string? prenomElv;
        private bool codeElv;
        private bool conduiteElv;
        private DateTime naissanceElv;

        public Eleve()
        {

        }

        public Eleve(int idElv, string? nomElv, string? prenomElv, bool codeElv, bool conduiteElv, DateTime naissanceElv)
        {
            IdElv = idElv;
            NomElv = nomElv;
            PrenomElv = prenomElv;
            CodeElv = codeElv;
            ConduiteElv = conduiteElv;
            NaissanceElv = naissanceElv;
        }

        
        public int IdElv { get { return idElv; } set { idElv = value; } }
        public string? NomElv { get { return nomElv; } set { nomElv = value; } }
        public string? PrenomElv { get { return prenomElv; } set { prenomElv = value; } }        
        public bool CodeElv { get { return codeElv; } set { codeElv = value; } }        
        public bool ConduiteElv { get { return conduiteElv; } set { conduiteElv = value; } }
        public DateTime NaissanceElv { get { return naissanceElv; } set { naissanceElv = value; } }
    }
}
