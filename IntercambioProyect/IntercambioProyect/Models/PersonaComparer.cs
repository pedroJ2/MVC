using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntercambioProyect.Models
{

    class PersonaComparer : IComparer<Persona>
    {
        private static Random rand = new Random();
        // Implement IComparable CompareTo to provide default sort order.
        internal Random random = new Random();

        public int Compare(Persona x, Persona y)
        {
            int i = random.Next(2);
            if (i == 0)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}