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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DTO;

namespace IbeeConer
{
    public partial class frmLoaiSanPham : DevExpress.XtraEditors.XtraForm
    {
        LoaiSanPham obj = new LoaiSanPham();
        LoaiSanPhamBLL bll = new LoaiSanPhamBLL();

        private int chieudaiId = 6;
        private string tablename = "LoaiSanPham";

        public frmLoaiSanPham()
        {
            InitializeComponent();
        }

        void KhoaDieuKhien()
        {
            txtTenLSP.Enabled = false;
            txtMoTa.Enabled = false;

            btnThem.Enabled = true;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        void MoDieuKhien()
        {
            txtTenLSP.Enabled = true;
            txtMoTa.Enabled = true;

            btnThem.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        void LamMoi()
        {
            txtMaLSP.Text = bll.LayIdTuDong("LSP", chieudaiId, tablename);
            txtTenLSP.Text = string.Empty;
            txtMoTa.Text = string.Empty;
        }

        void HienThi()
        {
            gcLoaiSP.DataSource = bll.GetData();
            gridView1.BestFitColumns();
        }

        private void frmLoaiSanPham_Load(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            HienThi();
            txtMaLSP.Text = bll.LayIdTuDong("LSP", chieudaiId, tablename);
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
                obj.MaLSP = txtMaLSP.Text;
                obj.TenLSP = txtTenLSP.Text;
                obj.MoTa = txtMoTa.Text;
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
        //SỦa thông tin trực tiếp trên GridControl
        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            string ma = gridView1.GetFocusedRowCellValue("MaLSP").ToString();
            if (XtraMessageBox.Show("Bạn có muốn sửa thông tin "+ma+" không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                obj.MaLSP = gridView1.GetFocusedRowCellValue("MaLSP").ToString();
                obj.TenLSP = gridView1.GetFocusedRowCellValue("TenLSP").ToString();
                obj.MoTa = gridView1.GetFocusedRowCellValue("MoTa").ToString();
                bll.Update(obj);
                XtraMessageBox.Show("Sửa thông tin thành công");
                HienThi();
            }
            else
            {
                HienThi();}
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            KhoaDieuKhien();
            try
            {
                txtMaLSP.Text = gridView1.GetFocusedRowCellValue("MaLSP").ToString();
                //gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[0]).ToString();
                txtTenLSP.Text = gridView1.GetFocusedRowCellValue("TenLSP").ToString();
                //gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[1]).ToString();
                txtMoTa.Text = gridView1.GetFocusedRowCellValue("MoTa").ToString();
                //gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns[2]).ToString();

            }
            catch
            {

            }}

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string id = gridView1.GetFocusedRowCellValue("MaLSP").ToString();
            if (XtraMessageBox.Show("Bạn có muốn xóa thông tin "+id+" không?", "Thông Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                try
                {
                    bll.Delete(id);
                    XtraMessageBox.Show("Đã xóa thông tin thành công");
                    HienThi();
                    txtMaLSP.Text = bll.LayIdTuDong("LSP", chieudaiId, tablename);
                }
                catch
                {
                    XtraMessageBox.Show("Xóa thông tin thất bại");
                }
            }
        }

        private bool KiemTraHopLeVaThongBao()
        {
            if (txtTenLSP.Text.Equals(string.Empty))
            {
                XtraMessageBox.Show("Vui lòng nhập tên loại sản phẩm");
                return false;
            }
            return true;
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gcLoaiSP)
                return;

            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.InRow == false)
                return;

            SuperToolTipSetupArgs toolTipArgs = new SuperToolTipSetupArgs();
            toolTipArgs.Title.Text = "Thông tin loại sản phẩm";

            //Get the data from this row
            DataRow drCurrentRow = gridView1.GetDataRow(hitInfo.RowHandle);
            if (drCurrentRow != null)
            {
                string BodyText = String.Format("Mã LSP: {0}\r\nTên LSP: {1}\r\nMô Tả: {2}",
                    drCurrentRow["MaLSP"],
                    drCurrentRow["TenLSP"],
                    drCurrentRow["MoTa"]);

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
    }
}