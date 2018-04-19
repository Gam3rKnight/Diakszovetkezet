using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diakszovetkezet
{

    public class kimutatDiakok
    {

        public string username { get; set; }
        public int elvegzettMunkak { get; set; }
        public int elvegzendoMunkak {get; set;}
        public kimutatDiakok(string username, int elvegzettMunkak, int elvegzendoMunkak)
        {
            this.username = username;
            this.elvegzettMunkak = elvegzettMunkak;
            this.elvegzendoMunkak = elvegzendoMunkak;
        }
    }
}
