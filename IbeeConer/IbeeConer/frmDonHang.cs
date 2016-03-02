using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DTO;
using IbeeConer.Utils;

namespace IbeeConer
{
    public partial class frmDonHang : DevExpress.XtraEditors.XtraForm
    {
        DonHang obj = new DonHang();
        DonHangBLL bll = new DonHangBLL();

        CTDH objCtdh = new CTDH();
        CTDHBLL bllCtdh = new CTDHBLL();

        SanPham objSP = new SanPham();

        private int chieudaiId = 5;
        private string tablename = "DonHang";

        private bool isNew = false;
        private int dong = 0;
        private List<double> soluongmuaCu = new List<double>();
        public frmDonHang()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtDotHang.Enabled = false;
            txtThang.Enabled = false;
            txtNam.Enabled = false;

            btnThemMoi.Enabled = true;
            btnThemCu.Enabled = true;

            leMaDH.Enabled = false;
            btnTinhTien.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;

            gcCTDH.Enabled = false;
        }

        void ThemMoi()
        {
            txtDotHang.Enabled = true;
            txtThang.Enabled = true;
            txtNam.Enabled = true;

            btnThemMoi.Enabled = false;
            btnThemCu.Enabled = false;

            leMaDH.Enabled = false;
            btnTinhTien.Enabled = true;
            // btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            gcCTDH.Enabled = true;
        }
        void ThemCu()
        {
            txtDotHang.Enabled = false;
            txtThang.Enabled = false;
            txtNam.Enabled = false;

            btnThemMoi.Enabled = false;
            btnThemCu.Enabled = false;

            leMaDH.Enabled = true;
            //btnTinhTien.Enabled = true;
            //btnLuu.Enabled = true;
            btnHuy.Enabled = true;

            gcCTDH.Enabled = false;

        }

        void LamMoi()
        {
            txtMaDH.Text = string.Empty;
            txtNgayLap.Text = string.Empty;
            txtNam.Text = string.Empty;
            txtDotHang.Text = string.Empty;
            txtThang.Text = string.Empty;
            txtTongGiaTri.Text = string.Empty;
            txtTienLoi.Text = string.Empty;
            leMaDH.EditValue = string.Empty;
        }
        void HienThi(string madonhang)
        {
            gcCTDH.DataSource = bllCtdh.GetDataByMaDH(madonhang);
            //Tự động chỉnh các cột theo nội dung
            gridView1.BestFitColumns();
        }
        private void frmDonHang_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi("");
            repositoryItemLookUpEdit1.DataSource = bllCtdh.GetDataKhachHang();

            repositoryItemLookUpEdit2.DataSource = bllCtdh.GetDataSanPhamBySoLuong();
            repositoryItemLookUpEdit2.DisplayMember = "TenSP";
            repositoryItemLookUpEdit2.ValueMember = "MaSP";

            leMaDH.Properties.DataSource = bll.GetData();
            leMaDH.Properties.DisplayMember = "MaDonHang";
            leMaDH.Properties.ValueMember = "MaDonHang";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            HienThi("");
            ThemMoi();
            LamMoi();
            isNew = true;

