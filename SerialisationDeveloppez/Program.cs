using SerialisationDeveloppez.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationDeveloppez
{

    //https://tlevesque.developpez.com/dotnet/xml-serialization/

    class Program
    {
        static void Main(string[] args)
        {

            List<Address> addresses = new List<Address>();
            Address ad01 = new Address()
            {
                Street = "2, rue du petit pont",
                ZipCode = "75009",
                City = "Paris",
                Country = "France",
                AddressType = AddressType.Bill
            };
            Address ad02 = new Address()
            {
                Street = "2, rue du petit pont",
                ZipCode = "95119",
                City = "Sannois",
                Country = "France",
                AddressType = AddressType.None
            };
            Address ad03 = new Address()
            {
                Street = "2, rue du petit doigt",
                ZipCode = "93000",
                City = "Bobigny",
                Country = "France",
                AddressType = AddressType.Ship,
            };
            addresses.Add(ad01);
            addresses.Add(ad02);
            addresses.Add(ad03);

            Person p = new Person
            {
                Id = 123,
                LastName = "Dupond",
                FirstName = "Jean",
                Address = new Address
                {
                    Street = "1, rue du petit pont",
                    ZipCode = "75005",
                    City = "Paris",
                    Country = "France",
                    AddressType = AddressType.Ship,
                },
                Addresses = addresses,
                DateOfBirth = DateTime.Now
            };

            XmlSerializer xs = new XmlSerializer(typeof(Person));
            using (StreamWriter wr = new StreamWriter("person.xml"))
            {
                xs.Serialize(wr, p);
            }

            List<Person> contactBook = new List<Person>();

            Person p02 = new Person
            {
                Id = 123,
                LastName = "Dupond",
                FirstName = "Jean",
                Address = new Address
                {
                    Street = "1, rue du petit pont",
                    ZipCode = "75005",
                    City = "Paris",
                    Country = "France"
                },
                Addresses = addresses,
                DateOfBirth = DateTime.Now
            };

            Person p03 = new Person
            {
                Id = 123,
                LastName = "Dupond",
                FirstName = "Jean",
                Address = new Address
                {
                    Street = "1, rue du petit pont",
                    ZipCode = "75005",
                    City = "Paris",
                    Country = "France"
                },
                Addresses = addresses,
                DateOfBirth = DateTime.Now
            };

            contactBook.Add(p);
            contactBook.Add(p02);
            contactBook.Add(p03);

            XmlSerializer xs02 = new XmlSerializer(typeof(List<Person>));
            using (StreamWriter wr = new StreamWriter("contactBook.xml"))
            {
                xs02.Serialize(wr, contactBook);
            }


            XmlSerializer xs03 = new XmlSerializer(typeof(Person));
            using (StreamReader rd = new StreamReader("person.xml"))
            {
                Person p04 = xs.Deserialize(rd) as Person;
                Console.WriteLine("Id : {0}", p04.Id);
                Console.WriteLine("Nom : {0} {1}", p04.FirstName, p.LastName);
                Console.WriteLine("Prénom : {0} - Id {1}", p04.FirstName, p04.Id);
            }

            ContactBook contactBook02 = new ContactBook();
            contactBook02.Owner = new Employee
            {
                Id = 3,
                LastName = "Dugenou",
                FirstName = "Gérard",
                Company = "SuperSoft",
                Position = "CEO",
                Salary = 2147483647
            };
            contactBook02.Contacts.Add(
                new Employee
                {
                    Id = 123,
                    LastName = "Dupond",
                    FirstName = "Jean",
                    Company = "SuperSoft",
                    Position = "Developer",
                    Salary = 40000
                }
            );


            XmlSerializer xs05 = new XmlSerializer(typeof(ContactBook));
            using (StreamWriter wr = new StreamWriter("contactBook02.xml"))
            {
                xs05.Serialize(wr, contactBook02);
            }

            Human h10 = new Human
            {
                Id = 123,
                LastName = "Dupond",
                FirstName = "Jean",
                Address = new Address
                {
                    Street = "1, rue du petit pont",
                    ZipCode = "75005",
                    City = "Paris",
                    Country = "France",
                    AddressType = AddressType.Ship,
                },
                Addresses = addresses,
                DateOfBirth = DateTime.Now,
                Owner = p,
                Contacts = contactBook

            };


            XmlSerializer xs10 = new XmlSerializer(typeof(Human));
            using (StreamWriter wr = new StreamWriter("human.xml"))
            {
                xs10.Serialize(wr, h10);
            }

            //On peut surcharger le constructeur pour serialiser tous les objects
            XmlSerializer xs20 = new XmlSerializer(typeof(ContactBook), new Type[] { typeof(Employee) });



            //Permet de redéfinir les attributs
            XmlAttributeOverrides overrides = new XmlAttributeOverrides();

            XmlAttributes attributesOwner = new XmlAttributes();
            attributesOwner.XmlElements.Add(new XmlElementAttribute("Propriétaire_Personne", typeof(Person)));
            attributesOwner.XmlElements.Add(new XmlElementAttribute("Propriétaire_Employé", typeof(Employee)));
            overrides.Add(typeof(ContactBook), "Owner", attributesOwner);

            XmlAttributes attributesContacts = new XmlAttributes();
            attributesContacts.XmlArrayItems.Add(new XmlArrayItemAttribute("Personne", typeof(Person)));
            attributesContacts.XmlArrayItems.Add(new XmlArrayItemAttribute("Employé", typeof(Employee)));
            overrides.Add(typeof(ContactBook), "Contacts", attributesContacts);

            XmlSerializer xs30 = new XmlSerializer(typeof(Human), overrides);
            using (StreamWriter wr = new StreamWriter("human15.xml"))
            {
                xs30.Serialize(wr, h10);
            }

            Voiture v = new Voiture
            {
                Modele = "Coccinelle",
                Constructeur = "Volkswagen",
                Cylindree = 1584
            };

            XmlSerializer xs70 = new XmlSerializer(typeof(Voiture));
            using (StreamWriter wr = new StreamWriter("voiture.xml"))
            {
                xs70.Serialize(wr, v);
            }

            Console.ReadLine();

        }

    }

}
