using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;

namespace Diakszovetkezet
{
    class DBConnection
    {
        string connectionString;
        SqlConnection myConnection;
        structUserData userData;
        public DBConnection()
        {
            connectionString = "Server=DESKTOP-4U577HS;Database=Diakszovetkezet;Trusted_Connection=True;";
            myConnection = new SqlConnection(connectionString);
            MessageBox.Show(myConnection.State.ToString(), "Info", MessageBoxButton.OK);
        }
    }
}
