using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Persona : IComparable
    {
        //Aqui usamos propiedades autoimplementadas (a partir de C# 3.0)
        //Fijate que no hay que definir primero las variables privadas
        public string Name { get; set; }

        public Date Birthday { get; set; }

        public float Height { get; set; }

        public Persona(string Name, Date Birthday, float Height)
        {
            this.Name = Name;
            this.Birthday = Birthday;
            this.Height = Height;
        }

        //Metodo CompareTo de la interfaz IComparable
        public int CompareTo(object obj)
        {
            Persona p = obj as Persona;
            //Comparamos las personas por Fecha de Nacimiento
            return this.Birthday.CompareTo(p.Birthday);
        }

        //Comparamos por nombre en orden alfabético
        public static int CompareByName(object x, object y)
        {
            Persona p1 = x as Persona;
            Persona p2 = y as Persona;
            //En C# se considera que una letra minuscula es menor que cualquier letra mayuscula
            //por eso tenemos que usar la propidad OrdinalIgnoreCase de la clase StringComparer
            return StringComparer.OrdinalIgnoreCase.Compare(p1.Name, p2.Name);
        }

        //Comparamos por altura de menor a mayor
        public static int CompareByHeight(object x, object y)
        {
            Persona p1 = x as Persona;
            Persona p2 = y as Persona;
            //El tipo float tiene un comparador por defecto, que es el que utilizamos
            return p1.Height.CompareTo(p2.Height);
        }

        //Comparamos por fecha de nacimiento como hacíamos en CompareTo
        public static int CompareByBirthday(object x, object y)
        {
            Persona p1 = x as Persona;
            Persona p2 = y as Persona;
            //El tipo float tiene un comparador por defecto, que es el que utilizamos
            return p1.Birthday.CompareTo(p2.Birthday);
        }

        //Comparamos por nombre en orden alfabético a partir d la segunda letra
        public static int CompareFromSecondLetter(object x, object y)
        {
            Persona p1 = x as Persona;
            Persona p2 = y as Persona;
            //Usamos substring para comparar los nombres a partir de la segunda letra
            return StringComparer.OrdinalIgnoreCase.Compare(p1.Name.Substring(1), p2.Name.Substring(1));
        }

    }

}
