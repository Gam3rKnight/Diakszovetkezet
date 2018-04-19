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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Diakszovetkezet
{
    /// <summary>
    /// Interaction logic for ucKereses.xaml
    /// </summary>
    public partial class ucKereses : UserControl
    {
        public ucKereses()
        {
            InitializeComponent();

        }
        public int selectedindex = 0;
       wndBejelentkezes bejelentkezes = new wndBejelentkezes();
        public class lvElmenetsMunka
        {
            public string Munka { get; set; }
            public string Cégnév { get; set; }
            public string Helyszín { get; set; }
            public string Helyekszáma { get; set; }
            public DateTime Munkakezdet { get; set; }
            public DateTime Munkavége { get; set; }
            public string Munkakör { get; set; }

        }

        public class lvElmenetsJelentkez
        {
            public string Név { get; set; }
            public string Munka { get; set; }
            public string Cégnév { get; set; }
            public string Helyszín { get; set; }
            public string Helyekszáma { get; set; }
            public DateTime Munkakezdet { get; set; }
            public DateTime Munkavége { get; set; }
            public string Munkakör { get; set; }

        }
        public static List<lvElmenetsMunka> lElementsMunka = new List<lvElmenetsMunka>();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result1 = from w in context.Work
                    join c in context.Companies on w.company_id equals c.c_id
                    where c.c_del == 1
                    select new { w, c };
                foreach (var d in result1)
                {
                    lElementsMunka.Add(new lvElmenetsMunka()
                    {

                        Munka = d.w.w_name,
                        Cégnév = d.w.w_name,
                        Helyszín = d.c.location,
                        Helyekszáma = d.w.s_number.ToString(),
                        Munkakezdet = Convert.ToDateTime(d.w.w_datestart),
                        Munkavége = Convert.ToDateTime(d.w.w_dateend),
                        Munkakör = d.c.c_description
                    });
                }
                dgkeres.ItemsSource = lElementsMunka;
            }




        }

        private void btSzures_Click(object sender, RoutedEventArgs e)
        {

            List<lvElmenetsMunka> lSzurt = new List<lvElmenetsMunka>();
            var date1 = Convert.ToDateTime(DpMettol.Text);
            var date2 = Convert.ToDateTime(DpMeddig.Text);

            foreach (var a in lElementsMunka)
            {
                if (a.Munkakezdet < date1 && a.Munkavége > date2)
                {
                    lSzurt.Add(a);
                }
            }

            dgkeres.ItemsSource = lSzurt;
        }

        private void BtJelentkez_OnClick(object sender, RoutedEventArgs e)
        {
            List<lvElmenetsJelentkez> lJelentkez = new List<lvElmenetsJelentkez>();

            lJelentkez.Add(new lvElmenetsJelentkez()
            {
                
                Munka = lElementsMunka[selectedindex].Munka,
                Cégnév = lElementsMunka[selectedindex].Cégnév,
                Helyszín = lElementsMunka[selectedindex].Helyszín,
                Munkakezdet = lElementsMunka[selectedindex].Munkakezdet,
                Munkavége = lElementsMunka[selectedindex].Munkavége,
                Munkakör = lElementsMunka[selectedindex].Munkakör,
            });

            // uj tábla szükséges a munka igények tárolására?



        }

        private void Dgkeres_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedindex = dgkeres.SelectedIndex;
        }


    }
}
