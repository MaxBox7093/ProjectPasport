using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace lab1
{
    internal class Human
    {
        private string nameRU { get; set; }
        private string nameEN { get; set; }
        private string surnameRU { get; set; }
        private string surnameEN { get; set; }
        private string PlaceOfBhirthRU { get; set; }
        private string PlaceOfBhirthEN { get; set; }
        private string Authority { get; set; }
        private string checkedSex { get; set; }
        private string dateOfBrith { get; set; }
        private string dateOfIssue { get; set; }

        public Human(ref string nameRU, ref string nameEN, ref string surnameRU, ref string surnameEN, ref string PlaceOfBhirthRU,
                ref string PlaceOfBhirthEN, ref string Authority, ref string checkedSex, ref string dateOfBrith, ref string dateOfIssue)
        {
            this.nameRU = nameRU;
            this.nameEN = nameEN;
            this.surnameRU = surnameRU;
            this.surnameEN = surnameEN;
            this.PlaceOfBhirthRU = PlaceOfBhirthRU;
            this.PlaceOfBhirthEN = PlaceOfBhirthEN;
            this.Authority = Authority;
            this.checkedSex = checkedSex;
            this.dateOfBrith = dateOfBrith;
            this.dateOfIssue = dateOfIssue;
        }

        public bool Validator() 
        {
            bool res = false;
            bool checkNameRu = RegularRU(nameRU);
            bool checkNameEn = RegularEN(nameEN);
            bool checkSurnameRu = RegularRU(surnameRU);
            bool checkSurnameEn = RegularEN(surnameEN);
            bool checkPlaceOfBirthRu = RegularPlaceRU(PlaceOfBhirthRU);
            bool checkPlaceOfBirthEn = RegularPlaceEN(PlaceOfBhirthEN);

            if (!checkNameRu)
                MessageBox.Show("Имя(RU): должно быть на русской раскладке, с заглавной буквы!");
            else if (!checkNameEn)
                MessageBox.Show("Имя(EN): должно быть на английской раскладке, с заглавной буквы!");
            else if (!checkSurnameRu)
                MessageBox.Show("Фамилия(RU): должна быть на русской раскладке, с заглавной буквы! Так же в графе указывается отчество при наличии.");
            else if (!checkSurnameEn)
                MessageBox.Show("Фамилия(EN): должна быть на английской раскладке, с заглавной буквы!");
            else if (!checkPlaceOfBirthRu)
                MessageBox.Show("Место рождения(RU): место рождения должно быть на русской раскладке!");
            else if (!checkPlaceOfBirthEn)
                MessageBox.Show("Место рождения(EN): место рождения должно быть на английской раскладке!");
            else if (checkedSex == "Error")
                MessageBox.Show("Укажите пол гражданина");
            else if (Authority == "")
                MessageBox.Show("Заполните поле 'Орган, выдавший документ'");
            else
                res = true;
            return res;
        }
        private bool RegularRU(string value)
        {
            Regex r = new Regex(@"^[А-Я][а-я]");
            bool result = r.IsMatch(value) ? true : false;
            return result;
        }
        private bool RegularEN(string value)
        {
            Regex r = new Regex(@"^[A-Z][a-z]");
            bool result = r.IsMatch(value) ? true : false;
            return result;
        }
        private bool RegularPlaceRU(string value)
        {
            Regex r = new Regex(@"^[А-Я]*[а-я]");
            bool result = r.IsMatch(value) ? true : false;
            return result;
        }
        private bool RegularPlaceEN(string value)
        {
            Regex r = new Regex(@"^[A-Z]*[a-z]");
            bool result = r.IsMatch(value) ? true : false;
            return result;
        }
    }
}