            DateTime now = DateTime.Now;
            txtNgayLap.Text = now.ToString("dd-MM-yyyy");
            txtMaDH.Text = bll.LayIdTuDong("DH", chieudaiId, tablename);
            txtNam.Text = now.ToString("yyyy");

        }
        private void btnThemCu_Click(object sender, EventArgs e)
        {
            leMaDH.Properties.DataSource = bll.GetData();
            HienThi("");
            ThemCu();
            LamMoi();
            isNew = false;
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn hủy không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                HienThi("");
                LamMoi();
                KhoaDieuKhien();
            }
        }
        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                if (e.Column.FieldName == "MaKH")
                {
                    btnLuu.Enabled = false;

                    DateTime now = DateTime.Now;
                    string s = now.ToString("yyMMddhhmmss");
                    gridView1.SetRowCellValue(e.RowHandle, "MaCTDH", s);
                }
                else
                {
                    if (e.Column.FieldName == "MaSP" || e.Column.FieldName == "SoLuongMua")
                    {
                        btnLuu.Enabled = false;

                        string id = gridView1.GetFocusedRowCellValue("MaSP").ToString();
                        DataTable dt = new DataTable();
                        dt = bllCtdh.GetDataSanPhamByID(id);
                        // string dongianhap = dt.Rows[0]["VietNamDong"].ToString();
                        //  gridView1.SetRowCellValue(e.RowHandle, "DonGiaNhap", dongianhap);
                        if (gridView1.GetFocusedRowCellValue("SoLuongMua") == null)
                            return;
                        double dongianhap;
                        //         int soluongmua = int.Parse(gridView1.GetFocusedRowCellValue("SoLuongMua").ToString());
                        string vietnamdong = dt.Rows[0]["VietNamDong"].ToString();
                        //2 cái trở lên tiền ship chỉ mất 50000
                        //  if (soluongmua >= 2)
                        //   {
                        //          dongianhap = double.Parse(vietnamdong) + 50000;
                        //      }
                        //       else
                        //       {
                        dongianhap = double.Parse(vietnamdong) + 70000;
                        //      }
                        gridView1.SetRowCellValue(e.RowHandle, "DonGiaNhap", dongianhap);
                    }
                    if (e.Column.FieldName == "SoLuongMua" || e.Column.FieldName == "TienLoi")
                    {
                        btnLuu.Enabled = false;

                        string id = gridView1.GetFocusedRowCellValue("MaSP").ToString();
                        DataTable dt = new DataTable();
                        dt = bllCtdh.GetDataSanPhamByID(id);
                        string soluongcon = dt.Rows[0]["SoLuong"].ToString();
                        //Kiểm tra số lượng mua và số lượng còn
                        if (gridView1.GetFocusedRowCellValue("SoLuongMua") != null)
                        {
                            if (double.Parse(gridView1.GetFocusedRowCellValue("SoLuongMua").ToString()) >
                                double.Parse(soluongcon))
                            {
                                XtraMessageBox.Show("Vượt quá số lượng hàng còn");
                                gridView1.SetRowCellValue(e.RowHandle, "SoLuongMua", double.Parse(soluongcon));
                            }
                        }
                        if (gridView1.GetFocusedRowCellValue("SoLuongMua") != null &&
                            gridView1.GetFocusedRowCellValue("TienLoi") != null)
                        {
                            // giaban = (gianhap+phuthu)* soluong
                            double dongiaban =
                                (double.Parse(gridView1.GetFocusedRowCellValue("DonGiaNhap").ToString()) +
                                 double.Parse(gridView1.GetFocusedRowCellValue("TienLoi").ToString()))*
                                double.Parse(gridView1.GetFocusedRowCellValue("SoLuongMua").ToString());
                            gridView1.SetRowCellValue(e.RowHandle, "DonGiaBan", dongiaban);
                        }
                    }
                }
            }
            catch
            {
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            /* string kh = gridView1.GetFocusedRowCellValue("MaKH").ToString();
             string sp = gridView1.GetFocusedRowCellValue("MaSP").ToString();
             if (kh.Equals(string.Empty) || sp.Equals(string.Empty))
                 XtraMessageBox.Show("Vui lòng chọn khách hàng và sản phẩm");*/
        }

        private void leMaDH_EditValueChanged(object sender, EventArgs e)
        {
            HienThi(leMaDH.EditValue.ToString());

            if (!leMaDH.EditValue.ToString().Equals(string.Empty))
            {
                gcCTDH.Enabled = true;

                btnTinhTien.Enabled = true;
                DataTable dt = new DataTable();
                dt = bll.GetDataByID(leMaDH.EditValue.ToString());

                txtMaDH.Text = dt.Rows[0]["MaDonHang"].ToString();
                txtNgayLap.Text = dt.Rows[0]["NgayLap"].ToString();
                txtDotHang.Text = dt.Rows[0]["DotHang"].ToString();
                txtThang.Text = dt.Rows[0]["Thang"].ToString();
                txtNam.Text = dt.Rows[0]["Nam"].ToString();
                txtTongGiaTri.Text = double.Parse(dt.Rows[0]["TongGiaTri"].ToString()).ToString();
                txtTienLoi.Text = double.Parse(dt.Rows[0]["TienLai"].ToString()).ToString();

            }
            // xem gridview có bao nhiêu dong để xác định update hay insert
            dong = gridView1.RowCount;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraHopLeVaThongBao())
            {
                if (isNew)
                {
                    obj.MaDonHang = txtMaDH.Text;
                    obj.DotHang = txtDotHang.Text;
                    obj.Thang = txtThang.Text;
                    obj.Nam = txtNam.Text;
                    obj.NgayLap = DateTime.Parse(txtNgayLap.Text);
                    obj.TongGiaTri = txtTongGiaTri.Text;
                    obj.TienLai = txtTienLoi.Text;
                    try
                    {
                        bll.Insert(obj);
                        XtraMessageBox.Show("Tạo đơn hàng " + txtMaDH.Text + " thành công");

                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Tạo đơn hàng thất bại");
                    }

                    int dem = 0;
                    // XtraMessageBox.Show(gridView1.RowCount.ToString());
                    for (int i = 0; i < gridView1.RowCount; i++)
                    {
                        objCtdh.MaCTDH = gridView1.GetRowCellValue(i, "MaCTDH").ToString();
                        objCtdh.MaDonHang = txtMaDH.Text;
                        objCtdh.MaKH = gridView1.GetRowCellValue(i, "MaKH").ToString();
                        objCtdh.MaSP = gridView1.GetRowCellValue(i, "MaSP").ToString();
                        objCtdh.SoLuongMua = gridView1.GetRowCellValue(i, "SoLuongMua").ToString();
                        objCtdh.DonGiaNhap = gridView1.GetRowCellValue(i, "DonGiaNhap").ToString();
                        objCtdh.TienLoi = gridView1.GetRowCellValue(i, "TienLoi").ToString();
                        objCtdh.DonGiaBan = gridView1.GetRowCellValue(i, "DonGiaBan").ToString();

                        try
                        {
                            bllCtdh.Insert(objCtdh);
                        }
                        catch (Exception)
                        {
                            XtraMessageBox.Show("Thêm chi tiết đơn hàng thất bại");
                            return;
                        }

                        dem++;
                    }
                    XtraMessageBox.Show("Thêm thành công " + dem + " chi tiết đơn hàng");
                    
                    updateSoLuongSP();

                    HienThi("");
                    LamMoi();
                    KhoaDieuKhien();
                }
                else
                {
                    obj.MaDonHang = txtMaDH.Text;
                    obj.DotHang = txtDotHang.Text;
                    obj.Thang = txtThang.Text;
                    obj.Nam = txtNam.Text;
                    obj.NgayLap = DateTime.Parse(txtNgayLap.Text);
                    obj.TongGiaTri = txtTongGiaTri.Text;
                    obj.TienLai = txtTienLoi.Text;
                    try
                    {
                        bll.Update(obj);
                        XtraMessageBox.Show("Cập nhật đơn hàng " + txtMaDH.Text + " thành công");

                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Cập nhật đơn hàng thất bại");
                        return;
                    }
                    DataTable dt = new DataTable();
                    try
                    {
                        int dem = 0, dem1 =0;
                        // XtraMessageBox.Show(gridView1.RowCount.ToString());
                        //Những chi tiết đã có thì sẽ cập nhật
                        for (int i = 0; i < dong; i++)
                        {
                            string id1 = gridView1.GetRowCellValue(i, "MaCTDH").ToString();
                            dt = bllCtdh.GetDataByID(id1);
                            soluongmuaCu.Add(double.Parse(dt.Rows[0]["SoLuongMua"].ToString()));

                            objCtdh.MaCTDH = gridView1.GetRowCellValue(i, "MaCTDH").ToString();
                            objCtdh.MaDonHang = txtMaDH.Text;
                            objCtdh.MaKH = gridView1.GetRowCellValue(i, "MaKH").ToString();
                            objCtdh.MaSP = gridView1.GetRowCellValue(i, "MaSP").ToString();
                            objCtdh.SoLuongMua = gridView1.GetRowCellValue(i, "SoLuongMua").ToString();
                            objCtdh.DonGiaNhap = gridView1.GetRowCellValue(i, "DonGiaNhap").ToString();
                            objCtdh.TienLoi = gridView1.GetRowCellValue(i, "TienLoi").ToString();
                            objCtdh.DonGiaBan = gridView1.GetRowCellValue(i, "DonGiaBan").ToString();

                            bllCtdh.Update(objCtdh);
                            dem1 ++;
                        }
                        //CHi tiết mới thì insert
                        for (int i = dong; i < gridView1.RowCount; i++)
                        {
                            objCtdh.MaCTDH = gridView1.GetRowCellValue(i, "MaCTDH").ToString();
                            objCtdh.MaDonHang = txtMaDH.Text;
                            objCtdh.MaKH = gridView1.GetRowCellValue(i, "MaKH").ToString();
                            objCtdh.MaSP = gridView1.GetRowCellValue(i, "MaSP").ToString();
                            objCtdh.SoLuongMua = gridView1.GetRowCellValue(i, "SoLuongMua").ToString();
                            objCtdh.DonGiaNhap = gridView1.GetRowCellValue(i, "DonGiaNhap").ToString();
                            objCtdh.TienLoi = gridView1.GetRowCellValue(i, "TienLoi").ToString();
                            objCtdh.DonGiaBan = gridView1.GetRowCellValue(i, "DonGiaBan").ToString();

                            bllCtdh.Insert(objCtdh);
                            dem++;
                        }
                        XtraMessageBox.Show("Cập nhật thành công " + dem1 + " chi tiết đơn hàng");
                        XtraMessageBox.Show("Thêm thành công " + dem + " chi tiết đơn hàng");
                    }
                    catch (Exception)
                    {
                        XtraMessageBox.Show("Chưa nhập đủ thông tin", "Thất Bại");
                        return;
                    }

                    updateSoLuongSP();

                    soluongmuaCu.Clear();

                    HienThi("");
                    LamMoi();
                    KhoaDieuKhien();
                }
            }
        }

        public void updateSoLuongSP()
        {
            DataTable dt = new DataTable();
            double updateSL = 0;
            //Khi thêm mới
            if (isNew)
            {
                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    string id = gridView1.GetRowCellValue(i, "MaSP").ToString();
                    dt = bllCtdh.GetDataSanPhamByID(id);
                    double soluongcon = double.Parse(dt.Rows[0]["SoLuong"].ToString());
                    double soluongmua = double.Parse(gridView1.GetRowCellValue(i, "SoLuongMua").ToString());
                    updateSL = soluongcon - soluongmua;
                    objSP.MaSP = id;
                    objSP.SoLuong = updateSL.ToString();
                    bllCtdh.UpdateSoLuongSP(objSP);
                }
            }
            //Khi thêm cũ
            else
            {
                //Những chi tiết đã có thì sẽ cập nhật
                for (int i = 0; i < dong; i++)
                {
                    string id = gridView1.GetRowCellValue(i, "MaSP").ToString();
                    dt = bllCtdh.GetDataSanPhamByID(id);
                    double soluongcon = double.Parse(dt.Rows[0]["SoLuong"].ToString());
                    double soluongmuaMoi = double.Parse(gridView1.GetRowCellValue(i, "SoLuongMua").ToString());
                    
                    //string id1 = gridView1.GetRowCellValue(i, "MaCTDH").ToString();
                    //dt = bllCtdh.GetDataByID(id1);
                    //soluongmuaCu = double.Parse(dt.Rows[0]["SoLuongMua"].ToString());

                    updateSL = soluongcon + soluongmuaCu[i] - soluongmuaMoi;

                    objSP.MaSP = id;
                    objSP.SoLuong = updateSL.ToString();
                    bllCtdh.UpdateSoLuongSP(objSP);
                }
                for (int i = dong; i < gridView1.RowCount; i++)
                {
                    string id = gridView1.GetRowCellValue(i, "MaSP").ToString();
                    dt = bllCtdh.GetDataSanPhamByID(id);
                    double soluongcon = double.Parse(dt.Rows[0]["SoLuong"].ToString());
                    double soluongmua = double.Parse(gridView1.GetRowCellValue(i, "SoLuongMua").ToString());
                    updateSL = soluongcon - soluongmua;
                    objSP.MaSP = id;
                    objSP.SoLuong = updateSL.ToString();
                    bllCtdh.UpdateSoLuongSP(objSP);
                }
            }
            repositoryItemLookUpEdit2.DataSource = bllCtdh.GetDataSanPhamBySoLuong();
        }
        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRowCellValue(i, "MaKH").ToString() == string.Empty)
                {
                    XtraMessageBox.Show("Vui lòng chọn khách hàng");
                    return;
                }
            }
            try
            {
                summary();
            }
            catch
            {
                XtraMessageBox.Show("Chưa nhập đủ các trường bắt buộc");
                return;
            }
            btnLuu.Enabled = true;

        }

        public void summary()
        {
            double tonggiatri = 0;
            double tienmuahang = 0;
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                tonggiatri += double.Parse(gridView1.GetRowCellValue(i, "DonGiaBan").ToString());
                tienmuahang += double.Parse(gridView1.GetRowCellValue(i, "DonGiaNhap").ToString()) * double.Parse(gridView1.GetRowCellValue(i, "SoLuongMua").ToString());
            }
            double tienloi = tonggiatri - tienmuahang;
            txtTongGiaTri.Text = tonggiatri.ToString();
            txtTienLoi.Text = tienloi.ToString();
            
        }

        private void gcCTDH_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                gridView1.AddNewRow();
            }
            else
            {
                //Khi nhấn F2 kết thúc nhập luôn
                if (e.KeyCode == Keys.F2)
                    gridView1.UpdateCurrentRow();
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn xóa dòng này?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                if (isNew)
                {
                    gridView1.DeleteSelectedRows();
                    btnLuu.Enabled = false;
                }
                else
                {
                    string id = gridView1.GetFocusedRowCellValue("MaCTDH").ToString();
                    string idSP = gridView1.GetFocusedRowCellValue("MaSP").ToString();
                    try
                    {
                        updateSoLuongSPKhiXoa(id, idSP);
                        bllCtdh.Delete(id);
                        //Nếu đã save trong CSDL thì giảm số dòng đi, chưa save thì chỉ trong trên Grid
                        dong--;
                        gridView1.DeleteSelectedRows();
                    }
                    catch (Exception)
                    {
                        gridView1.DeleteSelectedRows();
                    }
                    btnLuu.Enabled = false;
                }
            }
        }

        public void updateSoLuongSPKhiXoa(string id,string idSP)
        {
            DataTable dt = new DataTable();
            double updateSL = 0;
         //   string id = gridView1.GetFocusedRowCellValue("MaCTDH").ToString();
         //   string idSP = gridView1.GetFocusedRowCellValue("MaSP").ToString();
            dt = bllCtdh.GetDataSanPhamByID(idSP);
            double soluongcon = double.Parse(dt.Rows[0]["SoLuong"].ToString());

            dt = bllCtdh.GetDataByID(id);
            double soluongmua = double.Parse(dt.Rows[0]["SoLuongMua"].ToString());

            updateSL = soluongcon + soluongmua;

            objSP.MaSP = idSP;
            objSP.SoLuong = updateSL.ToString();
            bllCtdh.UpdateSoLuongSP(objSP);
            
            repositoryItemLookUpEdit2.DataSource = bllCtdh.GetDataSanPhamBySoLuong();
        }
        private bool KiemTraHopLeVaThongBao()
        {
            if (txtDotHang.Text.Equals("0") || txtThang.Text.Equals("0"))
            {
                XtraMessageBox.Show("Chưa nhập đủ thông tin đơn hàng");
                return false;
            }
            return true;
        }

        private void gridView1_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            btnLuu.Enabled = false;
        }

        private void btnXemVaIn_Click(object sender, EventArgs e)
        {
            var r = new rpKhachHang();
            r.TenBaoCao = "thông tin đặt hàng";
            MyUtil.XemVaIn(gcCTDH,r, System.Drawing.Printing.PaperKind.A4, true);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MyUtil.exportFile(gcCTDH,"*.xls");
        }
    }
}