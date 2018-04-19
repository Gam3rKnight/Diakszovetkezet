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

namespace dikhazva
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }


        //Regisztráló ablak beadása gombnyomásra
        private void btregisztacio_OnClick(object sender, RoutedEventArgs e)
        {
            wndRegisztracio regist = new wndRegisztracio();
            regist.Show();
        }

        // Bejelentkezes
        private void btbelepes_Click(object sender, RoutedEventArgs e)
        {
            // Kitöltöttség ellenörzése
            if (tbfnev.Text.Length==0|| tbjelszo.Password.Length==0)
            {
                MessageBox.Show("Töltse ki a mezőket", "Hiba", MessageBoxButton.OK);
                return;
            }



        }
    }
}
