using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;

namespace dentistry6boy
{

    public partial class qlNhakhoa : Form
    {
        private bool isAdmin; // Thêm biến thành viên để lưu trữ vai trò của người dùng

        private Dictionary<string, decimal> servicePrices = new Dictionary<string, decimal>();

        static string strCon = @"Data Source=DESKTOP-2HG5LN2;Initial Catalog=Dentistry;Integrated Security=True";
        SqlConnection sqlCon = new SqlConnection(strCon);
        private string gender = "";
        public qlNhakhoa()
        {
            InitializeComponent();
            // Đặt CultureInfo cho DateTimePicker
            appointmentDatePicker.Format = DateTimePickerFormat.Custom;
            appointmentDatePicker.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày tháng
            appointmentDatePicker.Value = DateTime.Now; // Set ngày mặc định
            dateOfBirthPicker.Format = DateTimePickerFormat.Custom;
            dateOfBirthPicker.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày tháng
            dateOfBirthPicker.Value = DateTime.Now; // Set ngày mặc định
            birthdayPicker.Format = DateTimePickerFormat.Custom;
            birthdayPicker.CustomFormat = "dd/MM/yyyy"; // Định dạng ngày tháng
            birthdayPicker.Value = DateTime.Now; // Set ngày mặc định

            // Đặt CultureInfo cho toàn bộ ứng dụng
            SetAppCulture(new CultureInfo("vi-VN"));
        }
        public qlNhakhoa(bool isAdmin)
        {
            InitializeComponent();
            this.isAdmin = isAdmin;

            // Điều chỉnh trạng thái của adminToolStripMenuItem
            adminToolStripMenuItem.Enabled = isAdmin;
        }
        private void UpdateAdminToolStripVisibility()
        {
            adminToolStripMenuItem.Enabled = isAdmin; // Cập nhật trạng thái của adminToolStripMenuItem dựa trên biến thành viên
        }
        private void SetAppCulture(CultureInfo culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
        private void Hien_thi_DL()
        {

            sqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("SELECT Appointments.AppointmentID, Patients.PatientID, Patients.PatientName, Patients.Gender, Patients.DateOfBirth, Patients.Address, Patients.PhoneNumber, Patients.Email, Appointments.AppointmentDateTime, Appointments.Notes, Appointments.Status FROM Appointments INNER JOIN Patients ON Appointments.PatientID = Patients.PatientID WHERE Appointments.Status = 'Chưa thăm khám';", sqlCon);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            DGV_lh.DataSource = Dt;
            sqlCon.Close();

        }
        private void Hien_thi_DLBn()
        {

            sqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Patients WHERE PatientStatus = 1;", sqlCon);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            DGV_bn.DataSource = Dt;
            sqlCon.Close();

        }

        private void Hien_thi_DV()
        {

            sqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Services;", sqlCon);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            DGV_dv.DataSource = Dt;
            sqlCon.Close();

        }

        private void Hien_thi_Bill()
        {

            sqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Bill;", sqlCon);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            DGV_bill.DataSource = Dt;
            sqlCon.Close();

        }

        private void qlNhakhoa_Load(object sender, EventArgs e)
        {
            Hien_thi_DL();
            Hien_thi_DLBn();
            Hien_thi_DV();
            Hien_thi_Bill();
        }
        private void RefreshDataGridView()
        {
            // Xóa dữ liệu hiện tại trong DataGridView
            DGV_lh.DataSource = null;
            DGV_lh.Rows.Clear();
            DGV_bn.DataSource = null;
            DGV_bn.Rows.Clear();
            // Tải lại dữ liệu vào DataGridView
            Hien_thi_DL();
            Hien_thi_DLBn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }
        //Hiển thị thông tin khi ấn vào một hàng nào đó
        private void DGV_lh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.RowIndex < DGV_lh.Rows.Count)
            {
                DataGridViewRow row = DGV_lh.Rows[e.RowIndex];
                txtPatientName.Text = row.Cells[2].Value.ToString();
                txtPhoneNumber.Text = row.Cells[6].Value.ToString();
                txtNotes.Text = row.Cells[9].Value.ToString();
                txtEmailAddress.Text = row.Cells[7].Value.ToString();
                txtAddress.Text = row.Cells[5].Value.ToString();
                string status = row.Cells[10].Value.ToString();

                // Set selected status in ComboBox
                comboBoxStatus.SelectedItem = status;

                // Handle gender
                string gender = row.Cells[3].Value.ToString();
                if (gender == "Nam")
                {
                    radNam.Checked = true;
                    radNu.Checked = false;
                }
                else if (gender == "Nữ")
                {
                    radNam.Checked = false;
                    radNu.Checked = true;
                }

                // Handle appointment date
                if (DateTime.TryParse(row.Cells[8].Value.ToString(), out DateTime appointmentDate))
                {
                    appointmentDatePicker.Value = appointmentDate;
                }
                else
                {
                    // Handle case where value cannot be converted to DateTime
                }

                // Handle date of birth
                if (DateTime.TryParse(row.Cells[4].Value.ToString(), out DateTime dateOfBirth))
                {
                    dateOfBirthPicker.Value = dateOfBirth;
                }
                else
                {
                    // Handle case where value cannot be converted to DateTime
                }
            }
        }



        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //thêm lịch hẹn
        private void btnThem_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin cần thiết đã được nhập chưa
            if (string.IsNullOrWhiteSpace(txtPatientName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmailAddress.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                comboBoxStatus.SelectedItem == null)
            {
                // Hiển thị thông báo yêu cầu nhập đầy đủ thông tin
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bệnh nhân và lịch hẹn.");
                return; // Không thực hiện các thao tác thêm nữa
            }
            // Mở kết nối đến cơ sở dữ liệu
            sqlCon.Open();

            // Tạo một transaction để đảm bảo tính nhất quán giữa các thao tác
            SqlTransaction transaction = sqlCon.BeginTransaction();

            try
            {
                string gender = radNam.Checked ? "Nam" : "Nữ";
                SqlCommand cmdAddPatient = null; // Khai báo ngoài phạm vi điều kiện
                if (comboBoxStatus.SelectedItem.ToString() == "Đã thăm khám")
                {

                    // Thêm thông tin bệnh nhân vào bảng "Patients"
                    cmdAddPatient = new SqlCommand("INSERT INTO Patients (PatientName, DateOfBirth, Gender, PhoneNumber, Email, Address, PatientStatus) VALUES (@PatientName, @DateOfBirth, @Gender, @PhoneNumber, @EmailAddress, @Address, '1'); SELECT SCOPE_IDENTITY();", sqlCon, transaction);
                    cmdAddPatient.Parameters.AddWithValue("@PatientName", txtPatientName.Text);
                    cmdAddPatient.Parameters.AddWithValue("@DateOfBirth", dateOfBirthPicker.Value);
                    cmdAddPatient.Parameters.AddWithValue("@Gender", gender);
                    cmdAddPatient.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                    cmdAddPatient.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text);
                    cmdAddPatient.Parameters.AddWithValue("@Address", txtAddress.Text);
                }
                
                // Thực thi câu lệnh và lấy ID của bệnh nhân vừa được thêm
                int patientId = Convert.ToInt32(cmdAddPatient.ExecuteScalar());

                // Thêm thông tin lịch hẹn vào bảng "Appointments" với ID của bệnh nhân vừa được thêm
                string selectedStatus = comboBoxStatus.SelectedItem.ToString(); // Lấy trạng thái được chọn từ ComboBox
                SqlCommand cmdAddAppointment = new SqlCommand("INSERT INTO Appointments (PatientId, AppointmentDateTime, Notes, Status) VALUES (@PatientId, @AppointmentDate, @Notes, @Status);", sqlCon, transaction);
                cmdAddAppointment.Parameters.AddWithValue("@PatientId", patientId);
                cmdAddAppointment.Parameters.AddWithValue("@AppointmentDate", appointmentDatePicker.Value);
                cmdAddAppointment.Parameters.AddWithValue("@Notes", txtNotes.Text);
                cmdAddAppointment.Parameters.AddWithValue("@Status", selectedStatus);

                // Thực thi câu lệnh thêm lịch hẹn
                cmdAddAppointment.ExecuteNonQuery();

                // Commit transaction nếu mọi thứ thành công
                transaction.Commit();

                // Thông báo thành công
                MessageBox.Show("Thêm lịch hẹn thành công!");
            }
            catch (Exception ex)
            {
                // Rollback transaction nếu có lỗi xảy ra
                transaction.Rollback();

                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi khi thêm lịch hẹn: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                sqlCon.Close();
            }
        }
        //update lịch hẹn
        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng trong DataGridView chưa
            if (DGV_lh.SelectedRows.Count > 0)
            {
                // Lấy ID của bệnh nhân từ hàng được chọn trong DataGridView
                int patientID = Convert.ToInt32(DGV_lh.SelectedRows[0].Cells["PatientID"].Value);

                // Chuẩn bị câu lệnh SQL để cập nhật thông tin bệnh nhân
                string gender = radNam.Checked ? "Nam" : "Nữ";
                string updatePatientQuery = @"
UPDATE Patients 
SET PatientName = @PatientName, 
    DateOfBirth = @DateOfBirth, 
    Gender = @Gender, 
    PhoneNumber = @PhoneNumber, 
    Email = @EmailAddress, 
    Address = @Address";
                if (comboBoxStatus.SelectedItem.ToString() == "Đã thăm khám")
                {
                    updatePatientQuery += ", PatientStatus = 1";
                }

                updatePatientQuery += " WHERE PatientID = @PatientID";
                // Chuẩn bị câu lệnh SQL để cập nhật thông tin lịch hẹn
                string updateAppointmentQuery = @"UPDATE Appointments 
                            SET AppointmentDateTime = @AppointmentDateTime, 
                                Notes = @Notes, 
                                Status = @Status 
                            WHERE PatientID = @PatientID";

                // Mở kết nối đến cơ sở dữ liệu và thực thi câu lệnh SQL
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    SqlTransaction transaction = sqlCon.BeginTransaction();
                    try
                    {
                        // Cập nhật thông tin trong bảng Patients
                        SqlCommand cmdUpdatePatient = new SqlCommand(updatePatientQuery, sqlCon, transaction);
                        cmdUpdatePatient.Parameters.AddWithValue("@PatientID", patientID);
                        cmdUpdatePatient.Parameters.AddWithValue("@PatientName", txtPatientName.Text);
                        cmdUpdatePatient.Parameters.AddWithValue("@DateOfBirth", dateOfBirthPicker.Value);
                        cmdUpdatePatient.Parameters.AddWithValue("@Gender", gender);
                        cmdUpdatePatient.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                        cmdUpdatePatient.Parameters.AddWithValue("@EmailAddress", txtEmailAddress.Text);
                        cmdUpdatePatient.Parameters.AddWithValue("@Address", txtAddress.Text);
                        cmdUpdatePatient.Parameters.AddWithValue("@Status", comboBoxStatus.SelectedItem.ToString());
                        cmdUpdatePatient.ExecuteNonQuery();

                        // Cập nhật thông tin trong bảng Appointments
                        string selectedStatus = comboBoxStatus.SelectedItem.ToString(); // Lấy trạng thái được chọn từ ComboBox
                        SqlCommand cmdUpdateAppointment = new SqlCommand(updateAppointmentQuery, sqlCon, transaction);
                        cmdUpdateAppointment.Parameters.AddWithValue("@PatientID", patientID);
                        cmdUpdateAppointment.Parameters.AddWithValue("@AppointmentDateTime", appointmentDatePicker.Value);
                        cmdUpdateAppointment.Parameters.AddWithValue("@Notes", txtNotes.Text);
                        // Đảm bảo rằng biến selectedStatus đã được định nghĩa ở một nơi khác trong code của bạn
                        cmdUpdateAppointment.Parameters.AddWithValue("@Status", selectedStatus);
                        cmdUpdateAppointment.ExecuteNonQuery();
                        // Commit transaction nếu mọi thứ thành công
                        transaction.Commit();

                        MessageBox.Show("Thông tin bệnh nhân và lịch hẹn đã được cập nhật thành công.");
                        // Sau khi cập nhật thành công, làm mới DataGridView để hiển thị thông tin mới
                        RefreshDataGridView();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction nếu có lỗi xảy ra
                        transaction.Rollback();
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để cập nhật.");
            }
        }
        //Xóa lịch hẹn
        SqlTransaction transaction = null; // Khai báo biến transaction ở mức phạm vi toàn cục
        private object cmdAddPatient;

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng trong DataGridView chưa
            if (DGV_lh.SelectedRows.Count > 0)
            {
                // Lấy ID của bệnh nhân từ hàng được chọn trong DataGridView
                int patientID = Convert.ToInt32(DGV_lh.SelectedRows[0].Cells["PatientID"].Value);

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân và tất cả các lịch hẹn của họ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Chuẩn bị câu lệnh SQL để xóa thông tin lịch hẹn của bệnh nhân
                    string deleteAppointmentQuery = "DELETE FROM Appointments WHERE PatientID = @PatientID";
                    // Chuẩn bị câu lệnh SQL để xóa thông tin bệnh nhân
                    string deletePatientQuery = "DELETE FROM Patients WHERE PatientID = @PatientID";

                    // Mở kết nối đến cơ sở dữ liệu và thực thi các câu lệnh SQL trong một giao dịch
                    using (SqlConnection sqlCon = new SqlConnection(strCon))
                    {
                        try
                        {
                            sqlCon.Open();
                            SqlTransaction transaction = sqlCon.BeginTransaction();

                            // Xóa thông tin lịch hẹn của bệnh nhân
                            SqlCommand cmdDeleteAppointment = new SqlCommand(deleteAppointmentQuery, sqlCon, transaction);
                            cmdDeleteAppointment.Parameters.AddWithValue("@PatientID", patientID);
                            cmdDeleteAppointment.ExecuteNonQuery();

                            // Xóa thông tin bệnh nhân
                            SqlCommand cmdDeletePatient = new SqlCommand(deletePatientQuery, sqlCon, transaction);
                            cmdDeletePatient.Parameters.AddWithValue("@PatientID", patientID);
                            cmdDeletePatient.ExecuteNonQuery();

                            transaction.Commit();

                            // Thông báo xóa thành công và làm mới DataGridView
                            MessageBox.Show("Bệnh nhân và tất cả các lịch hẹn của họ đã được xóa thành công!");
                            RefreshDataGridView();
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction nếu có lỗi xảy ra
                            transaction.Rollback();
                            MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }



        private void DGV_bn_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtpatname.Text = DGV_bn.CurrentRow.Cells[1].Value.ToString();
            txtphone.Text = DGV_bn.CurrentRow.Cells[5].Value.ToString();
            txtmail.Text = DGV_bn.CurrentRow.Cells[6].Value.ToString();
            txtdc.Text = DGV_bn.CurrentRow.Cells[4].Value.ToString();
            if (gender == "Nam")
            {
                radionam.Checked = true;
                radionu.Checked = false;
            }
            else if (gender == "Nữ")
            {
                radionam.Checked = false;
                radionu.Checked = true;
            }

            string birthdayString = DGV_bn.CurrentRow.Cells[2].Value.ToString(); // Lấy giá trị ngày tháng từ ô DataGridView
            DateTime birthday;
            if (DateTime.TryParse(birthdayString, out birthday)) // Chuyển đổi từ kiểu string sang kiểu DateTime
            {
                birthdayPicker.Value = birthday; // Gán giá trị DateTime vào Birthday
            }
            else
            {
                // Xử lý trường hợp không thể chuyển đổi giá trị sang kiểu DateTime
            }

        }

        //Chuyển đến form admin
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin adminForm = new fAdmin();
            adminForm.Show();
        }

        private void btnThemBN_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường thông tin cần thiết đã được nhập chưa
            if (string.IsNullOrWhiteSpace(txtpatname.Text) ||
                string.IsNullOrWhiteSpace(txtphone.Text) ||
                string.IsNullOrWhiteSpace(txtmail.Text) ||
                string.IsNullOrWhiteSpace(txtdc.Text)
                )
            {
                // Hiển thị thông báo yêu cầu nhập đầy đủ thông tin
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bệnh nhân.");
                return; // Không thực hiện các thao tác thêm nữa
            }
            // Mở kết nối đến cơ sở dữ liệu
            sqlCon.Open();

            // Tạo một transaction để đảm bảo tính nhất quán giữa các thao tác
            SqlTransaction transaction = sqlCon.BeginTransaction();

            try
            {
                string gender = radionam.Checked ? "Nam" : "Nữ";

                // Thêm thông tin bệnh nhân vào bảng "Patients"
                SqlCommand cmdAddPatient = new SqlCommand("INSERT INTO Patients (PatientName, DateOfBirth, Gender, PhoneNumber, Email, Address, PatientStatus) VALUES (@PatientName, @DateOfBirth, @Gender, @PhoneNumber, @EmailAddress, @Address, 1); SELECT SCOPE_IDENTITY();", sqlCon, transaction);
                cmdAddPatient.Parameters.AddWithValue("@PatientName", txtpatname.Text);
                cmdAddPatient.Parameters.AddWithValue("@DateOfBirth", birthdayPicker.Value);
                cmdAddPatient.Parameters.AddWithValue("@Gender", gender);
                cmdAddPatient.Parameters.AddWithValue("@PhoneNumber", txtphone.Text);
                cmdAddPatient.Parameters.AddWithValue("@EmailAddress", txtphone.Text);
                cmdAddPatient.Parameters.AddWithValue("@Address", txtdc.Text);
                // Thực thi câu lệnh thêm bệnh nhân
                cmdAddPatient.ExecuteNonQuery();

                // Commit transaction nếu mọi thứ thành công
                transaction.Commit();

                // Thông báo thành công
                MessageBox.Show("Thêm bệnh nhân thành công!");
            }
            catch (Exception ex)
            {
                // Rollback transaction nếu có lỗi xảy ra
                transaction.Rollback();

                // Hiển thị thông báo lỗi
                MessageBox.Show("Đã xảy ra lỗi khi thêm bệnh nhân: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                sqlCon.Close();
            }
        }

        private void btnRefBN_Click(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btnXoaBN_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng trong DataGridView chưa
            if (DGV_bn.SelectedRows.Count > 0)
            {
                // Lấy ID của bệnh nhân từ hàng được chọn trong DataGridView
                int patientID = Convert.ToInt32(DGV_bn.SelectedRows[0].Cells["PatientID"].Value);

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa bệnh nhân?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Mở kết nối đến cơ sở dữ liệu
                    using (SqlConnection sqlCon = new SqlConnection(strCon))
                    {
                        try
                        {
                            sqlCon.Open();

                            // Xóa các bản ghi từ bảng "Appointments" liên quan đến bệnh nhân
                            string deleteAppointmentsQuery = "DELETE FROM Appointments WHERE PatientID = @PatientID";
                            SqlCommand cmdDeleteAppointments = new SqlCommand(deleteAppointmentsQuery, sqlCon);
                            cmdDeleteAppointments.Parameters.AddWithValue("@PatientID", patientID);
                            cmdDeleteAppointments.ExecuteNonQuery();

                            // Xóa bệnh nhân từ bảng "Patients"
                            string deletePatientsQuery = "DELETE FROM Patients WHERE PatientID = @PatientID";
                            SqlCommand cmdDeletePatients = new SqlCommand(deletePatientsQuery, sqlCon);
                            cmdDeletePatients.Parameters.AddWithValue("@PatientID", patientID);
                            cmdDeletePatients.ExecuteNonQuery();

                            // Thông báo xóa thành công và làm mới DataGridView
                            MessageBox.Show("Bệnh nhân đã được xóa thành công!");
                            RefreshDataGridView();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để xóa.");
            }
        }

        private void btnSuaBN_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem người dùng đã chọn một hàng trong DataGridView chưa
            if (DGV_bn.SelectedRows.Count > 0)
            {
                // Lấy ID của bệnh nhân từ hàng được chọn trong DataGridView
                int patID = Convert.ToInt32(DGV_bn.SelectedRows[0].Cells["PatientID"].Value);

                // Chuẩn bị câu lệnh SQL để cập nhật thông tin bệnh nhân
                string gender = radionam.Checked ? "Nam" : "Nữ";
                string updatePatientQuery = @"
UPDATE Patients 
SET PatientName = @PatientName, 
    DateOfBirth = @DateOfBirth, 
    Gender = @Gender, 
    PhoneNumber = @PhoneNumber, 
    Email = @EmailAddress, 
    Address = @Address WHERE PatientID = @PatientID";


                // Mở kết nối đến cơ sở dữ liệu và thực thi câu lệnh SQL
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    SqlTransaction transaction = sqlCon.BeginTransaction();
                    try
                    {
                        // Cập nhật thông tin trong bảng Patients
                        SqlCommand cmdUpdatePatient = new SqlCommand(updatePatientQuery, sqlCon, transaction);
                        cmdUpdatePatient.Parameters.AddWithValue("@PatientID", patID);
                        cmdUpdatePatient.Parameters.AddWithValue("@PatientName", txtpatname.Text);
                        cmdUpdatePatient.Parameters.AddWithValue("@DateOfBirth", birthdayPicker.Value);
                        cmdUpdatePatient.Parameters.AddWithValue("@Gender", gender);
                        cmdUpdatePatient.Parameters.AddWithValue("@PhoneNumber", txtphone.Text);
                        cmdUpdatePatient.Parameters.AddWithValue("@EmailAddress", txtmail.Text);
                        cmdUpdatePatient.Parameters.AddWithValue("@Address", txtdc.Text);
                        cmdUpdatePatient.ExecuteNonQuery();


                        transaction.Commit();

                        MessageBox.Show("Thông tin bệnh nhân đã được cập nhật thành công.");
                        // Sau khi cập nhật thành công, làm mới DataGridView để hiển thị thông tin mới
                        RefreshDataGridView();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction nếu có lỗi xảy ra
                        transaction.Rollback();
                        MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một hàng để cập nhật.");
            }

        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            if (txtTimkiem.Text == "")
            {
                MessageBox.Show("Nhập từ khoá cần tìm");
            }
            else
            {
                try
                {

                    sqlCon.Open();
                    SqlDataAdapter Da = new SqlDataAdapter("SELECT Appointments.AppointmentID, Appointments.AppointmentDateTime, Appointments.Notes, Appointments.Status, Patients.PatientName, Patients.Gender, Patients.DateOfBirth, Patients.Address, Patients.PhoneNumber, Patients.Email FROM Appointments INNER JOIN Patients ON Appointments.PatientID = Patients.PatientID WHERE Appointments.Status = 'Chưa thăm khám' AND (Patients.PatientName LIKE '%' + @searchTerm + '%' OR Patients.PhoneNumber LIKE '%' + @searchTerm + '%' OR Patients.Email LIKE '%' + @searchTerm + '%')", sqlCon);
                    Da.SelectCommand.Parameters.AddWithValue("@searchTerm", txtTimkiem.Text);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    DGV_lh.DataSource = Dt;
                    sqlCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi");
                }

            }
        }



        private void DGV_dv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnTinhTotal_Click(object sender, EventArgs e)
        {
            CultureInfo viCulture = new CultureInfo("vi-VN");
            // Tính toán tổng tiền
            decimal total = 0.0m;
            foreach (DataGridViewRow row in DGV_dv.Rows)
            {
                // Kiểm tra xem hàng có tồn tại và có được chọn không
                if (row != null && row.Cells[4].Value != null && Convert.ToBoolean(row.Cells[4].Value))
                {
                    // Kiểm tra xem cột "Price" và "quantity" có tồn tại không
                    if (row.Cells["Price"].Value != null && row.Cells["quantity"].Value != null)
                    {
                        decimal Price = Convert.ToDecimal(row.Cells["Price"].Value);
                        int quantity;

                        if (int.TryParse(row.Cells["quantity"].Value.ToString(), out quantity))
                        {
                            total += Price * quantity;
                        }
                        else
                        {
                            // Xử lý trường hợp không thể chuyển đổi thành số nguyên
                            // Ví dụ: Hiển thị thông báo lỗi cho người dùng
                        }
                    }
                    else
                    {
                        // Xử lý trường hợp cột "Price" hoặc "quantity" không tồn tại
                    }
                }

            }

            // Hiển thị tổng tiền trong TextBox
            txtTotalPrice.Text = total.ToString("C", viCulture);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem các trường thông tin cần thiết đã được nhập chưa
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSDT.Text))
                {
                    // Hiển thị thông báo yêu cầu nhập đầy đủ thông tin
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                    return; // Không thực hiện các thao tác thêm nữa
                }

                List<(string ServiceName, int Quantity, decimal Price)> selectedServices = new List<(string, int, decimal)>();

                foreach (DataGridViewRow row in DGV_dv.Rows)
                {
                    if (row != null && row.Cells[4].Value != null && Convert.ToBoolean(row.Cells[4].Value))
                    {
                        // Kiểm tra xem cột "Price" và "quantity" có tồn tại không
                        if (row.Cells["Price"].Value != null && row.Cells["quantity"].Value != null)
                        {
                            string ServiceName = row.Cells["ServiceName"].Value.ToString();
                            int Quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                            decimal Price = Convert.ToDecimal(row.Cells["Price"].Value);
                            selectedServices.Add((ServiceName, Quantity, Price));
                        }
                        else
                        {
                            // Xử lý trường hợp cột "Price" hoặc "quantity" không tồn tại
                        }
                    }
                }

                // Tính tổng tiền của tất cả các dịch vụ được chọn
                decimal total = selectedServices.Sum(service => service.Quantity * service.Price);

                // Thêm thông tin hóa đơn vào bảng "Bill"
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    SqlTransaction transaction = sqlCon.BeginTransaction();

                    try
                    {
                        foreach (var service in selectedServices)
                        {
                            string insertQuery = "INSERT INTO Bill (HoTen, SoDienThoai, DichVu, SoLuong, TongTien) VALUES (@Name, @SDT, @ServiceName, @quantity, @TotalPrice);";
                            SqlCommand cmdAddBill = new SqlCommand(insertQuery, sqlCon, transaction);
                            cmdAddBill.Parameters.AddWithValue("@Name", txtName.Text);
                            cmdAddBill.Parameters.AddWithValue("@SDT", txtSDT.Text);
                            cmdAddBill.Parameters.AddWithValue("@ServiceName", service.ServiceName);
                            cmdAddBill.Parameters.AddWithValue("@quantity", service.Quantity);
                            cmdAddBill.Parameters.AddWithValue("@TotalPrice", service.Quantity * service.Price);
                            cmdAddBill.ExecuteNonQuery();
                        }

                        // Commit transaction nếu mọi thứ thành công
                        transaction.Commit();

                        // Thông báo thành công
                        MessageBox.Show("Đã lưu hóa đơn!");
                        Hien_thi_Bill();
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction nếu có lỗi xảy ra
                        transaction.Rollback();

                        // Hiển thị thông báo lỗi
                        MessageBox.Show("Đã xảy ra lỗi khi thêm dịch vụ: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi kết nối đến cơ sở dữ liệu
                MessageBox.Show("Đã xảy ra lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có dữ liệu hóa đơn để in không
                if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtSDT.Text) || string.IsNullOrWhiteSpace(txtTotalPrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi in.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Mở hộp thoại lưu tệp
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Tệp văn bản (*.txt)|*.txt|Tất cả các tệp (*.*)|*.*";
                saveFileDialog.Title = "In hóa đơn";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
                        // Ghi thông tin hóa đơn vào tệp văn bản
                        sw.WriteLine("Họ tên: " + txtName.Text);
                        sw.WriteLine("Số điện thoại: " + txtSDT.Text);
                        sw.WriteLine("Dịch vụ dùng: ");

                        decimal total = 0.0m;

                        foreach (DataGridViewRow row in DGV_dv.Rows)
                        {
                            DataGridViewCheckBoxCell chk = row.Cells["CheckBoxSelected"] as DataGridViewCheckBoxCell;

                            if (chk.Value != null && (bool)chk.Value)
                            {
                                string ServiceName = row.Cells["ServiceName"].Value.ToString();
                                int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                                decimal Price = Convert.ToDecimal(row.Cells["Price"].Value);
                                total += Price * quantity;
                                sw.WriteLine($"- {ServiceName} - Số lượng: {quantity} - Tổng tiền: {(Price * quantity).ToString("C")}");
                            }
                        }

                        // Ghi tổng tiền của hóa đơn
                        sw.WriteLine("Tổng tiền: " + total.ToString("C"));

                        MessageBox.Show("Hóa đơn đã được in thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi in hóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
