using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static dentistry6boy.fAccountProfile;

namespace dentistry6boy
{
    public partial class InfoForm : Form
    {
        SqlConnection sqlCon = null;
        string strCon = ConfigurationManager.ConnectionStrings["QLNK"].ConnectionString.ToString();
        int userID = SessionData.UserID;

        public InfoForm()
        {
            InitializeComponent();
        }
        public void HienThi()
        {
            string sqlSELECT = "SELECT * FROM users WHERE UserID = @userID";

            SqlCommand cmd = new SqlCommand(sqlSELECT, sqlCon);
            cmd.Parameters.AddWithValue("@userID", userID);

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            DGV_Info.DataSource = dt;
        }
        private void DGV_dv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (e.RowIndex >= 0)
            {
                // Lấy dữ liệu từ hàng được chọn
                DataGridViewRow row = DGV_Info.Rows[e.RowIndex];

                // Hiển thị dữ liệu từ hàng được chọn vào các TextBox tương ứng
                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtPass.Text = row.Cells["Password"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtTenhienthi.Text = row.Cells["Tenhienthi"].Value.ToString();
                txtRole.Text = row.Cells["Role"].Value.ToString();
            }
        }
        private void DGV_Info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
            HienThi();

            // Gán sự kiện CellClick cho DataGridView
            DGV_Info.CellClick += new DataGridViewCellEventHandler(DGV_dv_CellClick);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Lấy giá trị từ các TextBox
            string username = txtUsername.Text;
            string password = txtPass.Text;
            string phone = txtPhone.Text;
            string email = txtEmail.Text;
            string tenhienthi = txtTenhienthi.Text;
            string role = txtRole.Text;

            // Thực hiện cập nhật vào cơ sở dữ liệu
            string sqlUpdate = "UPDATE users SET Username = @username, Password = @password, Phone = @phone, Email = @email, Tenhienthi = @tenhienthi, Role = @role WHERE UserID = @userID";
            SqlCommand cmd = new SqlCommand(sqlUpdate, sqlCon);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@phone", phone);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@tenhienthi", tenhienthi);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@userID", userID); // userID là giá trị của UserID bạn muốn sửa

            try
            {
                if (sqlCon.State != ConnectionState.Open)
                {
                    sqlCon.Open();
                }

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Thông tin đã được cập nhật thành công.");
                    HienThi();
                    // Cập nhật lại giao diện hoặc làm bất kỳ xử lý nào khác sau khi cập nhật thành công
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                sqlCon.Close();
            }
        }

        private void btnRef_Click(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
