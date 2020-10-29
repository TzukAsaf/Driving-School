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

    public class Driving_Teachers : IEntity
    {
        private string id;
        private string first_name;
        private string last_name;
        private DateTime date_of_birth;
        private string homeTown;
        private string home_address;
        private string phone_number;
        private string manual_or_automatic;
        private string license_number;





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
        public string License_number
        {
            set
            {


                this.license_number = value;
            }
            get
            {
                return this.license_number;
            }
        }

        public Driving_Teachers(DataRow dr)
        {
            this.id = Convert.ToString(dr["ID"]);
            this.first_name = Convert.ToString(dr["First_name"]);
            this.last_name = Convert.ToString(dr["Last_name"]);
            this.date_of_birth = Convert.ToDateTime(dr["Date_of_birth"]);
            this.homeTown = Convert.ToString(dr["HomeTown"]);
            this.home_address = Convert.ToString(dr["Home_Address"]);
            this.phone_number = Convert.ToString(dr["Phone_number"]);
            this.manual_or_automatic = Convert.ToString(dr["Teaching_Manual_or_Automatic"]);
            this.license_number = Convert.ToString(dr["License_number"]);
        }

        public Driving_Teachers()
        {

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
            dr["Teaching_Manual_or_Automatic"] = manual_or_automatic;
            dr["License_number"] = license_number;
        }

    }
}
