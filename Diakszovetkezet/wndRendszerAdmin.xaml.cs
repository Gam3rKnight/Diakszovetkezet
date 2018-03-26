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
    /// Interaction logic for wndRendszerAdmin.xaml
    /// </summary>
    public partial class wndRendszerAdmin : Window
    {
        public wndRendszerAdmin()
        {
            InitializeComponent();
        }
        //<summary>
        //Modell osztály szükséges a listview listáinak feltöltéséhez
        //<summary>
        class lvElmenetsMunka
        {
            string Munka, Cégnév, Helyszín, Helyekszáma, Munkakezdet, Munkavége, Munkakör; 
        }

        //<summary>
        //Ebbe a listába fogjuk betölteni azokat az adatokat amiket a Munkák kilistázására fogunk használni.
        //<summary>
        List<lvElmenetsMunka> lElements = new List<lvElmenetsMunka>();
        

        private void miKilepes_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //<summary>
        //Itt egy további ablak nyílik meg ahol a felhasználók adatait tudjuk módosítani vagy törölni.
        //<summary>
        private void miFelhasznaloadatmod_Click(object sender, RoutedEventArgs e)
        {

        }
        //<summary>
        //Elnavigál minket a céges regisztrációs felületre
        //<summary>
        private void miCegregisztracio_Click(object sender, RoutedEventArgs e)
        {
            wndCegRegisztarcio cegRegisztarcio = new wndCegRegisztarcio();
            cegRegisztarcio.Show();
        }
        //<summary>
        //A sima felhasználói regisztrációs felülethez navigál
        //<summary>
        private void miFelhasznaloregisztracio_Click(object sender, RoutedEventArgs e)
        {
            wndRegisztracio regisztracio = new wndRegisztracio();
            regisztracio.Show();
        }
    }
}
