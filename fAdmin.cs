using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace dentistry6boy
{
    public partial class fAdmin : Form
    {
        static string strCon = @"Data Source=MSI\SQLEXPRESS;Initial Catalog=Dentistry;Integrated Security=True;";
        SqlConnection sqlCon = new SqlConnection(strCon);
        public fAdmin()
        {
            InitializeComponent();
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void fAdmin_Load(object sender, EventArgs e)
        {
            Hien_thi_DV();
            Hien_thi_NV();
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem các trường thông tin cần thiết đã được nhập chưa
                if (string.IsNullOrWhiteSpace(txtServiceName.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    // Hiển thị thông báo yêu cầu nhập đầy đủ thông tin
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin dịch vụ.");
                    return; // Không thực hiện các thao tác thêm nữa
                }
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    SqlTransaction transaction = sqlCon.BeginTransaction();

                    try
                    {
                        // Thêm thông tin dịch vụ vào bảng "Services"

                        string insertQuery = "INSERT INTO Services (ServiceName, Price) VALUES (@ServiceName, @Price);";
                        SqlCommand cmdAddService = new SqlCommand(insertQuery, sqlCon, transaction);
                        cmdAddService.Parameters.AddWithValue("@ServiceName", txtServiceName.Text);
                        cmdAddService.Parameters.AddWithValue("@Price", txtPrice.Text);

                        // Thực thi câu lệnh thêm dịch vụ
                        cmdAddService.ExecuteNonQuery();

                        // Commit transaction nếu mọi thứ thành công
                        transaction.Commit();

                        // Thông báo thành công
                        MessageBox.Show("Thêm dịch vụ thành công!");
                        Hien_thi_DV();
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

        //Tab Nhan vien
        private void Hien_thi_NV()
        {

            sqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Dentists;", sqlCon);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            DGV_NV.DataSource = Dt;
            sqlCon.Close();

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string gender = rbtnNam.Checked ? "Nam" : "Nữ";
                Exe("INSERT INTO Dentists(MaTT,HoTen,GioiTinh,NgaySinh,DiaChi,Email) VALUES(N'" + MaTT.Text + "',N'" + txtHovaten.Text + "', N'" + gender + "', N'" + dateNS.Value + "', N'" + txtDiachi.Text + "', N'" + txtEmail.Text + "') ");
                MessageBox.Show("Them thanh cong: ");
                Hien_thi_NV();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi thêm: " + ex.Message);
            }

        }

        private void Exe(string query)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    SqlCommand cmd = new SqlCommand(query, sqlCon);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi xảy ra: " + ex.Message);
            }
        }

        private void btnRs_Click(object sender, EventArgs e)
        {

            string gender = rbtnNam.Checked ? "Nam" : "Nữ";


            MaTT.ResetText();
            txtHovaten.ResetText();
            txtDiachi.ResetText();
            txtEmail.ResetText();
            dateNS.ResetText();


            rbtnNam.Checked = true;
            rbtnNu.Checked = false;


        }

        private void txtDiachi_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)

        {
            // Check if a row is selected in the DataGridView
            if (DGV_NV.SelectedRows.Count > 0)
            {
                // Get the DentistID from the selected row in the DataGridView
                int DentistID = Convert.ToInt32(DGV_NV.SelectedRows[0].Cells["DentistID"].Value);
                try
                {
                    // Set gender based on the selected RadioButton
                    string gender = rbtnNam.Checked ? "Nam" : "Nữ";

                    // Construct the SQL query using parameterized queries
                    string query = "UPDATE Dentists SET " +
                                   "HoTen = @HoTen, " +
                                   "MaTT = @MaTT, " +
                                   "NgaySinh = @NgaySinh, " +
                                   "DiaChi = @DiaChi, " +
                                   "Email = @Email " +
                                   "WHERE DentistID = @DentistID";

                    // Create a new SqlCommand object with the query and connection
                    using (SqlConnection sqlCon = new SqlConnection(strCon))
                    {
                        sqlCon.Open();
                        SqlTransaction transaction = sqlCon.BeginTransaction();
                        try
                        {
                            // Cập nhật thông tin trong bảng Patients
                            SqlCommand command = new SqlCommand(query, sqlCon, transaction);
                            // Add parameters to the SqlCommand
                            command.Parameters.AddWithValue("@HoTen", txtHovaten.Text);
                            command.Parameters.AddWithValue("@MaTT", MaTT.Text);
                            command.Parameters.AddWithValue("@NgaySinh", dateNS.Value);
                            command.Parameters.AddWithValue("@DiaChi", txtDiachi.Text);
                            command.Parameters.AddWithValue("@Email", txtEmail.Text);
                            command.Parameters.AddWithValue("@DentistID", DentistID);

                            // Execute the query
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            // Show success message
                            MessageBox.Show("Sửa thành công.");
                            // Refresh the DataGridView
                            Hien_thi_NV();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã xảy ra lỗi khi sửa: " + ex.Message);
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi sửa: " + ex.Message);
                }
            }
        }

        private void DGV_NV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            MaTT.Text = DGV_NV.CurrentRow.Cells[1].Value.ToString();
            txtHovaten.Text = DGV_NV.CurrentRow.Cells[2].Value.ToString();
            dateNS.Text = DGV_NV.CurrentRow.Cells[4].Value.ToString();
            txtDiachi.Text = DGV_NV.CurrentRow.Cells[5].Value.ToString();
            txtEmail.Text = DGV_NV.CurrentRow.Cells[6].Value.ToString();
        }
        private void rbtnNam_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            if (DGV_NV.SelectedRows.Count > 0)
            {
               
                int DentistID = Convert.ToInt32(DGV_NV.SelectedRows[0].Cells["DentistID"].Value);
                try
                {
                  
                    string query = "DELETE FROM Dentists WHERE DentistID = @DentistID";

                   
                    using (SqlConnection sqlCon = new SqlConnection(strCon))
                    {
                        sqlCon.Open();
                        SqlTransaction transaction = sqlCon.BeginTransaction();
                        try
                        {
                           
                            SqlCommand command = new SqlCommand(query, sqlCon, transaction);
                            command.Parameters.AddWithValue("@DentistID", DentistID);

                        
                            command.ExecuteNonQuery();
                            transaction.Commit();
                           
                            MessageBox.Show("Xóa thành công.");
                       
                            Hien_thi_NV();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi xóa: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa.");
            }
        }

       

        private void btnSearchDentist_Click(object sender, EventArgs e)
        {
            if (TimKiem.Text == "")
            {
                MessageBox.Show("Nhập từ khoá cần tìm");
            }
            else
            {
                try
                {

                    sqlCon.Open();
                    SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Dentists Where HoTen Like '%' + @searchTerm + '%';", sqlCon);
                    Da.SelectCommand.Parameters.AddWithValue("@searchTerm", TimKiem.Text);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    DGV_NV.DataSource = Dt;
                    sqlCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi");
                }

            }
        }
    }
}
