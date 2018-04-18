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
    /// Interaction logic for wndTanulo.xaml
    /// </summary>
    public partial class wndTanulo : Window
    {
        public wndTanulo()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        public bool ErtesitesAblak(string Kiiras)
        {

            var result = MessageBox.Show(Kiiras, "Értesítés", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                MessageBox.Show("Sikeresen elfogadta a munkát!", "Elfogadva");
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
