using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Demo_MyClass
{
    public partial class FormListView : Form
    {
        private List<NhanVien> danhSachNhanVien = new List<NhanVien>();

        public FormListView()
        {
            InitializeComponent();
            // Đảm bảo sự kiện được gắn tại đây
            btn_them.Click += new EventHandler(btnThem_Click);
            btn_sua.Click += new EventHandler(btnSua_Click);
            btn_xoa.Click += new EventHandler(btnXoa_Click);
            btn_dong.Click += new EventHandler(btnDong_Click);
        }

        private void FormListView_Load(object sender, EventArgs e)
        {
            CapNhatListView();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Hiển thị Form2 (thêm nhân viên)
            Nhanvien formNhanVien = new Nhanvien();
            if (formNhanVien.ShowDialog() == DialogResult.OK)
            {
                // Thêm nhân viên mới vào danh sách
                danhSachNhanVien.Add(formNhanVien.NhanVien);
                CapNhatListView();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Lấy chỉ số nhân viên được chọn
                int index = listView1.SelectedItems[0].Index;
                NhanVien nv = danhSachNhanVien[index];

                // Hiển thị Form2 với thông tin nhân viên cần sửa
                Nhanvien formNhanVien = new Nhanvien(nv);
                if (formNhanVien.ShowDialog() == DialogResult.OK)
                {
                    // Cập nhật thông tin nhân viên
                    danhSachNhanVien[index] = formNhanVien.NhanVien;
                    CapNhatListView();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                // Lấy chỉ số nhân viên được chọn
                int index = listView1.SelectedItems[0].Index;

                // Xóa nhân viên khỏi danh sách
                danhSachNhanVien.RemoveAt(index);
                CapNhatListView();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            // Đóng form
            this.Close();
        }

        private void CapNhatListView()
        {
            // Cập nhật danh sách nhân viên trong ListView
            listView1.Items.Clear();
            foreach (var nv in danhSachNhanVien)
            {
                ListViewItem item = new ListViewItem(nv.MSNV); // Mã số nhân viên
                item.SubItems.Add(nv.TenNV);                  // Tên nhân viên
                item.SubItems.Add(nv.LuongCB.ToString("C"));  // Lương cơ bản
                listView1.Items.Add(item);
            }
        }
    }
}

