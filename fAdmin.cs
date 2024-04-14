using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace dentistry6boy
{
    public partial class fAdmin : Form
    {
        SqlConnection sqlCon = null;
        string strCon = ConfigurationManager.ConnectionStrings["QLNK"].ConnectionString.ToString();

        public fAdmin()
        {
            InitializeComponent();
        }
        private void Hien_thi_DV()
        {

            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Services;", sqlCon);
            DataTable Dt = new DataTable();
            Da.Fill(Dt);
            DGV_dv.DataSource = Dt;
            sqlCon.Close();

        }
        private void DGV_dv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow row = DGV_dv.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ hàng được chọn vào các TextBox tương ứng
                txtServiceName.Text = row.Cells["ServiceName"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
            }
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

            // Gán sự kiện CellClick cho DataGridView
            DGV_dv.CellClick += new DataGridViewCellEventHandler(DGV_dv_CellClick);
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

                // Kiểm tra giá trị nhập vào cho giá là một số hợp lệ
                if (!decimal.TryParse(txtPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price))
                {
                    MessageBox.Show("Giá phải là một số.");
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
                        cmdAddService.Parameters.AddWithValue("@Price", price);

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

        // Code cho btnSuaDV_Click
        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem dữ liệu đã được chọn từ DataGridView chưa
                if (DGV_dv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần sửa từ danh sách.");
                    return; // Không thực hiện các thao tác sửa nữa
                }

                // Lấy ID của dịch vụ được chọn
                int selectedServiceID = Convert.ToInt32(DGV_dv.SelectedRows[0].Cells["ServiceID"].Value);

                // Kiểm tra xem các trường thông tin cần thiết đã được nhập chưa
                if (string.IsNullOrWhiteSpace(txtServiceName.Text) ||
                    string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    // Hiển thị thông báo yêu cầu nhập đầy đủ thông tin
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin dịch vụ.");
                    return; // Không thực hiện các thao tác sửa nữa
                }

                // Kiểm tra giá trị nhập vào cho giá là một số hợp lệ
                if (!decimal.TryParse(txtPrice.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price))
                {
                    MessageBox.Show("Giá phải là một số.");
                    return; // Không thực hiện các thao tác sửa nữa
                }

                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    SqlTransaction transaction = sqlCon.BeginTransaction();

                    try
                    {
                        // Cập nhật thông tin dịch vụ trong bảng "Services"
                        string updateQuery = "UPDATE Services SET ServiceName = @ServiceName, Price = @Price WHERE ServiceID = @ServiceID;";
                        SqlCommand cmdUpdateService = new SqlCommand(updateQuery, sqlCon, transaction);
                        cmdUpdateService.Parameters.AddWithValue("@ServiceID", selectedServiceID);
                        cmdUpdateService.Parameters.AddWithValue("@ServiceName", txtServiceName.Text);
                        cmdUpdateService.Parameters.AddWithValue("@Price", price);

                        // Thực thi câu lệnh cập nhật dịch vụ
                        int rowsAffected = cmdUpdateService.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Commit transaction nếu mọi thứ thành công
                            transaction.Commit();

                            // Thông báo thành công
                            MessageBox.Show("Sửa thông tin dịch vụ thành công!");
                            Hien_thi_DV();
                        }
                        else
                        {
                            // Rollback transaction nếu không có hàng nào được cập nhật
                            transaction.Rollback();

                            // Hiển thị thông báo lỗi
                            MessageBox.Show("Không có dữ liệu nào được sửa.");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback transaction nếu có lỗi xảy ra
                        transaction.Rollback();

                        // Hiển thị thông báo lỗi
                        MessageBox.Show("Đã xảy ra lỗi khi sửa thông tin dịch vụ: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi kết nối đến cơ sở dữ liệu
                MessageBox.Show("Đã xảy ra lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem dữ liệu đã được chọn từ DataGridView chưa
                if (DGV_dv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ cần xóa từ danh sách.");
                    return; // Không thực hiện các thao tác xóa nữa
                }

                // Lấy ID của dịch vụ được chọn
                int selectedServiceID = Convert.ToInt32(DGV_dv.SelectedRows[0].Cells["ServiceID"].Value);

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection sqlCon = new SqlConnection(strCon))
                    {
                        sqlCon.Open();
                        SqlTransaction transaction = sqlCon.BeginTransaction();

                        try
                        {
                            // Xóa thông tin dịch vụ trong bảng "Services"
                            string deleteQuery = "DELETE FROM Services WHERE ServiceID = @ServiceID;";
                            SqlCommand cmdDeleteService = new SqlCommand(deleteQuery, sqlCon, transaction);
                            cmdDeleteService.Parameters.AddWithValue("@ServiceID", selectedServiceID);

                            // Thực thi câu lệnh xóa dịch vụ
                            int rowsAffected = cmdDeleteService.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Commit transaction nếu mọi thứ thành công
                                transaction.Commit();

                                // Thông báo thành công
                                MessageBox.Show("Xóa dịch vụ thành công!");
                                Hien_thi_DV();
                            }
                            else
                            {
                                // Rollback transaction nếu không có hàng nào bị xóa
                                transaction.Rollback();

                                // Hiển thị thông báo lỗi
                                MessageBox.Show("Không có dữ liệu nào bị xóa.");
                            }
                        }
                        catch (Exception ex)
                        {
                            // Rollback transaction nếu có lỗi xảy ra
                            transaction.Rollback();

                            // Hiển thị thông báo lỗi
                            MessageBox.Show("Đã xảy ra lỗi khi xóa dịch vụ: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi kết nối đến cơ sở dữ liệu
                MessageBox.Show("Đã xảy ra lỗi khi kết nối đến cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void btnResetBN_Click(object sender, EventArgs e)
        {
            txtServiceName.Text = "";
            txtPrice.Text = "";
        }

        private void btnRefDV_Click(object sender, EventArgs e)
        {
            Hien_thi_DV();
        }
    }
}
