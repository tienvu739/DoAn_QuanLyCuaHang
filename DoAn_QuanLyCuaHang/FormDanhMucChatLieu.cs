using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DoAn_QuanLyCuaHang
{
    public partial class FromDanhMucChatLieu : Form
    {
        DataTable datatbl;
        public FromDanhMucChatLieu()
        {
            InitializeComponent();
        }

        private void LoadDataGridView ()
        {
            string sql = "select Machatlieu,Tenchatlieu from tblChatLieu";
            datatbl = QuanLyBanHang.getDatatable(sql);
            dataGridView1.DataSource = datatbl;
            dataGridView1.Columns[0].HeaderText = "Mã Chất Liệu";
            dataGridView1.Columns[1].HeaderText = "Tên Chất Liệu";
            dataGridView1.Columns[0].Width = 150;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void FromDanhMucChatLieu_Load(object sender, EventArgs e)
        {
            textMaChatLieu.Enabled = false;
            btBoQua.Enabled=false;
            btLuu.Enabled=false;
            LoadDataGridView();
        }


        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(btThem.Enabled==false)
            {
                MessageBox.Show("Đang ở chế độ thêm", "thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                textMaChatLieu.Focus();
                return;
            }
            if(datatbl.Rows.Count==0)
            {
                MessageBox.Show("Không có dữ liệu!","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Information);  
                return;
            }
            textMaChatLieu.Text = dataGridView1.CurrentRow.Cells["Machatlieu"].Value.ToString();
            textTenChatLieu.Text = dataGridView1.CurrentRow.Cells["Tenchatlieu"].Value.ToString();
            btSua.Enabled = true;
            btBoQua.Enabled=true;
            btXoa.Enabled=true;
        }
        private void resetValue()
        {
            textMaChatLieu.Text = string.Empty;
            textTenChatLieu.Text = string.Empty;
        }
        private void btThem_Click(object sender, EventArgs e)
        {
            textMaChatLieu.Enabled=true;
            btXoa.Enabled = false;
            btSua.Enabled=false;
            btThem.Enabled=false;
            resetValue();
            btBoQua.Enabled = true;
            btLuu.Enabled=true;
            textMaChatLieu.Focus();

        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            string sql;
            if(textMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("bạn chưa nhập mã chất liệu","thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textMaChatLieu.Focus();
                return;
            }
            if(textTenChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("bạn chưa nhập tên chất liệu", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenChatLieu.Focus();
                return;
            }
            sql = "select MaChatLieu from tblChatLieu where MaChatLieu = N'"+textMaChatLieu.Text.Trim()+"'";
            if(QuanLyBanHang.checkKey(sql))
            {
                MessageBox.Show("Đã tồn tại mã chất liệu, vui lòng nhập mã khác", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaChatLieu.Focus();
                return;
            }
            sql = "insert into tblChatLieu VALUES (N'"+textMaChatLieu.Text+"',N'"+textTenChatLieu.Text+"')";
            QuanLyBanHang.runSQL(sql);
            LoadDataGridView();
            resetValue();
            btThem.Enabled = true;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            btBoQua.Enabled = false;
            btLuu.Enabled = false;
            textMaChatLieu.Enabled = false;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string sql;
            if (datatbl.Rows.Count == 0)
            {
                MessageBox.Show("chưa có dữ liệu", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaChatLieu.Focus();
                return;
            }
            if (textMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("bạn chưa chọn dữ liệu cần sửa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenChatLieu.Focus();
                return;
            }
            if (textTenChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("bạn chưa chọn nhập tên cần sửa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenChatLieu.Focus();
                return;
            }
            sql = "update tblChatLieu set TenChatLieu = N'" + textTenChatLieu.Text + "' where MaChatLieu = N'"+textMaChatLieu.Text +"'";
            QuanLyBanHang.runSQL(sql);
            LoadDataGridView();
            resetValue();
            btBoQua.Enabled = false;

        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            string sql;
            if(datatbl.Rows.Count == 0) 
            {
                MessageBox.Show("chưa có dữ liệu", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textMaChatLieu.Focus();
                return;
            }
            if (textMaChatLieu.Text.Trim().Length == 0)
            {
                MessageBox.Show("bạn chưa chọn dữ liệu để xóa", "thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textTenChatLieu.Focus();
                return;
            }
            if(MessageBox.Show("bạn có muốn xóa không ?","thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sql = "delete tblChatLieu where MaChatLieu = N'"+textMaChatLieu.Text+"'";
                QuanLyBanHang.runSQL(sql);
                LoadDataGridView() ;
                resetValue();
            }    
        }

        private void btBoQua_Click(object sender, EventArgs e)
        {
            textMaChatLieu.Enabled = false;
            btXoa.Enabled = true;
            btSua.Enabled = true;
            btThem.Enabled = true;
            resetValue();
            btBoQua.Enabled = false;
            btLuu.Enabled = false;
            textMaChatLieu.Focus();
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
