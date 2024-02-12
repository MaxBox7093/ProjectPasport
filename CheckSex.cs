using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class CheckSex
    {
        private bool man;
        private bool woman;

        public CheckSex(bool man, bool checkbox2)
        {
            this.man = man;
            this.woman = checkbox2;
        }

        private string CheckError() 
        {
            string message = "Укажите пол гражданина!";
            string error = "Error";

            if (man == false & woman == false)
            {
                MessageBox.Show(message);
                return error;
            }
            else 
            {
                string check = CheckedSex();
                return check;
            }
        }

        private string CheckedSex() 
        {
            if (man == true)
                return "М/M";
            else
                return "Ж/F";
        }

        public string Checked()
        {
            return CheckError();
        }
    }
}
