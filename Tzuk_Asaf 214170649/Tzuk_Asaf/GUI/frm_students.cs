using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tzuk_Asaf.Modules;
using Tzuk_Asaf.db;
using Tzuk_Asaf.Utilities;

namespace Tzuk_Asaf.GUI
{
    public partial class frm_students : Form
    {
        private Student stud;
        private Form parent;

        

        private AddStates state;
        private StudentsDB students;
        public frm_students(Form f)
        {
            InitializeComponent();
            this.parent = f;
            students = new StudentsDB();
            state = AddStates.NAVIGATE;
            Populate(students.GetCurrentRow());
            SetButtonStates(true);
            
        }
        public frm_students()
        {
            InitializeComponent();
            students = new StudentsDB();
            state = AddStates.NAVIGATE;
            Populate(students.GetCurrentRow());
            SetButtonStates(true);
        }

        private void frm_students_Load(object sender, EventArgs e)
        {

        }


        private void Populate(Student student)
        {
            txt_id.Text = student.Id.ToString();
            txtfirstname.Text = student.First_name.ToString();
            txtlastname.Text = student.Last_name.ToString();
            dateTimePicker1.Text = student.Date_of_birth.ToString();
            comboBox1.Text = student.HomeTown.ToString();
            txtPhone.Text = student.Phone_number.ToString();
            txtTeacherId.Text = student.Teacher_id.ToString();
            txtAmountoflessons.Text = Convert.ToString(student.Amount_of_lessons);
            txtHomeAddress.Text = student.HomeAddress.ToString();

            if (student.Manual_or_automatic.ToString() == "Manual")
                radioButtonManual.Checked = true;
            else
                if (student.Manual_or_automatic.ToString() == "Automatic")
                    radioButtonAutomatic.Checked = true;
            if (student.Passed_test == "No" || student.Passed_test == "no")
                radioButtondidntPass.Checked = true;
            else
                radioButtonpass.Checked = true;


        }

      
        private bool UpdateObject(Student student)
        {
            bool ok = true;
            try
            {
                student.Id = txt_id.Text;
                errorProvider1.SetError(txt_id, "");
            }
            catch(Exception ex)
            {
                errorProvider1.SetError(txt_id, ex.Message);
                ok = false;
            }

            try
            {
                student.First_name = txtfirstname.Text;
                errorProvider1.SetError(txtfirstname, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtfirstname, ex.Message);
                ok = false;
            }

            try
            {
                student.Last_name = txtlastname.Text;
                errorProvider1.SetError(txtlastname, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtlastname, ex.Message);
                ok = false;
            }

            try
            {
                student.Date_of_birth = dateTimePicker1.Value;
                errorProvider1.SetError(dateTimePicker1, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(dateTimePicker1, ex.Message);
                ok = false;
            }

            try
            {
                student.HomeTown = comboBox1.Text;
                errorProvider1.SetError(comboBox1, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(comboBox1, ex.Message);
                ok = false;
            }

            try
            {
                student.HomeAddress = txtHomeAddress.Text;
                errorProvider1.SetError(txtHomeAddress, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtHomeAddress, ex.Message);
                ok = false;
            }

            try
            {
                student.Teacher_id = txtTeacherId.Text;
                errorProvider1.SetError(txtTeacherId, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtTeacherId, ex.Message);
                ok = false;
            }

            try
            {
                student.Amount_of_lessons = Convert.ToInt32(txtAmountoflessons.Text);
                errorProvider1.SetError(txtAmountoflessons, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtAmountoflessons, ex.Message);
                ok = false;
            }

            try
            {
                student.Phone_number = txtPhone.Text;
                errorProvider1.SetError(txtPhone, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtPhone, ex.Message);
                ok = false;
            }
            try
            {
                if (radioButtonpass.Checked == true)
                    student.Passed_test = "Yes";
                
               
                errorProvider1.SetError(radioButtonpass, "");

            }
            catch (Exception ex)
            {
                errorProvider1.SetError(radioButtonpass, ex.Message);
                ok = false;
            }

            if (radioButtondidntPass.Checked == true)
                student.Passed_test = "No";
            if (radioButtonAutomatic.Checked == true)
                student.Manual_or_automatic = "Automatic";
            else
                if (radioButtonManual.Checked == true)
                    student.Manual_or_automatic = "Manual";

            return ok;

        }

       

        private void Clear()
        {

            foreach (Control c in Controls)
            {
                if (c is TextBox)
                    (c as TextBox).Text = "";
                if (c is ComboBox)
                    (c as ComboBox).Text = "";
                if (c is DateTimePicker)
                    (c as DateTimePicker).Value = DateTime.Today;
            }
        }

        private void SetButtonStates(bool b)
        {
            btnPrev.Enabled = b;
            btnPrev.Enabled = b;
            btnUpdate.Enabled = b;
            btnNewitem.Enabled = b;
            btnSavechanges.Enabled = !b;
            btnCancel.Enabled = !b;

            txt_id.Enabled = !b;
            txtfirstname.Enabled = !b;
            dateTimePicker1.Enabled = !b;
            txtlastname.Enabled = !b;
            txtPhone.Enabled = !b;
            txtTeacherId.Enabled = !b;
            txtHomeAddress.Enabled = !b;
            comboBox1.Enabled = !b;
            txtAmountoflessons.Enabled = !b;
            radioButtonAutomatic.Enabled = !b;
            radioButtonManual.Enabled = !b;
            radioButtondidntPass.Enabled = !b;
            radioButtonpass.Enabled = !b;

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

    

     

       


       

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            students.MoveNext();
            Populate(students.GetCurrentRow());
        }

        private void radioButtonAutomatic_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frm_students_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            parent.Show();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            students.MovePrev();
            Populate(students.GetCurrentRow());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(false);
            Populate(students.GetCurrentRow());
            SetButtonStates(true);
        }

        

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SetButtonStates(false);
            state = AddStates.UPDATE;
        }

        private void btnSavechanges_Click_1(object sender, EventArgs e)
        {
            Student student = new Student();
            if (UpdateObject(student))

                if (state == AddStates.ADDNEW)
                {
                    students.Add(student);
                }
                else
                {
                    students.UpdateRow(student);

                }
            SetButtonStates(true);
            state = AddStates.NAVIGATE;
            students.Save();
        }

        private void btnNewitem_Click(object sender, EventArgs e)
        {
            Clear();
            state = AddStates.ADDNEW;
            SetButtonStates(false);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            string s = "HomeTown";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
