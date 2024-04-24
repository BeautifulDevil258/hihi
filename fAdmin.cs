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
        static string strCon = @"Data Source=TR0NG\MSSQLSERVER01;Initial Catalog=Dentistryy;Integrated Security=True;";
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
        private void fAdmin_Load(object sender, EventArgs e)
        {
            Hien_thi_DV();
            Hien_thi_Medicines();
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

        //PHẦN CỦA TUI
        // phần hiển thị thuốc
        private void Hien_thi_Medicines()
        {

            sqlCon.Open();
            SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Medicines;", sqlCon);
            DataTable Dt = new DataTable();             //tạo database 'dt' lưu dữ liệu từ kết quả truy vấn
            Da.Fill(Dt);                               //Fill để điền dlieu truy vấn  vào "Dt"  
            DGV_Medicine.DataSource = Dt;              //gán dt làm nguồn dữ liệu cho DGV_.... thông qua data source
            sqlCon.Close();                           

        }
        // Thêm Thuốc
        private void btnAddthuoc_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các trường dữ liệu có được điền đầy đủ không
            StringBuilder missingFields = new StringBuilder();
            if (string.IsNullOrWhiteSpace(txtMedicineName.Text))
                missingFields.Append("Tên thuốc\n");
            if (string.IsNullOrWhiteSpace(txtUnit.Text))
                missingFields.Append("Đơn vị\n");
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
                missingFields.Append("Mô tả\n");
            if (string.IsNullOrWhiteSpace(txtPriceMedicine.Text))
                missingFields.Append("Giá\n");
            if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                missingFields.Append("Số lượng\n");

            if (missingFields.Length > 0) //ktra chuỗi miss....
            {
                MessageBox.Show($"Vui lòng điền đầy đủ thông tin cho các trường sau:\n{missingFields}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(strCon))
            {
                try
                {
                    connection.Open();

                    // Tạo câu lệnh SQL để thêm dữ liệu
                    string query = "INSERT INTO Medicines (Name, Unit, Description, Price, Quantity, Import_Date, Manufacture_Date, Expiry_Date) VALUES (@Name, @Unit, @Description, @Price, @Quantity, @ImportDate, @ManufactureDate, @ExpiryDate)";

                    SqlCommand command = new SqlCommand(query, connection);

                    // Gán giá trị từ các TextBox và DateTimePicker vào tham số của câu lệnh SQL
                    command.Parameters.AddWithValue("@Name", txtMedicineName.Text); 
                    command.Parameters.AddWithValue("@Unit", txtUnit.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@Price", Convert.ToDouble(txtPriceMedicine.Text));
                    command.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                    command.Parameters.AddWithValue("@ImportDate", dateTimePickerManufacture.Value);
                    command.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufacture.Value);
                    command.Parameters.AddWithValue("@ExpiryDate", dateTimePickerExpiry.Value); //thêm tham số...,giá trị nội dung textbox

                    // Thực thi câu lệnh SQL
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thêm thuốc thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Xóa dữ liệu sau khi thêm thành công
                        ClearInputs();
                        Hien_thi_Medicines();
                    }
                    else
                    {
                        MessageBox.Show("Thêm thuốc thất bại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ClearInputs()
        {
            txtMedicineName.Clear();
            txtUnit.Clear();
            txtDescription.Clear();
            txtPriceMedicine.Clear();
            txtQuantity.Clear();
            dateTimePickerManufacture.Value = DateTime.Now;
            dateTimePickerManufacture.Value = DateTime.Now;
            dateTimePickerExpiry.Value = DateTime.Now;
        }


        //Reset kho thuốc
        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }


        // Chức năng Sửa
        private void btnSuathuoc_Click(object sender, EventArgs e)
        {
            if (DGV_Medicine.SelectedRows.Count > 0)
            {
                int MedicineID = Convert.ToInt32(DGV_Medicine.SelectedRows[0].Cells["ID"].Value);
                string updateMedicineQuery = @"
            UPDATE Medicines 
            SET Name = @Name, 
                Unit = @Unit, 
                Description = @Description, 
                Price = @Price, 
                Quantity = @Quantity, 
                Import_Date = @ImportDate,
                Manufacture_Date = @ManufactureDate,
                Expiry_Date = @ExpiryDate 
            WHERE ID = @ID;";

                using (SqlConnection sqlCon = new SqlConnection(strCon))
                {
                    sqlCon.Open();
                    SqlTransaction transaction = sqlCon.BeginTransaction();
                    try
                    {
                        SqlCommand cmdUpdateMedicine = new SqlCommand(updateMedicineQuery, sqlCon, transaction);
                        cmdUpdateMedicine.Parameters.AddWithValue("@ID", MedicineID);
                        cmdUpdateMedicine.Parameters.AddWithValue("@Name", txtMedicineName.Text);
                        cmdUpdateMedicine.Parameters.AddWithValue("@Unit", txtUnit.Text);
                        cmdUpdateMedicine.Parameters.AddWithValue("@Description", txtDescription.Text);
                        cmdUpdateMedicine.Parameters.AddWithValue("@Price", Convert.ToDouble(txtPriceMedicine.Text));
                        cmdUpdateMedicine.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                        cmdUpdateMedicine.Parameters.AddWithValue("@ImportDate", dateTimePickerImport.Text);
                        cmdUpdateMedicine.Parameters.AddWithValue("@ManufactureDate", dateTimePickerManufacture.Text);
                        cmdUpdateMedicine.Parameters.AddWithValue("@ExpiryDate", dateTimePickerExpiry.Value);
                        cmdUpdateMedicine.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show("Thông tin thuốc đã được cập nhật thành công.");
                        Hien_thi_Medicines();
                    }
                    catch (Exception ex)
                    {
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
        //Lấy dữ liệu từ DatagridView để hiện lên textbox
        private void DGV_Medicine_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtMedicineName.Text = DGV_Medicine.CurrentRow.Cells[1].Value.ToString();
                txtDescription.Text = DGV_Medicine.CurrentRow.Cells[2].Value.ToString();
                txtUnit.Text = DGV_Medicine.CurrentRow.Cells[3].Value.ToString();
                txtPriceMedicine.Text = DGV_Medicine.CurrentRow.Cells[4].Value.ToString();
                txtQuantity.Text = DGV_Medicine.CurrentRow.Cells[5].Value.ToString();
                string Import_DateString = DGV_Medicine.CurrentRow.Cells[6].Value.ToString();
                DateTime Import_Date;
                if (DateTime.TryParse(Import_DateString, out Import_Date))
                {
                    dateTimePickerImport.Value = Import_Date;
                }
                string Manufacture_DateString = DGV_Medicine.CurrentRow.Cells[7].Value.ToString();
                DateTime Manufacture_Date;
                if (DateTime.TryParse(Manufacture_DateString, out Manufacture_Date))
                {
                    dateTimePickerManufacture.Value = Manufacture_Date;
                }
                string Expiry_DateString = DGV_Medicine.CurrentRow.Cells[8].Value.ToString();
                DateTime Expiry_Date;
                if (DateTime.TryParse(Expiry_DateString, out Expiry_Date))
                {
                    dateTimePickerExpiry.Value = Expiry_Date;
                }
            }
        }



        //Xóa thuốc
        SqlTransaction transaction = null; // Khai báo biến transaction ở mức phạm vi toàn cục
        private object cmdDeleteMedicine;

        private void btnXoathuoc_Click(object sender, EventArgs e)
        {

            // Kiểm tra xem người dùng đã chọn một hàng trong DataGridView chưa
            if (DGV_Medicine.SelectedRows.Count > 0)
            {
                // Lấy ID của bệnh nhân từ hàng được chọn trong DataGridView
                int medicineID = Convert.ToInt32(DGV_Medicine.SelectedRows[0].Cells["ID"].Value);

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa thuốc này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Chuẩn bị câu lệnh SQL để xóa thông thuốc
                    string deleteMedicineQuery = "DELETE FROM Medicines WHERE ID = @ID";

                    // Mở kết nối đến cơ sở dữ liệu và thực thi các câu lệnh SQL trong một giao dịch
                    using (SqlConnection sqlCon = new SqlConnection(strCon))
                    {
                        try
                        {
                            sqlCon.Open();
                            SqlTransaction transaction = sqlCon.BeginTransaction();

                            // Xóa thông tin thuốc
                            SqlCommand cmdDeleteMedicine = new SqlCommand(deleteMedicineQuery, sqlCon, transaction);
                            cmdDeleteMedicine.Parameters.AddWithValue("@ID", medicineID);
                            cmdDeleteMedicine.ExecuteNonQuery();

                            transaction.Commit();

                            // Thông báo xóa thành công và làm mới DataGridView
                            MessageBox.Show("Thuốc đã được xóa thành công!");
                            Hien_thi_Medicines();
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

        private void btntimkiemthuoc_Click(object sender, EventArgs e)
        {
            if (txtSearchMedicine.Text == "")
            {
                MessageBox.Show("Nhập từ khoá cần tìm");
            }
            else
            {
                try
                {
                    sqlCon.Open();
                    SqlDataAdapter Da = new SqlDataAdapter("SELECT * FROM Medicines WHERE Name LIKE '%' + @searchTerm + '%'", sqlCon);
                    Da.SelectCommand.Parameters.AddWithValue("@searchTerm", txtSearchMedicine.Text);
                    DataTable Dt = new DataTable();
                    Da.Fill(Dt);
                    DGV_Medicine.DataSource = Dt;
                    sqlCon.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
    }

