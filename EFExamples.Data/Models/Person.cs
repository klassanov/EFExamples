using System.Collections.Generic;

namespace EFExamples.Data.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Nickname { get; set; }

        public int Height { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
