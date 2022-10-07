﻿using AutoEcole.AccesDonnees;
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
    /// Logique d'interaction pour MoniteurForm.xaml
    /// </summary>
    public partial class MoniteurForm : Page
    {
        MoniteurLM moniteurLM = new MoniteurLM();
        public MoniteurForm(Object? mnt = null)
        {
            Moniteur? moniteur = null;
            if (mnt != null) moniteur = (Moniteur)mnt;
            InitializeComponent();
            this.DataContext = moniteur;
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Moniteur moniteur = new Moniteur();
            int id;
            int.TryParse(Id.Text, out id);
            moniteur.IdMnt = id;
            moniteur.PrenomMnt = Prenom.Text;
            moniteur.NomMnt = Nom.Text;
            DateTime dateResult1;
            DateTime.TryParse(Naissance.Text, out dateResult1);
            moniteur.NaissanceMnt = dateResult1;
            DateTime dateResult2;
            DateTime.TryParse(Embauche.Text, out dateResult2);
            moniteur.EmbaucheMnt = dateResult2;
            if (Activite.IsChecked == true) moniteur.ActiviteMnt = true;
            else moniteur.ActiviteMnt = false;
            moniteurLM.updateMoniteur(moniteur);
            this.NavigationService.Navigate(new MoniteurListe());
        }

        private void DeleteClick(object sender, RoutedEventArgs e)
        {
            Moniteur moniteur = new Moniteur();
            int id;
            int.TryParse(Id.Text, out id);
            moniteurLM.deleteMoniteur(id);
            this.NavigationService.Navigate(new MoniteurListe());
        }

        private void GoBackClick(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
