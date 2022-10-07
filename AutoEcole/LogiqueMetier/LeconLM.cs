using AutoEcole.AccesDonnees;
using AutoEcole.Metier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoEcole.LogiqueMetier
{
    internal class LeconLM
    {
        LeconAD leconAD = new LeconAD();

        EleveLM eleveLM           = new EleveLM();
        MoniteurLM moniteurLM     = new MoniteurLM();
        ModeleLM modeleLM         = new ModeleLM();
        CalendrierLM calendrierLM = new CalendrierLM();

        public HashSet<Lecon>? findAllLecons()
        {
            try
            {
               return leconAD.findAll();                
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction findAllLecons dans la classe LeconLM : " + except);
                return null;
            }
        }

        public bool createLecon(Lecon lecon)
        {
            try
            {
                int idelv = -1;
                int idmnt = -1;
                idelv = eleveLM.findIdByName(lecon.PrenomElv, lecon.NomElv);
                idmnt = moniteurLM.findIdByName(lecon.PrenomMnt, lecon.NomMnt);
                if (idelv == -1) { MessageBox.Show("Cet élève n'existe pas dans la base de données");   return false; }
                if (idmnt == -1) { MessageBox.Show("Ce moniteur n'existe pas dans la base de données"); return false; }
                lecon.IdEleveLec    = idelv;
                lecon.IdMoniteurLec = idmnt;
                if(! modeleLM.checkIfModelExist(lecon.ModelLec)) { MessageBox.Show("Ce modèle n'existe pas dans la base de données"); return false; }
                if (!calendrierLM.checkIfDateExist(lecon.DateLec)) calendrierLM.createDate(lecon.DateLec);
                leconAD.create(lecon);
                return true;
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction createLecon dans la classe LeconLM : " + except);
                return false;
            }
        }

        public void deleteLecon(Lecon lecon)
        {
            try
            {
                leconAD.delete(lecon);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction deleteLecon dans la classe LeconLM : " + except);
            }
        }
        public void updateClient(Lecon lecon)
        {
            try
            {
                leconAD.update();
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction updateLecon dans la classe LeconLM : " + except);
            }
        }

        public HashSet<Lecon>? rechercherLecon(string text)
        {
            try
            {
                HashSet<Lecon>? lecons = null;
                DateTime datetimeResult;
                DateTime.TryParse(text, out datetimeResult);
                lecons = leconAD.rechercherDate(datetimeResult);
                if (lecons != null) return lecons;
                else lecons = leconAD.rechercherEleveOrMoniteur(text);
                if (lecons != null) return lecons;
                else return null;

            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction rechercherLecon dans la classe LeconLM : " + except);
                return null;
            }
        }
    }
}
