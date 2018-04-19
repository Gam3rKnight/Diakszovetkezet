using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using System.ComponentModel;
>>>>>>> Soma
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
<<<<<<< HEAD
=======
<<<<<<< HEAD:Diakszovetkezet/wndBejelentkezes.xaml.cs
    
    public partial class wndBejelentkezes : Window
    {
        private structUserData user;
        wndDiakAblak wndDiak;
        wndRendszerAdmin wndAdmin;
        wndRegisztracio wndReg;
      
        public wndBejelentkezes()
        {
            InitializeComponent();
            user = new structUserData();
        }

        public structUserData User
        {
            get { return user; }
            set { user = value; }
=======
>>>>>>> Soma
    /// <summary>
    /// Interaction logic for wndCegRegisztarcio.xaml
    /// </summary>
    public partial class wndCegRegisztarcio : Window
    {
        bool cegszabad = true;
        bool telephelycim = true;
        bool leiras = true;        
        double errorThickness = 2.0;
        bool jo = true;

        public wndCegRegisztarcio()
        {
            InitializeComponent();
<<<<<<< HEAD
=======
>>>>>>> master:wndCegRegisztarcio.xaml.cs
>>>>>>> Soma
        }

        private void btCegRegVissza_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD:Diakszovetkezet/wndBejelentkezes.xaml.cs
            if (tbFelhasznalonev.Text != "" && pbJelszo.Password != "")
            {
                using (DiakszovetkezetEntitiesFrameWork context = new DiakszovetkezetEntitiesFrameWork())
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
                        wndDiak = new wndDiakAblak();
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
                if(tbFelhasznalonev.Text=="")
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
=======
>>>>>>> Soma
=======
            wndRendszerAdmin rendszerAdmin = new wndRendszerAdmin();
            rendszerAdmin.Show();
        }

        private void btCegRegKesz_Click(object sender, RoutedEventArgs e)
        {
            CheckFields();
            if (!cegszabad)
            {
                jo = false;
                lbAlcim.Content = "A megadott cégnév már foglalt!";
                bdCegReg.Background = new SolidColorBrush(Colors.Red);
                tbCegNev.BorderBrush = Brushes.Red;
                tbCegNev.BorderThickness = new Thickness(errorThickness);
            }
            else if (!telephelycim)
            {
                jo = false;
                lbAlcim.Content = "A megadott telephely már foglalt!";
                bdCegReg.Background = new SolidColorBrush(Colors.Red);
                tbCegTelephely.BorderBrush = Brushes.Red;
                tbCegTelephely.BorderThickness = new Thickness(errorThickness);

            }

            else if (jo)
            {
                using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
                {
                    Companies uj = new Companies();
                    uj.c_name = tbCegNev.Text;
                    uj.location = tbCegTelephely.Text;
                    uj.c_description = tbCegLeiras.Text;
                    uj.c_del = 0;
                    entities.Companies.Add(uj);
                    //entities.SaveChanges();
                    if (entities.SaveChanges() > 0)
                    {
                        lbAlcim.Content = "Sikeres regisztráció!";
                        bdCegReg.Background = new SolidColorBrush(Colors.LightGreen);
                    }
                }

            }
>>>>>>> master

        }

        private void CheckFields()
        {
            if (tbCegNev.Text == "")
            {
                lbAlcim.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdCegReg.Background = new SolidColorBrush(Colors.Red);
                tbCegNev.BorderBrush = Brushes.Red;
                tbCegNev.BorderThickness = new Thickness(errorThickness);
                jo = false;
            }
            if (tbCegTelephely.Text == "")
            {
                lbAlcim.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdCegReg.Background = new SolidColorBrush(Colors.Red);
                tbCegTelephely.BorderBrush = Brushes.Red;
                tbCegTelephely.BorderThickness = new Thickness(errorThickness);
                jo = false;
            }
            if (tbCegLeiras.Text == "")
            {
                lbAlcim.Content = "A csillaggal jelölt mezők kitöltése kötelező!";
                bdCegReg.Background = new SolidColorBrush(Colors.Red);
                tbCegLeiras.BorderBrush = Brushes.Red;
                tbCegLeiras.BorderThickness = new Thickness(errorThickness);
                jo = false;
            }

            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result = from u in context.Companies
                             select u;

<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> master:wndCegRegisztarcio.xaml.cs
>>>>>>> Soma
=======
                foreach (var u in result)
                {
                    if (u.c_name == tbCegNev.Text) cegszabad = false;                    
                }
            }            
        }

        private void tbCegNev_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbCegNev.BorderBrush = Brushes.Transparent;
            tbCegNev.BorderThickness = new Thickness(0, 0, 0, 1);
            cegszabad = true;
>>>>>>> master
        }
    }
}
