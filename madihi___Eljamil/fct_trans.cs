using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace madihi___Eljamil
{
    class fct_trans
    {
        public int etat_initial { get; set; }

        public char sym { get; set; }

        public int etat_Final { get; set; }

        public fct_trans(int ei,char s,int ef)
        {
            etat_initial = ei;
            sym = s;
            etat_Final = ef;
        }
    }
}
