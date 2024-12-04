using System;
using System.Windows.Forms;

namespace Demo_MyClass
{
    public partial class Nhanvien : Form
    {
        public NhanVien NhanVien { get; private set; }

        public Nhanvien()
        {
            InitializeComponent();
            // Đảm bảo sự kiện được gắn
            btn_dongy.Click += new EventHandler(btnDongY_Click);
            btn_boqua.Click += new EventHandler(btnBoQua_Click);
        }

        // Constructor nhận một nhân viên hiện có
        public Nhanvien(NhanVien nhanVien) : this()
        {
            txt_msnv.Text = nhanVien.MSNV;
            txt_tennhanvien.Text = nhanVien.TenNV;
            txt_LuongCB.Text = nhanVien.LuongCB.ToString();
        }

        private void btnDongY_Click(object sender, EventArgs e)
        {
            string msnv = txt_msnv.Text;
            string tenNV = txt_tennhanvien.Text;
            decimal luongCB;

            // Kiểm tra tính hợp lệ của thông tin nhập
            if (string.IsNullOrWhiteSpace(msnv) || string.IsNullOrWhiteSpace(tenNV) || !decimal.TryParse(txt_LuongCB.Text, out luongCB))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo mới nhân viên
            NhanVien = new NhanVien(msnv, tenNV, luongCB);
            DialogResult = DialogResult.OK; // Trả về kết quả OK
            Close();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel; // Trả về kết quả Cancel
            Close();
        }
    }
}
