using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo el array de personas que voy a ordenar
            /*Persona[] personas = new Persona[]
            {
             new Persona("Tom", new Date(1, 11, 1988), 169),
             new Persona("Jio", new Date(31, 8, 1990), 170),
             new Persona("Simone", new Date(7, 9, 1991), 165),
             new Persona("Ruben", new Date(22, 10, 1988), 165)
            };

            //Ordeno el array de personas
            Sort(personas);

            //Imprimo las personas despues de ordenarlas
            foreach (Persona p in personas)
            {
                Console.WriteLine("Nombre: {0}   Date: {1}, {2}, {3}, Height: {4}",
                p.Name, p.Birthday.Day, p.Birthday.Month, p.Birthday.Year, p.Height);
            }
            Console.ReadKey();*/


            //Opcion de Delegate 
            Persona[] personas = new Persona[]
              {
                  new Persona("Tom", new Date(1, 11, 1988), 169),
                  new Persona("Jio", new Date(31, 8, 1990), 170),
                  new Persona("Simone", new Date(7, 9, 1991), 165),
                  new Persona("Ruben", new Date(22, 10, 1988), 165)
              };

            //Pasamos como parámetro al delegado el método CompareByName
            Sort(personas, Persona.CompareByName);
            //También se puede usar el nombre del método directamente sin pasarlo como parámetro
            //Sort(personas, new Comparison(Persona.CompareByName));

            Console.WriteLine("Ordenando las personas en orden alfabético");
            foreach (Persona p in personas)
            {
                Console.WriteLine("Nombre: {0}", p.Name);
            }

            Console.WriteLine();
            Console.WriteLine("Ordenando las personas por fecha de nacimiento");
            //Pasamos como parámetro al delegado el método CompareByBirthday
            Sort(personas, Persona.CompareByBirthday);
            foreach (Persona p in personas)
            {
                Console.WriteLine("Date: {0}, {1}, {2}", p.Birthday.Day, p.Birthday.Month, p.Birthday.Year);
            }

            Console.WriteLine();
            Console.WriteLine("Ordenando las personas por altura");
            //Pasamos como parámetro al delegado el método CompareByHeight
            Sort(personas, Persona.CompareByHeight);
            foreach (Persona p in personas)
            {
                Console.WriteLine("Height: {0}", p.Height);
            }

            Console.WriteLine();
            Console.WriteLine("Ordenamiento de Persona  por orden alfabético a partir d la segunda letra");

            Sort(personas, Persona.CompareFromSecondLetter);

            foreach (Persona p in personas) {
                Console.WriteLine("Name {0}",p.Name);
            }
            Console.ReadKey();

        }

        /*
        Metodo de ordenacion utilizando IComparable
        public void Sort(IComparable[] items)
        {
            for (i = 0; i < items.length; i++)
            {
                Icomparable tmp = items[i];
                items[i] = items[j];
                items[j] = tmp;
            }
        }*/

        //Metodo de ordenacion sencillo
        //Puedes ver otros métodos de ordenación en post anteriores:

        static void Sort(Persona[] items, Comparison compare)
        {
            for (int i = 0; i < items.Length - 1; i++)
                for (int j = i + 1; j < items.Length; j++)
                    //Comparamos usando el delegado 			
                    if (compare(items[i], items[j]) > 0)
                    {
                        Persona tmp = items[i];
                        items[i] = items[j];
                        items[j] = tmp;
                    }
        }

        public delegate int Comparison(object x, object y);

        



    }


}

