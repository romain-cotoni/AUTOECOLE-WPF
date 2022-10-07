using AutoEcole.AccesDonnees;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.LogiqueMetier
{
    internal class VehiculeLM
    {
        VehiculeAD vehiculeAD = new VehiculeAD();
        public HashSet<Vehicule>? findAllVehicules()
        {
            try
            {
                return vehiculeAD.findAll();
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction findAllVehicules dans la classe VehiculeLM : " + except);
                return null;
            }
        }

        public void createVehicule(Vehicule vehicule)
        {
            try
            {
                vehiculeAD.create(vehicule);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction createVehicule dans la classe VehiculeLM : " + except);
            }
        }

        public void deleteVehicule(string immat)
        {
            try
            {
                vehiculeAD.delete(immat);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction deleteVehicule dans la classe VehiculeLM : " + except);
            }
        }

        public void updateVehicule(Vehicule vehicule)
        {
            try
            {
                vehiculeAD.update(vehicule);
            }
            catch (Exception except)
            {
                System.Diagnostics.Debug.WriteLine("Erreur avec la fonction updateVehicule dans la classe VehiculeLM : " + except);
            }
        }
    }
}
