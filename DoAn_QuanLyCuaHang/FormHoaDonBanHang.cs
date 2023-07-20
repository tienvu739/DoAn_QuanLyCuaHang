using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COMExcel = Microsoft.Office.Interop.Excel;

namespace DoAn_QuanLyCuaHang
{
    public partial class FormHoaDonBanHang : Form
    {
        DataTable tblHoaDonBanHang;
        public FormHoaDonBanHang()
        {
            InitializeComponent();
        }
        private void loadDatagirdView()
        {
            string sql;
            sql = "select a.MaHang,b.TenHang,a.SoLuong,b.DonGiaBan,a.GiamGia," +
                "a.ThangTien from tblChiTietHDBan as a ,tblHang as b where a.MaHDBan = N'" + textMaHD.Text +
                "' and a.MaHang = b.MaHang";
            tblHoaDonBanHang = QuanLyBanHang.getDatatable(sql);
            dataGridView1.DataSource = tblHoaDonBanHang;
            dataGridView1.Columns[0].HeaderText = "Mã hàng";
            dataGridView1.Columns[1].HeaderText = "Tên hàng";
            dataGridView1.Columns[2].HeaderText = "Số lượng";
            dataGridView1.Columns[3].HeaderText = "Đơn giá";
            dataGridView1.Columns[4].HeaderText = "Giảm giá %";
            dataGridView1.Columns[5].HeaderText = "Thành tiền";
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 150;
            dataGridView1.Columns[2].Width = 50;
            dataGridView1.Columns[3].Width = 100;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 100;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
        private void loadInfoHang()
        {
            string sql;
            Double tong;
            sql = "select NgayBan from tblHDBan where MaHDBan = N'" + textMaHD.Text + "'";
            dateNgayBan.Value =  DateTime.Parse(QuanLyBanHang.getValues(sql));
            sql = "select MaNhanVien from tblHDBan where MaHDBan = N'" + textMaHD.Text + "'";
            comboMaNhanVien.Text = QuanLyBanHang.getValues(sql);
            sql = "select MaKhach from tblHDBan where MaHDBan = N'" + textMaHD.Text + "'";
            comboMaKhachHang.Text = QuanLyBanHang.getValues(sql);
            sql = "select TongTien from tblHDBan where MaHDBan = N'" + textMaHD.Text + "'";
            textTongTien.Text = QuanLyBanHang.getValues(sql);
            tong = Convert.ToDouble(QuanLyBanHang.getValues(sql));
            laChu.Text = "Bằng chữ: " + QuanLyBanHang.NumberToText(tong);
        }
        private void FormHoaDonBanHang_Load(object sender, EventArgs e)
        {
            string sql;
            btThemHD.Enabled = true;
            btLuuHD.Enabled = false;
            btHuyHD.Enabled = false;
            btInHD.Enabled = false;
            textMaHD.ReadOnly = true;
            textTenNhanVien.ReadOnly = true;
            textTenKhachHang.ReadOnly = true;
            textDiaChi.ReadOnly = true;
            textDienThoai.ReadOnly = true;
            textTenHang.ReadOnly = true;
            textDonGia.ReadOnly = true;
            textThanhTien.ReadOnly = true;
            textTongTien.ReadOnly = true;
            textGiamGia.Text = "0";
            textTongTien.Text = "0";
            sql = "select MaKhach,TenKhach from tblKhach";
            QuanLyBanHang.fillCombo(sql, comboMaKhachHang, "MaKhach", "TenKhach");
            comboMaKhachHang.SelectedIndex = -1;
            sql = "select MaNhanVien,TenNhanVien from tblNhanVien";
            QuanLyBanHang.fillCombo(sql, comboMaNhanVien, "MaNhanVien", "TenNhanVien");
            comboMaNhanVien.SelectedIndex = -1;
            sql = "select MaHang,TenHang from tblHang";
            QuanLyBanHang.fillCombo(sql, comboMaHang, "MaHang", "TenHang");
            comboMaHang.SelectedIndex = -1;
            if(textMaHD.Text != "")
            {
                loadInfoHang();
                btHuyHD.Enabled = true;
                btInHD.Enabled = true;
            }
            loadDatagirdView();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }
        private void reset()
        {
            textMaHD.Text = string.Empty;
            dateNgayBan.Value = DateTime.Now;
            comboMaHang.Text = string.Empty;
            comboMaNhanVien.Text = string.Empty;
            comboMaKhachHang.Text= string.Empty;
            laChu.Text = string.Empty;
            textTongTien.Text = string.Empty;
            textSoLuong.Text = string.Empty;
            textGiamGia.Text = string.Empty;
            textThanhTien.Text = string.Empty;
        }
        private void ResetValuesHang()
        {
            comboMaHang.Text = "";
            textSoLuong.Text = "";
            textGiamGia.Text = "0";
            textThanhTien.Text = "0";
        }
        private void btThemHD_Click(object sender, EventArgs e)
        {
            btHuyHD.Enabled = false;
            btInHD.Enabled=false;
            btLuuHD.Enabled=true;
            btThemHD.Enabled=false;
            reset();
            textMaHD.Text = QuanLyBanHang.CreateKey("HDB");
            loadDatagirdView();
        }

        private void btLuuHD_Click(object sender, EventArgs e)
        {
            string sql;
            Double sl, tong, slcon, tongmoi;
            sql = "select MaHDBan from tblHDBan where MaHDBan = N'" + textMaHD.Text + "'";
            if( ! QuanLyBanHang.checkKey(sql))
            {
                if(comboMaNhanVien.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn mã nhân viên","Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboMaNhanVien.Focus();
                    return;
                }
                
                if (comboMaKhachHang.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn mã khách hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboMaKhachHang.Focus();
                    return;
                }
                if (dateNgayBan.Text.Length == 0)
                {
                    MessageBox.Show("Bạn chưa chọn ngày bán", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboMaNhanVien.Focus();
                    return;
                }
                sql = "INSERT INTO tblHDBan VALUES ('" + textMaHD.Text + "','" +
                        comboMaNhanVien.SelectedValue + "','" + dateNgayBan.Text + "','" +
                        comboMaKhachHang.SelectedValue + "','" + textTongTien.Text + "')";
                QuanLyBanHang.runSQL(sql);
            }
            if (comboMaHang.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập mã hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboMaHang.Focus();
                return;
            }
            if ((textSoLuong.Text.Trim().Length == 0) || (textSoLuong.Text == "0"))
            {
                MessageBox.Show("Bạn phải nhập số lượng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textSoLuong.Text = "";
                textSoLuong.Focus();
                return;
            }
            if (textGiamGia.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn phải nhập giảm giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textGiamGia.Focus();
                return;
            }
            sql = "SELECT MaHang FROM tblChiTietHDBan WHERE MaHang=N'" + comboMaHang.SelectedValue + "' AND MaHDBan = N'" + textMaHD.Text + "'";
            if (QuanLyBanHang.checkKey(sql))
            {
                MessageBox.Show("Mã hàng này đã có, bạn phải nhập mã khác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ResetValuesHang();
                comboMaHang.Focus();
                return;
            }
            sl = Convert.ToDouble(QuanLyBanHang.getValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + comboMaHang.SelectedValue + "'"));
            if (Convert.ToDouble(textSoLuong.Text) > sl)
            {
                MessageBox.Show("Số lượng mặt hàng này chỉ còn " + sl, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textSoLuong.Text = "";
                textSoLuong.Focus();
                return;
            }
            sql = "INSERT INTO tblChiTietHDBan VALUES(N'" + textMaHD.Text + "',N'" + comboMaHang.SelectedValue + "'," + textSoLuong.Text + "," + textDonGia.Text + "," + textGiamGia.Text + "," + textThanhTien.Text + ")";
            QuanLyBanHang.runSQL(sql);
            loadDatagirdView();
            slcon = sl - Convert.ToDouble(textSoLuong.Text);
            sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + comboMaHang.SelectedValue + "'";
            QuanLyBanHang.runSQL(sql);
            tong = Convert.ToDouble(QuanLyBanHang.getValues("SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + textMaHD.Text + "'"));
            tongmoi = tong + Convert.ToDouble(textThanhTien.Text);
            sql = "UPDATE tblHDBan SET TongTien = '" + tongmoi + "' WHERE MaHDBan = N'" + textMaHD.Text + "'";
            QuanLyBanHang.runSQL(sql);
            textTongTien.Text = tongmoi.ToString();
            laChu.Text = "Bằng chữ: " + QuanLyBanHang.NumberToText(tongmoi);
            ResetValuesHang();
            btHuyHD.Enabled = true;
            btThemHD.Enabled = true;
            btInHD.Enabled = true;
        }

        private void comboMaNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboMaNhanVien.Text.Length == 0)
                textTenNhanVien.Text = string.Empty;
            sql = "select TenNhanVien from tblNhanVien where MaNhanVien = N'" + comboMaNhanVien.SelectedValue + "'";
            textTenNhanVien.Text = QuanLyBanHang.getValues(sql);
        }

        private void comboMaKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql;
            if (comboMaKhachHang.Text == "")
            {
                textTenKhachHang.Text = "";
                textDiaChi.Text = "";
                textDienThoai.Text = "";
            }
            //Khi chọn Mã khách hàng thì các thông tin của khách hàng sẽ hiện ra
            sql = "Select TenKhach from tblKhach where MaKhach = N'" + comboMaKhachHang.SelectedValue + "'";
            textTenKhachHang.Text = QuanLyBanHang.getValues(sql);
            sql = "Select DiaChi from tblKhach where MaKhach = N'" + comboMaKhachHang.SelectedValue + "'";
            textDiaChi.Text = QuanLyBanHang.getValues(sql);
            sql = "Select DienThoai from tblKhach where MaKhach= N'" + comboMaKhachHang.SelectedValue + "'";
            textDienThoai.Text = QuanLyBanHang.getValues(sql);
        }

        private void comboMaHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str;
            if (comboMaHang.Text == "")
            {
                textTenHang.Text = "";
                textDonGia.Text = "";
            }
            // Khi chọn mã hàng thì các thông tin về hàng hiện ra
            str = "SELECT TenHang FROM tblHang WHERE MaHang =N'" + comboMaHang.SelectedValue + "'";
            textTenHang.Text = QuanLyBanHang.getValues(str);
            str = "SELECT DonGiaBan FROM tblHang WHERE MaHang =N'" + comboMaHang.SelectedValue + "'";
            textDonGia.Text = QuanLyBanHang.getValues(str);
        }

        private void textSoLuong_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (textSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(textSoLuong.Text);
            if (textGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(textGiamGia.Text);
            if (textDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            textThanhTien.Text = tt.ToString();
        }

        private void comboBoxTimKiem_DropDown(object sender, EventArgs e)
        {
            QuanLyBanHang.fillCombo("select MaHDBan from tblHDBan", comboBoxTimKiem, "MaHDBan", "MaHDBan");
            comboBoxTimKiem.SelectedIndex = -1;
        }

        private void textGiamGia_TextChanged(object sender, EventArgs e)
        {
            double tt, sl, dg, gg;
            if (textSoLuong.Text == "")
                sl = 0;
            else
                sl = Convert.ToDouble(textSoLuong.Text);
            if (textGiamGia.Text == "")
                gg = 0;
            else
                gg = Convert.ToDouble(textGiamGia.Text);
            if (textDonGia.Text == "")
                dg = 0;
            else
                dg = Convert.ToDouble(textDonGia.Text);
            tt = sl * dg - sl * dg * gg / 100;
            textThanhTien.Text = tt.ToString();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(comboBoxTimKiem.Text == string.Empty)
            {
                MessageBox.Show("Bạn chưa chọn mã hóa đơn", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                comboBoxTimKiem.Focus();
                return;
            }
            textMaHD.Text = comboBoxTimKiem.Text;
            loadInfoHang();
            loadDatagirdView();
            comboBoxTimKiem.SelectedItem = -1;
        }
    }
}
