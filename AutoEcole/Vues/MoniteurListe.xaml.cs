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
    /// Logique d'interaction pour MoniteurListe.xaml
    /// </summary>
    public partial class MoniteurListe : Page
    {
        MoniteurLM moniteurLM = new MoniteurLM();
        public MoniteurListe()
        {
            InitializeComponent();
            HashSet<Moniteur>? moniteurs = moniteurLM.findAllMoniteurs();
            listviewMoniteurs.ItemsSource = moniteurs;
        }

        private void MoniteurAjouterClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MoniteurAjouter(null));
        }
        private void MoniteurFormClick(object sender, RoutedEventArgs e)
        {
            Moniteur moniteur = new Moniteur();
            moniteur.IdMnt        = ((Moniteur)((Button)sender).DataContext).IdMnt;
            moniteur.PrenomMnt    = ((Moniteur)((Button)sender).DataContext).PrenomMnt;
            moniteur.NomMnt       = ((Moniteur)((Button)sender).DataContext).NomMnt;
            moniteur.NaissanceMnt = ((Moniteur)((Button)sender).DataContext).NaissanceMnt;
            moniteur.EmbaucheMnt  = ((Moniteur)((Button)sender).DataContext).EmbaucheMnt;
            moniteur.ActiviteMnt  = ((Moniteur)((Button)sender).DataContext).ActiviteMnt;
            this.NavigationService.Navigate(new MoniteurForm(moniteur));
        }
    }
}
