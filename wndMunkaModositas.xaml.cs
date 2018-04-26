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
    /// Interaction logic for wndMunkaModositas.xaml
    /// </summary>
    public partial class wndMunkaModositas : Window
    {
        public wndMunkaModositas()
        {
            InitializeComponent();
            tbRollback.Visibility = Visibility.Hidden;

        }

        public int MunkaID;
        DataRecover recover = new DataRecover();

        public class DataRecover
        {
            public string munkaNév { get; set; }
            public DateTime munkaKezdet { get; set; }
            public DateTime munkaVége { get; set; }
            public string munkaKezdetTime { get; set; }
            public string munkaVégeTime { get; set; }
            public string helyekSzáma { get; set; }
            public string leírás { get; set; }
        }

        private void btVissza_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void tbRollback_Click(object sender, RoutedEventArgs e)
        {
            tbRollback.Visibility = Visibility.Hidden;

            tbMunkanév.Text = recover.munkaNév;
            dpMunkakezdet.SelectedDate = recover.munkaKezdet;
            dpMunkavége.SelectedDate = recover.munkaVége;
            tbMunkakezdet.Text = recover.munkaKezdetTime;
            tbMunkavége.Text = recover.munkaVégeTime;
            tbHelyekszáma.Text = recover.helyekSzáma;
            tbLeírás.Text = recover.leírás;
        }

        private void btTörlés_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Biztosan törölni akarja az adatokat?\nVan lehetősége később is visszaállítani!", "Figyelmeztetés!", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            { 
               

                recover.munkaNév = tbMunkanév.Text;
                recover.munkaKezdet = dpMunkakezdet.DisplayDate;
                recover.munkaVége = dpMunkavége.DisplayDate;
                recover.munkaKezdetTime = tbMunkakezdet.Text;
                recover.munkaVégeTime = tbMunkavége.Text;
                recover.helyekSzáma = tbHelyekszáma.Text;
                recover.leírás = tbLeírás.Text;

                tbRollback.Visibility = Visibility.Visible;

                tbMunkanév.Text = "";
                dpMunkakezdet.SelectedDate = DateTime.Now;
                dpMunkavége.SelectedDate = DateTime.Now;
                tbMunkakezdet.Text = "";
                tbMunkavége.Text = "";
                tbHelyekszáma.Text = "";
                tbLeírás.Text = "";
            }
           
        }

        private void btMódosítás_Click(object sender, RoutedEventArgs e)
        {
            
            using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
            {
                try
                {
                    Work w = entities.Work.First(i => i.w_id == MunkaID);
                    w.w_name = tbMunkanév.Text;
                    w.w_datestart = dpMunkakezdet.DisplayDate;
                    w.w_dateend = dpMunkavége.DisplayDate;
                    w.w_name = tbMunkanév.Text;

                    w.s_number = Convert.ToInt32(tbHelyekszáma.Text);

                    w.w_description = tbLeírás.Text;
                    entities.SaveChanges();

                    wndRendszerAdmin admin = new wndRendszerAdmin();
                    admin.ListakFeltoltese();

                    MessageBox.Show("A módosítások sikeresen megtörténtek!", "Értesítés!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        
    }
}
