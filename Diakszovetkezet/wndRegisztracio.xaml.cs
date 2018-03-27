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

namespace Diakszovetkezet
{
    /// <summary>
    /// Interaction logic for wndRegisztracio.xaml
    /// </summary>
    public partial class wndRegisztracio : Window
    {
        bool userszabad = true;
        bool emailszabad = true;
        bool jelszoegyezik = true;
        public wndRegisztracio()
        {
            InitializeComponent();
        }

        private void btRegisztral_Click(object sender, RoutedEventArgs e)
        {
            CheckFields();
            if(!userszabad)
            {
                MessageBox.Show("A megadott felhasználónév már foglalt!\nKérem válasszon másikat!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                tbFelhasznalonev.BorderBrush = Brushes.Red;
                tbFelhasznalonev.BorderThickness = new Thickness(2.0);
            }
            else if(!emailszabad)
            {
                MessageBox.Show("A megadott email cím már foglalt!\nKérem válasszon másikat!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                tbEmail.BorderBrush = Brushes.Red;
                tbEmail.BorderThickness = new Thickness(2.0);
            }
            else if(!jelszoegyezik)
            {
                MessageBox.Show("A megadott jelszavak nem egyeznek!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                pbJelszo.BorderBrush = Brushes.Red;
                pbJelszo.BorderThickness = new Thickness(2.0);
                pbJelszoujra.BorderBrush = Brushes.Red;
                pbJelszoujra.BorderThickness = new Thickness(2.0);
            }
        }

        private void CheckFields()
        {
            if(tbFelhasznalonev.Text == "")
            {
                
            }
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result = from u in context.Users
                             select u;
                
                foreach (var u in result)
                {
                    if (u.username == tbFelhasznalonev.Text) userszabad = false;
                    if (u.email == tbEmail.Text) emailszabad = false;
                }
            }
            if (pbJelszo.Password != pbJelszoujra.Password) jelszoegyezik = false;
        }

        private void tbFelhasznalonev_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbFelhasznalonev.BorderBrush = Brushes.Transparent;
            tbFelhasznalonev.BorderThickness = new Thickness(0, 0, 0, 1);
            userszabad = true;
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbEmail.BorderBrush = Brushes.Transparent;
            tbEmail.BorderThickness = new Thickness(0, 0, 0, 1);
            emailszabad = true;
        }

        private void btUrit_Click(object sender, RoutedEventArgs e)
        {
            tbFelhasznalonev.Clear();
            pbJelszo.Clear();
            pbJelszoujra.Clear();
            tbEmail.Clear();
            tbVeznev.Clear();
            tbKernev.Clear();
        }

        private void pbJelszo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pbJelszo.BorderBrush = Brushes.Transparent;
            pbJelszo.BorderThickness = new Thickness(0, 0, 0, 1);
            jelszoegyezik = true;
        }

        private void pbJelszoujra_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pbJelszoujra.BorderBrush = Brushes.Transparent;
            pbJelszoujra.BorderThickness = new Thickness(0, 0, 0, 1);
            jelszoegyezik = true;
        }
    }
}
