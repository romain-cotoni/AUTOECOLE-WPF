using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoEcole.Metier
{
    public class Calendrier
    {
        private DateTime dateheure;

        public Calendrier()
        {
        }

        public Calendrier(DateTime dateheure)
        {
            Dateheure = dateheure;
        }

        public DateTime Dateheure { get { return dateheure; } set { dateheure = value; } }
    }
}
