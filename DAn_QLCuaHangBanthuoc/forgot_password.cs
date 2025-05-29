using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class forgot_password : Form
    {
        public forgot_password()
        {
            InitializeComponent();
        }
        private string currentOtp = "";
        private string GenerateOtp()
        {
            Random rand = new Random();
            return rand.Next(100000, 999999).ToString();  // mã OTP 6 số
        }
        private void SendOtpToEmail(string emailTo, string otpCode)
        {
            string fromEmail = "duonghieulehy@gmail.com";  // Email gửi OTP
            string password = "bwbm jglt wzyf oeva";        // App Password (KHÔNG dùng mật khẩu thật)

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromEmail);
            mail.To.Add(emailTo);
            mail.Subject = "Mã OTP khôi phục mật khẩu";
            mail.Body = $"Mã xác thực OTP của bạn là: {otpCode}";

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(fromEmail, password);
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(mail);
                MessageBox.Show("The OTP has been sent to your email.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while sending email: " + ex.Message);
            }
        }
        private bool IsEmailExists(string email)
        {
            bool exists = false;
            string connectionString = @"Data Source=LEHIEU\LEHIEU;Initial Catalog=DAn_1_QLBanThuoc;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Staff WHERE gmail = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        exists = count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking email: " + ex.Message);
                    }
                }
            }

            return exists;
        }
        private bool IsEmailExists(string email, string username)
        {
            bool exists = false;
            string connectionString = @"Data Source=LEHIEU\LEHIEU;Initial Catalog=DAn_1_QLBanThuoc;Integrated Security=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Staff WHERE gmail = @Email AND username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        conn.Open();
                        int count = (int)cmd.ExecuteScalar();
                        exists = count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error checking email and username: " + ex.Message);
                    }
                }
            }

            return exists;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string emailInput = txtemail.Text.Trim();
            string usernameInput = txtTK.Text.Trim();

            if (string.IsNullOrEmpty(emailInput))
            {
                MessageBox.Show("Please enter your email.");
                return;
            }

            if (string.IsNullOrEmpty(usernameInput))
            {
                MessageBox.Show("Please enter your username.");
                return;
            }

            // Kiểm tra email và username trong CSDL
            if (IsEmailExists(emailInput, usernameInput))
            {
                currentOtp = GenerateOtp();
                SendOtpToEmail(emailInput, currentOtp);
            }
            else
            {
                MessageBox.Show("This email does not belong to the provided username!");
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // Kiểm tra người dùng đã nhập đầy đủ thông tin hay chưa
            if (string.IsNullOrWhiteSpace(txtTK.Text) || string.IsNullOrWhiteSpace(txtcode.Text))
            {
                MessageBox.Show("Please enter both Username and OTP code!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mã OTP có khớp không
            if (txtcode.Text == currentOtp)
            {
                new_password frm = new new_password(txtTK.Text);
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The OTP code is incorrect!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
