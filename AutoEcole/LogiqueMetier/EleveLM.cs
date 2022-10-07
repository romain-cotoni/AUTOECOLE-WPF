using AutoEcole.AccesDonnees;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AutoEcole.LogiqueMetier
{

    internal class EleveLM
    {
        EleveAD eleveAD = new EleveAD();
        public HashSet<Eleve>? findAllEleves()
        {
            try
            {
                return eleveAD.findAll();
            }
            catch(Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction findAllEleves dans la classe EleveLM : " + except);
                return null;
            }
        }

        public int findIdByName(string? prenom, string? nom)
        {
            try
            {
                return eleveAD.findByName(prenom, nom);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction findIdByName dans la classe EleveLM : " + except);
                return 0;
            }
        }

        public void createClient(Eleve eleve)
        {
            try
            {
                int id = eleveAD.getNextId();
                System.Diagnostics.Debug.WriteLine("getNextId: " + id);
                eleve.IdElv = id;
                eleveAD.create(eleve);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction createClient dans la classe EleveLM : " + except);
            }
        }

        public void deleteClient(int id)
        {
            try
            {
                eleveAD.delete(id);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction deleteClient dans la classe EleveLM : " + except);
            }
        }

        public void updateClient(Eleve eleve)
        {
            try
            {
                eleveAD.update(eleve);
            }
            catch(Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction updateClient dans la classe EleveLM : " + except);
            }
        }

        public HashSet<Eleve>? rechercherEleve(string nom)
        {
            try
            {
                HashSet<Eleve>? eleves = null;
                eleves = eleveAD.rechercher(nom);
                if (eleves != null) return eleves;
                else return null;
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction rechercherEleve dans la classe EleveLM : " + except);
                return null;
            }
        }
    }
}
