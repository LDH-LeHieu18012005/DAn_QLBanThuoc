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
using iTextSharp.text.pdf.qrcode;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_add_customer : Form
    {
        BLL_customer BLL;
        string ID;
        int mode;
        public frm_add_customer(int mode, string selectedID="")
        {
            InitializeComponent();
            BLL = new BLL_customer();
            this.mode = mode;
            ID = selectedID;
            if (mode == 1)
            {
                ID = selectedID;
                btn_add.Enabled = false;
                DataRow selectedRow = BLL.GetRecord(ID);
                txt_name.Text = selectedRow[1].ToString();
                txt_age.Text = selectedRow[2].ToString();
                string gender = selectedRow[3].ToString().Trim();
                txt_phone.Text = selectedRow[4].ToString();
                txt_address.Text = selectedRow[5].ToString();
                if (gender == "Male")
                {
                    cbo_gender.SelectedItem = "Male";
                }
                else { cbo_gender.SelectedItem = "Female"; };
            }
            else
            {
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
            }
        }
        bool Check()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Please enter a name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_name.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_age.Text) || !int.TryParse(txt_age.Text, out int age) || age <= 0 || age>150)
            {
                MessageBox.Show("Please enter a valid age (positive integer 1-150)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_age.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbo_gender.Text))
            {
                MessageBox.Show("Please select a gender!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_gender.Focus();
                return false;
            }
            string phonePattern = @"^0(3[2-9]|5[6-9]|7[0-9]|8[1-9]|9[0-4|6-9])[0-9]{7}$";
            if (string.IsNullOrWhiteSpace(txt_phone.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txt_phone.Text, phonePattern))
            {
                MessageBox.Show("Please enter a valid phone number (10-11 digits)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_phone.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txt_address.Text))
            {
                MessageBox.Show("Please enter an address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_address.Focus();
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
                    BLL.AddRecord(txt_name.Text, txt_age.Text, cbo_gender.Text, txt_phone.Text, txt_address.Text);
                    MessageBox.Show("Customer added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else
                    {
                        MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    BLL.UpdateRecord(ID, txt_name.Text, txt_age.Text, cbo_gender.Text, txt_phone.Text, txt_address.Text);
                    MessageBox.Show("Customer updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else
                    {
                        MessageBox.Show($"Error adding customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the customer with ID '{ID}'?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BLL.DeleteRecord(ID);
                Close();
            }
        }
    }
}
