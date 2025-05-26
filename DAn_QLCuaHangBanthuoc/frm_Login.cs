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
    public partial class frm_Login : Form
    {
        private Dictionary<string, string> accountList;
        private Dictionary<string, string> staffRoles;
        private int mode; // 0 for admin, 1 for staff
        private BLL_login BLL_Login;

        public frm_Login(int mode)
        {
            InitializeComponent();
            accountList = new Dictionary<string, string>();
            staffRoles = new Dictionary<string, string>();
            BLL_Login = new BLL_login();
            this.mode = mode;
            UpdateLinkLabelText();
        }

        private void UpdateLinkLabelText()
        {
            if (mode == 0)
            {
                linkLabel1.Text = "Sign in as a staff member";
                lbl_role.Text = "Manager";
            }
            else
            {
                linkLabel1.Text = "Sign in with administrator role";
                lbl_role.Text = "Staff";
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Login()
        {
            accountList.Clear();
            staffRoles.Clear();

            if (mode == 0) // Admin mode
            {
                // Only allow users with Management role to login in admin mode
                DataTable dataTable = BLL_Login.GetNV();
                foreach (DataRow row in dataTable.Rows)
                {
                    string username = row[7].ToString();
                    string password = row[8].ToString();
                    string role = row[9].ToString(); // type_staff column

                    if (role == "Management")
                    {
                        accountList.Add(username, password);
                        staffRoles.Add(username, role);
                    }
                }

                // Add the hardcoded admin account if needed
                accountList.Add("admin", "000");
                staffRoles.Add("admin", "Management");
            }
            else // Staff mode
            {
                // Allow all staff to login (both Management and Staff roles)
                DataTable dataTable = BLL_Login.GetNV();
                foreach (DataRow row in dataTable.Rows)
                {
                    string username = row[7].ToString();
                    string password = row[8].ToString();
                    string role = row[9].ToString(); // type_staff column
                    bool isActive = Convert.ToBoolean(row[10]); // is_active column

                    // Only add active staff accounts
                    if (isActive)
                    {
                        accountList.Add(username, password);
                        staffRoles.Add(username, role);
                    }
                }
            }

            if (txtTK.Text != "" && txtMK.Text != "")
            {
                if (accountList.Keys.Contains(txtTK.Text))
                {
                    if (txtMK.Text == accountList[txtTK.Text])
                    {
                        // Get the actual role from staffRoles dictionary
                        string role = staffRoles[txtTK.Text];

                        this.Hide();
                        frm_Main menuForm = new frm_Main(mode, this, role, txtTK.Text);
                        menuForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtMK.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect username or password!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTK.Text = "";
                    txtMK.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please provide both username and password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (mode == 0)
            {
                mode = 1;
            }
            else
            {
                mode = 0;
            }
            UpdateLinkLabelText();
            txtTK.Clear();
            txtMK.Clear();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            forgot_password frm = new forgot_password();
            frm.Show();
            this.Hide();
        }
    }
}