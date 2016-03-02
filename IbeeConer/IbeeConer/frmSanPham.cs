using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DTO;
using IbeeConer.Utils;

namespace IbeeConer
{
    public partial class frmSanPham : DevExpress.XtraEditors.XtraForm
    {
        SanPham obj = new SanPham();
        SanPhamBLL bll = new SanPhamBLL();

        private int chieudaiId = 5;
        private string tablename = "SanPham";
        public frmSanPham()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtTenSP.Enabled = false;
            txtLink.Enabled = false;
            txtNDT.Enabled = false;
            leLSP.Enabled = false;
            txtSoLuong.Enabled = false;
            txtGhiChu.Enabled = false;
            pbSP.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        void MoDieuKhien()
        {
            txtTenSP.Enabled = true;
            txtLink.Enabled = true;
            txtNDT.Enabled = true;
            leLSP.Enabled = true;
            txtSoLuong.Enabled = true;
            txtGhiChu.Enabled = true;
            pbSP.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        void LamMoi()
        {
            txtMaSP.Text = bll.LayIdTuDong("SP", chieudaiId, tablename);
            txtTenSP.Text = string.Empty;
            txtLink.Text = string.Empty;
            txtNDT.Text = string.Empty;
            txtVND.Text = string.Empty;
            leLSP.EditValue = string.Empty;
            txtSoLuong.Text = string.Empty;
            pbSP.Image = pbSP.InitialImage;
            txtGhiChu.Text = string.Empty;
        }
        void HienThi()
        {
            gcSanPham.DataSource = bll.GetData();
            //Tự động chỉnh các cột theo nội dung
            gridView1.BestFitColumns();
        }
        private void frmSanPham_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
            txtMaSP.Text = bll.LayIdTuDong("SP", chieudaiId, tablename);

            leLSP.Properties.DataSource = bll.GetDataLoaiSanPham();
            leLSP.Properties.ValueMember = "MaLSP";
            leLSP.Properties.DisplayMember = "TenLSP";

            repositoryItemLookUpEdit1.DataSource = bll.GetDataLoaiSanPham();
            repositoryItemLookUpEdit1.ValueMember = "MaLSP";
            repositoryItemLookUpEdit1.DisplayMember = "TenLSP";}

        private void pbSP_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            fileDialog.Title = "Chọn icon";
            fileDialog.Filter = "icon files (*.icon, *.png)|*.icon; *.png; *.jpg";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                var image = Bitmap.FromFile(fileDialog.FileName);
                pbSP.Image = MyUtil.ResizeImage(image, 500, 400);
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            LamMoi();
        }
        private bool KiemTraHopLeVaThongBao()
        {
            if (txtTenSP.Text.Equals(string.Empty))
            {
                XtraMessageBox.Show("Vui lòng nhập tên sản phẩm");
                return false;
            }
            if (leLSP.Text.Equals(string.Empty))
            {
                XtraMessageBox.Show("Vui lòng chọn loại sản phẩm");
                return false;
            }
            return true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (KiemTraHopLeVaThongBao())
                {
                    obj.MaSP = txtMaSP.Text;
                    obj.TenSP = txtTenSP.Text;
                    obj.LinkSP = txtLink.Text;
                    obj.NhanDanTe = txtNDT.Text;
                    obj.VietNamDong = txtVND.Text;
                    //Lưu lookup edit theo id
                    obj.MaLSP = leLSP.EditValue.ToString();
                    obj.SoLuong = txtSoLuong.Text;
                    obj.HinhAnh = MyUtil.ImageToByteArray(pbSP.Image);
                    obj.GhiChu = txtGhiChu.Text;
                    bll.Insert(obj);
                    XtraMessageBox.Show("Thêm thông tin thành công");
                    HienThi();
                    LamMoi();
                    KhoaDieuKhien();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn hủy không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                LamMoi();
                KhoaDieuKhien();
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            /* try
             {
                 using (MemoryStream stream = new MemoryStream((byte[]) gridView1.GetFocusedRowCellValue("HinhAnh")))
                 {
                     pbSP.Image = new Bitmap(stream);
                     //pbSP.Image = Image.FromStream(stream);
                 }
             }
             catch{ }*/
            //Lấy qua mảng byte lưu trong database
            /* try
             {
                 string id = gridView1.GetFocusedRowCellValue("MaSP").ToString();
                 DataTable dt = bll.GetDataByID(id);
                 byte[] c = (byte[]) (dt.Rows[0]["HinhAnh"]);
                 pbSP.Image = MyUtil.ByteArrayToImage(c);
             }
             catch { }*/

            KhoaDieuKhien();
            pbSP.Enabled = true;
                //Lấy qua gridcontrol
                try
            {
                //Ép kiểu object sang byte[]
                byte[] b = (byte[])gridView1.GetFocusedRowCellValue("HinhAnh");
               // byte[] b = (byte[])gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["HinhAnh"]);
                pbSP.Image = MyUtil.ByteArrayToImage(b);

                txtMaSP.Text = gridView1.GetFocusedRowCellValue("MaSP").ToString();
                txtTenSP.Text = gridView1.GetFocusedRowCellValue("TenSP").ToString();
                txtLink.Text = gridView1.GetFocusedRowCellValue("LinkSP").ToString();
                //ép kiểu về double để hiển thị lên text box không bị số 0 ở đằng sau(có 2 cách)
                txtNDT.Text = Convert.ToDouble(gridView1.GetFocusedRowCellValue("NhanDanTe").ToString()).ToString();
                txtVND.Text = Double.Parse(gridView1.GetFocusedRowCellValue("VietNamDong").ToString()).ToString();
                txtSoLuong.Text = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("GhiChu").ToString();
                leLSP.EditValue = gridView1.GetFocusedRowCellValue("MaLSP").ToString();
            }
            catch {

            }
            
        }
        private void txtNDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyUtil.KiemTraRangBuocTextBox(true, e);
        }

