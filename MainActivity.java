package com.example.qlsv;

import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;
import android.widget.AdapterView;

import androidx.appcompat.app.AppCompatActivity;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity {

    EditText editTextMaSV, editTextHoTen, editTextNgaySinh, editTextDiaChi, editTextSDT, editTextKhoa, editTextLop, editTextMonHoc;
    Button buttonAdd, buttonEdit, buttonDelete;
    ListView listViewStudents;
    ArrayList<String> studentList;
    ArrayAdapter<String> adapter;
    int selectedPosition = -1;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        // Ánh xạ các thành phần giao diện
        editTextMaSV = findViewById(R.id.editTextMaSV);
        editTextHoTen = findViewById(R.id.editTextHoTen);
        editTextNgaySinh = findViewById(R.id.editTextNgaySinh);
        editTextDiaChi = findViewById(R.id.editTextDiaChi);
        editTextSDT = findViewById(R.id.editTextSDT);
        editTextKhoa = findViewById(R.id.editTextKhoa);
        editTextLop = findViewById(R.id.editTextLop);
        editTextMonHoc = findViewById(R.id.editTextMonHoc);
        buttonAdd = findViewById(R.id.buttonAdd);
        buttonEdit = findViewById(R.id.buttonEdit);
        buttonDelete = findViewById(R.id.buttonDelete);
        listViewStudents = findViewById(R.id.listViewStudents);

        // Khởi tạo danh sách sinh viên và adapter
        studentList = new ArrayList<>();
        adapter = new ArrayAdapter<>(this, android.R.layout.simple_list_item_1, studentList);
        listViewStudents.setAdapter(adapter);

        // Xử lý sự kiện khi nhấn nút "Thêm mới"
        buttonAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                // Lấy thông tin từ EditText
                String maSV = editTextMaSV.getText().toString().trim();
                String hoTen = editTextHoTen.getText().toString().trim();
                String ngaySinh = editTextNgaySinh.getText().toString().trim();
                String diaChi = editTextDiaChi.getText().toString().trim();
                String sdt = editTextSDT.getText().toString().trim();
                String khoa = editTextKhoa.getText().toString().trim();
                String lop = editTextLop.getText().toString().trim();
                String monHoc = editTextMonHoc.getText().toString().trim();

                // Kiểm tra xem có nhập đủ thông tin không
                if (maSV.isEmpty() || hoTen.isEmpty() || ngaySinh.isEmpty() || diaChi.isEmpty() || sdt.isEmpty() || khoa.isEmpty() || lop.isEmpty() || monHoc.isEmpty()) {
                    Toast.makeText(MainActivity.this, "Vui lòng nhập đầy đủ thông tin", Toast.LENGTH_SHORT).show();
                } else {
                    // Thêm thông tin sinh viên vào danh sách và cập nhật ListView
                    String studentInfo = "Mã SV: " + maSV + "\n" +
                            "Họ và tên: " + hoTen + "\n" +
                            "Ngày sinh: " + ngaySinh + "\n" +
                            "Địa chỉ: " + diaChi + "\n" +
                            "SĐT: " + sdt + "\n" +
                            "Khoa: " + khoa + "\n" +
                            "Lớp: " + lop + "\n" +
                            "Môn học: " + monHoc;

                    studentList.add(studentInfo);
                    adapter.notifyDataSetChanged();

                    // Hiển thị thông báo khi thêm sinh viên thành công
                    Toast.makeText(MainActivity.this, "Thêm sinh viên thành công", Toast.LENGTH_SHORT).show();

                    // Xóa dữ liệu trong EditText sau khi thêm thành công
                    editTextMaSV.setText("");
                    editTextHoTen.setText("");
                    editTextNgaySinh.setText("");
                    editTextDiaChi.setText("");
                    editTextSDT.setText("");
                    editTextKhoa.setText("");
                    editTextLop.setText("");
                    editTextMonHoc.setText("");
                }
            }
        });

        // Xử lý sự kiện khi nhấn nút "Sửa"
        buttonEdit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (selectedPosition != -1) {
                    // Lấy thông tin từ EditText
                    String maSV = editTextMaSV.getText().toString().trim();
                    String hoTen = editTextHoTen.getText().toString().trim();
                    String ngaySinh = editTextNgaySinh.getText().toString().trim();
                    String diaChi = editTextDiaChi.getText().toString().trim();
                    String sdt = editTextSDT.getText().toString().trim();
                    String khoa = editTextKhoa.getText().toString().trim();
                    String lop = editTextLop.getText().toString().trim();
                    String monHoc = editTextMonHoc.getText().toString().trim();

                    // Kiểm tra xem có nhập đủ thông tin không
                    if (maSV.isEmpty() || hoTen.isEmpty() || ngaySinh.isEmpty() || diaChi.isEmpty() || sdt.isEmpty() || khoa.isEmpty() || lop.isEmpty() || monHoc.isEmpty()) {
                        Toast.makeText(MainActivity.this, "Vui lòng nhập đầy đủ thông tin", Toast.LENGTH_SHORT).show();
                    } else {
                        // Sửa thông tin sinh viên và cập nhật ListView
                        String studentInfo = "Mã SV: " + maSV + "\n" +
                                "Họ và tên: " + hoTen + "\n" +
                                "Ngày sinh: " + ngaySinh + "\n" +
                                "Địa chỉ: " + diaChi + "\n" +
                                "SĐT: " + sdt + "\n" +
                                "Khoa: " + khoa + "\n" +
                                "Lớp: " + lop + "\n" +
                                "Môn học: " + monHoc;

                        studentList.set(selectedPosition, studentInfo);
                        adapter.notifyDataSetChanged();

                        // Hiển thị thông báo khi sửa sinh viên thành công
                        Toast.makeText(MainActivity.this, "Sửa sinh viên thành công", Toast.LENGTH_SHORT).show();

                        // Đặt lại trạng thái ban đầu
                        selectedPosition = -1;
                        clearEditTexts();
                    }
                } else {
                    Toast.makeText(MainActivity.this, "Vui lòng chọn sinh viên để sửa", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // Xử lý sự kiện khi nhấn nút "Xóa"
        buttonDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (selectedPosition != -1) {
                    // Xóa sinh viên khỏi danh sách và cập nhật ListView
                    studentList.remove(selectedPosition);
                    adapter.notifyDataSetChanged();

                    // Hiển thị thông báo khi xóa thành công
                    Toast.makeText(MainActivity.this, "Xóa sinh viên thành công", Toast.LENGTH_SHORT).show();

                    // Đặt lại trạng thái ban đầu
                    selectedPosition = -1;
                    clearEditTexts();
                } else {
                    Toast.makeText(MainActivity.this, "Vui lòng chọn sinh viên để xóa", Toast.LENGTH_SHORT).show();
                }
            }
        });

        // Xử lý sự kiện khi người dùng chọn một sinh viên từ danh sách
        listViewStudents.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                // Lưu vị trí sinh viên được chọn
                selectedPosition = position;

                // Lấy thông tin sinh viên từ vị trí được chọn
                String studentInfo = (String) parent.getItemAtPosition(position);

                // Tách thông tin sinh viên thành các trường thông tin riêng lẻ
                String[] studentInfoArray = studentInfo.split("\n");

                // Hiển thị thông tin sinh viên lên các EditText để sửa
                editTextMaSV.setText(studentInfoArray[0].substring(7)); // Bỏ "Mã SV: "
                editTextHoTen.setText(studentInfoArray[1].substring(10)); // Bỏ "Họ và tên: "
                editTextNgaySinh.setText(studentInfoArray[2].substring(12)); // Bỏ "Ngày sinh: "
                editTextDiaChi.setText(studentInfoArray[3].substring(9)); // Bỏ "Địa chỉ: "
                editTextSDT.setText(studentInfoArray[4].substring(5)); // Bỏ "SĐT: "
                editTextKhoa.setText(studentInfoArray[5].substring(6)); // Bỏ "Khoa: "
                editTextLop.setText(studentInfoArray[6].substring(6)); // Bỏ "Lớp: "
                editTextMonHoc.setText(studentInfoArray[7].substring(9)); // Bỏ "Môn học: "
            }
        });
    }

    // Phương thức để xóa dữ liệu trong EditTexts
    private void clearEditTexts() {
        editTextMaSV.setText("");
        editTextHoTen.setText("");
        editTextNgaySinh.setText("");
        editTextDiaChi.setText("");
        editTextSDT.setText("");
        editTextKhoa.setText("");
        editTextLop.setText("");
        editTextMonHoc.setText("");
    }
}
