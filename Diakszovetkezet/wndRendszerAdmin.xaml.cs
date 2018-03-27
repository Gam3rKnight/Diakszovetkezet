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

        class lvElmenetsDiak
        {
            string Felhasználónév, Vezetéknév, Keresztnév, Email, Munkakezdés, Munkavégzés;
        }

        class lvElmenetsDiakMunka
        {
            string Felhasználónév, Vezetéknév, Keresztnév, Cégnév, Helyszín, Helyekszáma, DiákMunkakezdete, DiákMunkavége, CégMunkakezdete, CégMunkavége;
        }

        //<summary>
        //Ebbe a listába fogjuk betölteni azokat az adatokat amiket a listview-ba fogunk betölteni.
        //<summary>
        List<lvElmenetsMunka> lElementsMunka = new List<lvElmenetsMunka>();
        List<lvElmenetsDiak> lElementsDiak = new List<lvElmenetsDiak>();
        List<lvElmenetsDiakMunka> lElementsDiakMunka = new List<lvElmenetsDiakMunka>();



        private void miKilepes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
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

        private void miDiakfoablak_Click(object sender, RoutedEventArgs e)
        {
            wndDiakAblak diakAblak = new wndDiakAblak();
            diakAblak.Show();
        }

        private void miFrissites_Click(object sender, RoutedEventArgs e)
        {
           

            ListakFeltoltese();
        }
        
        //<summary>
        //Ha jobbklikkel kattintunk a listába akkor megjelenik egy legördülő menü(contextmenü) amiben további funkciók vannak
        //<summary>
        private void lvDiákMunkaLista_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            OpenContextMenu(ContextMenuMunkaName);
            OpenContextMenu(ContextMenuDiakName);
            OpenContextMenu(ContextMenuDiakMunkaName);
        }

        private void OpenContextMenu(FrameworkElement element)
        {
            if (element.ContextMenu != null)
            {
                element.ContextMenu.PlacementTarget = element;
                element.ContextMenu.IsOpen = true;
            }
        }

        private void ListakFeltoltese()
        {
           
            using (DiakszovetkezetEntitiesFrameWork context = new DiakszovetkezetEntitiesFrameWork())
            {
                var result = from u in context.Users join st in context.StudentTime on u.username equals st.s_username where u.role == 1 && u.del == 1
                             select new {u, st};
                foreach(var x in result )
                {
                    lElementsDiak.Add(new lvElmenetsDiak() {
                        

                    });
                }
            }

     
     
    }
}
