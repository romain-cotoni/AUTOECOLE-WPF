using AutoEcole.AccesDonnees;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.LogiqueMetier
{
    internal class CalendrierLM
    {
        CalendrierAD calendrierAD = new CalendrierAD();

        public bool checkIfDateExist(DateTime datetime)
        {
            try
            {
                return calendrierAD.checkIfDateExist(datetime);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction checkIfDateExist dans la classe CalendrierLM : " + except);
                return false;


            }
        }

        public void createDate(DateTime datetime)
        {
            try
            {
                calendrierAD.create(datetime);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction createDate dans la classe CalendrierLM : " + except);
            }
        }
    }
}
