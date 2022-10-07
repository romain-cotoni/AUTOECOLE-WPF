using AutoEcole.AccesDonnees;
using AutoEcole.LogiqueMetier;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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
    /// Logique d'interaction pour LeconAjouter.xaml
    /// </summary>
    public partial class LeconAjouter : Page
    {
        LeconLM leconLM = new LeconLM();
        public LeconAjouter(Object? lec = null)
        {
            Lecon? lecon = null;
            if (lec != null) lecon = (Lecon)lec;
            InitializeComponent();
            this.DataContext = lecon;
        }

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CreateClick(object sender, RoutedEventArgs e)
        {
            DateTime datetimeResult;
            DateTime.TryParse(DateHeure.Text, out datetimeResult);
            int duree;
            int.TryParse(Duree.Text, out duree);

            Lecon lecon     = new Lecon();
            lecon.ModelLec  = Modele.Text;
            lecon.DateLec   = datetimeResult;
            lecon.NomElv    = NomElv.Text;
            lecon.PrenomElv = PrenomElv.Text;
            lecon.NomMnt    = NomMnt.Text;
            lecon.PrenomMnt = PrenomMnt.Text;
            lecon.DureeLec  = duree;

            bool retour = leconLM.createLecon(lecon);
            if(retour) this.NavigationService.Navigate(new LeconListe());
        }
    }
}
