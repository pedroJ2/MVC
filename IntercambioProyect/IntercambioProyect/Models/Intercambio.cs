using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntercambioProyect.Models
{
    public class Intercambio
    {
        private List<Persona> lstPerson;
        private List<Asignacion> result;

        public Intercambio()
        {
            result = new List<Asignacion>();
            lstPerson = new List<Persona>();
        }

        public void setPersons(List<Persona> persona)
        {
            foreach (var Persona in persona)
            {
                lstPerson.Add(Persona);
            }
        }

        public List<Asignacion> OrganizarIntercambio()
        {
            lstPerson.Sort(new PersonaComparer());
            List<Asignacion> asigna = new List<Asignacion>();

            foreach (var asignacion in lstPerson.Select((Value, Index) => new { Value, Index }))
            {
                if (asignacion.Value.Equals(lstPerson.Last()))
                {
                    asigna.Add(new Asignacion(asignacion.Value, lstPerson.First()));
                }
                else
                {
                    asigna.Add(new Asignacion(asignacion.Value, lstPerson[asignacion.Index + 1]));
                }

            }

            return asigna;
        }
    }
}