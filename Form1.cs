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
            OpenFileDialog open_dialog = new OpenFileDialog();
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            if (open_dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Bitmap originalImage = new Bitmap(open_dialog.FileName);

                    // Создаем новый Bitmap с нужным размером
                    Bitmap resizedImage = new Bitmap(pictureBox1.Width, pictureBox1.Height);

                    // Используем Graphics для отрисовки оригинального изображения на новом Bitmap с нужным размером
                    using (Graphics g = Graphics.FromImage(resizedImage))
                    {
                        g.DrawImage(originalImage, 0, 0, pictureBox1.Width, pictureBox1.Height);
                    }

                    // Освобождаем ресурсы оригинального изображения
                    originalImage.Dispose();

                    // Присваиваем новое изображение pictureBox1
                    pictureBox1.Image = resizedImage;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            UsingXML xml = new UsingXML();

            if(human.Validator() == true)
                xml.XmlWrite(ref nameRU, ref nameEN, ref surnameRU, ref surnameEN, ref PlacOfBhirthRU,
                ref PlacOfBhirthEN, ref Authority, ref checkedSex, ref dateOfBrith, ref dateOfIssue);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var helper = new WordHelper("C:\\Users\\maxim\\OneDrive\\Рабочий стол\\Проектирование машинного интерфейса\\lab1\\Print.docx");
            bool man = radioButton1.Checked;
            bool woman = radioButton2.Checked;
            CheckSex check = new CheckSex(man, woman);
            string patch = @"C:\Users\maxim\OneDrive\Рабочий стол\Проектирование машинного интерфейса\lab1\Image\img.jpg";
            pictureBox1.Image.Save(patch, System.Drawing.Imaging.ImageFormat.Jpeg);
            var items = new Dictionary<string, string>
            {
                {"<NumberPasport>", "51№0030000"},
                {"<Surname>", textBox1.Text + " / " + textBox2.Text},
                {"<Surname2>", "RUS" + textBox2.Text},
                {"<Name>", textBox4.Text + " / " + textBox3.Text},
                {"<Name2>", textBox3.Text},
                {"<DateOfBirth>", dateTimePicker1.Value.ToShortDateString()},
                {"<DateOfIssue>", dateTimePicker2.Value.ToShortDateString()},
                {"<Place>", textBox6.Text + " / " + textBox5.Text},
                {"<Sex>", check.Checked() },
                {"<Authority>", textBox4.Text},
                {"<DateEnd>", dateTimePicker2.Value.AddYears(3).ToShortDateString() }
            };

            helper.Process(items, patch);
        }
    }
}
