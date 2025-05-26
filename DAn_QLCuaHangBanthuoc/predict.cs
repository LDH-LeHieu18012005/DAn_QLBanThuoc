using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

using Newtonsoft.Json;

namespace DAn_QLCuaHangBanthuoc
{
    public partial class predict : Form
    {
        public predict()
        {
            InitializeComponent();
        }
        private float[] ProcessInputData()
        {
            float gender = cbGender.SelectedItem.ToString() == "Male" ? 1 : 0;
            float age = float.Parse(txtAge.Text) / 100f; // Min-max scale ví dụ
            float hypertension = chkHTN.Checked ? 1 : 0;
            float heartDisease = chkHeart.Checked ? 1 : 0;
            float everMarried = cbMarried.SelectedItem.ToString() == "Yes" ? 1 : 0;
            float residenceType = cbRes.SelectedItem.ToString() == "Urban" ? 1 : 0;
            float avgGlucose = float.Parse(txtGlucose.Text) / 300f; // scale ví dụ
            float bmi = float.Parse(txtBMI.Text) / 50f; // scale ví dụ

            // One-hot cho work_type: Never_worked, Private, Self-employed
            string work = cbWork.SelectedItem.ToString();
            float work_Never = work == "Never_worked" ? 1 : 0;
            float work_Private = work == "Private" ? 1 : 0;
            float work_Self = work == "Self-employed" ? 1 : 0;

            // One-hot cho smoking_status: never smoked, smokes
            string smoke = cbSmoke.SelectedItem.ToString();
            float smoke_never = smoke == "never smoked" ? 1 : 0;
            float smoke_smokes = smoke == "smokes" ? 1 : 0;

            return new float[]
            {
        gender, age, hypertension, heartDisease, everMarried, residenceType,
        avgGlucose, bmi,
        work_Never, work_Private, work_Self,
        smoke_never, smoke_smokes
            };
        }
        private bool ValidateInputs()
        {
            // Kiểm tra các ComboBox có được chọn hay không
            if (cbGender.SelectedItem == null ||
                cbMarried.SelectedItem == null ||
                cbRes.SelectedItem == null ||
                cbWork.SelectedItem == null ||
                cbSmoke.SelectedItem == null)
            {
                MessageBox.Show("Please select all dropdown options.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra các textbox có được nhập và hợp lệ hay không
            if (string.IsNullOrWhiteSpace(txtAge.Text) ||
                string.IsNullOrWhiteSpace(txtGlucose.Text) ||
                string.IsNullOrWhiteSpace(txtBMI.Text))
            {
                MessageBox.Show("Please enter Age, Glucose level, and BMI.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Kiểm tra dữ liệu nhập có phải số hợp lệ không
            bool isAgeValid = float.TryParse(txtAge.Text, out float age);
            bool isGlucoseValid = float.TryParse(txtGlucose.Text, out float glucose);
            bool isBMIValid = float.TryParse(txtBMI.Text, out float bmi);

            if (!isAgeValid || !isGlucoseValid || !isBMIValid)
            {
                MessageBox.Show("Age, Glucose, and BMI must be valid numbers.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void btnPredict_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                // Nếu không hợp lệ thì thoát, không tiếp tục
                return;
            }
            var features = ProcessInputData();

            var requestData = new { features = features };
            string json = JsonConvert.SerializeObject(requestData);

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync("http://127.0.0.1:5000/predict", content);
                    response.EnsureSuccessStatusCode(); // sẽ throw lỗi nếu không 2xx

                    string responseJson = await response.Content.ReadAsStringAsync();
                    dynamic result = JsonConvert.DeserializeObject(responseJson);

                    MessageBox.Show("Dự đoán: " + ((int)result.stroke_risk == 1 ? "Nguy cơ đột quỵ" : "Không có nguy cơ"));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi gửi yêu cầu: " + ex.Message);
                }
            }
        }
    }
}
