using System.Windows.Forms;
using System.Xml;

namespace lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                radioButton2.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameRU = textBox4.Text;
            string nameEN = textBox3.Text;

            string surnameRU = textBox1.Text;
            string surnameEN = textBox2.Text;

            string PlacOfBhirthRU = textBox6.Text;
            string PlacOfBhirthEN = textBox5.Text;

            string Authority = textBox7.Text;

            bool man = radioButton1.Checked;
            bool woman = radioButton2.Checked;

            string dateOfBrith = dateTimePicker1.Value.ToShortDateString();
            string dateOfIssue = dateTimePicker2.Value.ToShortDateString();

            CheckSex check = new CheckSex(man, woman);

            string checkedSex = check.Checked();

            Human human = new Human(ref nameRU, ref nameEN, ref surnameRU, ref surnameEN, ref PlacOfBhirthRU,
                ref PlacOfBhirthEN, ref Authority, ref checkedSex, ref dateOfBrith, ref dateOfIssue);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.xml";
            openFileDialog1.FileName = String.Empty;

            openFileDialog1.ShowDialog();
            string filePath;
            filePath = openFileDialog1.FileName;

            UsingXML xml = new UsingXML();
            string[] mass = xml.XmlRead(filePath);
            textBox1.Text = mass[0];
            textBox2.Text = mass[1];
            textBox4.Text = mass[2];
            textBox3.Text = mass[3];
            textBox6.Text = mass[4];
            textBox5.Text = mass[5];
            textBox7.Text = mass[6];
            if (mass[7] == "М/M")
                radioButton1.Checked = true;
            else if (mass[7] == "Ж/F")
                radioButton2.Checked = true;
            dateTimePicker1.Value = DateTime.Parse(mass[8]);
            dateTimePicker2.Value = DateTime.Parse(mass[9]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDoc = new XmlDocument();

            XmlElement rootElement = xmlDoc.CreateElement("Person");
            xmlDoc.AppendChild(rootElement);

            XmlElement nameRuElement = xmlDoc.CreateElement("NameRu");
            nameRuElement.InnerText = textBox4.Text;
            rootElement.AppendChild(nameRuElement);

            XmlElement nameEnElement = xmlDoc.CreateElement("NameEn");
            nameEnElement.InnerText = textBox3.Text;
            rootElement.AppendChild(nameEnElement);

            XmlElement surnameRUElement = xmlDoc.CreateElement("surnameRU");
            surnameRUElement.InnerText = textBox1.Text;
            rootElement.AppendChild(surnameRUElement);

            XmlElement surnameENElement = xmlDoc.CreateElement("surnameEN");
            surnameENElement.InnerText = textBox2.Text;
            rootElement.AppendChild(surnameENElement);

            XmlElement PlacOfBhirthRU = xmlDoc.CreateElement("PlacOfBhirthRU");
            PlacOfBhirthRU.InnerText = textBox6.Text;
            rootElement.AppendChild(PlacOfBhirthRU);

            XmlElement PlacOfBhirthEN = xmlDoc.CreateElement("PlacOfBhirthEN");
            PlacOfBhirthEN.InnerText = textBox5.Text;
            rootElement.AppendChild(PlacOfBhirthEN);

            XmlElement Authority = xmlDoc.CreateElement("Authority");
            Authority.InnerText = textBox7.Text;
            rootElement.AppendChild(Authority);

            bool man = radioButton1.Checked;
            bool woman = radioButton2.Checked;
            CheckSex check = new CheckSex(man, woman);
            XmlElement checkedSex = xmlDoc.CreateElement("checkedSex");
            checkedSex.InnerText = check.Checked();
            rootElement.AppendChild(checkedSex);

            XmlElement dateOfBrith = xmlDoc.CreateElement("dateOfBrith");
            dateOfBrith.InnerText = dateTimePicker1.Value.ToString();
            rootElement.AppendChild(dateOfBrith);

            XmlElement dateOfIssue = xmlDoc.CreateElement("dateOfIssue");
            dateOfIssue.InnerText = dateTimePicker2.Value.ToString();
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
