using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzuk_Asaf.Modules;


namespace Tzuk_Asaf.db
{
    public class Driving_TeachersDB: GeneralDB
    {
        public Driving_TeachersDB() : base("DrivingTeachers", "ID"){}
        public new Driving_Teachers GetCurrentRow()
        {
            return new Driving_Teachers(base.GetCurrentRow());

        }
        public int GetKey()
        {
            int x = currentRow;
            GoToLast();
            int key = Convert.ToInt32(base.GetCurrentRow()[primaryKey]) + 1;
            currentRow = x;
            return key;
        }
        
    }
}
