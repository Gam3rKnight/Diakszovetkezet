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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Diakszovetkezet
{
    /// <summary>
    /// Interaction logic for wndKimutatasok.xaml
    /// </summary>
    public partial class wndKimutatasok : Window
    {
<<<<<<< HEAD
<<<<<<< HEAD
        public wndKimutatasok()
=======
        int elvegzett = 0;
        int elvegzendo = 0;
        float maxWidth = 650.0f;
        float fillTo = 0.8f;
        List<kimutatDiakok> diakok;
        public wndKimutatasok(List<kimutatDiakok> diakok)
>>>>>>> master
        {
            InitializeComponent();
            rcElvegzett.Width = 0;
            rcElvegzendo.Width = 0;
            this.diakok = diakok;
            lbElvegzett.SetValue(Canvas.TopProperty, (double)rcElvegzett.GetValue(Canvas.TopProperty) + rcElvegzett.Height / 2 - lbElvegzett.Height / 2);
            lbElvegzett.SetValue(Canvas.LeftProperty, (double)rcElvegzett.GetValue(Canvas.LeftProperty) + rcElvegzett.Width + 10);
            lbElvegzendo.SetValue(Canvas.TopProperty, (double)rcElvegzendo.GetValue(Canvas.TopProperty) + rcElvegzendo.Height / 2 - lbElvegzendo.Height / 2);
            lbElvegzendo.SetValue(Canvas.LeftProperty, (double)rcElvegzendo.GetValue(Canvas.LeftProperty) + rcElvegzendo.Width + 10);
            List<string> usernames = new List<string>();
            foreach (var u in diakok)
            {
                usernames.Add(u.username);
            }
            cbDiak.DataContext = usernames;
        }

        private void btFrissit_Click(object sender, RoutedEventArgs e)
        {
            if(cbDiak.SelectedItem==null)
            {
                return;
            }
            string username = cbDiak.SelectedItem as string;
            kimutatDiakok diak = diakok.Find(x => x.username == username);
            elvegzett = diak.elvegzettMunkak;
            elvegzendo = diak.elvegzendoMunkak;


            double actualWidthElv = rcElvegzett.Width;
            double actualWidthElvendo = rcElvegzendo.Width;
            double newWidthElv;
            double newWidthElvendo;

            if (elvegzett > elvegzendo)
            {
                newWidthElv = maxWidth * fillTo;
                newWidthElvendo = maxWidth * fillTo / ((double)elvegzett / elvegzendo);
                 }
            else
            {

                newWidthElvendo = maxWidth * fillTo;
                newWidthElv = maxWidth * fillTo / ((double)elvegzendo / elvegzett);
           }
            DoubleAnimation doubleAnimation = new DoubleAnimation(actualWidthElv, newWidthElv, new Duration(TimeSpan.FromMilliseconds(1200)));
            DoubleAnimation doubleAnimation2 = new DoubleAnimation(actualWidthElvendo, newWidthElvendo, new Duration(TimeSpan.FromMilliseconds(1200)));
            rcElvegzett.BeginAnimation(FrameworkElement.WidthProperty, doubleAnimation);
            rcElvegzendo.BeginAnimation(FrameworkElement.WidthProperty, doubleAnimation2);

            lbElvegzett.Content = elvegzett;
            lbElvegzendo.Content = elvegzendo;
            lbElvegzett.SetValue(Canvas.LeftProperty, (double)rcElvegzett.GetValue(Canvas.LeftProperty) + rcElvegzett.Width + 10);
            lbElvegzendo.SetValue(Canvas.LeftProperty, (double)rcElvegzendo.GetValue(Canvas.LeftProperty) + rcElvegzendo.Width + 10);

        }
=======
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
>>>>>>> Soma
    }
}
