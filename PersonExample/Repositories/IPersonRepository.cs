using System.Collections.Generic;
using PersonDB.Models;

namespace PersonDB.Repositories
{
    interface IPersonRepository
    {
        List<Person> Read();
        Person GetPersonById(int id);
        void Create(Person person);
        void Update(Person person, int id);
        void Delete(int id);
    }
}