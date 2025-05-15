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
    public partial class frm_add_type : Form
    {
        BLL_type BLL;
        string ID;
        int mode;
        public frm_add_type(int mode = 0, string selectedID = "")
        {
            InitializeComponent();
            BLL = new BLL_type();
            this.mode = mode;
            ID = selectedID;
            if (mode == 1)
            {
                ID = selectedID;
                btn_add.Enabled = false;
                DataRow selectedRow = BLL.GetRecord(ID);
                txt_name.Text = selectedRow["name_type"].ToString();
                txt_des.Text = selectedRow["description"].ToString();
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
                MessageBox.Show("Please enter a type name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_name.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txt_des.Text) && txt_des.Text.Length > 100)
            {
                MessageBox.Show("Description cannot exceed 100 characters!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_des.Focus();
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
                    BLL.AddRecord(txt_name.Text, txt_des.Text);
                    MessageBox.Show("Medicine type added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Medicine type name already exists"))
                    {
                        MessageBox.Show("This medicine type name already exists! Please use a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_name.Clear();
                        txt_name.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Error adding medicine type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    BLL.UpdateRecord(ID, txt_name.Text, txt_des.Text);
                    MessageBox.Show("Medicine type updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Medicine type name already exists"))
                    {
                        MessageBox.Show("This medicine type name is already used by another type! Please use a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_name.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Error updating medicine type: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the medicine type with ID '{ID}'?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BLL.DeleteRecord(ID);
                MessageBox.Show("Medicine type deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
