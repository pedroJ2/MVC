using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntercambioProyect.Models
{
    public class Asignacion
    {
        public Persona PersonaEntrega { set; get; }
        public Persona PersonaRecibe { set; get; }

        public Asignacion(Persona PersonaEntrega, Persona PersonaRecibe)
        {
            this.PersonaEntrega = PersonaEntrega;
            this.PersonaRecibe = PersonaRecibe;
        }
    }
}