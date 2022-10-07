using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.Metier
{
    public class Lecon
    {
        private string?  modelLec;
        private DateTime dateLec;
        private int?     idEleveLec;
        private int?     idMoniteurLec;
        private int?     dureeLec;
        private string?  prenomElv;
        private string?  nomElv;
        private string?  prenomMnt;
        private string?  nomMnt;

        public Lecon()
        {

        }

        public Lecon(string modelLec, DateTime dateLec, int idEleveLec, int idMoniteurLec, int dureeLec)
        {
            ModelLec = modelLec;
            DateLec = dateLec;
            IdEleveLec = idEleveLec;
            IdMoniteurLec = idMoniteurLec;
            DureeLec = dureeLec;
        }


        public string? ModelLec { get { return modelLec; } set { modelLec = value; } }
        public DateTime DateLec { get { return dateLec; } set { dateLec = value; } }
        public int? IdEleveLec { get { return idEleveLec; } set { idEleveLec = value; } }
        public string? NomElv { get { return nomElv; } set { nomElv = value; } }
        public string? PrenomElv { get { return prenomElv; } set { prenomElv = value; } }
        public int? IdMoniteurLec { get { return idMoniteurLec; } set { idMoniteurLec = value; } }
        public string? NomMnt { get { return nomMnt; } set { nomMnt = value; } }
        public string? PrenomMnt { get { return prenomMnt; } set { prenomMnt = value; } }
        public int? DureeLec { get { return dureeLec; } set { dureeLec = value; } }
    }
}
