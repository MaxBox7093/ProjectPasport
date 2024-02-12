using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace lab1
{
    internal class UsingXML
    {
        private string NameRu;
        private string NameEn;
        private string SurnameRu;
        private string SurnameEn;
        private string PlacOfBhirthRu;
        private string PlacOfBhirthEn;
        private string Authority;
        private string checkedSex;
        private string dateOfBrith;
        private string dateOfIssue;

        public string[] XmlRead() 
        {
            using (XmlReader reader = XmlReader.Create(@"C:\Users\maxim\OneDrive\Рабочий стол\Проектирование машинного интерфейса\lab1\User.xml"))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "NameRu")
                    {
                        this.NameRu = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "NameEn")
                    {
                        this.NameEn = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "surnameRU")
                    {
                        this.SurnameRu = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "surnameEN")
                    {
                        this.SurnameEn = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "PlacOfBhirthRU")
                    {
                        this.PlacOfBhirthRu = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "PlacOfBhirthEN")
                    {
                        this.PlacOfBhirthEn = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "Authority")
                    {
                        this.Authority = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "checkedSex")
                    {
                        this.checkedSex = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "dateOfBrith")
                    {
                        this.dateOfBrith = reader.ReadElementContentAsString();
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "dateOfIssue")
                    {
                        this.dateOfIssue = reader.ReadElementContentAsString();
                    }
                }
                string[] mass = new string[] {NameRu, NameEn, SurnameRu, SurnameEn, PlacOfBhirthRu, PlacOfBhirthEn,
                Authority, checkedSex, dateOfBrith, dateOfIssue};
                return mass;
            }
        }

        public void XmlWrite(ref string nameRU, ref string nameEN, ref string surnameRU, ref string surnameEN, ref string PlaceOfBhirthRU,
                ref string PlaceOfBhirthEN, ref string Authority, ref string checkedSex, ref string dateOfBrith, ref string dateOfIssue) 
        {

        }
    }
}
