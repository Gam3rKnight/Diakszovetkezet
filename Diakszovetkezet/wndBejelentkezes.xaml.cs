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
    
    public partial class MainWindow : Window
    {
        private structUserData user;
        wndDiakAblak wndDiak;
        wndRendszerAdmin wndAdmin;
      
        public MainWindow()
        {
            InitializeComponent();
            user = new structUserData();
            wndDiak = new wndDiakAblak();
            wndAdmin = new wndRendszerAdmin();
        }

        public structUserData User
        {
            get { return user; }
            set { user = value; }
        }

        private void btBejelentkezes_Click(object sender, RoutedEventArgs e)
        {
            using (DiakszovetkezetEntities context = new DiakszovetkezetEntities())
            {
                var result = from u in context.Users
                             select u;
                bool vane = false;
                

                foreach (var u in result)
                {
                    if (tbFelhasznalonev.Text == u.username && pbJelszo.Password == u.password);
                    {
                        vane = true;
                        user.userName = u.username;
                        user.email = u.email;
                        user.firstName = u.fname;
                        user.lastName = u.lname;
                        user.role = u.role;
                    }
                }
                if (vane&&user.role==1)
                    {
                        wndDiak.ShowDialog();
                    }
                else if(user.role==0)
                {
                    wndAdmin.ShowDialog();
                }
                    else MessageBox.Show("Sikertelen bejelentkezés!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                
            }
        }
    }
}
