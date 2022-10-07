using AutoEcole.AccesDonnees;
using AutoEcole.Metier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.LogiqueMetier
{
    internal class ModeleLM
    {
        ModeleAD modeleAD = new ModeleAD();

        public HashSet<Modele>? findAllModeles()
        {
            try
            {
                return modeleAD.findAll();
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction findAllModeles dans la classe ModeleLM : " + except);
                return null;
            }
        }

        public void createModele(Modele modele)
        {
            try
            {
                modeleAD.create(modele);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction createModele dans la classe ModeleLM : " + except);
            }
        }

        public void updateModele(Modele modele)
        {
            try
            {
                //TODO vérifier si le changement du champs model n'affecte pas des véhicules existant dans la table VEHICULE
                modeleAD.update(modele);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction updateModele dans la classe ModeleLM : " + except);
            }
        }
        public void deleteModele(string mdl)
        {
            try
            {
                //TODO vérifier si le delete du MODELE n'affecte pas des véhicules existant dans la table VEHICULE
                modeleAD.delete(mdl);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction deleteModele dans la classe ModeleLM : " + except);
            }
        }

        public bool checkIfModelExist(string? mdl)
        {
            try
            {
                return modeleAD.checkIfModelExist(mdl);
            }
            catch(Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction checkIfModelExist dans la classe ModeleLM : " + except);
                return false;
            }
        }
    }
}
