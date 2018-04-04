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
            public string Munka { get; set; }
            public string Cégnév { get; set; }
            public string Helyszín { get; set; }
            public string Helyekszáma { get; set; }
            public string Munkakezdet { get; set; }
            public string Munkavége { get; set; }
            public string Munkakör { get; set; }

        }

        class lvElmenetsDiak
        {
            public string Felhasználónév { get; set; }
            public string Vezetéknév { get; set; }
            public string Keresztnév { get; set; }
            public string Email { get; set; }
            public string Munkakezdés { get; set; }
            public string Munkavégzés { get; set; }
        }

        class lvElmenetsDiakMunka
        {
            public string Felhasználónév { get; set; }
            public string Vezeték { get; set; }
            public string Kereszt { get; set; }
            public string Cégnév { get; set; }
            public string Helyszín { get; set; }
            public string Helyekszáma { get; set; }
            public string DiákMunkakezdete { get; set; }
            public string DiákMunkavége { get; set; }
            public string CégMunkakezdete { get; set; }
            public string CégMunkavége { get; set; }
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
            wndTanulo diakAblak = new wndTanulo();
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

            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result = from u in context.Users
                             join st in context.StudentTime on u.username equals st.s_username
                            where u.role == 1 && u.del == 1
                             select new { u, st };

                foreach (var x in result)
                {
                    lElementsDiak.Add(new lvElmenetsDiak()
                    {
                        Felhasználónév = x.u.username,
                        Vezetéknév = x.u.fname,
                        Keresztnév = x.u.lname,
                        Email = x.u.email,
                        Munkakezdés = x.st.datestart.ToString(),
                        Munkavégzés = x.st.dateend.ToString()


                    });
                }

                var result1 = from w in context.Work join c in context.Companies on w.company_id equals c.c_id
                              where c.c_del == 1
                              select new {w, c };
                foreach (var d in result1)
                {
                    lElementsMunka.Add(new lvElmenetsMunka() {

                        Munka = d.w.w_name,
                        Cégnév = d.w.w_name,
                        Helyszín = d.c.location,
                        Helyekszáma = d.w.s_number.ToString(),
                        Munkakezdet = d.w.w_datestart.ToString(),
                        Munkavége = d.w.w_dateend.ToString(),
                        Munkakör = d.c.c_description
                    });
                }

            }
            lvDiakLista.ItemsSource = lElementsDiak;
            lvMunkaLista.ItemsSource = lElementsMunka;
            

        }

        private void miKimutatasok_Click(object sender, RoutedEventArgs e)
        {
            wndKimutatasok kimutatasok = new wndKimutatasok();
            kimutatasok.ShowDialog();
        }

        private void ErtesitesCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MunkatorolComman_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MunkamodCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EretesitCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void IdopontmodCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void EretesitesekCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void IdopontokmodCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void IdopontosszeCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void MunkafoglalasCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void imgErtesitesHarang_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
