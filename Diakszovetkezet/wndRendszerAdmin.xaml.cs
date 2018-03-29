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
<<<<<<< HEAD
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
=======
>>>>>>> Béla
        }

        //<summary>
        //Ebbe a listába fogjuk betölteni azokat az adatokat amiket a Munkák kilistázására fogunk használni.
        //<summary>
        List<lvElmenetsMunka> lElements = new List<lvElmenetsMunka>();

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
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
<<<<<<< HEAD
                var result = from u in context.Users
                             join st in context.StudentTime on u.username equals st.s_username
                            where u.role == 1 && u.del == 1
                             select new { u, st };

                foreach (var x in result)
                {
                    lElementsDiak.Add(new lvElmenetsDiak()
                    {
                        Felhasználónév = x.u.username,
                        Vezetéknév = x.u.lname,
                        Keresztnév = x.u.fname,
                        Email = x.u.email,
                        Munkakezdés = x.st.datestart.ToString(),
                        Munkavégzés = x.st.dateend.ToString()


                    });
                }

                var result1 = from w in context.Work join c in context.Companies on w.company_id equals c.c_id
                              where c.c_del == 1
                              select new {w, c };
                foreach (var d in result1)
=======
                var result = from u in context.Users join st in context.StudentTime on u.username equals st.s_username where u.role == 1 && u.del == 1
                             select new {u, st};
                foreach(var x in result )
>>>>>>> master
                {
                    lElementsDiak.Add(new lvElmenetsDiak() {
                        

<<<<<<< HEAD
                        Munka = d.w.w_name,
                        Cégnév = d.c.c_name,
                        Helyszín = d.c.location,
                        Helyekszáma = d.w.s_number.ToString(),
                        Munkakezdet = d.w.w_datestart.ToString(),
                        Munkavége = d.w.w_dateend.ToString(),
                        Munkakör = d.w.w_description
=======
>>>>>>> master
                    });
                }
            }
<<<<<<< HEAD
            lvMunkaLista.ItemsSource = lElementsMunka;
            lvDiakLista.ItemsSource = lElementsDiak;

            
=======
>>>>>>> master

     
     
=======
            this.Close();
        }
        
>>>>>>> Béla
    }
}
