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
using System.Configuration;
namespace dentistry6boy
{
    public partial class fAccountProfile : Form
    {
        SqlConnection sqlCon = null;
        string strCon = ConfigurationManager.ConnectionStrings["QLNK"].ConnectionString.ToString();

        public static class SessionData
        {
            public static int UserID { get; set; }
        }

        public fAccountProfile()
        {
            InitializeComponent();
        }
        private int GetUserIDByUsername(string username)
        {
            int userID = -1; // Giả định rằng không tìm thấy UserID

            string query = "SELECT UserID FROM users WHERE Username = @username";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.Parameters.AddWithValue("@username", username);

            if (sqlCon.State != ConnectionState.Open)
            {
                sqlCon.Open();
            }

            object result = cmd.ExecuteScalar();
            if (result != null)
            {
                userID = Convert.ToInt32(result);
            }

            sqlCon.Close();
            return userID;
        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            Dangky adminForm = new Dangky(); // Tạo một thể hiện mới của form fAdmin
            adminForm.Show(); // Hiển thị form fAdmin
            this.Hide();
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Kiểm tra xem người dùng đã nhập đủ tên đăng nhập và mật khẩu chưa
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu.");
                return;
            }

            // Thực hiện truy vấn để kiểm tra xem tên đăng nhập và mật khẩu có tồn tại trong cơ sở dữ liệu không
            string sqlQuery = "SELECT Role FROM users WHERE Username = @username AND Password = @password";
            SqlCommand cmd = new SqlCommand(sqlQuery, sqlCon);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            // Kiểm tra và đóng kết nối nếu cần
            if (sqlCon.State != ConnectionState.Closed)
            {
                sqlCon.Close(); // Đảm bảo rằng kết nối đã được đóng trước khi mở kết nối mới
            }

            // Mở kết nối
            sqlCon.Open();

            // Thực thi truy vấn
            object result = cmd.ExecuteScalar();

            // Đóng kết nối
            sqlCon.Close();

            // Kiểm tra kết quả
            if (result != null)
            {
                string role = result.ToString();
                SessionData.UserID = GetUserIDByUsername(username);

                // Xác định vai trò của người dùng
                bool isAdmin = (role == "admin");

                // Mở form qlNhakhoa và truyền vai trò của người dùng
                qlNhakhoa qlNhakhoaForm = new qlNhakhoa(isAdmin);
                qlNhakhoaForm.Show();
                this.Hide(); // Ẩn form đăng nhập
            }
            else
            {
                // Nếu không tìm thấy, hiển thị thông báo lỗi
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng. Vui lòng thử lại.");
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangnhap_Click(sender, e); // Gọi hàm xử lý đăng nhập khi nhấn phím Enter
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus(); // Chuyển trỏ tới TextBox mật khẩu khi nhấn phím Enter
            }
        }
    }
    }

