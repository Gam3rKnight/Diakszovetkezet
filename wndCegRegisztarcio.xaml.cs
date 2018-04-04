using System;
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
using System.Windows.Shapes;

namespace Diakszovetkezet
{
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
    /// <summary>
    /// Interaction logic for wndCegRegisztarcio.xaml
    /// </summary>
    public partial class wndCegRegisztarcio : Window
    {
        public wndCegRegisztarcio()
        {
            InitializeComponent();
>>>>>>> master:wndCegRegisztarcio.xaml.cs
        }

        private void btCegRegVissza_Click(object sender, RoutedEventArgs e)
        {
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

        }

        private void btCegRegKesza_Click(object sender, RoutedEventArgs e)
        {

>>>>>>> master:wndCegRegisztarcio.xaml.cs
        }
    }
}
