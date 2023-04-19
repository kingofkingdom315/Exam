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
        unsafe struct Person
        {
            public String name;
            public String famalyname;
            public DateTime borndate;
        };

        unsafe class PersonnelManagement
        {
            public Person[] person;

            PersonnelManagement(Person[] buf, int n)
            {
                try
                {
                    this.person = buf;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }

            }

            public bool Sort()
            {
                try
                {
                    Person buf;
                    for (int i = 0; i < person.Length; i++)
                    {
                        for (int j = 0; j < person.Length; j++)
                        {
                            if (person[i].borndate < person[j].borndate)
                            {
                                buf = person[i];
                                person[i] = person[j];
                                person[j] = buf;
                            }
                            else if (person[i].borndate == person[j].borndate)
                            {
                                if (person[i].famalyname.CompareTo(person[j].famalyname) < 0)
                                {
                                    buf = person[i];
                                    person[i] = person[j];
                                    person[j] = buf;
                                }
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }

            public bool Save(string filepath)
            {
                try
                {
                    File.Create(filepath);

                    String s = "";

                    for (int i = 0; i < person.Length; i++)
                    {
                        s += person[i].name + ":";
                        s += person[i].famalyname + ":";
                        s += person[i].borndate.ToShortDateString() + ";";
                    }

                    File.WriteAllText(filepath, s);

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    return false;
                }
            }
        };

        static void Main(string[] args)
        {

        }
    }
}
