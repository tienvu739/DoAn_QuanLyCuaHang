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
            string MaHangxoa, sql;
            Double ThanhTienxoa, SoLuongxoa, sl, slcon, tong, tongmoi;
            if (tblHoaDonBanHang.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                MaHangxoa = dataGridView1.CurrentRow.Cells["MaHang"].Value.ToString();
                SoLuongxoa = Convert.ToDouble(dataGridView1.CurrentRow.Cells["SoLuong"].Value.ToString());
                ThanhTienxoa = Convert.ToDouble(dataGridView1.CurrentRow.Cells["ThangTien"].Value.ToString());
                sql = "DELETE tblChiTietHDBan WHERE MaHDBan=N'" + textMaHD.Text + "' AND MaHang = N'" + MaHangxoa + "'";
                QuanLyBanHang.runSQL(sql);
                // Cập nhật lại số lượng cho các mặt hàng
                sl = Convert.ToDouble(QuanLyBanHang.getValues("SELECT SoLuong FROM tblHang WHERE MaHang = N'" + MaHangxoa + "'"));
                slcon = sl + SoLuongxoa;
                sql = "UPDATE tblHang SET SoLuong =" + slcon + " WHERE MaHang= N'" + MaHangxoa + "'";
                QuanLyBanHang.runSQL(sql);
                // Cập nhật lại tổng tiền cho hóa đơn bán
                tong = Convert.ToDouble(QuanLyBanHang.getValues("SELECT TongTien FROM tblHDBan WHERE MaHDBan = N'" + textMaHD.Text + "'"));
                tongmoi = tong - ThanhTienxoa;
                sql = "UPDATE tblHDBan SET TongTien =" + tongmoi + " WHERE MaHDBan = N'" + textMaHD.Text + "'";
                QuanLyBanHang.runSQL(sql);
                if(tongmoi ==0)
                {
                    sql = "DELETE tblHDBan WHERE MaHDBan = N'" + textMaHD.Text + "'";
                    QuanLyBanHang.runSQL(sql);
                }
                textTongTien.Text = tongmoi.ToString();
                laChu.Text = "Bằng chữ: " + QuanLyBanHang.NumberToText(tongmoi);
                loadDatagirdView();
            }
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
            btInHD.Enabled = true;
            btHuyHD.Enabled = true;
        }

        private void btInHD_Click(object sender, EventArgs e)
        {
            COMExcel.Application exApp = new COMExcel.Application();
            COMExcel.Workbook wb ;
            COMExcel.Worksheet ws ;
            COMExcel.Range exRange;
            string sql;
            DataTable tblHoaDon, tblHang;
            int hang = 0, cot = 0;
            wb = exApp.Workbooks.Add(COMExcel.XlWBATemplate.xlWBATWorksheet);
            ws = wb.Worksheets[1];
            exRange = ws.Cells[1, 1];
            exRange.Range["A1:Z300"].Font.Name = "Times new roman"; //Font chữ
            exRange.Range["A1:B3"].Font.Size = 10;
            exRange.Range["A1:B3"].Font.Bold = true;
            exRange.Range["A1:B3"].Font.ColorIndex = 5; //Màu xanh da trời
            exRange.Range["A1:A1"].ColumnWidth = 7;
            exRange.Range["B1:B1"].ColumnWidth = 15;
            exRange.Range["A1:B1"].MergeCells = true;
            exRange.Range["A1:B1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A1:B1"].Value = "Shop B.A.";
            exRange.Range["A2:B2"].MergeCells = true;
            exRange.Range["A2:B2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:B2"].Value = "Chùa Bộc - Hà Nội";
            exRange.Range["A3:B3"].MergeCells = true;
            exRange.Range["A3:B3"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A3:B3"].Value = "Điện thoại: (04)38526419";
            exRange.Range["C2:E2"].Font.Size = 16;
            exRange.Range["C2:E2"].Font.Bold = true;
            exRange.Range["C2:E2"].Font.ColorIndex = 3; //Màu đỏ
            exRange.Range["C2:E2"].MergeCells = true;
            exRange.Range["C2:E2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C2:E2"].Value = "HÓA ĐƠN BÁN";
            sql = "SELECT a.MaHDBan, a.NgayBan, a.TongTien, b.TenKhach," +
                " b.DiaChi, b.DienThoai, c.TenNhanVien FROM tblHDBan AS a," +
                " tblKhach AS b, tblNhanVien AS c WHERE a.MaHDBan = N'" + textMaHD.Text +
                "' AND a.MaKhach = b.MaKhach AND a.MaNhanVien = c.MaNhanVien";
            tblHoaDon = QuanLyBanHang.getDatatable(sql);
            exRange.Range["B6:C9"].Font.Size = 12;
            exRange.Range["B6:B6"].Value = "Mã hóa đơn:";
            exRange.Range["C6:E6"].MergeCells = true;
            exRange.Range["C6:E6"].Value = tblHoaDon.Rows[0][0].ToString();
            exRange.Range["B7:B7"].Value = "Khách hàng:";
            exRange.Range["C7:E7"].MergeCells = true;
            exRange.Range["C7:E7"].Value = tblHoaDon.Rows[0][3].ToString();
            exRange.Range["B8:B8"].Value = "Địa chỉ:";
            exRange.Range["C8:E8"].MergeCells = true;
            exRange.Range["C8:E8"].Value = tblHoaDon.Rows[0][4].ToString();
            exRange.Range["B9:B9"].Value = "Điện thoại:";
            exRange.Range["C9:E9"].MergeCells = true;
            exRange.Range["C9:E9"].Value = tblHoaDon.Rows[0][5].ToString();
            //Lấy thông tin các mặt hàng
            sql = "SELECT b.TenHang, a.SoLuong, b.DonGiaBan, a.GiamGia, a.ThangTien " +
                  "FROM tblChiTietHDBan AS a , tblHang AS b WHERE a.MaHDBan = N'" +
                  textMaHD.Text + "' AND a.MaHang = b.MaHang";
            tblHang = QuanLyBanHang.getDatatable(sql);
            //Tạo dòng tiêu đề bảng
            exRange.Range["A11:F11"].Font.Bold = true;
            exRange.Range["A11:F11"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["C11:F11"].ColumnWidth = 12;
            exRange.Range["A11:A11"].Value = "STT";
            exRange.Range["B11:B11"].Value = "Tên hàng";
            exRange.Range["C11:C11"].Value = "Số lượng";
            exRange.Range["D11:D11"].Value = "Đơn giá";
            exRange.Range["E11:E11"].Value = "Giảm giá";
            exRange.Range["F11:F11"].Value = "Thành tiền";
            for (hang = 0; hang < tblHang.Rows.Count; hang++)
            {
                //Điền số thứ tự vào cột 1 từ dòng 12
                ws.Cells[1][hang + 12] = hang + 1;
                for (cot = 0; cot < tblHang.Columns.Count; cot++)
                //Điền thông tin hàng từ cột thứ 2, dòng 12
                {
                    ws.Cells[cot + 2][hang + 12] = tblHang.Rows[hang][cot].ToString();
                    if (cot == 3) ws.Cells[cot + 2][hang + 12] = tblHang.Rows[hang][cot].ToString() + "%";
                }
            }
            exRange = ws.Cells[cot][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = "Tổng tiền:";
            exRange = ws.Cells[cot + 1][hang + 14];
            exRange.Font.Bold = true;
            exRange.Value2 = tblHoaDon.Rows[0][2].ToString();
            exRange = ws.Cells[1][hang + 15]; //Ô A1 
            exRange.Range["A1:F1"].MergeCells = true;
            exRange.Range["A1:F1"].Font.Bold = true;
            exRange.Range["A1:F1"].Font.Italic = true;
            exRange.Range["A1:F1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignRight;
            exRange.Range["A1:F1"].Value = "Bằng chữ: " + QuanLyBanHang.NumberToText(Convert.ToDouble(tblHoaDon.Rows[0][2].ToString()));
            exRange = ws.Cells[4][hang + 17]; //Ô A1 
            exRange.Range["A1:C1"].MergeCells = true;
            exRange.Range["A1:C1"].Font.Italic = true;
            exRange.Range["A1:C1"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            DateTime d = Convert.ToDateTime(tblHoaDon.Rows[0][1]);
            exRange.Range["A1:C1"].Value = "Hà Nội, ngày " + d.Day + " tháng " + d.Month + " năm " + d.Year;
            exRange.Range["A2:C2"].MergeCells = true;
            exRange.Range["A2:C2"].Font.Italic = true;
            exRange.Range["A2:C2"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A2:C2"].Value = "Nhân viên bán hàng";
            exRange.Range["A6:C6"].MergeCells = true;
            exRange.Range["A6:C6"].Font.Italic = true;
            exRange.Range["A6:C6"].HorizontalAlignment = COMExcel.XlHAlign.xlHAlignCenter;
            exRange.Range["A6:C6"].Value = tblHoaDon.Rows[0][6];
            ws.Name = "Hóa đơn nhập";
            exApp.Visible = true;
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btHuyHD_Click(object sender, EventArgs e)
        {
            string sql;
            Double  SoLuongxoa, sl, slcon;
            if ((MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
            {
                sql = "select MaHang,SoLuong from tblChiTietHDBan where MaHDBan = N'" + textMaHD.Text + "'";
                DataTable tblHang = QuanLyBanHang.getDatatable(sql);
                for(int hang = 0; hang < tblHang.Rows.Count; hang++)
                {
                    slcon = Convert.ToDouble(QuanLyBanHang.getValues("select SoLuong from tblHang where MaHang = N'" + tblHang.Rows[hang][0]+"'"));
                    SoLuongxoa = Convert.ToDouble(tblHang.Rows[hang][1]);
                    sl = slcon + SoLuongxoa;
                    sql = "UPDATE tblHang SET SoLuong = " + sl + " where MaHang = N'" + tblHang.Rows[hang][0]+"'";
                    QuanLyBanHang.runSQL(sql);
                }
                sql = "DELETE tblChiTietHDBan WHERE MaHDBan = N'" + textMaHD.Text + "'";
                QuanLyBanHang.runSQL(sql);
                sql = "DELETE tblHDBan WHERE MaHDBan = N'" + textMaHD.Text + "'";
                QuanLyBanHang.runSQL(sql);
                loadDatagirdView();
                reset();
            }
        }
    }
}
