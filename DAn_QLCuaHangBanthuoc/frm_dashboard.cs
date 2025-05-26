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
using System.Windows.Forms.DataVisualization.Charting;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_dashboard : Form
    {
        BLL_Statistic statisticBLL;
        public frm_dashboard()
        {
            InitializeComponent();
            statisticBLL = new BLL_Statistic();
            LoadDashboardData();
            BestSale();
            LoadBatch();
            CapNhatDoanhThu(DateTime.Now.Month, DateTime.Now.Year);
        }
        private void LoadDashboardData()
        {
            try
            {
                DataTable dt = statisticBLL.Counts();
                DataRow row = dt.Rows[0];
                lbl_customer.Text = row["TotalCustomers"].ToString();
                lbl_medicine.Text = row["TotalMedicines"].ToString();
                lbl_staff.Text = row["TotalStaff"].ToString();
                lbl_revenue.Text = Convert.ToDecimal(row["TotalRevenue"]).ToString("N0") + " VND";
                lbl_profit.Text = Convert.ToDecimal(row["TotalProfit"]).ToString("N0") + " VND";
            }
            catch (Exception ex)
            {
                // Fallback to 0 if data retrieval fails
                lbl_customer.Text = "0";
                lbl_medicine.Text = "0";
                lbl_staff.Text = "0";
                lbl_revenue.Text = "0";
                lbl_profit.Text = "0";
                MessageBox.Show($"Error loading dashboard data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BestSale()
        {
            DataTable dataTable = statisticBLL.TopSale();
            if (dataTable.Rows.Count > 0)
            {
                // Sắp xếp dữ liệu theo số lượng bán giảm dần
                var sortedRows = dataTable.AsEnumerable()
                    .OrderByDescending(row => Convert.ToInt32(row["TotalQuantitySold"]))
                    .ToList();

                ch_top.Series["Series1"].Points.Clear();
                foreach (var row in sortedRows)
                {
                    string tenSanPham = row["MedicineName"].ToString();
                    int tongSoLuongBan = Convert.ToInt32(row["TotalQuantitySold"]);
                    decimal tongDoanhThu = Convert.ToDecimal(row["TotalRevenue"]);

                    var point = new DataPoint
                    {
                        YValues = new double[] { tongSoLuongBan }, // Quantity sold for pie chart
                        LegendText = $"{tenSanPham}: {tongSoLuongBan:N0} ({tongDoanhThu / 1000000:N0}M VND)", // Rút gọn doanh thu
                        AxisLabel = "", // Xóa nhãn trục
                        Label = "" // Không hiển thị nhãn trên lát cắt
                    };
                    ch_top.Series["Series1"].Points.Add(point);
                }

                ch_top.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
                ch_top.Series["Series1"].IsValueShownAsLabel = false; // Tắt hiển thị nhãn trên lát cắt
                ch_top.Legends[0].Enabled = true;
                ch_top.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
                ch_top.Legends[0].LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Table;
                ch_top.Legends[0].TableStyle = System.Windows.Forms.DataVisualization.Charting.LegendTableStyle.Auto;

                // Thêm tiêu đề cho chú thích
                ch_top.Legends[0].Title = "Top Medicines by Sales";
                ch_top.Legends[0].TitleAlignment = System.Drawing.StringAlignment.Center;
                ch_top.Legends[0].TitleFont = new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold);

                // Tăng kích thước chữ của các mục trong chú thích
                ch_top.Legends[0].Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Regular); // Tăng kích thước font lên 10

                ch_top.ChartAreas[0].Area3DStyle.Enable3D = false; // Optional: Disable 3D for clarity
            }
            else
            {
                MessageBox.Show($"No data available for top sales. Rows retrieved: {dataTable.Rows.Count}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        void LoadBatch()
        {
            dgv_batch.Rows.Clear();
            DataTable dataTable = statisticBLL.GetData();
            foreach (DataRow row in dataTable.Rows)
            {
                dgv_batch.Rows.Add(row[0], row[1], row[2], row[3], row[4], row[5], row[6], row[7]);
            }
        }
        void CapNhatDoanhThu(int? month, int year)
        {
            string procedureCall = month.HasValue
                ? $"exec ThongKeDoanhThuTheoThangNam {month}, {year}"
                : $"exec ThongKeDoanhThuTheoThangNam NULL, {year}";

            DataTable dataTable = statisticBLL.TKDoanhThu(month, year);

            ch_revenue.Series["Series1"].Points.Clear();

            if (month.HasValue)
            {
                DataRow row = dataTable.Rows.Count > 0 ? dataTable.Rows[0] : null;
                int revenue = row != null && row["Revenue"] != DBNull.Value
                    ? Convert.ToInt32(row["Revenue"])
                    : 0;

                var point = new DataPoint(month.Value, revenue)
                {
                    LegendText = $"Tháng {month.Value}: {revenue:N0} VNĐ",
                    Label = $"{revenue:N0} VNĐ"
                };
                ch_revenue.Series["Series1"].Points.Add(point);

                // ✅ Hiện số trên cột khi có tháng cụ thể
                ch_revenue.Series["Series1"].IsValueShownAsLabel = true;
            }
            else
            {
                int[] revenues = new int[12];
                foreach (DataRow row in dataTable.Rows)
                {
                    int monthNumber = Convert.ToInt32(row["MonthNumber"]);
                    int revenue = row["Revenue"] != DBNull.Value ? Convert.ToInt32(row["Revenue"]) : 0;
                    revenues[monthNumber - 1] = revenue;
                }

                for (int i = 1; i <= 12; i++)
                {
                    int revenue = revenues[i - 1];

                    var point = new DataPoint(i, revenue)
                    {
                        LegendText = $"Tháng {i}: {revenue:N0} VNĐ"
                        // ❌ Không thêm Label để ẩn số trên cột
                    };
                    ch_revenue.Series["Series1"].Points.Add(point);
                }

                // ❌ Không hiển thị giá trị trên cột khi hiển thị cả năm
                ch_revenue.Series["Series1"].IsValueShownAsLabel = false;
            }

            // Cấu hình biểu đồ chung
            ch_revenue.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            ch_revenue.Legends[0].Enabled = true;
            ch_revenue.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
        }


        void CapNhatDoanhThuTheoQuy(int? quarter, int year)
        {
            DataTable dataTable = statisticBLL.TKDoanhThuTheoQuy(quarter, year);
            var series = ch_revenue.Series["Series1"];
            series.Points.Clear();
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Color = Color.Orange;
            series.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            series.LabelForeColor = Color.DarkBlue;

            if (quarter.HasValue)
            {
                int revenue = dataTable.Rows.Count > 0 && dataTable.Rows[0]["Doanh Thu"] != DBNull.Value
                    ? Convert.ToInt32(dataTable.Rows[0]["Doanh Thu"])
                    : 0;

                var point = new DataPoint(quarter.Value, revenue)
                {
                    Label = $"{revenue:N0} VNĐ",
                    AxisLabel = $"Q{quarter.Value}",
                    ToolTip = $"Quý {quarter.Value}: {revenue:N0} VNĐ"
                };
                series.Points.Add(point);
            }
            else
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    int quarterNumber = Convert.ToInt32(row["Quý"]);
                    int revenue = row["Doanh Thu"] != DBNull.Value ? Convert.ToInt32(row["Doanh Thu"]) : 0;

                    var point = new DataPoint(quarterNumber, revenue)
                    {
                        Label = $"{revenue:N0} VNĐ",
                        AxisLabel = $"Q{quarterNumber}",
                        ToolTip = $"Quý {quarterNumber}: {revenue:N0} VNĐ"
                    };
                    series.Points.Add(point);
                }
            }

            ch_revenue.ChartAreas[0].AxisX.Title = "Quý";
            ch_revenue.ChartAreas[0].AxisY.Title = "Doanh thu (VNĐ)";
            ch_revenue.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            ch_revenue.ChartAreas[0].AxisY.LabelStyle.Format = "#,##0 VNĐ";

            ch_revenue.Legends[0].Enabled = false;
        }

        private void cbo_month_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_month.SelectedIndex != -1)
            {
                cbo_quarter.SelectedIndex = -1;
                if (cbo_year.SelectedIndex != -1)
                {
                    int month = Convert.ToInt32(cbo_month.SelectedItem);
                    int year = Convert.ToInt32(cbo_year.SelectedItem);
                    CapNhatDoanhThu(month, year);
                }
                else
                {
                    MessageBox.Show("Please select a year first!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_month.SelectedIndex = -1; 
                }
            }
        }

        private void cbo_quarter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_quarter.SelectedIndex != -1)
            {
                cbo_month.SelectedIndex = -1;
                if (cbo_year.SelectedIndex != -1)
                {
                    int quarter = Convert.ToInt32(cbo_quarter.SelectedItem);
                    int year = Convert.ToInt32(cbo_year.SelectedItem);

                    CapNhatDoanhThuTheoQuy(quarter, year);
                }
                else
                {
                    MessageBox.Show("Please select a year first!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbo_quarter.SelectedIndex = -1; 
                }
            }
        }

        private void cbo_year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbo_year.SelectedIndex != -1)
            {
                int year = Convert.ToInt32(cbo_year.SelectedItem);

                if (cbo_month.SelectedIndex != -1)
                {
                    int month = Convert.ToInt32(cbo_month.SelectedItem);
                    CapNhatDoanhThu(month, year);
                }
                else if (cbo_quarter.SelectedIndex != -1)
                {
                    int quarter = Convert.ToInt32(cbo_quarter.SelectedItem);
                    CapNhatDoanhThuTheoQuy(quarter, year);
                }
                else
                {
                    CapNhatDoanhThu(null, year);
                }
            }
        }
    }
}
