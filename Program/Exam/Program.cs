using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exam
{
    class Program
    {
        struct Person
        {
            String name;
            String famalyname;
            DateTime borndate;
        };

        class PersonnelManagement
        {
            Person*[] person;

            PersonnelManagement(Person[] buf,int n)
            {
                person = new Person[n];

                person = buf;
            }

        };

        static void Main(string[] args)
        {
            
        }
    }
}
