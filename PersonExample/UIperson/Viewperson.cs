using System;
using System.Collections.Generic;
using PersonDB.Models;
using PersonDB.Repositories;


namespace PersonDB.UIperson
{
    internal class ViewPerson
    {
        // shows data from the list

        public static void PrintToScreen(List<Person> persons)
        {
            Console.WriteLine("Id, Name, Age\n" +
                              "-------------------\n");
            foreach (var p in persons)
            {
                Console.WriteLine(p.ShowData());
            }
        }

        public static void PrintToScreen(Person person)
        {
            Console.WriteLine($"{person.Name}, {person.Age}");
            if (person.Phone.Count == 0)
                Console.WriteLine("No Phone!");
            foreach (var phnPhone in person.Phone)
            {
                Console.WriteLine($"\n   {phnPhone}");
            }
            Console.WriteLine("\n-------------\n");
        }
        public static void AddPerson()
        {
            var personRepository = new PersonRepository();
            Console.Write("Give name: ");
            var name = Console.ReadLine();
            Console.Write("Give age: ");
            var age = short.Parse(Console.ReadLine());

            var phones = new List<Phone>();
            string addAnother;
            Console.WriteLine("Add phones");
            do
            {

                Console.Write("Write phone type: ");
                var type = Console.ReadLine();
                Console.Write("Write phone number: ");
                var phone = Console.ReadLine();

                var addPhone = new Phone(type, phone);

                Console.Write("Add another phone Y/N?: ");
                addAnother = Console.ReadLine();

            } while (addAnother != null && addAnother.ToUpper() != "N");

            var addPerson = new Person(name, age, phones);
            personRepository.Create(addPerson);
        }
    }
}