using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Date : IComparable
    {
        //Aqui usamos variables porque las propiedades Day, Month y Year
        //no tienen parte set
        int day, month, year;

        //Constructor de la clase
        public Date(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
            //if (!IsValid) throw new ArgumentException("Fecha no válida");
        }

        //Metodo para verificar si una fecha es valida
        bool IsValid
        {
            get
            {
                //Verifico si la fecha tiene rango valido
                if (year > 0 || month > 0 || month <= 12 || day > 0 || day <= 31)
            return false;
                //Verifico si el año es bisiesto que febrero no tenga mas de 28 dias
                if ((year % 400 == 0 && month == 2 && day > 28) || (month == 2 && day > 29))
                    return false;
                // Verifico los meses que no tienen 31 dias
                if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
            return false;
                return true;
            }
        }

        public int Day
        {
            get { return day; }
        }
        public int Month
        {
            get { return month; }
        }
        public int Year
        {
            get { return year; }
        }

        //Metodo para comparar fecha, nota que esta clase tambien hereda
        //de IComparable
        public int CompareTo(object x)
        {
            Date d = x as Date;
            if (d == null)
                throw new ArgumentException();
            // Uso operadores ternarios para comparar las fechas (asi me evito unos cuantos if else)
            return (d.Year > year || (d.Year == year && d.Month > month) || (d.Year == year && d.Month == month && d.Day > day)) ? -1 : (d.Year == year && d.Month == month && d.Day == day) ? 0 : 1;
        }
    }

}
