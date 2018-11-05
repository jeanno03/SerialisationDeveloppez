using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationDeveloppez.Models
{
    public class Human
    {

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Address Address { get; set; }
        //Pour affichage en double
        [XmlArray("Adresses")]
        [XmlArrayItem("Adresse")]
        public List<Address> Addresses { get; set; }
        //l'élément est facultaif
        [XmlIgnore]
        public bool IsSelected { get; set; }

        //l'élément est ignoré et on met le faux setter a la place
        [XmlIgnore]
        public DateTime DateOfBirth { get; set; }

        [XmlElement("DateDeNaissance")]
        public string DateOfBirthFormatted
        {
            get { return DateOfBirth.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture); }
            set { DateOfBirth = DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture); }
        }

        //Permet de serialiser d'autres classes
        [XmlElement("Propriétaire_Personne", typeof(Person))]
        [XmlElement("Propriétaire_Employé", typeof(Employee))]
        public Person Owner { get; set; }

        //Combinaison possible
        [XmlElement("Personne", typeof(Person))]
        [XmlElement("Employé", typeof(Employee))]
        public List<Person> Contacts { get; set; }

    }
}

