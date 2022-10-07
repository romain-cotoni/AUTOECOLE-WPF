using AutoEcole.AccesDonnees;
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
    /// Logique d'interaction pour LeconListe.xaml
    /// </summary>
    public partial class LeconListe : Page
    {
        LeconLM leconLM = new LeconLM();
        public LeconListe()
        {
            InitializeComponent();
            HashSet<Lecon>? lecons = leconLM.findAllLecons();

           listviewLecons.ItemsSource = lecons;
        }

        private void LeconAjouterClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new LeconAjouter(null));
        }

        private void LeconFormClick(object sender, RoutedEventArgs e)
        {
            Lecon lecon = new Lecon();
            lecon.IdEleveLec    = ((Lecon)((Button)sender).DataContext).IdEleveLec;
            lecon.IdMoniteurLec = ((Lecon)((Button)sender).DataContext).IdMoniteurLec;
            lecon.PrenomElv     = ((Lecon)((Button)sender).DataContext).PrenomElv;
            lecon.NomElv        = ((Lecon)((Button)sender).DataContext).NomElv;
            lecon.PrenomMnt     = ((Lecon)((Button)sender).DataContext).PrenomMnt;
            lecon.NomMnt        = ((Lecon)((Button)sender).DataContext).NomMnt;
            lecon.ModelLec      = ((Lecon)((Button)sender).DataContext).ModelLec;
            lecon.DateLec       = ((Lecon)((Button)sender).DataContext).DateLec;
            lecon.DureeLec      = ((Lecon)((Button)sender).DataContext).DureeLec;
            this.NavigationService.Navigate(new LeconForm(lecon));
        }

        private void LeconRechercherClick(object sender, RoutedEventArgs e)
        {
            HashSet<Lecon>? lecons = null;
            lecons = leconLM.rechercherLecon(Rechercher.Text);
            if(lecons != null) listviewLecons.ItemsSource = lecons;
            else listviewLecons.ItemsSource = leconLM.findAllLecons();
        }
    }
}
