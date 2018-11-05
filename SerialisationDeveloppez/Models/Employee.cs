using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationDeveloppez.Models
{
    public class Employee:Person
    {
        public string Company { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
    }
}
