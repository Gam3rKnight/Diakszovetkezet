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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Diakszovetkezet
{
    /// <summary>
    /// Interaction logic for wndKimutatasok.xaml
    /// </summary>
    public partial class wndKimutatasok : Window
    {
        int elvegzett = 0;
        int elvegzendo = 0;
        float maxWidth = 650.0f;
        float fillTo = 0.8f;
        List<kimutatDiakok> diakok;
        public wndKimutatasok(List<kimutatDiakok> diakok)
        {
            InitializeComponent();
            rcElvegzett.Width = 0;
            rcElvegzendo.Width = 0;
            this.diakok = diakok;
            lbElvegzett.SetValue(Canvas.TopProperty, (double)rcElvegzett.GetValue(Canvas.TopProperty) + rcElvegzett.Height / 2 - lbElvegzett.Height / 2);
            lbElvegzett.SetValue(Canvas.LeftProperty, (double)rcElvegzett.GetValue(Canvas.LeftProperty) + rcElvegzett.Width + 10);
            lbElvegzendo.SetValue(Canvas.TopProperty, (double)rcElvegzendo.GetValue(Canvas.TopProperty) + rcElvegzendo.Height / 2 - lbElvegzendo.Height / 2);
            lbElvegzendo.SetValue(Canvas.LeftProperty, (double)rcElvegzendo.GetValue(Canvas.LeftProperty) + rcElvegzendo.Width + 10);
            List<string> usernames = new List<string>();
            foreach (var u in diakok)
            {
                usernames.Add(u.username);
            }
            cbDiak.DataContext = usernames;
        }

        private void btFrissit_Click(object sender, RoutedEventArgs e)
        {
            if(cbDiak.SelectedItem==null)
            {
                return;
            }
            string username = cbDiak.SelectedItem as string;
            kimutatDiakok diak = diakok.Find(x => x.username == username);
            elvegzett = diak.elvegzettMunkak;
            elvegzendo = diak.elvegzendoMunkak;


            double actualWidthElv = rcElvegzett.Width;
            double actualWidthElvendo = rcElvegzendo.Width;
            double newWidthElv;
            double newWidthElvendo;

            if (elvegzett > elvegzendo)
            {
                newWidthElv = maxWidth * fillTo;
                newWidthElvendo = maxWidth * fillTo / ((double)elvegzett / elvegzendo);
                 }
            else
            {

                newWidthElvendo = maxWidth * fillTo;
                newWidthElv = maxWidth * fillTo / ((double)elvegzendo / elvegzett);
           }
            DoubleAnimation doubleAnimation = new DoubleAnimation(actualWidthElv, newWidthElv, new Duration(TimeSpan.FromMilliseconds(1200)));
            DoubleAnimation doubleAnimation2 = new DoubleAnimation(actualWidthElvendo, newWidthElvendo, new Duration(TimeSpan.FromMilliseconds(1200)));
            rcElvegzett.BeginAnimation(FrameworkElement.WidthProperty, doubleAnimation);
            rcElvegzendo.BeginAnimation(FrameworkElement.WidthProperty, doubleAnimation2);

            lbElvegzett.Content = elvegzett;
            lbElvegzendo.Content = elvegzendo;
            lbElvegzett.SetValue(Canvas.LeftProperty, (double)rcElvegzett.GetValue(Canvas.LeftProperty) + rcElvegzett.Width + 10);
            lbElvegzendo.SetValue(Canvas.LeftProperty, (double)rcElvegzendo.GetValue(Canvas.LeftProperty) + rcElvegzendo.Width + 10);

        }
    }
}
