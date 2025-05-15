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
                try
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("Invoice.pdf", FileMode.Create));
                    document.SetMargins(0, document.TopMargin, document.LeftMargin, document.BottomMargin);
                    document.Open();
                    Bitmap bmp = new Bitmap(pn_Print.Width, pn_Print.Height);
                    btn_print.Visible = false;
                    btn_close.Visible = false;
                    pn_Print.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, pn_Print.Width, pn_Print.Height));
                    btn_print.Visible = true;
                    btn_close.Visible = true;
                    iTextSharp.text.Image pic = iTextSharp.text.Image.GetInstance(bmp, System.Drawing.Imaging.ImageFormat.Bmp);
                    pic.ScaleToFit(PageSize.A4.Width, PageSize.A4.Height);
                    pic.SetAbsolutePosition(document.Left, document.Top - pic.ScaledHeight);
                    document.Add(pic);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi tạo PDF: " + ex.Message);
                }
                finally
                {
                    document.Close();
                    this.Close();
                }
                Process.Start("Invoice.pdf");
                _mainForm.container(new frm_sale(_mainForm));
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
