﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Diakszovetkezet
{

    public partial class wndBejelentkezes : Window
    {
        private structUserData user;
        wndTanulo wndDiak;
        wndRendszerAdmin wndAdmin;
        wndRegisztracio wndReg;

        public wndBejelentkezes()
        {
            InitializeComponent();

        }

        

        private void BejelentkezesFolyamat()

        {
            if (tbFelhasznalonev.Text != "" && pbJelszo.Password != "")
            {
                using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
                {
                    var result = from u in context.Users
                                 select u;
                    bool vane = false;

                    foreach (var u in result)
                    {
                        if (tbFelhasznalonev.Text == u.username && pbJelszo.Password == u.password)
                        {
                            vane = true;
                            user.userName = u.username;
                            user.email = u.email;
                            user.firstName = u.fname;
                            user.lastName = u.lname;
                            user.role = u.role;
                        }
                    }
                    if (vane && user.role == 1)
                    {
                        wndDiak = new wndTanulo();
                        wndDiak.Closing += Window_Closing;
                        wndDiak.ShowDialog();
                        tbFelhasznalonev.Clear();
                        pbJelszo.Clear();
                    }
                    else if (vane && user.role == 0)
                    {
                        wndAdmin = new wndRendszerAdmin();
                        wndAdmin.Closing += Window_Closing;
                        wndAdmin.ShowDialog();
                        tbFelhasznalonev.Clear();
                        pbJelszo.Clear();
                    }
                    else MessageBox.Show("Sikertelen bejelentkezés!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                MessageBox.Show("Nem megfelelően töltötte ki a megjelölt mezőket!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);

                if (tbFelhasznalonev.Text == "")

                {
                    tbFelhasznalonev.BorderBrush = Brushes.Red;
                    tbFelhasznalonev.BorderThickness = new Thickness(2.0);
                }

                if (pbJelszo.Password == "")
                {
                    pbJelszo.BorderBrush = Brushes.Red;
                    pbJelszo.BorderThickness = new Thickness(2.0);
                }
            }
        }


        private void btBejelentkezes_Click(object sender, RoutedEventArgs e)
        {
            BejelentkezesFolyamat();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
           Application.Current.Shutdown();
        }

        private void pbJelszo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pbJelszo.BorderBrush = Brushes.Transparent;
            pbJelszo.BorderThickness = new Thickness(0, 0, 0, 1);
        }

        private void tbFelhasznalonev_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbFelhasznalonev.BorderBrush = Brushes.Transparent;
            tbFelhasznalonev.BorderThickness = new Thickness(0, 0, 0, 1);
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = (MessageBox.Show("Biztosan be akarja zárni az ablakot?", "Figyelmeztetés", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.Yes) == MessageBoxResult.No);
        }

        private void btRegisztracio_Click(object sender, RoutedEventArgs e)
        {
            wndReg = new wndRegisztracio();
            wndReg.Closing += Window_Closing;
            wndReg.ShowDialog();
        }


        private void grLoginGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BejelentkezesFolyamat();
            }
        }

    }
}
