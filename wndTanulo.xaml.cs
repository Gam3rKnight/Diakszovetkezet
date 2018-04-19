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
using tanuloablak;

namespace Diakszovetkezet
{
    /// <summary>
    /// Interaction logic for wndTanulo.xaml
    /// </summary>
    public partial class wndTanulo : Window
    {
        
     
        public wndTanulo()
        {
            InitializeComponent();
            
        }
        public bool vanErt(string ertesites)
        {
            var result = MessageBox.Show(ertesites, "Értesítés", MessageBoxButton.YesNo, MessageBoxImage.Information);
            if (result == MessageBoxResult.Yes)
            { return true; }
            else return false;
        }
        private wndErtesites wndErtesit;

        private void TbMyName_Loaded_1(object sender, RoutedEventArgs e)
        {
            ucgrid.Children.Clear();
            var uc1 = new ucKereses();
            ucgrid.Children.Add(uc1);

        }

        private void miKilepes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void miIdotablazat_Click(object sender, RoutedEventArgs e)
        {
            ucgrid.Children.Clear();
            var uc1 = new ucIdotablazat();
            ucgrid.Children.Add(uc1);
        }

        private void miKereses_Click(object sender, RoutedEventArgs e)
        {
            ucgrid.Children.Clear();
            var uc1 = new ucKereses();
            ucgrid.Children.Add(uc1);

        }
        

        private void miMunkanaplo_Click(object sender, RoutedEventArgs e)
        {
            ucgrid.Children.Clear();
            var uc1 = new ucMunkanaplo();
            ucgrid.Children.Add(uc1);
        }
        

        private void miMunkaajanlatok_Click(object sender, RoutedEventArgs e)
        {
            wndErtesit = new wndErtesites();
            wndErtesit.ShowDialog();
        }
    }
}
   