        //tự động điền VNĐ
        private void txtNDT_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtNDT.Text.Equals(string.Empty))
                {
                    txtVND.Text = string.Empty;
                    return;
                }

                double d = Double.Parse(txtNDT.Text) * 3550;
                txtVND.Text = d.ToString();
            }
            catch
            { }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = gridView1.GetFocusedRowCellValue("MaSP").ToString();
            if (XtraMessageBox.Show("Bạn có muốn xóa thông tin " + id + " không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                try
                {
                    bll.Delete(id);
                    XtraMessageBox.Show("Đã xóa thông tin thành công");
                    HienThi();
                    txtMaSP.Text = bll.LayIdTuDong("SP", chieudaiId,tablename);
                }
                catch
                {
                    XtraMessageBox.Show("Xóa thông tin thất bại");
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string id = gridView1.GetFocusedRowCellValue("MaSP").ToString();
                if (
                    XtraMessageBox.Show("Bạn có muốn sửa thông tin " + id + " không?", "Thông Báo",
                        MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    obj.MaSP = gridView1.GetFocusedRowCellValue("MaSP").ToString();
                    obj.TenSP = gridView1.GetFocusedRowCellValue("TenSP").ToString();
                    obj.LinkSP = gridView1.GetFocusedRowCellValue("LinkSP").ToString();
                    obj.NhanDanTe = gridView1.GetFocusedRowCellValue("NhanDanTe").ToString();
                    obj.VietNamDong = gridView1.GetFocusedRowCellValue("VietNamDong").ToString();
                    obj.SoLuong = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
                    obj.GhiChu = gridView1.GetFocusedRowCellValue("GhiChu").ToString();
                    obj.MaLSP = gridView1.GetFocusedRowCellValue("MaLSP").ToString();
                    obj.HinhAnh = MyUtil.ImageToByteArray(pbSP.Image);
                    bll.Update(obj);
                    XtraMessageBox.Show("Sửa thông tin thành công");
                    HienThi();
                    LamMoi();
                }
                else
                {
                    HienThi();
                }
            }
            catch { }
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "NhanDanTe")
            {
                double nhandante = double.Parse(gridView1.GetFocusedRowCellValue("NhanDanTe").ToString());
                gridView1.SetRowCellValue(e.RowHandle, "VietNamDong",nhandante*3550);
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gcSanPham)
                return;

            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.InRow == false)
                return;

            SuperToolTipSetupArgs toolTipArgs = new SuperToolTipSetupArgs();
            toolTipArgs.Title.Text = "Thông tin sản phẩm";

            //Get the data from this row
            DataRow drCurrentRow = gridView1.GetDataRow(hitInfo.RowHandle);
            if (drCurrentRow != null)
            {
                string BodyText = String.Format("Mã SP: {0}\r\nTên SP: {1}\r\nNhân dân tệ: ¥{2}\r\nSố lượng: {3} ",
                    drCurrentRow["MaSP"],
                    drCurrentRow["TenSP"],
                    double.Parse(drCurrentRow["NhanDanTe"].ToString()),
                    drCurrentRow["SoLuong"]);

                toolTipArgs.Contents.Text = BodyText;
            }

            e.Info = new ToolTipControlInfo();
            //<bold>Updated by John (DevExpress Support):</bold>
            //e.Info.Object = hitInfo.Column;
            e.Info.Object = hitInfo.HitTest.ToString() + hitInfo.RowHandle.ToString(); //NewLine
                                                                                       //<bold>End Update</bold>
            e.Info.ToolTipType = ToolTipType.SuperTip;
            e.Info.SuperTip = new SuperToolTip();
            e.Info.SuperTip.Setup(toolTipArgs);
        }

        private void btnXemVaIn_Click(object sender, EventArgs e)
        {
            var r = new rpKhachHang();
            r.TenBaoCao = "Thông tin sản phẩm";
            MyUtil.XemVaIn(gcSanPham,r, System.Drawing.Printing.PaperKind.A4, true);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MyUtil.exportFile(gcSanPham, "*.xls");
        }
    }
}