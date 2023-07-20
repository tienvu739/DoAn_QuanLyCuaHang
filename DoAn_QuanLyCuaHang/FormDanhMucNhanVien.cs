using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAn_QuanLyCuaHang
{
    public partial class FormDanhMucNhanVien : Form
    {
        DataTable tblNV;
        public FormDanhMucNhanVien()
        {
            InitializeComponent();
        }
        public void loadDatagirdViewNV()
        {
            string sql;
            sql = "select MaNhanVien,TenNhanVien,GioiTinh,DiaChi,DienThoai,NgaySinh from tblNhanVien";
            tblNV = QuanLyBanHang.getDatatable(sql);
            dataGridView1.DataSource = tblNV;
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Giới tính";
            dataGridView1.Columns[3].HeaderText = "Điạ chỉ";
            dataGridView1.Columns[4].HeaderText = "Điện thoại";
            dataGridView1.Columns[5].HeaderText = "Ngày sinh";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void FormDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            textMaNV.Enabled = false;
            btBoQua.Enabled = false;
            btLuu.Enabled = false;
            loadDatagirdViewNV();
        }

        private void resetValue()
        {
            textMaNV.Text = string.Empty;
            textTenNV.Text = string.Empty;
            checkGioiTinh.Checked = false;
            textDiaChi.Text = string.Empty;
            textDienThoai.Text = string.Empty;
            dateNgaySinh.Value = DateTime.Now;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            textMaNV.Enabled=true;
            btBoQua.Enabled=true;
            btLuu.Enabled=true;
            btThem.Enabled=false;
            btSua.Enabled=false;
            btXoa.Enabled=false;
            resetValue();
            textMaNV.Focus();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql,gt;

            if (textMaNV.Text.Trim().Length == 0)
            { 
                MessageBox.Show("Bạn chưa nhập mã nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaNV.Focus();
                return;
            }
            if (textTenNV.Text.Trim().Length == 0)
            {     
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenNV.Focus();
                return;
            }
            if (textDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDiaChi.Focus();
                return;
            }
            if (textDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDienThoai.Focus();
                return;
            }
            if (checkGioiTinh.Checked == true)
                gt = "nam";
            else
                gt = "nu";
            sql = "select MaNhanVien from tblNhanVien where MaNhanVien = N'" + textMaNV.Text + "'";
            if(QuanLyBanHang.checkKey(sql))
            {
                MessageBox.Show("Mã nhân viên này đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaNV.Focus();
                textMaNV.Text=string.Empty;
                return;
            }
            sql = "insert into tblNhanVien(MaNhanVien,TenNhanVien,GioiTinh,DiaChi,DienThoai,NgaySinh) values (N'" +textMaNV.Text+ "',N'"+textTenNV.Text+"',N'"+gt
                +"',N'"+textDiaChi.Text+"',N'"+textDienThoai.Text+"',N'"+dateNgaySinh.Value+"')";
            QuanLyBanHang.runSQL(sql);
            loadDatagirdViewNV();
            textMaNV.Enabled = false;
            btBoQua.Enabled = false;
            btLuu.Enabled = false;
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            resetValue();
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(tblNV.Rows.Count == 0) 
            {
                MessageBox.Show("Không có dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            textMaNV.Text= dataGridView1.CurrentRow.Cells["MaNhanVien"].Value.ToString();
            textTenNV.Text = dataGridView1.CurrentRow.Cells["TenNhanVien"].Value.ToString();
            if (dataGridView1.CurrentRow.Cells["GioiTinh"].Value.ToString() == "nam")
                checkGioiTinh.Checked = true;
            else
                checkGioiTinh.Checked = false;
            textDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            textDienThoai.Text = dataGridView1.CurrentRow.Cells["Dienthoai"].Value.ToString();
            dateNgaySinh.Value = (DateTime)dataGridView1.CurrentRow.Cells["NgaySinh"].Value;
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblNV.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenNV.Focus();
                return;
            }
            if (textMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chọn dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaNV.Focus();
                return;
            }
            if (MessageBox.Show("bạn có muốn xóa không ?", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete tblNhanVien where MaNhanVien = N'" + textMaNV.Text + "'";
                QuanLyBanHang.runSQL(sql);
                loadDatagirdViewNV();
                resetValue();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string sql, gt;
            if(tblNV.Rows.Count == 0 )
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenNV.Focus();
                return;
            }
            if (textMaNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chọn dữ liệu để sửa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaNV.Focus();
                return;
            }
            if (textTenNV.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenNV.Focus();
                return;
            }
            if (textDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDiaChi.Focus();
                return;
            }
            if (textDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDienThoai.Focus();
                return;
            }
            if (checkGioiTinh.Checked == true)
                gt = "nam";
            else
                gt = "nu";
            sql = "update tblNhanVien set TenNhanVien = N'"+textTenNV.Text+"',GioiTinh=N'"+gt+"',DiaChi =N'"+textDiaChi.Text
                +"',DienThoai=N'"+textDienThoai.Text+"',NgaySinh=N'"+dateNgaySinh.Value+"' where MaNhanVien = N'"+textMaNV.Text+"'";
            QuanLyBanHang.runSQL(sql);
            loadDatagirdViewNV();
            resetValue();
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            textMaNV.Enabled = false;
            btBoQua.Enabled = false;
            btLuu.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            resetValue();
        }
    }
}
