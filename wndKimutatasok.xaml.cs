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
    /// Interaction logic for wndKimutatasok.xaml
    /// </summary>
    public partial class wndKimutatasok : Window
    {
<<<<<<< HEAD:Diakszovetkezet/wndRegisztracio.xaml.cs
        bool userszabad = true;
        bool emailszabad = true;
        bool jelszoegyezik = true;
        double errorThickness = 2.0;
        bool jo = true;
        public wndRegisztracio()
=======
        public wndKimutatasok()
>>>>>>> master:wndKimutatasok.xaml.cs
        {
            InitializeComponent();
        }

        private void btRegisztral_Click(object sender, RoutedEventArgs e)
        {
            CheckFields();
            if(!userszabad)
            {
                jo = false;
                lbRegisztracio.Content = "A megadott felhasználónév már foglalt!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                tbFelhasznalonev.BorderBrush = Brushes.Red;
                tbFelhasznalonev.BorderThickness = new Thickness(errorThickness);
                
            }
            else if(!emailszabad)
            {
                jo = false;
                lbRegisztracio.Content = "A megadott email cím már foglalt!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                tbEmail.BorderBrush = Brushes.Red;
                tbEmail.BorderThickness = new Thickness(errorThickness);
                
            }
            else if(!jelszoegyezik)
            {
                jo = false;
                lbRegisztracio.Content = "A megadott jelszavak nem egyeznek!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                pbJelszo.BorderBrush = Brushes.Red;
                pbJelszo.BorderThickness = new Thickness(errorThickness);
                pbJelszoujra.BorderBrush = Brushes.Red;
                pbJelszoujra.BorderThickness = new Thickness(errorThickness);
            }
            else if(jo)
            { 
                using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
                {
                    Users uj = new Users();
                    uj.username = tbFelhasznalonev.Text;
                    uj.password = pbJelszo.Password;
                    uj.email = tbEmail.Text;
                    uj.fname = tbVeznev.Text;
                    uj.lname = tbKernev.Text;
                    uj.role = 1;
                    uj.del = 0;
                    entities.Users.Add(uj);
                    if(entities.SaveChanges()>0)
                    {
                        lbRegisztracio.Content = "Sikeres regisztráció!";
                        bdRegisztracio.Background = new SolidColorBrush(Colors.LightGreen);
                    }
                }
                
            }
        }

        private void CheckFields()
        {
<<<<<<< HEAD
            using (DiakszovetkezetEntitiesFrameWork context = new DiakszovetkezetEntitiesFrameWork())
=======
            if(tbFelhasznalonev.Text == "")
            {
                lbRegisztracio.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                tbFelhasznalonev.BorderBrush = Brushes.Red;
                tbFelhasznalonev.BorderThickness = new Thickness(errorThickness);
                jo = false;
            }
            if (pbJelszo.Password == "")
            {
                lbRegisztracio.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                pbJelszo.BorderBrush = Brushes.Red;
                pbJelszo.BorderThickness = new Thickness(errorThickness);
                jo = false;
            }
            if (pbJelszoujra.Password == "")
            {
                lbRegisztracio.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdRegisztracio.Background = new SolidColorBrush(Colors.Red);
                pbJelszoujra.BorderBrush = Brushes.Red;
                pbJelszoujra.BorderThickness = new Thickness(errorThickness);
                jo = false;
            }
            if (tbEmail.Text != "")
            {
                
                string[] email = tbEmail.Text.Split('@', '.');
                if (email.Length != 3)
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
         
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
>>>>>>> Béla
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
            lbRegisztracio.Content = "Diák regisztráció";
            bdRegisztracio.Background = new SolidColorBrush(Colors.LightSkyBlue);
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
