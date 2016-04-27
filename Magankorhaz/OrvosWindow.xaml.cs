﻿using System;
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
using System.Windows.Shapes;
using Magankorhaz.UserControlok;
using Magankorhaz.FeldolgozoOsztalyok;

namespace Magankorhaz
{
    /// <summary>
    /// Interaction logic for OrvosWindow.xaml
    /// </summary>
    public partial class OrvosWindow : Window
    {
        Magankorhaz.Adatbazis.Orvos orvos;
        public OrvosWindow(string felhasznalonev)
        {
            InitializeComponent();
            felhasznalo.Content = felhasznalonev;
            orvos = OrvosBetoltese(felhasznalonev);
            FeluletBeallitasa();
        }

        private void kijelentkezesButton_Click(object sender, RoutedEventArgs e)
        {
            orvosWindow.Close();
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
        }

        private void orvosWindow_Loaded(object sender, RoutedEventArgs e)
        {
            OrvosSajatAdatok sajatAdatok = new OrvosSajatAdatok(orvos);
            orvosTartalomGrid.Children.Add(sajatAdatok);
        }

        Magankorhaz.Adatbazis.Orvos OrvosBetoltese(string felhasznalonev)
        {
            //TODO adatbazisbol beszerezni
            if (felhasznalonev == "orvos")
            {
                OrvosRendelesFeldolgozo feldolgozo = new OrvosRendelesFeldolgozo(Adatbazis.AdatBazis.DataBase);
                return feldolgozo.ElsoOrvos();
            }
            return new Adatbazis.Orvos();
        }

        void FeluletBeallitasa()
        {
            felhasznalo.Content = orvos.Nev;
            felhasznaloTipus.Content = "Orvos";
        }

        private void sajatadatokMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            orvosTartalomGrid.Children.Clear();
            orvosTartalomGrid.Children.Add(new OrvosSajatAdatok(orvos));
        }

        private void rendelesekMenuGomb_Click(object sender, RoutedEventArgs e)
        {
            orvosTartalomGrid.Children.Clear();
            orvosTartalomGrid.Children.Add(new OrvosRendelesek(orvos));
        }

    }
}
