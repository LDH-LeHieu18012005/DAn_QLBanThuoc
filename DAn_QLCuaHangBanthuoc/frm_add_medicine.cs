using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BLL;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_add_medicine : Form
    {
        BLL_medicine BLL;
        string ID;
        int mode;
        string selectedImagePath;
        public frm_add_medicine(int mode, string selectedID = "")
        {
            InitializeComponent();
            BLL = new BLL_medicine();
            this.mode = mode;
            ID = selectedID;
            LoadMedicineTypes();

            if (mode == 1)
            {
                ID = selectedID;
                btn_add.Enabled = false;
                DataRow selectedRow = BLL.GetRecord(ID);
                if (selectedRow != null)
                {
                    cbo_type.SelectedValue = selectedRow["id_type"] != DBNull.Value ? selectedRow["id_type"] : -1;
                    txt_name.Text = selectedRow["name_medicine"].ToString();
                    txt_active_ingredient.Text = selectedRow["active_ingredient"].ToString();
                    txt_contraindication.Text = selectedRow["contraindication"].ToString();
                    txt_side_effects.Text = selectedRow["side_effects"].ToString();
                    string unit = selectedRow["unit"].ToString();
                    if (unit == "Tablet")
                    {
                        cbo_unit.SelectedItem = "Tablet";
                    }
                    else if (unit == "Capsule") { cbo_unit.SelectedItem = "Capsule"; }
                    else { cbo_unit.SelectedItem = "Syrup"; };
                    txt_price.Text = selectedRow["price"].ToString();
                    string ac = selectedRow["is_active"].ToString();
                    if (ac == "0" || ac == "False")
                    {
                        cbo_active.SelectedItem = "0";
                    }
                    else if (ac == "1" || ac == "True")
                    {
                        cbo_active.SelectedItem = "1";
                    }
                    selectedImagePath = selectedRow["images"].ToString();
                    if (!string.IsNullOrWhiteSpace(selectedImagePath) && File.Exists(selectedImagePath))
                    {
                        pic_image.Image = Image.FromFile(selectedImagePath);
                    }
                }
                else
                {
                    MessageBox.Show("Medicine not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            else
            {
                btn_edit.Enabled = false;
                btn_delete.Enabled = false;
                txt_price.Enabled = false;
            }
        }
        private void LoadMedicineTypes()
        {
            DataTable dt = BLL.GetMedicineTypes();
            DataRow row = dt.NewRow();
            row["id_type"] = -1;
            row["name_type"] = "-- Select Type --";
            dt.Rows.InsertAt(row, 0);
            cbo_type.DataSource = dt;
            cbo_type.DisplayMember = "name_type";
            cbo_type.ValueMember = "id_type";
            cbo_type.SelectedValue = -1;
        }
        bool Check()
        {
            if (string.IsNullOrWhiteSpace(txt_name.Text))
            {
                MessageBox.Show("Please enter a medicine name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_name.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbo_unit.Text))
            {
                MessageBox.Show("Please select a unit!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_unit.Focus();
                return false;
            }
            if (cbo_active.SelectedItem == null)
            {
                MessageBox.Show("Please select an active status!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbo_active.Focus();
                return false;
            }
            return true;
        }
        private void pc_Image_DoubleClick(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.webp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    pic_image.Image = Image.FromFile(selectedImagePath);
                }
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                try
                {
                    int? idType = cbo_type.SelectedValue != null && (int)cbo_type.SelectedValue != -1 ? (int?)cbo_type.SelectedValue : null;
                    if (cbo_type.SelectedValue.ToString() == "-1" || cbo_type.SelectedValue.ToString() == "-1")
                    {
                        MessageBox.Show("Please select both a type medicine!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbo_active.Focus();
                        return;
                    }
                    BLL.AddRecord(idType, txt_name.Text, txt_active_ingredient.Text, txt_contraindication.Text, txt_side_effects.Text, cbo_unit.Text, cbo_active.Text, selectedImagePath ?? "");
                    MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Medicine name already exists"))
                    {
                        MessageBox.Show("This medicine name already exists! Please use a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_name.Clear();
                        txt_name.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Error adding medicine: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (Check())
            {
                if (!decimal.TryParse(txt_price.Text, out decimal price) || price < 0)
                {
                    MessageBox.Show("Please enter a valid price (non-negative number)!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_price.Focus();
                    return;
                }
                try
                {
                    int? idType = cbo_type.SelectedValue != null && (int)cbo_type.SelectedValue != -1 ? (int?)cbo_type.SelectedValue : null;
                    BLL.UpdateRecord(ID, idType, txt_name.Text, txt_active_ingredient.Text, txt_contraindication.Text, txt_side_effects.Text, cbo_unit.Text, decimal.Parse(txt_price.Text), cbo_active.Text, selectedImagePath ?? "");
                    MessageBox.Show("Medicine updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("Medicine name already exists"))
                    {
                        MessageBox.Show("This medicine name is already used by another medicine! Please use a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_name.Focus();
                    }
                    else
                    {
                        MessageBox.Show($"Error updating medicine: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"Are you sure you want to delete the medicine with ID '{ID}'?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                BLL.DeleteRecord(ID);
                MessageBox.Show("Medicine deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
    }
}
