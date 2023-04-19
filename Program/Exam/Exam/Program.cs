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

        class PersonnelManagement
        {
            public Person[] person;

            public PersonnelManagement(Person[] buf)
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
                            if (person[i].borndate > person[j].borndate)
                            {
                                buf = person[i];
                                person[i] = person[j];
                                person[j] = buf;
                            }
                            else if (person[i].borndate == person[j].borndate)
                            {
                                if (person[i].famalyname.ToLower().CompareTo(person[j].famalyname.ToLower()) < 0)
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
            int n;
            Person[] pers;
            String path, s;
            int cur = 1,cur1 = 1;

            try
            {
                Console.WriteLine("Введите размер массива");
                n = int.Parse(Console.ReadLine());
                PersonnelManagement management;

                pers = new Person[n];

                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Введите имя");
                    pers[i].name = Console.ReadLine();
                    Console.WriteLine("Введите фамилию");
                    pers[i].famalyname = Console.ReadLine();
                    Console.WriteLine("Введите дату рождения");
                    pers[i].borndate = Convert.ToDateTime(Console.ReadLine());
                }

                management = new PersonnelManagement(pers);

                management.Sort();

                path = "Person.txt";

                management.Save(path);

                s = File.ReadAllText(path);
                Console.WriteLine("№" + cur); cur++;
                Console.Write("имя: "); cur1++;
                foreach (Char c in s)
                {
                    if (c == ';' && cur <= n)
                    {
                        Console.Write("\n№" + cur); cur++;
                    }
                    else if (c == ':')
                    {
                        if (cur1 == 1)
                        {
                            Console.Write("\nимя: "); cur1++;
                        }
                        else if (cur1 == 2)
                        {
                            Console.Write("\nфамилия: "); cur1++;
                        }
                        else if (cur1 == 3)
                        {
                            Console.Write("\nдата рождения: "); cur1 = 1;
                        }
                    }
                    else
                    {
                        Console.Write(c);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                Console.Read();
            }
        }
    }
}
