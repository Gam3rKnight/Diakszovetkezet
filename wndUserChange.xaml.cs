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
using System.Windows.Shapes;

namespace Diakszovetkezet
{
    /// <summary>
    /// Interaction logic for wndUserChange.xaml
    /// </summary>
    public partial class wndUserChange : Window
    {
       
        bool jelszoegyezik = true;
        double errorThickness = 2.0;
        bool jo = true;
        string id;

        public wndUserChange(string id)
        {
            InitializeComponent();
            this.id = id;

            using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
            {
                var result = from u in entities.Users
                             where u.username == id
                             select u;
                foreach (var user in result)
                {
                    tbFelhasznalonev.Text = user.username;
                    tbEmail.Text = user.email;
                    tbVeznev.Text = user.fname;
                    tbKernev.Text = user.lname;
                }
            }
            tbFelhasznalonev.IsEnabled = false;
            tbFelhasznalonev.ToolTip = new ToolTip().Content = "A felhasználónév nem módosítható!";
            lbFelhasznalonev.ToolTip = new ToolTip().Content = "A felhasználónév nem módosítható!";

        }

        private void btModosit_Click(object sender, RoutedEventArgs e)
        {
            CheckFields();

            if (!jelszoegyezik)

            {
                jo = false;
                lbRegisztracio.Content = "A megadott jelszavak nem egyeznek!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                pbJelszo.BorderBrush = Brushes.Red;
                pbJelszo.BorderThickness = new Thickness(errorThickness);
                pbJelszoujra.BorderBrush = Brushes.Red;
                pbJelszoujra.BorderThickness = new Thickness(errorThickness);
            }
            else if (jo)
            {
                using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
                {
                    var result = from u in entities.Users
                                 where u.username == id
                                 select u;
                    foreach (var user in result)
                    {

                        user.username = tbFelhasznalonev.Text;
                        user.email = tbEmail.Text;
                        user.fname = tbVeznev.Text;
                        user.lname = tbKernev.Text;
                    }
                    if (entities.SaveChanges() > 0)
                    {
                        lbRegisztracio.Content = "Sikeres módosítás!";
                        bdRegisztracio.Background = new SolidColorBrush(Colors.LightGreen);
                    }


                }

            }
        }

        private void CheckFields()
        {
            if (tbFelhasznalonev.Text == "")
            {
                lbRegisztracio.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                tbFelhasznalonev.BorderBrush = Brushes.Red;
                tbFelhasznalonev.BorderThickness = new Thickness(errorThickness);
                jo = false;
            }

            if (tbEmail.Text != "")
            {

                string[] email = tbEmail.Text.Split('@');
                if (email.Length != 2)
                {
                    MessageBox.Show("Az email nem megfeleő formátumú!\nA szabványos email formátum: 'nev'@'domainnev'.'hu'", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                    tbEmail.BorderBrush = Brushes.Red;
                    tbEmail.BorderThickness = new Thickness(errorThickness);
                    jo = false;
                }

            }
          
            else
            {
                jo = false;
                lbRegisztracio.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                tbEmail.BorderBrush = Brushes.Red;
                tbEmail.BorderThickness = new Thickness(errorThickness);
            }


            if (pbJelszo.Password != pbJelszoujra.Password) jelszoegyezik = false;
        }

        private void tbFelhasznalonev_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbFelhasznalonev.BorderBrush = Brushes.Transparent;
            tbFelhasznalonev.BorderThickness = new Thickness(0, 0, 0, 1);
         
            jo = true;
        }

        private void tbEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbEmail.BorderBrush = Brushes.Transparent;
            tbEmail.BorderThickness = new Thickness(0, 0, 0, 1);
            
            jo = true;
        }

        private void btUrit_Click(object sender, RoutedEventArgs e)
        {
            tbFelhasznalonev.Clear();
            pbJelszo.Clear();
            pbJelszoujra.Clear();
            tbEmail.Clear();
            tbVeznev.Clear();
            tbKernev.Clear();
            lbRegisztracio.Content = "Diák módosítás";

            bdRegisztracio.Background = new SolidColorBrush(Colors.LightSkyBlue);
            jo = true;
        }

        private void pbJelszo_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pbJelszo.BorderBrush = Brushes.Transparent;
            pbJelszo.BorderThickness = new Thickness(0, 0, 0, 1);
            jelszoegyezik = true;
            jo = true;
        }

        private void pbJelszoujra_PasswordChanged(object sender, RoutedEventArgs e)
        {
            pbJelszoujra.BorderBrush = Brushes.Transparent;
            pbJelszoujra.BorderThickness = new Thickness(0, 0, 0, 1);
            jelszoegyezik = true;
            jo = true;
        }
    }
}

 

