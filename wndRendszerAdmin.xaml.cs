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
            ListakFeltoltese();
        }

        private int ID;

        //<summary>
        //Modell osztály szükséges a listview listáinak feltöltéséhez
        //<summary>
        class lvElmenetsMunka
        {
            public int ID { get; set; }
            public string Munka { get; set; }
            public string Cégnév { get; set; }
            public string Helyszín { get; set; }
            public int Helyekszáma { get; set; }
            public DateTime Munkakezdet { get; set; }
            public DateTime Munkavége { get; set; }
            public string Munkakör { get; set; }

        }

        class lvElmenetsDiak
        {
            public string Felhasználónév { get; set; }
            public string Vezetéknév { get; set; }
            public string Keresztnév { get; set; }
            public string Email { get; set; }
            public DateTime Munkakezdés { get; set; }
            public DateTime Munkavégzés { get; set; }
        }

        class lvElmenetsEgyeztetMunka
        {
            public int ID { get; set; }
            public string Cégnév { get; set; }
            public string Helyszín { get; set; }
            public int Helyekszáma { get; set; }
            public DateTime CégMunkakezdete { get; set; }
            public DateTime CégMunkavége { get; set; }
        }

        class lvElmenetsEgyeztetDiak
        {
            public string Felhasználónév { get; set; }
            public string Vezetéknév { get; set; }
            public string Keresztnév { get; set; }
            public DateTime Diákkezdete { get; set; }
            public DateTime Diákvége { get; set; }
        }

        class lvElementsFoglalas
        {
            public int C_ID { get; set; }
            public string Felhasználónév { get; set; }
            public string Vezetéknév { get; set; }
            public string Keresztnév { get; set; }
            public string Munka { get; set; }
            public string Cégnév { get; set; }
            public DateTime Munkakezdet { get; set; }
            public DateTime Munkavége { get; set; }
            public string Munkakör { get; set; }
        }
        

        //<summary>
        //Ebbe a listába fogjuk betölteni azokat az adatokat amiket a listview-ba fogunk betölteni.
        //<summary>
        List<lvElmenetsMunka> lElementsMunka = new List<lvElmenetsMunka>();
        List<lvElmenetsDiak> lElementsDiak = new List<lvElmenetsDiak>();
        List<lvElmenetsEgyeztetMunka> lElementsEgyeztetMunkaLista = new List<lvElmenetsEgyeztetMunka>();
        List<lvElmenetsEgyeztetDiak> lElementsEgyeztetDiakLista = new List<lvElmenetsEgyeztetDiak>();
        List<lvElementsFoglalas> lElementsFogalalsLista = new List<lvElementsFoglalas>();

        //<summary>
        //A diákok listáját tároljuk amit majd átadunk a kimutatások ablaknak
        //<summary>
        List<kimutatDiakok> diakok = new List<kimutatDiakok>();


        private void miKilepes_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        //<summary>
        //Itt egy további ablak nyílik meg ahol a felhasználók adatait tudjuk módosítani vagy törölni.
        //<summary>

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
        
        private void miKimutatasok_Click(object sender, RoutedEventArgs e)
        {
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                Random r = new Random();
                int i = r.Next(0,50), j = r.Next(0,50);
                diakok.Clear();
                var result = from u in context.Users
                             where u.role == 1 
                             select u;
                foreach(var u in result)
                {
                    diakok.Add(new kimutatDiakok(u.username, i, j));
                    i = r.Next(0,50);
                    j = r.Next(0,50);
               }
            }
            
            wndKimutatasok kimutatasok = new wndKimutatasok(diakok);
            kimutatasok.ShowDialog();
        }

        //<summary>
        //Ha jobbklikkel kattintunk a listába akkor megjelenik egy legördülő menü(contextmenü) amiben további funkciók vannak
        //<summary>
        private void lvDiákMunkaLista_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            OpenContextMenu(ContextMenuMunkaName);
            OpenContextMenu(ContextMenuDiakName);
            OpenContextMenu(ContextMenuEgyezDiakName);
            OpenContextMenu(ContextMenuEgyezMunkaName);
        }

        private void lvEgyezDiákLista_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            OpenContextMenu(ContextMenuMunkaName);
            OpenContextMenu(ContextMenuDiakName);
            OpenContextMenu(ContextMenuEgyezDiakName);
            OpenContextMenu(ContextMenuEgyezMunkaName);
        }

        private void lvEgyezMunkaLista_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            OpenContextMenu(ContextMenuMunkaName);
            OpenContextMenu(ContextMenuDiakName);
            OpenContextMenu(ContextMenuEgyezDiakName);
            OpenContextMenu(ContextMenuEgyezMunkaName);
        }

        //<summary>
        //A contextmenu meghívása az element alapján
        //<summary>
        private void OpenContextMenu(FrameworkElement element)
        {
            if (element.ContextMenu != null)
            {
                element.ContextMenu.PlacementTarget = element;
                element.ContextMenu.IsOpen = true;
            }
        }

        //<summary>
        //A keresés box clearelése beírása és leütésenkénti keresés sql-ből
        //<summary>
        private void tbCegKereses_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbCegKereses.Text == "Cég keresés")
            {
                tbCegKereses.Text = "";
                tbCegKereses.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void tbCegKereses_LostFocus(object sender, RoutedEventArgs e)
        {
            if (tbCegKereses.Text == "")
            {
                tbCegKereses.Text = "Cég keresés";
                tbCegKereses.Foreground = new SolidColorBrush(Colors.Gray);
            }
        }

        private void tbCegKereses_KeyDown(object sender, KeyEventArgs e)
        {
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                lElementsEgyeztetMunkaLista.Clear();
                lElementsMunka.Clear();

                var result1 = from w in context.Work
                              join c in context.Companies on w.company_id equals c.c_id
                              where c.c_del == 1 && c.c_name.StartsWith(tbCegKereses.Text) || c.c_name.EndsWith(tbCegKereses.Text)
                              select new { w, c };

                foreach (var d in result1)
                {
                    lElementsMunka.Add(new lvElmenetsMunka()
                    {
                        ID = d.w.w_id,
                        Munka = d.w.w_name,
                        Cégnév = d.c.c_name,
                        Helyszín = d.c.location,
                        Helyekszáma = d.w.s_number,
                        Munkakezdet = d.w.w_datestart,
                        Munkavége = d.w.w_dateend,
                        Munkakör = d.c.c_description
                    });

                    lElementsEgyeztetMunkaLista.Add(new lvElmenetsEgyeztetMunka()
                    {
                        ID = d.c.c_id,
                        Cégnév = d.c.c_name,
                        Helyszín = d.c.location,
                        Helyekszáma = d.w.s_number,
                        CégMunkakezdete = d.w.w_datestart,
                        CégMunkavége = d.w.w_dateend

                    });
                }
                lvEgyezMunkaLista.ItemsSource = null;
                lvMunkaLista.ItemsSource = null;
                lvMunkaLista.ItemsSource = lElementsMunka;
                lvEgyezMunkaLista.ItemsSource = lElementsEgyeztetMunkaLista;
            }
        }

        //<summary>
        //Az összes lista feltöltése a frissétés gombra kattintva
        //<summary>
        public void ListakFeltoltese()
        {

            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result = from u in context.Users
                             join st in context.StudentTime on u.username equals st.s_username
                            where u.role == 1 && u.del == 1
                             select new { u, st };

                lElementsEgyeztetMunkaLista.Clear();
                lElementsEgyeztetDiakLista.Clear();
                lElementsMunka.Clear();
                lElementsDiak.Clear();
                lElementsFogalalsLista.Clear();

                foreach (var x in result)
                {
                    lElementsDiak.Add(new lvElmenetsDiak()
                    {
                        Felhasználónév = x.u.username,
                        Vezetéknév = x.u.fname,
                        Keresztnév = x.u.lname,
                        Email = x.u.email,
                        Munkakezdés = x.st.datestart,
                        Munkavégzés = x.st.dateend


                    });

                    lElementsEgyeztetDiakLista.Add(new lvElmenetsEgyeztetDiak()
                    {
                        Felhasználónév = x.u.username,
                        Vezetéknév = x.u.lname,
                        Keresztnév = x.u.fname,
                        Diákkezdete = x.st.datestart,
                        Diákvége = x.st.dateend
                    });


                }

                var result1 = from w in context.Work join c in context.Companies on w.company_id equals c.c_id
                              where c.c_del == 1 && w.s_number > 0
                              select new {w, c };
                foreach (var d in result1)
                {
                    lElementsMunka.Add(new lvElmenetsMunka() {

                        ID = d.w.w_id,
                        Munka = d.w.w_name,
                        Cégnév = d.c.c_name,
                        Helyszín = d.c.location,
                        Helyekszáma = d.w.s_number,
                        Munkakezdet = d.w.w_datestart,
                        Munkavége = d.w.w_dateend,
                        Munkakör = d.c.c_description
                    });

                    lElementsEgyeztetMunkaLista.Add(new lvElmenetsEgyeztetMunka()
                    {
                        ID = d.c.c_id,
                        Cégnév = d.c.c_name,
                        Helyszín = d.c.location,
                        Helyekszáma = d.w.s_number,
                        CégMunkakezdete = d.w.w_datestart,
                        CégMunkavége = d.w.w_dateend

                    });
                }

                var result2 = from w in context.Work
                              join sw in context.StudentWork on w.w_id equals sw.work_id
                              join co in context.Companies on  w.company_id equals co.c_id
                              join u in context.Users on sw.student_id equals u.username
                              where sw.sw_del == 1
                              select new { w, sw, u , co};

                foreach (var read in result2)
                {
                    lElementsFogalalsLista.Add(new lvElementsFoglalas()
                    {
                        C_ID = read.w.w_id,
                        Felhasználónév = read.u.username,
                        Vezetéknév = read.u.lname,
                        Keresztnév = read.u.fname,
                        Cégnév = read.co.c_name,
                        Munka = read.w.w_name,
                        Munkakezdet = read.w.w_datestart,
                        Munkavége = read.w.w_dateend,
                        Munkakör = read.w.w_description
                    });
                }

                

            }
            lvDiakLista.ItemsSource = null;
            lvDiakLista.ItemsSource = lElementsDiak;
            lvEgyezDiákLista.ItemsSource = null;
            lvEgyezDiákLista.ItemsSource = lElementsEgyeztetDiakLista;
            lvMunkaLista.ItemsSource = null;
            lvMunkaLista.ItemsSource = lElementsMunka;
            lvEgyezMunkaLista.ItemsSource = null;
            lvEgyezMunkaLista.ItemsSource = lElementsEgyeztetMunkaLista;
            lvFoglalasLista.ItemsSource = null;
            lvFoglalasLista.ItemsSource = lElementsFogalalsLista;
            
        }

        //<summary>
        //A kiválasztott lista elem alapján és a contextmenu parancsára kikeresi az abban az időpontban megfelelő munkákat
        //<summary>
        private void miDiakIdoMunkaCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                lElementsEgyeztetDiakLista.Clear();

                var selectedObj = lvEgyezMunkaLista.SelectedItems[0] as lvElmenetsEgyeztetMunka;

                var result1 = from w in context.Work
                              join c in context.Companies on w.company_id equals c.c_id
                              where c.c_del == 1 && c.c_id == selectedObj.ID
                              select new { w, c };

                var result2 = from u in context.Users
                              join st in context.StudentTime on u.username equals st.s_username
                              where u.del == 1
                              select new { u, st };

                foreach (var d in result1)
                {
                    foreach (var x in result2)
                    {
                        if (d.w.w_dateend >= x.st.dateend && d.w.w_datestart <= x.st.datestart)
                        {
                            lElementsEgyeztetDiakLista.Add(new lvElmenetsEgyeztetDiak()
                            {
                                Felhasználónév = x.u.username,
                                Vezetéknév = x.u.lname,
                                Keresztnév = x.u.fname,
                                Diákkezdete = x.st.datestart,
                                Diákvége = x.st.dateend
                            });
                        }

                    }
                }

                ID = Convert.ToInt32(selectedObj.ID);


            }

            lvEgyezDiákLista.ItemsSource = null;

            lvEgyezDiákLista.ItemsSource = lElementsEgyeztetDiakLista;
        }

        private void miIdopontfoglalDiakCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            var selectedObj = lvEgyezDiákLista.SelectedItems[0] as lvElmenetsEgyeztetDiak;

            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result = from w in context.Work
                             join c in context.Companies on w.company_id equals c.c_id
                             where c.c_del == 1 && c.c_id == ID
                             select new { w, c };

                
                int id_work = 0;
                foreach (var d in result)
                {
                    id_work = d.w.w_id;
                }




                using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
                    {
                        try
                        {
                        StudentJobs stuj = new StudentJobs();
                            stuj.student_id = selectedObj.Felhasználónév;
                            stuj.work_id = id_work;
                            stuj.sj_del = 1;
                            entities.StudentJobs.Add(stuj);
                            entities.SaveChanges();

                        }
                        catch (Exception ex)
                        {
                        
                            MessageBox.Show("A foglalás már létezik. "+ex.Message, "Figyelmeztetés!");
                        }
                    }
                
            
            }
        }
        
        private void miMunkatorolComman_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedObj = lvMunkaLista.SelectedItems[0] as lvElmenetsMunka;
            using (var entities = new DiakszovetkezetEntities())
            {
                var result = new Work { w_id = selectedObj.ID};
                
               var message = MessageBox.Show("Biztosan törli a munkát?", "Figyelmeztetés!", MessageBoxButton.YesNo);

                if (message == MessageBoxResult.Yes)
                {
                    try
                    {
                        entities.Entry(result).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                        MessageBox.Show("Sikeresen törölte a ("+selectedObj.Cégnév+" cég, "+selectedObj.Munka+" munkáját)!", "Törlési Értesítő!");
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Nem sikerült a törlés", "Figyelmeztetés!");
                    }
                }
                
                ListakFeltoltese();
            }
        }

        private void miMunkamodCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            wndMunkaModositas munkaModositas = new wndMunkaModositas();
            munkaModositas.Show();

            var selectedObj = lvMunkaLista.SelectedItems[0] as lvElmenetsMunka;

            using (DiakszovetkezetEntities entites = new DiakszovetkezetEntities())
            {
                var result = from w in entites.Work
                             join c in entites.Companies on w.company_id equals c.c_id
                             where w.w_id == selectedObj.ID
                             select new { w, c };

                foreach (var read in result)
                {
                    munkaModositas.MunkaID = read.w.w_id;
                    munkaModositas.tbCegnév.Text = read.c.c_name;
                    munkaModositas.tbMunkanév.Text = read.w.w_name;
                    munkaModositas.dpMunkakezdet.SelectedDate = read.w.w_datestart;
                    munkaModositas.dpMunkavége.SelectedDate = read.w.w_dateend;
                    munkaModositas.tbMunkakezdet.Text = read.w.w_datestart.ToString("HH:mm:ss");
                    munkaModositas.tbMunkavége.Text = read.w.w_dateend.ToString("HH:mm:ss");
                    munkaModositas.tbHelyekszáma.Text = read.w.s_number.ToString();
                    munkaModositas.tbLeírás.Text = read.w.w_description;
                }

            }
        }

        private void miFoglalTorolCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var selectedObj = lvFoglalasLista.SelectedItems[0] as lvElementsFoglalas;

            using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
            {
                var result = new StudentWork { student_id = selectedObj.Felhasználónév, work_id = selectedObj.C_ID };
                
                var message = MessageBox.Show("Biztosan törli a foglalást?", "Figyelmeztetés!", MessageBoxButton.YesNo);

                if (message == MessageBoxResult.Yes)
                {
                    try
                    {
                       
                            Work w = entities.Work.First(i => i.w_id == selectedObj.C_ID);
                            w.s_number = w.s_number + 1;
                            entities.SaveChanges();
                        
                        entities.Entry(result).State = System.Data.Entity.EntityState.Deleted;
                        entities.SaveChanges();
                        ListakFeltoltese();
                        MessageBox.Show("Sikeresen törölte a (" + selectedObj.Cégnév + " cég, " + selectedObj.Felhasználónév + " felhasználó) foglalását!", "Törlési Értesítő!");
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Nem sikerült a törlés", "Figyelmeztetés!");
                    }
                }

            }
        }

        private void miMunkaRegisztracio_Click(object sender, RoutedEventArgs e)
        {
            //Dani Része
        }

        private void IdopontmodCommand_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            wndIdopontmod idopontmod = new wndIdopontmod();
            var selectedObj = lvDiakLista.SelectedItems[0] as lvElmenetsDiak;
            string[] splitKezd = selectedObj.Munkakezdés.ToString().Split(' ');
            string[] splitVeg = selectedObj.Munkavégzés.ToString().Split(' ');
            idopontmod.tbKezdesIdopont.Text = splitKezd[3];
            idopontmod.tbVegzesIdopont.Text = splitVeg[3];
            idopontmod.dpKezdesDatum.Text = selectedObj.Munkakezdés.ToShortDateString();
            idopontmod.dpVegzesDatum.Text = selectedObj.Munkavégzés.ToShortDateString();
            idopontmod.tbNev.Text = selectedObj.Vezetéknév + " " + selectedObj.Keresztnév;
            idopontmod.FelhasznaloID = selectedObj.Felhasználónév;
            idopontmod.Show();
        }




        private void miFelhasznaloadatmod_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            lvElmenetsDiak item = lvDiakLista.SelectedItem as lvElmenetsDiak;
           
            if (lvDiakLista.SelectedItems.Count != 1 || item == null)
            {
                return;
            }
            else
            {
                 wndUserChange userChange = new wndUserChange(item.Felhasználónév);
                 userChange.ShowDialog();
                
            }
        }

        private void lvDiakLista_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
