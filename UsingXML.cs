using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace lab1
{
    internal class UsingXML
    {
        private string NameRu = "";
        private string NameEn = "";
        private string SurnameRu = "";
        private string SurnameEn = "";
        private string PlacOfBhirthRu = "";
        private string PlacOfBhirthEn = "";
        private string Authority = "";
        private string checkedSex = "";
        private string dateOfBrith = "";
        private string dateOfIssue = "";

        public string[] XmlRead(string filepath) 
        {
            using (XmlReader reader = XmlReader.Create(filepath))
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

        public void XmlWrite(ref string nameRUW, ref string nameENW, ref string surnameRUW, ref string surnameENW, ref string PlaceOfBhirthRUW,
                ref string PlaceOfBhirthENW, ref string AuthorityW, ref string checkedSexW, ref string dateOfBrithW, ref string dateOfIssueW) 
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("Person");
            xmlDoc.AppendChild(rootElement);

            XmlElement nameRuElement = xmlDoc.CreateElement("NameRu");
            nameRuElement.InnerText = nameRUW;
            rootElement.AppendChild(nameRuElement);

            XmlElement nameEnElement = xmlDoc.CreateElement("NameEn");
            nameEnElement.InnerText = nameENW;
            rootElement.AppendChild(nameEnElement);

            XmlElement surnameRUElement = xmlDoc.CreateElement("surnameRU");
            surnameRUElement.InnerText = surnameRUW;
            rootElement.AppendChild(surnameRUElement);

            XmlElement surnameENElement = xmlDoc.CreateElement("surnameEN");
            surnameENElement.InnerText = surnameENW;
            rootElement.AppendChild(surnameENElement);

            XmlElement PlacOfBhirthRU = xmlDoc.CreateElement("PlacOfBhirthRU");
            PlacOfBhirthRU.InnerText = PlaceOfBhirthRUW;
            rootElement.AppendChild(PlacOfBhirthRU);

            XmlElement PlacOfBhirthEN = xmlDoc.CreateElement("PlacOfBhirthEN");
            PlacOfBhirthEN.InnerText = PlaceOfBhirthENW;
            rootElement.AppendChild(PlacOfBhirthEN);

            XmlElement Authority = xmlDoc.CreateElement("Authority");
            Authority.InnerText = AuthorityW;
            rootElement.AppendChild(Authority);

            XmlElement checkedSex = xmlDoc.CreateElement("checkedSex");
            checkedSex.InnerText = checkedSexW;
            rootElement.AppendChild(checkedSex);

            XmlElement dateOfBrith = xmlDoc.CreateElement("dateOfBrith");
            dateOfBrith.InnerText = dateOfBrithW;
            rootElement.AppendChild(dateOfBrith);

            XmlElement dateOfIssue = xmlDoc.CreateElement("dateOfIssue");
            dateOfIssue.InnerText = dateOfIssueW;
            rootElement.AppendChild(dateOfIssue);

            // Показываем диалоговое окно для сохранения файла
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    // Сохраняем документ XML в выбранный файл
                    xmlDoc.Save(saveFileDialog1.FileName);
                    MessageBox.Show("Файл успешно сохранен.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении файла: " + ex.Message);
                }
            }
        }
    }
}
