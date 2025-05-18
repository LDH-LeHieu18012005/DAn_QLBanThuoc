using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ZXing;
using ZXing.QrCode;
using ZXing.Windows.Compatibility;
using AForge.Video;
using AForge.Video.DirectShow;


namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_add_sale : Form
    {
        private readonly frm_Main _mainForm;
        BLL_sale bll = new BLL_sale();
        List<string> ID_medicine = new List<string>();
        List<int> stock_quantity = new List<int>();
        DataTable TableMedicine;
        FilterInfoCollection FilterInfoCollection;
        VideoCaptureDevice videocaptureDevice;
        private bool isCameraRunning;

        public frm_add_sale(frm_Main mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            bll = new BLL_sale();
            load();
        }
        void load()
        {
            DataTable staff = bll.GetStaff();
            DataRow row = staff.NewRow();
            row["id_staff"] = -1;
            row["name_staff"] = "-- Select Staff --";
            staff.Rows.InsertAt(row, 0);
            cbo_staff.DataSource = staff;
            cbo_staff.DisplayMember = "name_staff";
            cbo_staff.ValueMember = "id_staff";
            cbo_staff.SelectedValue = -1;

            DataTable c = bll.GetCustomer();
            DataRow row2 = c.NewRow();
            row2["id_customer"] = -1;
            row2["name_customer"] = "-- Select Customer --";
            c.Rows.InsertAt(row2, 0);
            cbo_customer.DataSource = c;
            cbo_customer.DisplayMember = "name_customer";
            cbo_customer.ValueMember = "id_customer";
            cbo_customer.SelectedValue = -1;

            TableMedicine = bll.GetMedicine();
            DataRow row3 = TableMedicine.NewRow();
            row3["id_medicine"] = -1;
            row3["name_medicine"] = "-- Select Medicne --";
            TableMedicine.Rows.InsertAt(row3, 0);
            FilterInfoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in FilterInfoCollection)
                cmbmayanh.Items.Add(device.Name);
            cmbmayanh.SelectedIndex = 0;
        }
        private void CaptureDevice_Newfame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            var reader = new ZXing.BarcodeReader();
            reader.Options.PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE, BarcodeFormat.CODE_128, BarcodeFormat.EAN_13 };
            // Nếu bạn chỉ quét QR thì chỉ giữ QR_CODE cũng được


            var result = reader.Decode(bitmap);
            if (result != null)
            {
                txt_medicineID.Invoke(new MethodInvoker(delegate ()
                {
                    txt_medicineID.Text = result.ToString();
                }));
            }
        }
        private async Task StopCameraAsync()
        {
            // Dừng camera một cách an toàn trong luồng riêng biệt
            if (isCameraRunning && videocaptureDevice != null)
            {
                try
                {
                    videocaptureDevice.SignalToStop();
                    await Task.Run(() => videocaptureDevice.WaitForStop());  // Chờ camera dừng lại hoàn toàn
                    videocaptureDevice.NewFrame -= CaptureDevice_Newfame; // Gỡ sự kiện
                    isCameraRunning = false;
                    Console.WriteLine("Camera stopped...");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error stopping camera: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No camera to stop.");
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            _mainForm.container(new frm_sale(_mainForm));
        }

        private void UpdateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dgv_data.Rows)
            {
                if (!row.IsNewRow)
                {
                    int quantity = Convert.ToInt32(row.Cells[1].Value); 
                    decimal price = Convert.ToDecimal(row.Cells[2].Value); 
                    totalAmount += quantity * price;
                }
            }
            lbl_price.Text = totalAmount.ToString("N0") + " VND";
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            string selectedId = txt_medicineID.Text.Trim();

            if (string.IsNullOrEmpty(selectedId))
            {
                MessageBox.Show("Vui lòng nhập mã thuốc!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã thuốc có tồn tại không
            if (!TableMedicine.Rows.Cast<DataRow>().Any(r => r["id_medicine"].ToString() == selectedId))
            {
                MessageBox.Show("Mã thuốc không tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng mã
            if (ID_medicine.Contains(selectedId))
            {
                MessageBox.Show("Thuốc đã được thêm vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Thêm thuốc
            foreach (DataRow row in TableMedicine.Rows)
            {
                if (selectedId == row["id_medicine"].ToString())
                {
                    dgv_data.Rows.Add(row["name_medicine"], 1, row["price"]);
                    ID_medicine.Add(selectedId);
                    stock_quantity.Add(Convert.ToInt32(row["total_quantity"]));
                    UpdateTotalAmount();
                    txt_medicineID.Clear(); // Xóa text sau khi thêm
                    return;
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_data.SelectedRows.Count > 0)
            {
                int selectedIndex = dgv_data.SelectedRows[0].Index;
                dgv_data.Rows.RemoveAt(selectedIndex);
                if (selectedIndex >= 0 && selectedIndex < ID_medicine.Count)
                {
                    ID_medicine.RemoveAt(selectedIndex);
                    stock_quantity.RemoveAt(selectedIndex);
                }
                UpdateTotalAmount();
                btn_delete.Visible = false;
                btn_add.Visible = true;
            }
        }

        private void btn_new_sale_Click(object sender, EventArgs e)
        {
            if (dgv_data.Rows.Count == 0 || (dgv_data.Rows.Count == 1 && dgv_data.Rows[0].IsNewRow))
            {
                MessageBox.Show("Please add at least one product to the invoice!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbo_staff.SelectedValue == null || cbo_staff.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a staff!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbo_customer.SelectedValue == null || cbo_customer.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Please select a customer!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            for (int i = 0; i < dgv_data.Rows.Count - 1; i++)
            {
                if (!int.TryParse(dgv_data.Rows[i].Cells[1].Value?.ToString(), out int quantity) || quantity < 1)
                {
                    MessageBox.Show("Product quantity must be a number greater than 0!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (quantity > stock_quantity[i])
                {
                    string id = dgv_data.Rows[i].Cells[0].Value.ToString();
                    MessageBox.Show($"The quantity of product with ID {id} exceeds the available stock: {stock_quantity[i]}!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (MessageBox.Show("Are you sure you want to create this invoice?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bll.AddRecord(cbo_staff.SelectedValue.ToString(), cbo_customer.SelectedValue.ToString());
                    string idHDBnew = bll.GetIDHDB();

                    for (int i = 0; i < dgv_data.Rows.Count - 1; i++) 
                    {
                        string idMedicine = ID_medicine[i]; 
                        string quantity = dgv_data.Rows[i].Cells[1].Value.ToString(); 
                        string price = dgv_data.Rows[i].Cells[2].Value.ToString(); 
                        bll.AddDetails(idHDBnew, idMedicine, quantity, price);
                    }
                    MessageBox.Show("Invoice created successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgv_data.Rows.Clear();
                    ID_medicine.Clear();
                    stock_quantity.Clear();
                    _mainForm.container(new frm_sale(_mainForm));
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            var reader = new ZXing.BarcodeReader
            {
                AutoRotate = true,
                Options = { PossibleFormats = new List<BarcodeFormat> { BarcodeFormat.QR_CODE, BarcodeFormat.CODE_128, BarcodeFormat.EAN_13 } }
            };
            var result = reader.Decode(bitmap);

            if (result != null)
            {
                txt_medicineID.Invoke(new MethodInvoker(() =>
                {
                    txt_medicineID.Text = result.Text;
                }));
            }
        }

        private void StartCamera()
        {
            if (videocaptureDevice != null && videocaptureDevice.IsRunning)
            {
                videocaptureDevice.SignalToStop();
                videocaptureDevice.NewFrame -= CaptureDevice_NewFrame;
            }

            if (cmbmayanh.SelectedIndex >= 0)
            {
                string cameraName = cmbmayanh.SelectedItem.ToString();
                FilterInfo selectedCamera = FilterInfoCollection.Cast<FilterInfo>().FirstOrDefault(f => f.Name == cameraName);
                if (selectedCamera != null)
                {
                    videocaptureDevice = new VideoCaptureDevice(selectedCamera.MonikerString);
                    videocaptureDevice.NewFrame += CaptureDevice_NewFrame;
                    videocaptureDevice.Start();
                    isCameraRunning = true;
                }
            }
        }

        private void dgv_data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_delete.Visible = true;
            btn_add.Visible = false;
        }

        private void guna2ShadowPanel1_Click(object sender, EventArgs e)
        {
            btn_delete.Visible = false;
            btn_add.Visible = true;
        }

        private void btnStartCamera_Click_1(object sender, EventArgs e)
        {
            StartCamera();
        }
    }
}
