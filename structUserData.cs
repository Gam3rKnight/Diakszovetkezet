using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diakszovetkezet
{
    public struct structUserData
    {
        private static string UserName;
        private static string Email;
        private static string FirstName;
        private static string LastName;
        private static int Role;

        public string userName { get { return UserName; } set { UserName = value; } }
        public string email { get { return Email; } set { Email = value; } }
        public string firstName { get { return FirstName; } set { FirstName = value; } }
        public string lastName { get { return LastName; } set { LastName = value; } }
        public int role { get { return Role; } set { Role = value; } }
    }
}
