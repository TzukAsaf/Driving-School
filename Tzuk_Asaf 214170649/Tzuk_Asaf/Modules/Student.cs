using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzuk_Asaf.utilities;
using System.Data;
using Tzuk_Asaf.GUI;

namespace Tzuk_Asaf.Modules
{
    public class Student : IEntity
    {
        private string id;
        private string first_name;
        private string last_name;
        private DateTime date_of_birth;
        private string homeTown;
        private string home_address;
        private string teacher_id;
        private string phone_number;
        private string manual_or_automatic;
        private int amount_of_lessons;
        private string passed_test;

        public string Id
        {
            set
            {
                if (!ValidationUtilites.IsLegalId(value))
                    throw new Exception("Illegal id, try again");

                this.id = value;
            }
            get
            {
                return this.id;
            }
        }
        public string First_name
        {
            set
            {
                if (value.Length < 2)
                    throw new Exception("name is too short, try again");

                this.first_name = value;
            }
            get
            {
                return this.first_name;

            }
        }

        public string Last_name
        {
            set
            {
                if (value.Length < 2)
                    throw new Exception("name is too short, try again");

                this.last_name = value;
            }
            get
            {
                return this.last_name;

            }
        }
        public DateTime Date_of_birth
        {
            set
            {
                if (ValidationUtilites.GetAge(value) < 18)
                    throw new Exception("Too young to teach");

                this.date_of_birth = value;

            }
            get
            {
                return this.date_of_birth;

            }
        }
        public string HomeTown
        {
            set
            {
                this.homeTown = value;


            }
            get
            {
                return this.homeTown;
            }
        }

        public string HomeAddress
        {
            set
            {
                this.home_address = value;


            }
            get
            {
                return this.home_address;
            }
        }

        public string Phone_number
        {
            set
            {

                this.phone_number = value;

            }
            get
            {
                return this.phone_number;
            }
        }
        public string Manual_or_automatic
        {

            set
            {

                this.manual_or_automatic = value;
            }
            get
            {
                return this.manual_or_automatic;
            }
        }

        public string Teacher_id
        {
            set
            {
                this.teacher_id = value;

            }
            get
            {
                return this.teacher_id;
            }
        }

        public int Amount_of_lessons
        {
            set
            {
                this.amount_of_lessons = value;
            }

            get
            {
                return this.amount_of_lessons;
            }
        }

        public string Passed_test
        {
            set
            {
                this.passed_test = value;
            }

            get
            {
                return this.passed_test;
            }

        }

        public Student()
        {

        }

        public Student(DataRow dr)
        {
            this.id = Convert.ToString(dr["Student_ID"]);
            this.first_name = Convert.ToString(dr["First_name"]);
            this.last_name = Convert.ToString(dr["Last_name"]);
            this.date_of_birth = Convert.ToDateTime(dr["Date_of_birth"]);
            this.homeTown = Convert.ToString(dr["HomeTown"]);
            this.home_address = Convert.ToString(dr["Home_Address"]);
            this.phone_number = Convert.ToString(dr["Phone_number"]);
            this.manual_or_automatic = Convert.ToString(dr["Manual_or_Automatic"]);
            this.amount_of_lessons = Convert.ToInt32(dr["Amount_of_driving_lessons"]);
            this.passed_test = Convert.ToString(dr["If_passed_Test"]);
            this.teacher_id = Convert.ToString(dr["Teacher_ID"]);


        }
        public void Populate(DataRow dr)
        {
            dr["ID"] = id;
            dr["First_name"] = first_name;
            dr["Last_name"] = last_name;
            dr["Date_of_birth"] = date_of_birth;
            dr["HomeTown"] = homeTown;
            dr["Home_Address"] = home_address;
            dr["Phone_number"] = phone_number;
            dr["Manual_or_Automatic"] = manual_or_automatic;
            dr["Amount_of_driving_lessons"] = amount_of_lessons;
            dr["If_passed_Test"] = passed_test;
            dr["Teacher_ID"] = teacher_id;

        }

    }
}

