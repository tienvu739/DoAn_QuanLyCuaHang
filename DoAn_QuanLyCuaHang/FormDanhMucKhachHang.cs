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
    public partial class FormDanhMucKhachHang : Form
    {
        DataTable tblkhach;
        public FormDanhMucKhachHang()
        {
            InitializeComponent();
        }
        private void loadDataGirdViewKhachHang()
        {
            string sql = "select MaKhach,TenKhach,DiaChi,DienThoai from tblKhach";
            tblkhach = QuanLyBanHang.getDatatable(sql);
            dataGridView1.DataSource = tblkhach;
            dataGridView1.Columns[0].HeaderText = "Mã khách hàng";
            dataGridView1.Columns[1].HeaderText = "Tên khách hàng";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
            dataGridView1.Columns[3].HeaderText = "Điện thoại";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 150;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void FormDanhMucKhachHang_Load(object sender, EventArgs e)
        {
            textMa.Enabled = false;
            btLuu.Enabled = false;
            btBoQua.Enabled = false;
            loadDataGirdViewKhachHang();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(btThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm","Thông bao",MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTen.Focus();
                return;
            }
            if(tblkhach.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textTen.Focus();
                return;
            }
            textMa.Text = dataGridView1.CurrentRow.Cells["MaKhach"].Value.ToString();
            textTen.Text = dataGridView1.CurrentRow.Cells["TenKhach"].Value.ToString();
            textDiaChi.Text = dataGridView1.CurrentRow.Cells["DiaChi"].Value.ToString();
            textDienThoai.Text = dataGridView1.CurrentRow.Cells["DienThoai"].Value.ToString();
        }
        private void resetValue()
        {
            textTen.Text = string.Empty;
            textMa.Text = string.Empty;
            textDiaChi.Text = string.Empty;
            textDienThoai.Text= string.Empty;
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            textMa.Enabled = true;
            btBoQua.Enabled = true;
            btLuu.Enabled = true;
            resetValue();
            btThem.Enabled = false;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            textMa.Focus();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(textMa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMa.Focus() ;
                return;
            }
            if (textTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTen.Focus();
                return;
            }
            if (textDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDiaChi.Focus();
                return;
            }
            if (textDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập điện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDienThoai.Focus();
                return;
            }
            sql = "select MaKhach from tblKhach where MaKhach = N'"+textMa.Text+"'";
            if(QuanLyBanHang.checkKey(sql))
            {
                MessageBox.Show("Mã đã tồn tại","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textMa.Focus();
                return;
            }
            sql = "insert into tblKhach values (N'"+textMa.Text +"',N'"+textTen.Text+"',N'"+textDiaChi.Text+"',N'"+textDienThoai.Text+"')";
            QuanLyBanHang.runSQL(sql);
            loadDataGirdViewKhachHang();
            resetValue();
            textMa.Enabled = false;
            btBoQua.Enabled= false;
            btLuu.Enabled= false;
            btThem.Enabled= true;
            btSua.Enabled= true;
            btXoa.Enabled = true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkhach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu đẻ xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMa.Focus();
                return;
            }
            if (textMa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDienThoai.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa không", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete tblKhach where MaKhach = N'" + textMa.Text + "'";
                QuanLyBanHang.runSQL(sql);
                loadDataGirdViewKhachHang();
                resetValue();
            }
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            textMa.Enabled = false;
            btLuu.Enabled = false;
            btBoQua.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            resetValue();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (tblkhach.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu đẻ xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMa.Focus();
                return;
            }
            if (textMa.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDienThoai.Focus();
                return;
            }
            if (textTen.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTen.Focus();
                return;
            }
            if (textDiaChi.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDiaChi.Focus();
                return;
            }
            if (textDienThoai.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập điện", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDienThoai.Focus();
                return;
            }
            sql = "update tblKhach set TenKhach = N'" + textTen.Text + "', DiaChi = N'" + textDiaChi.Text + "', DienThoai = N'" + textDienThoai.Text + "' where MaKhach = N'" + textMa.Text + "'";
            QuanLyBanHang.runSQL(sql);
            loadDataGirdViewKhachHang();
            resetValue();
        }
    }
}
