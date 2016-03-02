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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraReports.UI;
using DTO;
using IbeeConer.Properties;
using IbeeConer.Utils;

namespace IbeeConer
{
    public partial class frmKhachHang : DevExpress.XtraEditors.XtraForm
    {
        KhachHang obj = new KhachHang();
        KhachHangBLL bll = new KhachHangBLL();

        private int chieudaiId = 5;
        private string tablename = "KhachHang";
        public frmKhachHang()
        {
            InitializeComponent();
        }
        void KhoaDieuKhien()
        {
            txtTenKH.Enabled = false;
            txtDchi.Enabled = false;
            txtDt.Enabled = false;
            txtGhiChu.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        void MoDieuKhien()
        {
            txtTenKH.Enabled = true;
            txtDchi.Enabled = true;
            txtDt.Enabled = true;
            txtGhiChu.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        void LamMoi()
        {
            txtMaKH.Text = bll.LayIdTuDong("KH", chieudaiId, tablename);
            txtTenKH.Text = string.Empty;
            txtDchi.Text = string.Empty;
            txtDt.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }
        void HienThi()
        {
            gcKhachHang.DataSource = bll.GetData();
            //Tự động chỉnh các cột theo nội dung
            gridView1.BestFitColumns();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
            txtMaKH.Text = bll.LayIdTuDong("KH", chieudaiId, tablename);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            MoDieuKhien();
            LamMoi();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (KiemTraHopLeVaThongBao())
            {
                obj.MaKH = txtMaKH.Text;
                obj.TenKH = txtTenKH.Text;
                obj.DienThoai = txtDt.Text;
                obj.DiaChi = txtDchi.Text;
                obj.GhiChu = txtGhiChu.Text;
                bll.Insert(obj);
                XtraMessageBox.Show("Thêm thông tin thành công");
                HienThi();
                LamMoi();
                KhoaDieuKhien();
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
            KhoaDieuKhien();
            try
            {
                txtMaKH.Text = gridView1.GetFocusedRowCellValue("MaKH").ToString();
                //gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtTenKH.Text = gridView1.GetFocusedRowCellValue("TenKH").ToString();
                //gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtDt.Text = gridView1.GetFocusedRowCellValue("DienThoai").ToString();
                //gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();
                txtDchi.Text = gridView1.GetFocusedRowCellValue("DiaChi").ToString();
                txtGhiChu.Text = gridView1.GetFocusedRowCellValue("GhiChu").ToString();
            }
            catch
            {

            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string id = gridView1.GetFocusedRowCellValue("MaKH").ToString();
            if (XtraMessageBox.Show("Bạn có muốn sửa thông tin " + id + " không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                obj.MaKH = gridView1.GetFocusedRowCellValue("MaKH").ToString();
                obj.TenKH = gridView1.GetFocusedRowCellValue("TenKH").ToString();
                obj.DienThoai = gridView1.GetFocusedRowCellValue("DienThoai").ToString();
                obj.DiaChi = gridView1.GetFocusedRowCellValue("DiaChi").ToString();
                obj.GhiChu = gridView1.GetFocusedRowCellValue("GhiChu").ToString();
                bll.Update(obj);
                XtraMessageBox.Show("Sửa thông tin thành công");
                HienThi();
            }
            else
            {
                HienThi();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = gridView1.GetFocusedRowCellValue("MaKH").ToString();
            if (XtraMessageBox.Show("Bạn có muốn xóa thông tin "+id+" không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                try
                {
                    bll.Delete(id);
                    XtraMessageBox.Show("Đã xóa thông tin thành công");
                    HienThi();
                    txtMaKH.Text = bll.LayIdTuDong("KH", chieudaiId, tablename);
                }
                catch
                {
                    XtraMessageBox.Show("Xóa thông tin thất bại");
                }
            }
        }
        private bool KiemTraHopLeVaThongBao()
        {
            if (txtTenKH.Text.Equals(string.Empty) )
            {
                XtraMessageBox.Show("Vui lòng nhập tên khách hàng");
                return false;
            }
            return true;
        }
        //chỉ được nhập số
        private void txtDt_KeyPress(object sender, KeyPressEventArgs e)
        {
            MyUtil.KiemTraRangBuocTextBox(true, e);
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gcKhachHang)
                return;

            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.InRow == false)
                return;

            SuperToolTipSetupArgs toolTipArgs = new SuperToolTipSetupArgs();
            toolTipArgs.Title.Text = "Thông tin khách";

            //Get the data from this row
            DataRow drCurrentRow = gridView1.GetDataRow(hitInfo.RowHandle);
            if (drCurrentRow != null)
            {
                string BodyText = String.Format("Mã KH: {0}\r\nTên KH: {1}\r\nĐiện Thoại: {2}\r\nĐịa Chỉ: {3} ",
                    drCurrentRow["MaKH"],
                    drCurrentRow["TenKH"],
                    drCurrentRow["DienThoai"],
                    drCurrentRow["DiaChi"]);

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
            r.TenBaoCao = "Thông tin khách hàng";
            MyUtil.XemVaIn(gcKhachHang,r, System.Drawing.Printing.PaperKind.A4, true);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MyUtil.exportFile(gcKhachHang, "*.xls");
        }
    }
}