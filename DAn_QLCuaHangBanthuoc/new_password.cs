using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class new_password : Form
    {
        private string taiKhoan;

        // Đây là constructor có 1 tham số string
        public new_password(string tenTaiKhoan)
        {
            InitializeComponent();
            taiKhoan = tenTaiKhoan;
        }
        public new_password()
        {
            InitializeComponent();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            string newPassword = txtpass.Text.Trim();
            string confirmPassword = txtnewpass.Text.Trim();

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Please enter both the new password and the confirmation password.");
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("The confirmation password does not match!");
                return;
            }

            try
            {
                // Chuỗi kết nối, bạn thay đổi theo cấu hình của bạn
                string connectionString = @"Data Source=LEHIEU\LEHIEU;Initial Catalog=DAn_1_QLBanThuoc;Integrated Security=True;TrustServerCertificate=True";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Câu lệnh update mật khẩu
                    string sql = "UPDATE Staff SET password = @password WHERE username = @username";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@password", newPassword);
                        cmd.Parameters.AddWithValue("@username", taiKhoan);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Password updated successfully!");
                            this.Close();

                            // Mở lại form đăng nhập
                            frm_Login loginForm = new frm_Login(1); // Thay LoginForm bằng tên form login của bạn
                            loginForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password update failed. Please try again.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating password: " + ex.Message);
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            frm_Login loginForm = new frm_Login(0);  // Tạo đối tượng form đăng nhập
            loginForm.Show();                       // Hiển thị form đăng nhập
            this.Close();
        }
    }
}
