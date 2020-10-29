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
    public partial class frm_driving_teacher : Form
    {
        private AddStates state;
        private Driving_TeachersDB teachers;
        private Student teach;
        private Form parent;


        public frm_driving_teacher(Form f)
        {
            InitializeComponent();
       
            this.parent = f;
            teachers = new Driving_TeachersDB();
            state = AddStates.NAVIGATE;
            Populate(teachers.GetCurrentRow());
            SetButtonStates(true);
        }

        public frm_driving_teacher()
        {
            InitializeComponent();

            teachers = new Driving_TeachersDB();
            state = AddStates.NAVIGATE;
            Populate(teachers.GetCurrentRow());
            SetButtonStates(true);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }



        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }



        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void Populate(Driving_Teachers teacher)
        {
            txt_id.Text = teacher.Id.ToString();
            txt_firstname.Text = teacher.First_name.ToString();
            txt_lastname.Text = teacher.Last_name.ToString();
            dateTimePicker1.Text = teacher.Date_of_birth.ToString();
            combo_town.Text = teacher.HomeTown.ToString();
            txt_phone.Text = teacher.Phone_number.ToString();
            if (teacher.Manual_or_automatic.ToString() == "Manual")
                radioButton1.Checked = true;
            else
                if (teacher.Manual_or_automatic.ToString() == "Automatic")
                radioButton2.Checked = true;
            txt_licensenum.Text = teacher.License_number.ToString();

        }
        private bool UpdateObject(Driving_Teachers teacher)
        {
            bool ok = true;
            try
            {
                teacher.Id = txt_id.Text;
                errorProvider1.SetError(txt_id, "");

            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txt_id, ex.Message);
                ok = false;
            }
            try//first name
            {
                teacher.First_name = txt_firstname.Text;
                errorProvider1.SetError(txt_firstname, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txt_firstname, ex.Message);
                ok = false;
            }
            try// last name
            {
                teacher.Last_name = txt_lastname.Text;
                errorProvider1.SetError(txt_lastname, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txt_lastname, ex.Message);
                ok = false;
            }

            try//date of birth
            {
                teacher.Date_of_birth = dateTimePicker1.Value;
                errorProvider1.SetError(dateTimePicker1, "");
            }

            


            catch (Exception ex)
            {
                errorProvider1.SetError(dateTimePicker1, ex.Message);
                ok = false;
            }

            try
            {
                teacher.HomeTown = combo_town.Text;
                errorProvider1.SetError(combo_town, "");

            }
            catch(Exception ex)
            {
                ok = false;

            }
            try//phone number
            {
                teacher.Phone_number = txt_phone.Text;
                errorProvider1.SetError(txt_phone, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txt_phone, ex.Message);
                ok = false;
            }
            //manual or automatic
            if (radioButton1.Checked == true)
                teacher.Manual_or_automatic = "Manual";
            else
                if (radioButton2.Checked == true)
                teacher.Manual_or_automatic = "Automatic";


            try//license number
            {
                teacher.License_number = txt_licensenum.Text;
                errorProvider1.SetError(txt_licensenum, "");
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txt_licensenum, ex.Message);
                ok = false;
            }

            return ok;

        }






        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //UpdateObject(teacher);
            SetButtonStates(false);
            state = AddStates.UPDATE;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            teachers.MoveNext();
            Populate(teachers.GetCurrentRow());

        }
        private void btnPrev_Click(object sender, EventArgs e)
        {
            teachers.MovePrev();
            Populate(teachers.GetCurrentRow());
        }


        private void btnNewitem_Click(object sender, EventArgs e)
        {
            Clear();
            state = AddStates.ADDNEW;
            SetButtonStates(false);

        }
        private void btnSavechanges_Click(object sender, EventArgs e)
        {

            Driving_Teachers teacher = new Driving_Teachers();
            if (UpdateObject(teacher))

                if (state == AddStates.ADDNEW)
                {
                    teachers.Add(teacher);
                }
                else
                {
                    teachers.UpdateRow(teacher);

                }
            SetButtonStates(true);
            state = AddStates.NAVIGATE;
            teachers.Save();





        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SetButtonStates(false);
            Populate(teachers.GetCurrentRow());
            SetButtonStates(true);
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
            btnNext.Enabled = b;
            btnPrev.Enabled = b;
            btnUpdate.Enabled = b;
            btnNewitem.Enabled = b;
            btnSavechanges.Enabled = !b;
            btnCancel.Enabled = !b;

            txt_id.Enabled = !b;
            txt_firstname.Enabled = !b;
            dateTimePicker1.Enabled = !b;
            txt_lastname.Enabled = !b;
            txt_phone.Enabled = !b;
            txt_licensenum.Enabled = !b;           
            txt_address.Enabled = !b;
            combo_town.Enabled = !b;
            radioButton1.Enabled = !b;
            radioButton2.Enabled = !b;

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void frm_driving_teacher_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            parent.Show();
        }
    }
}
