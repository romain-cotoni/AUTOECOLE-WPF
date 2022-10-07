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
    /// Logique d'interaction pour EleveListe.xaml
    /// </summary>
    public partial class EleveListe : Page
    {
        EleveLM eleveLM = new EleveLM();
        public EleveListe()
        {
            InitializeComponent();
            HashSet<Eleve>? eleves = eleveLM.findAllEleves();
            listviewClients.ItemsSource = eleves;
        }

        private void EleveAjouterClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EleveAjouter(null));
        }

        private void EleveFormClick(object sender, RoutedEventArgs e)
        {
            Eleve eleve = new Eleve();
            eleve.IdElv = ((Eleve)((Button)sender).DataContext).IdElv;
            eleve.PrenomElv = ((Eleve)((Button)sender).DataContext).PrenomElv;
            eleve.NomElv = ((Eleve)((Button)sender).DataContext).NomElv;
            eleve.NaissanceElv = ((Eleve)((Button)sender).DataContext).NaissanceElv;
            eleve.CodeElv = ((Eleve)((Button)sender).DataContext).CodeElv;
            eleve.ConduiteElv = ((Eleve)((Button)sender).DataContext).ConduiteElv;
            this.NavigationService.Navigate(new EleveForm(eleve));
        }

        private void EleveRechercherClick(object sender, RoutedEventArgs e)
        {
            HashSet<Eleve>? eleves = null;
            eleves = eleveLM.rechercherEleve(Rechercher.Text);
            if (eleves?.Count>=1) listviewClients.ItemsSource = eleves;
            else listviewClients.ItemsSource = eleveLM.findAllEleves();
        }
    }
}
