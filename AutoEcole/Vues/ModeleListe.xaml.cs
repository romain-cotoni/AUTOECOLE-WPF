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
    /// Logique d'interaction pour ModeleListe.xaml
    /// </summary>
    public partial class ModeleListe : Page
    {
        ModeleLM modeleLM = new ModeleLM();
        public ModeleListe()
        {
            InitializeComponent();
            HashSet<Modele>? modeles = modeleLM.findAllModeles();
            listviewModels.ItemsSource = modeles;
        }
        private void ModelAjouterClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ModeleAjouter(null));
        }

        private void ModelFormClick(object sender, RoutedEventArgs e)
        {
            Modele modele = new Modele();
            modele.ModelMdl     = ((Modele)((Button)sender).DataContext).ModelMdl;
            modele.MarqueMdl    = ((Modele)((Button)sender).DataContext).MarqueMdl;
            modele.AnneMdl      = ((Modele)((Button)sender).DataContext).AnneMdl;
            modele.DateAchatMdl = ((Modele)((Button)sender).DataContext).DateAchatMdl;
            this.NavigationService.Navigate(new ModeleForm(modele));
        }

    }
}
