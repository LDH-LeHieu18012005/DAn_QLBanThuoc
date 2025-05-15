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
using System.IO;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_medicine : Form
    {
        private readonly frm_Main _mainForm; // Save reference to frm_Main
        private DataGridViewToExcelExporter excelExporter;
        BLL_medicine BLL;
        public frm_medicine(frm_Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm; // Save frm_Main
            BLL = new BLL_medicine();
            excelExporter = new DataGridViewToExcelExporter();
            SetupDataGridView();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                dgv_data.Rows.Clear();
                DataTable dataTable = BLL.GetData(txt_search.Text);
                if (dataTable == null || dataTable.Rows.Count == 0)
                {
                    System.Diagnostics.Debug.WriteLine("LoadData: No data returned.");
                    return;
                }

                foreach (DataRow row in dataTable.Rows)
                {
                    Image image = null;
                    string imagePath = row["ima"]?.ToString();
                    if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
                    {
                        try
                        {
                            image = Image.FromFile(imagePath);
                        }
                        catch
                        {
                            image = null;
                        }
                    }

                    dgv_data.Rows.Add(
                        row["id"],
                        row["name"],
                        row["type_name"],
                        row["ac_i"], 
                        row["con"],
                        row["si"],
                        row["manu"], 
                        row["ex"],
                        row["to"],
                        row["p"],
                        row["is"],
                        image
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupDataGridView()
        {
            dgv_data.Columns.Clear();
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "id", HeaderText = "ID" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "name", HeaderText = "Medicine Name" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "type_name", HeaderText = "Type" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "ac_i", HeaderText = "Active Ingredient" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "con", HeaderText = "Contraindication" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "si", HeaderText = "Side Effects" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "manu", HeaderText = "Manufacturing Date" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "ex", HeaderText = "Expiry Date" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "to", HeaderText = "Total Quantity" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "p", HeaderText = "Price" });
            dgv_data.Columns.Add(new DataGridViewTextBoxColumn { Name = "is", HeaderText = "Active" });
            var imageColumn = new DataGridViewImageColumn
            {
                Name = "images",
                HeaderText = "Image",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dgv_data.Columns.Add(imageColumn);
            dgv_data.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            frm_add_medicine frm = new frm_add_medicine(0);
            frm.ShowDialog();
            LoadData();
        }

        private void btn_type_Click(object sender, EventArgs e)
        {
            _mainForm.container(new frm_type_medicine());
        }

        private void dgv_data_DoubleClick(object sender, EventArgs e)
        {
            if (dgv_data.SelectedRows.Count > 0)
            {
                string id = dgv_data.SelectedRows[0].Cells["id"].Value?.ToString();
                if (!string.IsNullOrEmpty(id))
                {
                    frm_add_medicine frm = new frm_add_medicine(1, id);
                    frm.FormClosed += (s, args) => LoadData();
                    frm.ShowDialog();
                }
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgv_data.Rows[e.RowIndex];
                lbl_name.Text = row.Cells["name"].Value?.ToString() ?? "";
                lbl_type.Text = row.Cells["type_name"].Value?.ToString() ?? "";
                lbl_ac.Text = row.Cells["ac_i"].Value?.ToString() ?? "";
                lbl_con.Text = row.Cells["con"].Value?.ToString() ?? "";
                lbl_side.Text = row.Cells["si"].Value?.ToString() ?? "";
                lbl_manu.Text = (row.Cells["manu"].Value != null && row.Cells["manu"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["manu"].Value).ToString("dd/MM/yyyy") : "");
                lbl_exp.Text = (row.Cells["ex"].Value != null && row.Cells["ex"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["ex"].Value).ToString("dd/MM/yyyy") : "");
                lbl_quan.Text = row.Cells["to"].Value?.ToString() ?? "";
                lbl_price.Text = (row.Cells["p"].Value?.ToString() ?? "") + " VND";
                lbl_status.Text = row.Cells["is"].Value?.ToString() ?? "";
                if (row.Cells["images"].Value != null)
                {
                    pic_image.Image = (Image)row.Cells["images"].Value;
                }
                else
                {
                    pic_image.Image = Image.FromFile("C:\\Users\\DELL\\Desktop\\DAn_QLBanThuoc\\DAn_QLCuaHangBanthuoc\\image");
                }
            }
        }

        private void btn_excel_Click(object sender, EventArgs e)
        {
            if (dgv_data.Rows.Count == 0)
            {
                MessageBox.Show("No data to export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                Title = "Select location to save Excel file",
                FileName = $"MedicineList_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                excelExporter.ExportToExcelWithClosedXML(dgv_data, saveFileDialog.FileName, "MedicineList");
            }
        }
    }
}
