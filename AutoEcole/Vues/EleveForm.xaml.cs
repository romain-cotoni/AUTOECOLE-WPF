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
    /// Logique d'interaction pour EleveForm.xaml
    /// </summary>
    public partial class EleveForm : Page
    {
        EleveLM eleveLM = new EleveLM();
        public EleveForm(Object? elv = null)
        {
            Eleve? eleve = null;
            if (elv != null) eleve = (Eleve)elv;
            InitializeComponent();
            this.DataContext = eleve;
        }

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            Eleve eleve = new Eleve();
            int id;
            int.TryParse(Id.Text, out id);
            eleveLM.deleteClient(id);
            this.NavigationService.Navigate(new EleveListe());
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Eleve eleve = new Eleve();
            int id;
            int.TryParse(Id.Text, out id);
            eleve.PrenomElv = Prenom.Text;
            eleve.NomElv = Nom.Text;
            DateTime dateResult;
            DateTime.TryParse(Naissance.Text, out dateResult);
            eleve.NaissanceElv = dateResult; //MessageBox.Show(eleve.NaissanceElv.ToString());
            if (CodeCheck.IsChecked == true) eleve.CodeElv = true;
            else eleve.CodeElv = false;
            if (ConduiteCheck.IsChecked == true) eleve.CodeElv = true;
            else eleve.ConduiteElv = false;
            eleveLM.updateClient(eleve);
            this.NavigationService.Navigate(new EleveListe());
        }
    }
}
