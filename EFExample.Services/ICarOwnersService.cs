using EFExamples.Data.Models;
using System.Collections.Generic;

namespace EFExample.Services
{
    public interface ICarOwnersService
    {
        void AddPerson();

        List<Person> GetAllPeople();
    }
}
