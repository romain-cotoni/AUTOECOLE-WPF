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
    /// Logique d'interaction pour LeconForm.xaml
    /// </summary>
    public partial class LeconForm : Page
    {
        LeconLM leconLM = new LeconLM();
        public LeconForm(Object? lec = null)
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

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            DateTime datetimeResult;
            DateTime.TryParse(DateHeure.Text, out datetimeResult);
            int idelv;
            int.TryParse(IdElv.Text, out idelv);
            int idmnt;
            int.TryParse(IdMnt.Text, out idmnt);
            

            Lecon lecon = new Lecon();
            lecon.ModelLec = Modele.Text;
            lecon.DateLec = datetimeResult;
            lecon.IdEleveLec = idelv;
            lecon.IdMoniteurLec = idmnt;
            leconLM.deleteLecon(lecon);
            this.NavigationService.Navigate(new LeconListe());
        }
        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            //TO DO
            //Lecon lecon = new Lecon();
            //leconLM.updateClient(lecon);
            this.NavigationService.Navigate(new LeconListe());
        }
    }
}
