using AutoEcole.AccesDonnees;
using AutoEcole.LogiqueMetier;
using AutoEcole.Metier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Logique d'interaction pour ModeleForm.xaml
    /// </summary>
    public partial class ModeleForm : Page
    {
        ModeleLM modeleLM = new ModeleLM();
        public ModeleForm(Object? mdl = null)
        {
            Modele? modele = null;
            if (mdl != null) modele = (Modele)mdl;
            InitializeComponent();
            this.DataContext = modele;
        }


        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            DateTime dateResult;
            DateTime.TryParse(Achat.Text, out dateResult);

            Modele modele = new Modele();
            modele.ModelMdl     = Modele.Text;
            modele.MarqueMdl    = Marque.Text;
            modele.AnneMdl      = Annee.Text;
            modele.DateAchatMdl = dateResult;
            modeleLM.updateModele(modele);
            this.NavigationService.Navigate(new ModeleListe());
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            modeleLM.deleteModele(Modele.Text) ;
            this.NavigationService.Navigate(new ModeleListe());
        }

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
