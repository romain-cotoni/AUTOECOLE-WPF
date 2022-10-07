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
    /// Logique d'interaction pour VehiculeListe.xaml
    /// </summary>
    public partial class VehiculeListe : Page
    {
        VehiculeLM vehiculeLM = new VehiculeLM();

        public VehiculeListe()
        {
            InitializeComponent();
            HashSet<Vehicule>? vehicules = vehiculeLM.findAllVehicules();
            listviewVehicules.ItemsSource = vehicules;
        }

        private void VehiculeAjouterClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VehiculeAjouter(null));
        }

        private void VehiculeFormClick(object sender, RoutedEventArgs e)
        {
            Vehicule vehicule = new Vehicule();
            vehicule.ImmatVcl = ((Vehicule)((Button)sender).DataContext).ImmatVcl;
            vehicule.ModelVcl = ((Vehicule)((Button)sender).DataContext).ModelVcl;
            vehicule.EtatVcl  = ((Vehicule)((Button)sender).DataContext).EtatVcl;
            this.NavigationService.Navigate(new VehiculeForm(vehicule));
        }
    }
}
