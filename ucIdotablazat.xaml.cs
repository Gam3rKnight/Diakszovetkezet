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
    /// Interaction logic for ucIdotablazat.xaml
    /// </summary>
    public partial class ucIdotablazat : UserControl
    {
        public ucIdotablazat()
        {
            InitializeComponent();
        }

        public class lvElmenetsIdotabla
        {
            public DateTime Munkakezdet { get; set; }
            public DateTime Munkavége { get; set; }

        }
        public static List<lvElmenetsIdotabla> lElementsIdotabla = new List<lvElmenetsIdotabla>();

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result = from u in context.StudentTime
                    select u;



                foreach (var d in result)
                    lElementsIdotabla.Add(new lvElmenetsIdotabla
                    {
                        Munkakezdet = Convert.ToDateTime(d.datestart),
                        Munkavége = Convert.ToDateTime(d.dateend),
                    });
                dgido.ItemsSource = lElementsIdotabla;
            }


        }

        private void btSzures_Click(object sender, RoutedEventArgs e)
        {

            DpMettol.Text = "";
            DpMeddig.Text = "";
        }





    }
}
