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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_add_purchase : Form
    {
        private readonly frm_Main _mainForm;
        BLL_batch BLL_b;
        BLL_purchase BLL_p;
        List<string> ID_Batch = new List<string>(); // Tracks IDs in the DataGridView
        DataTable Table_Batch; // Source data for medicines
        DataTable TempBatchTable; // Temporary table for DataGridView data
        public frm_add_purchase(frm_Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            BLL_b = new BLL_batch();
            BLL_p = new BLL_purchase();
            btn_delete.Visible = false;
            Load_cbo();
            InitializeTempBatchTable();
            dgv_data2.Columns.Clear();
            dgv_data2.DataSource = TempBatchTable;
            dgv_data2.Columns["IDBatch"].ReadOnly = true;
            dgv_data2.Columns["IDMedicine"].ReadOnly = true;
            dgv_data2.Columns["Status"].ReadOnly = true;
            dgv_data2.Columns["Medicine"].ReadOnly = true;
            dgv_data2.CellValidating += dgv_data2_CellValidating;
        }
        private void InitializeTempBatchTable()
        {
            TempBatchTable = new DataTable();
            TempBatchTable.Columns.Add("IDBatch", typeof(int)); 
            TempBatchTable.Columns.Add("IDMedicine", typeof(int)); 
            TempBatchTable.Columns.Add("Medicine", typeof(string));
            TempBatchTable.Columns.Add("Quantity", typeof(int)); 
            TempBatchTable.Columns.Add("EntryPrice", typeof(decimal));
            TempBatchTable.Columns.Add("Manufacture", typeof(DateTime)); 
            TempBatchTable.Columns.Add("Expriy", typeof(DateTime)); 
            TempBatchTable.Columns.Add("Status", typeof(string)); 
        }
        void Load_cbo()
        {
            DataTable staff = BLL_p.GetStaff();
            DataRow row = staff.NewRow();
            row["id_staff"] = -1;
            row["name_staff"] = "-- Select Staff --";
            staff.Rows.InsertAt(row, 0);
            cbo_staff.DataSource = staff;
            cbo_staff.DisplayMember = "name_staff";
            cbo_staff.ValueMember = "id_staff";
            cbo_staff.SelectedValue = -1;

            DataTable supp = BLL_p.GetSupplier();
            DataRow row2 = supp.NewRow();
            row2["id_supplier"] = -1;
            row2["name_supplier"] = "-- Select Supplier --";
            supp.Rows.InsertAt(row2, 0);
            cbo_supplier.DataSource = supp;
            cbo_supplier.DisplayMember = "name_supplier";
            cbo_supplier.ValueMember = "id_supplier";
            cbo_supplier.SelectedValue = -1;

            DataTable me = BLL_p.GetMedicine();
            DataRow row3= me.NewRow();
            row3["id_medicine"] = -1;
            row3["name_medicine"] = "-- Select Medicne --";
            me.Rows.InsertAt(row3, 0);
            cbo_medicine.DataSource = me;
            cbo_medicine.DisplayMember = "name_medicine";
            cbo_medicine.ValueMember = "id_medicine";
            cbo_medicine.SelectedValue = -1;

            Table_Batch = BLL_p.GetMedicine();
        }
        private void dgv_data2_DoubleClick(object sender, EventArgs e)
        {
            btn_add.Visible = false;
            btn_delete.Visible = true;
        }

        private void cbo_medicine_MouseClick(object sender, MouseEventArgs e)
        {
            btn_add.Visible = true;
            btn_delete.Visible = false;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cbo_medicine.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a medicine!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string selectedMedicineId = cbo_medicine.SelectedValue.ToString();
            if (ID_Batch.Contains(selectedMedicineId))
            {
                MessageBox.Show("The product has been added to the purchase invoice!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DataRow selectedRow = null;
            foreach (DataRow row in Table_Batch.Rows)
            {
                if (row["id_medicine"].ToString() == selectedMedicineId)
                {
                    selectedRow = row;
                    break;
                }
            }

            if (selectedRow != null)
            {
                DataRow newRow = TempBatchTable.NewRow();
                newRow["IDBatch"] = 1; 
                newRow["IDMedicine"] = selectedRow["id_medicine"];
                newRow["Medicine"] = selectedRow["name_medicine"];
                newRow["Quantity"] = 1;
                newRow["EntryPrice"] = 1;
                newRow["Manufacture"] = DateTime.Today;
                newRow["Expriy"] = DateTime.Today.AddYears(1);
                newRow["Status"] = "Active";
                TempBatchTable.Rows.Add(newRow);

                ID_Batch.Add(selectedMedicineId);

                decimal totalAmount = 0;
                foreach (DataRow row in TempBatchTable.Rows)
                {
                    decimal entryPrice = Convert.ToDecimal(row["EntryPrice"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    totalAmount += entryPrice * quantity;
                }
                lbl_total_price.Text = totalAmount.ToString() + " VND";
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_data2.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgv_data2.SelectedRows[0];
                string medicineId = selectedRow.Cells["IDMedicine"].Value.ToString();
                ID_Batch.Remove(medicineId);
                TempBatchTable.Rows.RemoveAt(selectedRow.Index);
                decimal totalAmount = 0;
                foreach (DataRow row in TempBatchTable.Rows)
                {
                    decimal entryPrice = Convert.ToDecimal(row["EntryPrice"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    totalAmount += entryPrice * quantity;
                }
                lbl_total_price.Text = totalAmount.ToString() + " VND";

                btn_delete.Visible = false;
                btn_add.Visible = true;
            }
        }

        private void btn_new_perchase_Click(object sender, EventArgs e)
        {
            if (cbo_staff.SelectedValue.ToString() == "-1" || cbo_supplier.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select both an employee and a supplier!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dgv_data2.EndEdit();
            BindingContext[TempBatchTable].EndCurrentEdit();

            if (TempBatchTable.Rows.Count == 0)
            {
                MessageBox.Show("Please add at least one batch!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idStaff = Convert.ToInt32(cbo_staff.SelectedValue);
            int idSupplier = Convert.ToInt32(cbo_supplier.SelectedValue);
            decimal totalAmount = 0;

            foreach (DataRow row in TempBatchTable.Rows)
            {
                decimal entryPrice = Convert.ToDecimal(row["EntryPrice"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                totalAmount += entryPrice * quantity;
            }

            DialogResult result = MessageBox.Show(
                $"Are you sure you want to create this purchase invoice?\nTotal Amount: {totalAmount} VND",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.No)
            {
                return;
            }

            BLL_p.CreatePurchaseInvoice(DateTime.Today, idSupplier, idStaff, totalAmount);
            string purchaseId = BLL_p.GetIDHDN();
            int id_purchase = int.Parse(purchaseId);

            foreach (DataRow row in TempBatchTable.Rows)
            {
                int idMedicine = Convert.ToInt32(row["IDMedicine"]);
                int quantity = Convert.ToInt32(row["Quantity"]);
                decimal entryPrice = Convert.ToDecimal(row["EntryPrice"]);
                DateTime mfgDate = Convert.ToDateTime(row["Manufacture"]);
                DateTime expDate = Convert.ToDateTime(row["Expriy"]);
                string status = row["Status"].ToString();
                if (expDate <= mfgDate)
                {
                    MessageBox.Show($"Invalid expiration date for medicine ID {idMedicine}. Expiration date must be after the manufacturing date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int batchId = BLL_b.CreateBatch(idMedicine, quantity, entryPrice, mfgDate, expDate, status);
                BLL_p.CreatePurchaseDetail(id_purchase, batchId);
            }

            MessageBox.Show("Purchase invoice created successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TempBatchTable.Clear();
            ID_Batch.Clear();
            cbo_staff.SelectedValue = -1;
            cbo_supplier.SelectedValue = -1;
            cbo_medicine.SelectedValue = -1;
            _mainForm.container(new frm_purchase(_mainForm));
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            _mainForm.container(new frm_purchase(_mainForm));
        }

        private void dgv_data2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (TempBatchTable.Rows.Count == 0 || (dgv_data2.CurrentRow != null && dgv_data2.CurrentRow.IsNewRow && string.IsNullOrWhiteSpace(e.FormattedValue?.ToString())))
            {
                return; 
            }

            if (dgv_data2.Columns[e.ColumnIndex].Name == "Quantity")
            {
                int quantity;
                if (!int.TryParse(e.FormattedValue?.ToString(), out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Quantity must be a positive number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            else if (dgv_data2.Columns[e.ColumnIndex].Name == "EntryPrice")
            {
                decimal entryPrice;
                if (!decimal.TryParse(e.FormattedValue?.ToString(), out entryPrice) || entryPrice < 0)
                {
                    MessageBox.Show("Entry Price must be a non-negative number!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
            }
            else if (dgv_data2.Columns[e.ColumnIndex].Name == "Manufacture" || dgv_data2.Columns[e.ColumnIndex].Name == "Expriy")
            {
                DateTime dateValue;
                if (!DateTime.TryParse(e.FormattedValue?.ToString(), out dateValue))
                {
                    MessageBox.Show("Invalid date format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                    return;
                }
                dgv_data2.EndEdit();
                if (dgv_data2.CurrentRow != null)
                {
                    DataRowView rowView = dgv_data2.CurrentRow.DataBoundItem as DataRowView;
                    if (rowView != null)
                    {
                        DataRow row = rowView.Row;
                        DateTime manufacture = Convert.ToDateTime(row["Manufacture"]);
                        DateTime expiry = Convert.ToDateTime(row["Expriy"]);
                        if (dgv_data2.Columns[e.ColumnIndex].Name == "Manufacture")
                        {
                            manufacture = dateValue;
                        }
                        else
                        {
                            expiry = dateValue;
                        }
                        if (expiry <= manufacture)
                        {
                            MessageBox.Show("Expiration date must be after manufacturing date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            e.Cancel = true;
                            return;
                        }
                    }
                }
            }

            if (dgv_data2.Columns[e.ColumnIndex].Name == "Quantity" || dgv_data2.Columns[e.ColumnIndex].Name == "EntryPrice")
            {
                dgv_data2.EndEdit();
                if (dgv_data2.CurrentRow != null && dgv_data2.CurrentRow.IsNewRow)
                {
                    BindingContext[TempBatchTable].EndCurrentEdit();
                }

                decimal totalAmount = 0;
                foreach (DataRow row in TempBatchTable.Rows)
                {
                    decimal entryPrice = Convert.ToDecimal(row["EntryPrice"]);
                    int quantity = Convert.ToInt32(row["Quantity"]);
                    totalAmount += entryPrice * quantity;
                }
                lbl_total_price.Text = totalAmount.ToString() + " VND";
            }
        }

        private void guna2ShadowPanel1_Click(object sender, EventArgs e)
        {
            btn_delete.Visible = false;
            btn_add.Visible = true;
        }
    }
}
