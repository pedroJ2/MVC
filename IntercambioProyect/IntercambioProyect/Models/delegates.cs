//Autor: Tomás J. Ramírez <tom.sarduy@gmail.com>
//http://www.puntopeek.com


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Delegates
{
    class Date : IComparable
    {
        int day, month, year;
        public Date(int day, int month, int year)
        {
            //if (!IsValid) throw new ArgumentException();
            this.day = day;
            this.month = month;
            this.year = year;
        }
        bool IsValid
        {
            get
            {
                if (year <= 0 || month <= 0 || month > 12 || day <= 0 || day > 31)
                    return false;
                if ((year % 400 == 0 && month == 2 && day > 28) || (month == 2 && day > 29))
                    return false;
                if ((month == 4 || month == 6 || month == 9 || month == 11) && day == 31)
                    return false;
                return true;
            }
        }
        public int Day
        {
            get{return day;}
        }
        public int Month
        {
            get{return month;}
        }
        public int Year
        {
            get{return year;}
        }
        public int CompareTo(object x)
        {
            Date d = x as Date;
            if (d == null)
                throw new ArgumentException();
            return (d.Year > year || (d.Year == year && d.Month > month) || (d.Year == year && d.Month == month && d.Day > day) ) ? -1 : ( d.Year == year && d.Month == month && d.Day == day ) ? 0 : 1 ;
        }
    }
    class Email
    {
        Date received, sended;
        int size;
        string sender, subject;

        public Email(string sender, string subject, Date received, Date sended, int size)
        {
            this.sender = sender;
            this.subject = subject;
            this.received = received;
            this.sended = sended;
            this.size = size;
        }
        public Date Received
        {
            get { return received; }
        }
        public Date Sended
        {
            get { return sended; }
        }
        public int Size
        {
            get { return size; }
        }
        public string Subject
        {
            get { return subject; }
        }
        public string Sender
        {
            get { return sender; }
        }
        public static int CompareBySize(object x, object y)
        {
            Email e1 = x as Email;
            Email e2 = y as Email;
            if (e1 != null && e2 != null)
                return e1.Size.CompareTo(e2.Size);
            else
                throw new ArgumentException();
        }
        public static int CompareBySender(object x, object y)
        {
            Email e1 = x as Email;
            Email e2 = y as Email;
            if (e1 != null && e2 != null)
                return e1.Sender.CompareTo(e2.Sender);
            else
                throw new ArgumentException();
        }
        public static int CompareBySubject(object x, object y)
        {
            Email e1 = x as Email;
            Email e2 = y as Email;
            if (e1 != null && e2 != null)
                return e1.Subject.CompareTo(e2.Subject);
            else
                throw new ArgumentException();
        }
        public static int CompareBySended(object x, object y)
        {
            Email e1 = x as Email;
            Email e2 = y as Email;
            if (e1 != null && e2 != null)
                return e1.Sended.CompareTo(e2.Sended);
            else
                throw new ArgumentException();
        }
        public static int CompareByReceived(object x, object y)
        {
            Email e1 = x as Email;
            Email e2 = y as Email;
            if (e1 != null && e2 != null)
                return e1.Received.CompareTo(e2.Received);
            else
                throw new ArgumentException();
        }
    }
    public delegate int Comparison(object x, object y);
    class SortingMethods
    {
        public static void Sort(Email[] emails, Comparison compare)
        {
            Email temp;
            for (int i = 0; i < emails.Length - 1; i++)
                for (int j = 0; j < emails.Length; j++)
                    if (compare(emails[i], emails[j]) > 0)
                    {
                        temp = emails[i];
                        emails[i] = emails[j];
                        emails[j] = temp;
                    }
        }
    }
    #region Testing delegates
    /*
    class Program
    {
        static void Print(Email[] emails)
        {
            for (int i = 0; i < emails.Length; i++)
                Console.WriteLine("Sender:{0}, Subject:{1}, ReceivedDate: {2}/{3}/{4}, SendedDate: {5}/{6}/{7}, Size: {8}", emails[i].Sender, emails[i].Subject, emails[i].Received.Day, emails[i].Received.Month, emails[i].Received.Year, emails[i].Sended.Day, emails[i].Sended.Month, emails[i].Sended.Year, emails[i].Size);
        }
        static void Main(string[] args)
        {
            Email[] emails = new Email[5];
            emails[0] = new Email("tatá", "te amo", new Date(2, 5, 2008), new Date(2, 5, 2008), 100);
            emails[1] = new Email("lisbeth", "hola", new Date(12, 6, 2008), new Date(12, 6, 2008), 600);
            emails[2] = new Email("reinier", "mi nene hermosa", new Date(2, 5, 2009), new Date(2, 5, 2009), 1000);
            emails[3] = new Email("yile", "sobre lp", new Date(23, 5, 2008), new Date(23, 5, 2008), 50);
            emails[4] = new Email("yosly", "importante", new Date(2, 9, 2008), new Date(2, 9, 2008), 100);
            //SortingMethods.Sort(emails, new Comparison(Email.CompareBySender));
            SortingMethods.Sort(emails, Email.CompareBySender);
            Print(emails);
            Console.ReadLine();
        }
    }
    */
    #endregion

    class Program
    {
        static void Print(Email[] emails)
        {
            for (int i = 0; i < emails.Length; i++)
                Console.WriteLine("Sender:{0}, Subject:{1}, ReceivedDate: {2}/{3}/{4}, SendedDate: {5}/{6}/{7}, Size: {8}", emails[i].Sender, emails[i].Subject, emails[i].Received.Day, emails[i].Received.Month, emails[i].Received.Year, emails[i].Sended.Day, emails[i].Sended.Month, emails[i].Sended.Year, emails[i].Size);
        }
        static void Main(string[] args)
        {
            Email[] emails = new Email[5];
            emails[0] = new Email("tatá", "te amo", new Date(2, 5, 2008), new Date(2, 5, 2008), 100);
            emails[1] = new Email("lisbeth", "hola", new Date(12, 6, 2008), new Date(12, 6, 2008), 600);
            emails[2] = new Email("reinier", "mi nene hermosa", new Date(2, 5, 2009), new Date(2, 5, 2009), 1000);
            emails[3] = new Email("yile", "sobre lp", new Date(23, 5, 2008), new Date(23, 5, 2008), 50);
            emails[4] = new Email("yosly", "importante", new Date(2, 9, 2008), new Date(2, 9, 2008), 100);
        
            SortingMethods.Sort(emails,
                delegate(object x, object y)
                {
                    Email e1 = x as Email;
                    Email e2 = y as Email;
                    if (e1 == null || e2 == null)
                        throw new ArgumentException();
                    return e1.Subject.CompareTo(e2.Subject);
                }
            );
            Print(emails);
            Console.ReadLine();
        }
    }
}
