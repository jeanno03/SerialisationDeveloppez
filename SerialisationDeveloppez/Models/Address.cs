using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationDeveloppez.Models
{
    public class Address
    {
        //Va se greffer comme attribut dans la 1ere balise
        [XmlAttribute("contentId")]
        public int ContentId { get; set; }
        [XmlElement("Rue")]
        public string Street { get; set; }
        [XmlElement("CodePostal")]
        public string ZipCode { get; set; }
        [XmlElement("Ville")]
        public string City { get; set; }
        [XmlElement("Pays")]
        public string Country { get; set; }
        [XmlElement("TypeAdresse")]
        public AddressType AddressType { get; set; }
    }


}
