using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_add_staff : Form
    {
        BLL_staff BLL;
        string ID;
        int mode;
        public frm_add_staff(int mode, string selectedID = "")
        {
            InitializeComponent();
            BLL = new BLL_staff();
            this.mode = mode;
            ID = selectedID;
            if (mode == 1)
            {
                ID = selectedID;
                btn_add.Enabled = false;
                DataRow selectedRow = BLL.GetRecord(ID);
                txt_name.Text = selectedRow["name_staff"].ToString();
                string gender = selectedRow["gender"].ToString().Trim();
                if (gender == "Male")
                {
                    cbo_gender.SelectedItem = "Male";
                }
                else { cbo_gender.SelectedItem = "Female"; }
                txt_address.Text = selectedRow["address"].ToString();
                txt_gmail.Text = selectedRow["gmail"].ToString();
                txt_phone.Text = selectedRow["phone"].ToString();
                if (DateTime.TryParse(selectedRow["start_date"].ToString(), out DateTime startDate))
                {
                    txt_date.Text = startDate.ToString("dd/MM/yyyy");
                }
                else
                {
                    txt_date.Text = string.Empty; 
                }
                txt_username.Text = selectedRow["username"].ToString();
                txt_password.Text = selectedRow["password"].ToString();
                string role = selectedRow["type_staff"].ToString();
                if (role == "Staff")
                {
                    cbo_role.SelectedItem = "Staff";
                }
                else { cbo_role.SelectedItem = "Management"; }
                string ac = selectedRow["is_active"].ToString();
                if (ac == "0" || ac =="False")
                {
                    cbo_active.SelectedItem = "0";
                }
                else if (ac == "1" || ac == "True")
                {
                    cbo_active.SelectedItem = "1";
                }
            }
            else
            {
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                txt_date.Text = DateTime.Today.ToString("dd/MM/yyyy");
            }
        }
        bool Check()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Please enter a staff name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_name.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbo_gender.Text) || (cbo_gender.Text != "Male" && cbo_gender.Text != "Female"))
            {
                MessageBox.Show("Please select a valid gender (Male or Female)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_gender.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_address.Text))
            {
                MessageBox.Show("Please enter an address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_address.Focus();
                return false;
            }
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (string.IsNullOrWhiteSpace(txt_gmail.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txt_gmail.Text, emailPattern))
            {
                MessageBox.Show("Please enter a valid email address (e.g., user@example.com)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_gmail.Focus();
                txt_gmail.Clear();
                return false;
            }
            string phonePattern = @"^0(3[2-9]|5[6-9]|7[0-9]|8[1-9]|9[0-4|6-9])[0-9]{7}$";
            if (string.IsNullOrWhiteSpace(txt_phone.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txt_phone.Text, phonePattern))
            {
                MessageBox.Show("Please enter a valid Vietnamese phone number (10 digits)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_phone.Focus();
                txt_phone.Clear();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_date.Text) || !DateTime.TryParseExact(txt_date.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime startDate))
            {
                MessageBox.Show("Please enter a valid start date (dd/MM/yyyy)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_date.Focus();
                txt_date.Clear();
                return false;
            }
            if (startDate > DateTime.Today)
            {
                MessageBox.Show("Start date cannot be in the future!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_date.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_username.Text))
            {
                MessageBox.Show("Please enter a username!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_username.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_password.Text) || txt_password.Text.Length < 6)
            {
                MessageBox.Show("Please enter a password (at least 6 characters)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_password.Focus();
                txt_password.Clear();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbo_active.Text))
            {
                MessageBox.Show("Please select an active status!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_active.Focus();
                return false;
            }
            return true;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    DateTime startDate = DateTime.ParseExact(txt_date.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    BLL.AddRecord(txt_name.Text, cbo_gender.Text, txt_address.Text, txt_gmail.Text, txt_phone.Text, startDate, txt_username.Text, txt_password.Text, cbo_role.Text, cbo_active.Text);
                    MessageBox.Show("Staff added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Phone number already exists"))
                    {
                        MessageBox.Show("This phone number already exists! Please use a different phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_phone.Clear();
                        txt_phone.Focus();
                    }
                    else if (ex.Message.Contains("Email already exists"))
                    {
                        MessageBox.Show("This email already exists! Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_gmail.Clear();
                        txt_gmail.Focus();
                    }
                    else if (ex.Message.Contains("Username already exists"))
                    {
                        MessageBox.Show("This username already exists! Please use a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_username.Clear();
                        txt_username.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Error adding staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (Check()) 
            {
                if (DateTime.TryParseExact(txt_date.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime startDate))
                {
                    try
                    {
                        BLL.UpdateRecord(ID, txt_name.Text, cbo_gender.Text, txt_address.Text, txt_gmail.Text, txt_phone.Text, startDate, txt_username.Text, txt_password.Text, cbo_role.Text, cbo_active.Text);
                        MessageBox.Show("Staff updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Contains("Phone number already exists"))
                        {
                            MessageBox.Show("This phone number is already used by another staff! Please use a different phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_phone.Focus();
                        }
                        else if (ex.Message.Contains("Email already exists"))
                        {
                            MessageBox.Show("This email is already used by another staff! Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_gmail.Focus();
                        }
                        else if (ex.Message.Contains("Username already exists"))
                        {
                            MessageBox.Show("This username is already used by another staff! Please use a different username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_username.Focus();
                        }
                        else
                        {
                            MessageBox.Show($"Error updating staff: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid start date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_date.Focus();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the staff with ID '{ID}'?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BLL.DeleteRecord(ID);
                MessageBox.Show("Staff deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
