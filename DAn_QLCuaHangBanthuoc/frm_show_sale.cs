using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using BLL;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class frm_show_sale : Form
    {
        private readonly frm_Main _mainForm;
        BLL_sale bll;
        string id;
        string status;
        public frm_show_sale(frm_Main mainForm, string idHD)
        {
            InitializeComponent();
            _mainForm = mainForm;
            bll = new BLL_sale();
            if (!string.IsNullOrEmpty(idHD))
            {
                id = idHD;
                DataTable tb = bll.GetSaleDetail(id);
                DataRow row = bll.GetRow(id);
                lbl_date.Text = row[3].ToString();
                lbl_customer.Text = row[2].ToString();
                decimal totalAmount = 0;
                if (tb.Rows.Count > 0)
                {
                    foreach (DataRow r in tb.Rows)
                    {
                        dgv_data.Rows.Add(r[7], r[6], r[5], r[8]);
                        totalAmount += Convert.ToDecimal(r[8]);
                        status = r[4].ToString();
                    }
                    lbl_price.Text = totalAmount + " VND";
                }
            }
            checkTT();
        }
        bool checkTT()
        {
            if (status == "Pending")
            {
                btn_print.Enabled = false; 
                cbo_status.Visible = true; 
                btn_edit.Visible = true; 
                label11.Visible = true; 
                return false;
            }
            else 
            {
                btn_print.Enabled = true; 
                cbo_status.Visible = false;
                btn_edit.Visible = false; 
                label11.Visible = false; 
                return true;
            }
        }
        private void btn_print_Click(object sender, EventArgs e)
        {
            if (checkTT())
            {
                Document document = new Document(PageSize.A4);
                // Lưu tệp PDF vào thư mục MyDocuments
                string pdfPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Invoice.pdf");
                string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "error.log");

                FileStream fs = null;
                try
                {
                    // Tạo tệp PDF
                    fs = new FileStream(pdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
                    PdfWriter writer = PdfWriter.GetInstance(document, fs);
                    document.SetMargins(0, document.TopMargin, document.LeftMargin, document.BottomMargin);
                    document.Open();

                    // Chụp giao diện pn_Print
                    Bitmap bmp = new Bitmap(pn_Print.Width, pn_Print.Height);
                    try
                    {
                        btn_print.Visible = false;
                        btn_close.Visible = false;
                        pn_Print.Refresh(); // Đảm bảo panel được vẽ hoàn toàn
                        pn_Print.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, pn_Print.Width, pn_Print.Height));

                        // Lưu Bitmap để kiểm tra (tạm thời)
                        string tempImagePath = Path.Combine(Path.GetTempPath(), "test_bitmap.png");
                        bmp.Save(tempImagePath, System.Drawing.Imaging.ImageFormat.Png);
                        File.AppendAllText(logPath, $"{DateTime.Now}: Đã lưu Bitmap tạm tại {tempImagePath}\n");
                    }
                    catch (Exception bmpEx)
                    {
                        File.AppendAllText(logPath, $"{DateTime.Now}: Lỗi khi chụp Bitmap: {bmpEx.ToString()}\n");
                        throw;
                    }
                    finally
                    {
                        btn_print.Visible = true;
                        btn_close.Visible = true;
                    }

                    // Thêm hình ảnh vào PDF
                    iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp);
                    pic.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    pic.SetAbsolutePosition(document.Left, document.Top - pic.ScaledHeight);
                    document.Add(pic);

                    // Đóng document trước khi đóng FileStream
                    document.Close();
                    File.AppendAllText(logPath, $"{DateTime.Now}: Đã tạo tệp PDF tại {pdfPath}\n");
                }
                catch (UnauthorizedAccessException uae)
                {
                    File.AppendAllText(logPath, $"{DateTime.Now}: Lỗi quyền truy cập: {uae.ToString()}\n");
                    MessageBox.Show("Không có quyền ghi tệp vào thư mục. Vui lòng chạy ứng dụng với quyền quản trị viên hoặc kiểm tra quyền truy cập thư mục Documents.");
                    return;
                }
                catch (Exception ex)
                {
                    File.AppendAllText(logPath, $"{DateTime.Now}: Lỗi khi tạo PDF: {ex.ToString()}\n");
                    MessageBox.Show("Lỗi khi tạo PDF. Vui lòng kiểm tra tệp error.log trong thư mục Documents.");
                    return;
                }
                finally
                {
                    // Đóng FileStream sau khi document đã được đóng
                    fs?.Close();
                    fs?.Dispose();
                }

                // Mở tệp PDF
                try
                {
                    if (File.Exists(pdfPath))
                    {
                        File.AppendAllText(logPath, $"{DateTime.Now}: Đang mở tệp PDF: {pdfPath}\n");
                        Process.Start(new ProcessStartInfo(pdfPath) { UseShellExecute = true });
                    }
                    else
                    {
                        File.AppendAllText(logPath, $"{DateTime.Now}: Tệp PDF không tồn tại tại {pdfPath}\n");
                        MessageBox.Show($"Tệp {pdfPath} không được tạo. Vui lòng kiểm tra tệp error.log trong thư mục Documents.");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(logPath, $"{DateTime.Now}: Lỗi khi mở PDF: {ex.ToString()}\n");
                    MessageBox.Show("Không thể mở tệp PDF: " + ex.Message);
                    return;
                }

                // Chuyển về form bán hàng và đóng form hiện tại
                _mainForm.container(new frm_sale(_mainForm));
                this.Close();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            _mainForm.container(new frm_sale(_mainForm));
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbo_status.Text))
            {
                MessageBox.Show("Please confirm the invoice status.!!!", "Warning!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bll.Confirm(id, cbo_status.Text);
            status = cbo_status.Text;
            MessageBox.Show("Invoice status updated successfully!!!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            checkTT();
        }
    }
}
