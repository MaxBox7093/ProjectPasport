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
            UsingXML xml = new UsingXML();
            string[] mass = xml.XmlRead();
            textBox1.Text = mass[0];
            textBox2.Text = mass[1];
            textBox4.Text = mass[2];
            textBox3.Text = mass[3];
            textBox6.Text = mass[4];
            textBox5.Text = mass[5];
            textBox7.Text = mass[6];
            if (mass[7] == "Ì/M")
                radioButton1.Checked = true;
            else if (mass[7] == "Æ/F")
                radioButton2.Checked = true;
            dateTimePicker1.Value = DateTime.Parse(mass[8]);
            dateTimePicker2.Value = DateTime.Parse(mass[9]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UsingXML xml = new UsingXML();
            
        }
    }
}
