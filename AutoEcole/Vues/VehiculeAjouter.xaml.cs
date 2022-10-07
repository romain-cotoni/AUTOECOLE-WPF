using AutoEcole.LogiqueMetier;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AutoEcole.Vues
{
    /// <summary>
    /// Logique d'interaction pour VehiculeAjouter.xaml
    /// </summary>
    public partial class VehiculeAjouter : Page
    {
        VehiculeLM vehiculeLM = new VehiculeLM();
        public VehiculeAjouter(Object? vcl = null)
        {
            Vehicule? vehicule = null;
            if (vcl != null) vehicule = (Vehicule)vcl;
            InitializeComponent();
            this.DataContext = vehicule;
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            Vehicule vehicule = new Vehicule();
            vehicule.ImmatVcl = Immatriculation.Text;
            vehicule.ModelVcl = Model.Text;
            if (EtatCheck.IsChecked == true) vehicule.EtatVcl = true;
            else vehicule.EtatVcl = false;
            vehiculeLM.createVehicule(vehicule);
            this.NavigationService.Navigate(new VehiculeListe());
        }
    }
}
