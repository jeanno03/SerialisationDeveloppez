using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationDeveloppez.Models
{
    //Permet de serialiser en cas d'héritage
    [XmlInclude(typeof(Employee))]
    [XmlRoot("Personne")]
    public class Person
    {
        //Va se greffer dans la 1ere balise
        [XmlAttribute("Id")]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public Address Address { get; set; }
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
    }
}
