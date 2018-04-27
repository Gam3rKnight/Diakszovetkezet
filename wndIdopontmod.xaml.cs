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
    /// Interaction logic for wndIdopontmod.xaml
    /// </summary>
    public partial class wndIdopontmod : Window
    {
        public wndIdopontmod()
        {
            InitializeComponent();
        }

        
        public string FelhasznaloID;
       
        private void btModositas_Click(object sender, RoutedEventArgs e)
        {
            using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
            {
                try
                {
                    StudentTime st = entities.StudentTime.First(i => i.s_username == FelhasznaloID);
                    
                    st.datestart = Convert.ToDateTime(dpKezdesDatum.Text +" "+ tbKezdesIdopont.Text);
                    st.dateend = Convert.ToDateTime(dpVegzesDatum.Text + " " + tbVegzesIdopont.Text);
                    entities.StudentTime.Add(st);
                    entities.SaveChanges();
                    wndRendszerAdmin wndAdmin = new wndRendszerAdmin();
                    wndAdmin.ListakFeltoltese();
                    MessageBox.Show("A módosítások sikeresen megtörténtek!", "Értesítés!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
