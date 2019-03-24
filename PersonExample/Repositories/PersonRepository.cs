using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersontestdbContext _context = new PersontestdbContext();

        public void Create(Person person)
        {
            _context.Person.Add(person);
            _context.SaveChanges();
        }

        public List<Person> Read()
        {
            var persons = _context.Person.ToListAsync().Result;
            return persons;
        }

        public Person GetPersonById(int id)
        {
            var person = _context.Person.FirstOrDefault(p => p.Id == id);
            return person;
        }
        //Crud Update
        public void Update(Person person, int id)
        {
            var updatePerson = GetPersonById(id);
            if (updatePerson != null)
            {
                updatePerson.Name = person.Name;
                updatePerson.Age = person.Age;
                _context.Person.Update(person);
            }
            _context.SaveChanges();
        }
        //Crud Delete
        public void Delete(int id)
        {
            var delPerson = _context.Person.FirstOrDefault(p => p.Id == id);
            if (delPerson != null)
                _context.Person.Remove(delPerson);
            _context.SaveChanges();
        }

        public List<Person> GetPersonPhone()
        {
            var persons = _context.Person
                .Include(p => p.Phone)
                .ToListAsync().Result;
            return persons;
        }

        public Person GetPersonByIdAndPhones(int id)
        {
            var person = _context.Person
                .Include(p => p.Phone)
                .Single(p => p.Id == id);

            return person;
        }

    }
}