using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationDeveloppez.Models
{
    public class Voiture
    {
        public string Modele { get; set; }
        [XmlAttribute("Constructeur")]
        public string Constructeur { get; set; }
        public int Cylindree { get; set; }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            // Commentaire XML
            writer.WriteComment("Hello world from IXmlSerializable !");
            // On ouvre l'élément <Modele>, sans le refermer
            writer.WriteStartElement("Modele");
            // Ajoute de l'attribut Constructeur="..."
            writer.WriteAttributeString("Constructeur", this.Constructeur);
            // On écrit le nom du modèle dans l'élément <Modele>
            writer.WriteString(this.Modele);
            // Fermeture de l'élément <Modele>
            writer.WriteEndElement();
            // Ajout de l'élément Cylindrée avec son contenu
            writer.WriteElementString("Cylindree", this.Cylindree.ToString()); // <Cylindree>...</Cylindree>
        }
    }
}
