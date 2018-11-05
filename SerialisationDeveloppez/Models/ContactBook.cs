using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationDeveloppez.Models
{
    public class ContactBook
    {
        public ContactBook()
        {
            this.Contacts = new List<Person>();
        }

        public Person Owner;
        public List<Person> Contacts { get; set; }
    }
}
