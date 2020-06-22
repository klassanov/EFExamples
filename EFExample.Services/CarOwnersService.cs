using EFExamples.Data;
using EFExamples.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFExample.Services
{
    public class CarOwnersService : ICarOwnersService
    {
        public List<Person> GetAllPeople()
        {
            List<Person> people = null;
            using (CarOwnersContext context = new CarOwnersContext())
            {
                people = context.People.ToList();
            }
            return people;
        }

        public void AddPerson()
        {
            using (CarOwnersContext context = new CarOwnersContext())
            {
                context.People.Add(new Person { Age = 3, Name = "Pesho" });
                context.SaveChanges();
            }
        }
    }
}
