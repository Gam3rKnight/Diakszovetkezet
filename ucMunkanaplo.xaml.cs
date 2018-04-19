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
using Diakszovetkezet;

namespace tanuloablak
{
    /// <summary>
    /// Interaction logic for ucMunkanaplo.xaml
    /// </summary>
    public partial class ucMunkanaplo : UserControl
    {
        public ucMunkanaplo()
        {
            InitializeComponent();
        }
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
        public static List<lvElmenetsMunka> lElementsMunka = new List<lvElmenetsMunka>();

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
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
    }
}
