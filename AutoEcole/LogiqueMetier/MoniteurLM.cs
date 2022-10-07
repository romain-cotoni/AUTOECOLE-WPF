using AutoEcole.AccesDonnees;
using AutoEcole.Metier;
using AutoEcole.Vues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoEcole.LogiqueMetier
{
    internal class MoniteurLM
    {
        MoniteurAD moniteurAD     = new MoniteurAD();
        CalendrierLM calendrierLM = new CalendrierLM();
        public HashSet<Moniteur>? findAllMoniteurs()
        {
            try
            {
                return moniteurAD.findAll();
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction findAllMoniteurs dans la classe MoniteurLM : " + except);
                return null;
            }
        }

        public int findIdByName(string? prenom, string? nom)
        {
            try
            {
                return moniteurAD.findByName(prenom, nom);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction findIdByName dans la classe MoniteurLM : " + except);
                return 0;
            }
        }

        public void createMoniteur(Moniteur moniteur)
        {
            try
            {
                int id = moniteurAD.getNextId();
                moniteur.IdMnt = id;
                if(!calendrierLM.checkIfDateExist(moniteur.NaissanceMnt)) calendrierLM.createDate(moniteur.NaissanceMnt);
                if(!calendrierLM.checkIfDateExist(moniteur.EmbaucheMnt)) calendrierLM.createDate(moniteur.EmbaucheMnt);
                moniteurAD.create(moniteur);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction createMoniteur dans la classe MoniteurLM : " + except);
            }
        }

        public void deleteMoniteur(int id)
        {
            try
            {
                moniteurAD.delete(id);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction deleteMoniteur dans la classe MoniteurLM : " + except);
            }
        }

        public void updateMoniteur(Moniteur moniteur)
        {
            try
            {
                if (!calendrierLM.checkIfDateExist(moniteur.NaissanceMnt)) calendrierLM.createDate(moniteur.NaissanceMnt);
                if (!calendrierLM.checkIfDateExist(moniteur.EmbaucheMnt)) calendrierLM.createDate(moniteur.EmbaucheMnt);
                moniteurAD.update(moniteur);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction updateMoniteur dans la classe MoniteurLM : " + except);
            }
        }
    }
}
