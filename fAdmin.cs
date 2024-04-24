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
using System.Windows.Forms.VisualStyles;

namespace dentistry6boy
{
    public partial class fAdmin : Form
    {
        static string strCon = @"Data Source=DESKTOP-2HG5LN2;Initial Catalog=Dentistry;Integrated Security=True";
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
    }
}
