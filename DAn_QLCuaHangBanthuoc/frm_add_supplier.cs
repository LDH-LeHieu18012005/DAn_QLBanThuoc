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
    public partial class frm_add_supplier : Form
    {
        BLL_supplier BLL;
        string ID;
        int mode;
        public frm_add_supplier(int mode, string selectedID = "")
        {
            InitializeComponent();
            BLL = new BLL_supplier();
            this.mode = mode;
            ID = selectedID;
            if (mode == 1)
            {
                ID = selectedID;
                btn_add.Enabled = false;
                DataRow selectedRow = BLL.GetRecord(ID); 
                txt_name.Text = selectedRow["name_supplier"].ToString();
                txt_phone.Text = selectedRow["phone"].ToString();
                txt_gmail.Text = selectedRow["gmail"].ToString();
                txt_address.Text = selectedRow["address"].ToString();
            }
            else
            {
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
            }
        }
        bool Check()
        {
            if(string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Please enter a supplier name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_name.Focus();
                return false;
            }
            string phonePattern = @"^0(3[2-9]|5[6-9]|7[0-9]|8[1-9]|9[0-4|6-9])[0-9]{7}$";
            if (string.IsNullOrWhiteSpace(txt_phone.Text) || !System.Text.RegularExpressions.Regex.IsMatch(txt_phone.Text, phonePattern))
            {
                MessageBox.Show("Please enter a valid Vietnamese phone number (10 digits)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_phone.Focus();
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
                    BLL.AddRecord(txt_name.Text, txt_phone.Text, txt_gmail.Text, txt_address.Text);
                    MessageBox.Show("Supplier added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    else
                    {
                        MessageBox.Show($"Error adding supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    BLL.UpdateRecord(ID, txt_name.Text, txt_phone.Text, txt_gmail.Text, txt_address.Text);
                    MessageBox.Show("Supplier updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Phone number already exists"))
                    {
                        MessageBox.Show("This phone number already exists! Please use a different phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_phone.Focus();
                    }
                    else if (ex.Message.Contains("Email already exists"))
                    {
                        MessageBox.Show("This email already exists! Please use a different email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_gmail.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Error adding supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the supplier with ID '{ID}'?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BLL.DeleteRecord(ID);
                MessageBox.Show("Supplier deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
