using Diakszovetkezet;
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

namespace tanuloablak
{
    /// <summary>
    /// Interaction logic for wndErtesites.xaml
    /// </summary>
    public partial class wndErtesites : Window
    {
        

        public wndErtesites()
        {
            InitializeComponent();
        }
        structUserData userData;

        public class lvElementsMunkaErtetsites
        {
            public int ID { get; set; }
            public string Munka { get; set; }
            public string Cégnév { get; set; }
            public string Helyszín { get; set; }
            public DateTime Munkakezdet { get; set; }
            public DateTime Munkavége { get; set; }
            public string Munkakör { get; set; }
        }

        private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
        {
            List<lvElementsMunkaErtetsites> lElementsMunkaErtesites = new List<lvElementsMunkaErtetsites>();

            using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
            {
                var result = from sj in entities.StudentJobs
                             join w in entities.Work on sj.work_id equals w.w_id
                             join u in entities.Users on sj.student_id equals u.username
                             join c in entities.Companies on w.company_id equals c.c_id
                             where u.username == userData.userName && sj.sj_del == 1
                             select new { sj, w, u, c };

                try
                {
                    foreach (var d in result)
                    {
                        lElementsMunkaErtesites.Add(new lvElementsMunkaErtetsites
                        {
                            ID = d.w.w_id,
                            Munka = d.w.w_name,
                            Cégnév = d.c.c_name,
                            Helyszín = d.c.location,
                            Munkakezdet = d.w.w_datestart,
                            Munkavége = d.w.w_dateend,
                            Munkakör = d.w.w_description
                        });
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show(userData.userName+" Felhasznlóban van!");
                }

                dgkeres.ItemsSource = null;
                dgkeres.ItemsSource = lElementsMunkaErtesites;
            }
        }

        private void btElfogad_Click(object sender, RoutedEventArgs e)
        {
            var selectedObj = dgkeres.SelectedItems[0] as lvElementsMunkaErtetsites;

            using (DiakszovetkezetEntities entities = new DiakszovetkezetEntities())
            {
                var result = from w in entities.Work
                             join c in entities.Companies on w.company_id equals c.c_id
                             where c.c_del == 1 && w.w_id == selectedObj.ID
                             select new { w, c };

                try
                {
                    StudentWork stuw = new StudentWork();
                    stuw.student_id = userData.userName;
                    stuw.work_id = selectedObj.ID;
                    stuw.sw_del = 1;
                    stuw.sw_date = DateTime.Now;
                    entities.StudentWork.Add(stuw);
                    entities.SaveChanges();

                    foreach (var c in result)
                    {
                        Work w = entities.Work.First(i => i.w_id == c.w.w_id);
                        w.s_number = c.w.s_number - 1;
                        entities.SaveChanges();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Nem sikerült a folalás!"+ex.Message);
                }
            }
        }
    }
}
