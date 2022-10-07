using AutoEcole.Vues;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace AutoEcole
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetMainFrameContent(Page page)
        {
            this.MainFrame.Content = page;
        }

        private void AccueilClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Accueil();
        }

        private void EleveListeClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EleveListe();
        }

        private void EleveAjouterClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new EleveAjouter(null);
        }

        private void MoniteurListeClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new MoniteurListe();
        }

        private void MoniteurAjouterClick(object sender, RoutedEventArgs e)
        {
            this.MainFrame.Navigate(new MoniteurAjouter());
        }

        private void VehiculeListeClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new VehiculeListe();
        }
        private void VehiculeAjouterClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new VehiculeAjouter();
        }
        private void ModeleListeClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModeleListe();
        }

        private void ModeleAjouterClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ModeleAjouter();
        }

        private void LeconListeClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LeconListe();
        }

        private void LeconAjouterClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new LeconAjouter();
        }

        private void StatistiqueClick(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Statistique();
        }
    }
}
