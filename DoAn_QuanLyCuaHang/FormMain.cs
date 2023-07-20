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
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            QuanLyBanHang.connect();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DialogResult exit = MessageBox.Show("bạn có muốn thoát?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {   
                QuanLyBanHang.disconnect();
                Application.Exit();
            }
        }

        private void chấtLiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FromDanhMucChatLieu form1 = new FromDanhMucChatLieu();
            form1.MdiParent = this;
            form1.Show();
        }

        private void nhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDanhMucNhanVien form2 = new FormDanhMucNhanVien();
            form2.MdiParent = this;
            form2.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDanhMucKhachHang form3 = new FormDanhMucKhachHang();
            form3.MdiParent = this;
            form3.Show();
        }

        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDanhMucHangHoa form4 = new FormDanhMucHangHoa();
            form4.MdiParent = this;
            form4.Show();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormHoaDonBanHang form = new FormHoaDonBanHang();
            form.MdiParent = this;
            form.Show();
        }
    }
}
