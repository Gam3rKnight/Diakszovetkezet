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
        }

        private void btCegRegVissza_Click(object sender, RoutedEventArgs e)
        {
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
        }
    }
}
