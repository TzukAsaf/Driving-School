using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tzuk_Asaf.Data;
using Tzuk_Asaf.Modules;

namespace Tzuk_Asaf.db
{
    public class StudentsDB : GeneralDB
    {
        public StudentsDB() : base("Students", "student_ID") { }
        public new Student GetCurrentRow()
        {
            return new Student(base.GetCurrentRow());

        }
        public int GetKey()
        {
            int x = currentRow;
            GoToLast();
            int key = Convert.ToInt32(base.GetCurrentRow()[primaryKey]) + 1;
            currentRow = x;
            return key;
        }


        public DataView GetDataView()
        {
            DAL d = DAL.GetInstance();
            DataTable a = d.GetDisplayTable("Students", "Select Student_ID, First_name,Last_name From customers");
            return new DataView(table);


        }

    }
}
