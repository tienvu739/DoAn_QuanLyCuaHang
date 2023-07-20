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
    public partial class FormDanhMucHangHoa : Form
    {
        DataTable tblHangHoa;
        public FormDanhMucHangHoa()
        {
            InitializeComponent();
        }
        private void loadViewHangHoa()
        {
            string sql;
            sql = "select MaHang,TenHang,MaChatLieu,SoLuong,DonGiaNhap,DonGiaBan,Anh,GhiChu from tblHang";
            tblHangHoa = QuanLyBanHang.getDatatable(sql);
            dataGridView1.DataSource = tblHangHoa;
            dataGridView1.Columns[0].HeaderText = "Mã hàng hóa";
            dataGridView1.Columns[1].HeaderText = "Tên hàng hóa";
            dataGridView1.Columns[2].HeaderText = "Mã chất liệu";
            dataGridView1.Columns[3].HeaderText = "Số lượng";
            dataGridView1.Columns[4].HeaderText = "Đơn giá nhập";
            dataGridView1.Columns[5].HeaderText = "Đơn giá bán";
            dataGridView1.Columns[6].HeaderText = "Ảnh";
            dataGridView1.Columns[7].HeaderText = "Ghi chú";
            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 100;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 50;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.Columns[6].Width = 100;
            dataGridView1.Columns[7].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void FormDanhMucHangHoa_Load(object sender, EventArgs e)
        {
            string sql = "select * from tblChatLieu";
            textMaHang.Enabled = false;
            btLuu.Enabled = false;
            btBoQua.Enabled = false;
            loadViewHangHoa();
            QuanLyBanHang.fillCombo(sql, comboBoxMaChatLieu, "MaChatLieu", "TenChatLieu");
            comboBoxMaChatLieu.SelectedIndex = -1;
            reset();
        }
        private void reset()
        {
            textMaHang.Text = string.Empty;
            textTenHang.Text = string.Empty;
            textSoLuong.Text = string.Empty;
            textGhiChu.Text = string.Empty;
            textDonGiaNhap.Text = string.Empty;
            textDonGiaBan.Text = string.Empty;
            textAnh.Text = string.Empty;
            pictureAnh.Image = null;
            textSoLuong.Enabled = true;
            textDonGiaNhap.Enabled = false;
            textDonGiaBan.Enabled = false;
            comboBoxMaChatLieu.SelectedIndex = -1;
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            string MaChatLieu;
            string sql;
            if(btThem.Enabled == false)
            {
                MessageBox.Show("Bạn đang ở chế độ thêm","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaHang.Focus();
                return;
            }
            if(tblHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenHang.Focus();
                return;
            }
            textMaHang.Text = dataGridView1.CurrentRow.Cells["MaHang"].Value.ToString();
            textTenHang.Text = dataGridView1.CurrentRow.Cells["TenHang"].Value.ToString();
            MaChatLieu = dataGridView1.CurrentRow.Cells["MaChatLieu"].Value.ToString();
            sql = "select TenChatLieu from tblChatLieu where MaChatLieu = N'" + MaChatLieu + "'";
            comboBoxMaChatLieu.Text = QuanLyBanHang.getValues(sql);
            textSoLuong.Text = dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString();
            textDonGiaNhap.Text = dataGridView1.CurrentRow.Cells["DonGiaNhap"].Value.ToString();
            textDonGiaBan.Text = dataGridView1.CurrentRow.Cells["DonGiaBan"].Value.ToString();
            sql = "select Anh from tblHang where MaHang = N'"+textMaHang.Text + "'";
            textAnh.Text = QuanLyBanHang.getValues(sql);
            pictureAnh.Image = Image.FromFile(textAnh.Text);
            sql = "select GhiChu from tblHang where MaHang = N'"+textMaHang.Text+ "'";
            textGhiChu.Text = QuanLyBanHang.getValues(sql);
            btXoa.Enabled = true;
            btSua.Enabled = true;
            btBoQua.Enabled = true;
        }

        private void btnMo_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            openFile.FilterIndex = 2;
            openFile.Title = "Chọn ảnh minh họa";
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                pictureAnh.Image = Image.FromFile(openFile.FileName);
                textAnh.Text = openFile.FileName;
            }    
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            btSua.Enabled = false;
            btLuu.Enabled = true;
            btXoa.Enabled=false;
            btBoQua.Enabled = true;
            btThem.Enabled = false;
            reset();
            textMaHang.Enabled = true;
            textMaHang.Focus();
            textSoLuong.Enabled = true;
            textDonGiaNhap.Enabled = true;
            textDonGiaBan.Enabled = true;
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if (textMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn mã hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(tblHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu đẻ xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(MessageBox.Show("Bạn có muốn xóa không","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete tblHang where MaHang = N'" + textMaHang.Text + "'";
                QuanLyBanHang.runSQL(sql);
                loadViewHangHoa();
                reset();
                return;
            }
            return;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (textMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn mã hàng để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (tblHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu đẻ xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenHang.Focus();
                return;
            }
            if (comboBoxMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxMaChatLieu.Focus();
                return;
            }
            if (textSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSoLuong.Focus();
                return;
            }
            if (textDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDonGiaNhap.Focus();
                return;
            }
            if (textDonGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDonGiaBan.Focus();
                return;
            }
            if (textAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn ảnh minh họa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textAnh.Focus();
                return;
            }
            if (textGhiChu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnMo.Focus();
                return;
            }
            sql = "update tblHang set TenHang = N'" + textTenHang.Text + "', MaChatLieu = N'" + comboBoxMaChatLieu.SelectedValue.ToString() +
                "', SoLuong = N'" + textSoLuong.Text + "', DonGiaNhap = N'" + textDonGiaNhap.Text + "', DonGiaBan = N'" +
                textDonGiaBan.Text + "', Anh = N'" + textAnh.Text + "', GhiChu = N'" + textGhiChu.Text + "' where MaHang = N'" + textMaHang.Text + "'";
            QuanLyBanHang.runSQL(sql);
            loadViewHangHoa();
            reset();
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(textMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã hàng","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textMaHang.Focus();
                return;
            }
            if (textTenHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập tên hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenHang.Focus();
                return;
            }
            if (comboBoxMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã chất liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxMaChatLieu.Focus();
                return;
            }
            if (textSoLuong.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textSoLuong.Focus();
                return;
            }
            if (textDonGiaNhap.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá nhập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDonGiaNhap.Focus();
                return;
            }
            if (textDonGiaBan.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập đơn giá bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textDonGiaBan.Focus();
                return;
            }
            if (textAnh.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa chọn ảnh minh họa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textAnh.Focus();
                return;
            }
            if (textGhiChu.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập ghi chú", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnMo.Focus();
                return;
            }
            sql =  "select MaHang from tblHang where MaHang = N'"+textMaHang.Text+"'";
            if(QuanLyBanHang.checkKey(sql))
            {
                MessageBox.Show("Mã hàng đã tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaHang.Focus();
                return;
            }
            sql =  "insert into tblHang values(N'"+textMaHang.Text+"',N'"+textTenHang.Text+"',N'"+comboBoxMaChatLieu.SelectedValue.ToString()+"',N'"+
                textSoLuong.Text+"',N'"+textDonGiaNhap.Text+"',N'"+textDonGiaBan.Text+"',N'"+textAnh.Text+"',N'"+textGhiChu.Text+"')";
            QuanLyBanHang.runSQL(sql);
            loadViewHangHoa();
            reset();
            btBoQua.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            btLuu.Enabled = false;
            textMaHang.Enabled = false;
            textDonGiaNhap.Enabled = false;
            textDonGiaBan.Enabled = false;
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            btBoQua.Enabled = false;
            btThem.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            btLuu.Enabled = false;
            textMaHang.Enabled = false;
            textDonGiaNhap.Enabled = false;
            textDonGiaBan.Enabled = false;
        }

        private void btTimKiem_Click(object sender, EventArgs e)
        {
            string sql;
            if(textMaHang.Text == string.Empty && textTenHang.Text == string.Empty && comboBoxMaChatLieu.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            sql = "select * from tblHang where 1=1";
            if (textMaHang.Text != string.Empty)
                sql += "and MaHang like N'%" + textMaHang.Text + "%'";
            if (textTenHang.Text != string.Empty)
                sql += "and TenHang like N'%" + textTenHang.Text + "%'";
            if (comboBoxMaChatLieu.Text != string.Empty)
                sql += "and MaChatLieu like N'%" + comboBoxMaChatLieu.SelectedValue.ToString() + "%'";
            tblHangHoa = QuanLyBanHang.getDatatable(sql);
            if(tblHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error); return;
            }
            else
            {
                MessageBox.Show("Có "+tblHangHoa.Rows.Count+" tìm kiếm","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = tblHangHoa;
                reset();
            }    
        }

        private void btHienThi_Click(object sender, EventArgs e)
        {
            string sql = "select * from tblHang";
            tblHangHoa = QuanLyBanHang.getDatatable(sql);
            dataGridView1.DataSource=tblHangHoa;
            reset();
        }
    }
}
