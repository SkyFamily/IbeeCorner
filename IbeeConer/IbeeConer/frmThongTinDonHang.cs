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
using IbeeConer.Utils;

namespace IbeeConer
{
    public partial class frmThongTinDonHang : DevExpress.XtraEditors.XtraForm
    {
        private DonHangBLL bll = new DonHangBLL();
        DonHang obj = new DonHang();
        public frmThongTinDonHang()
        {
            InitializeComponent();
        }
        void HienThi()
        {
            gcTTDH.DataSource = bll.GetData();
            //Tự động chỉnh các cột theo nội dung
            gridView1.BestFitColumns();
        }
        private void ThongTinDonHang_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                string id = gridView1.GetFocusedRowCellValue("MaDonHang").ToString();
                if (
                    XtraMessageBox.Show("Bạn có muốn sửa thông tin " + id + " không?", "Thông Báo",
                        MessageBoxButtons.YesNo) ==
                    DialogResult.Yes)
                {
                    obj.MaDonHang = gridView1.GetFocusedRowCellValue("MaDonHang").ToString();
                    obj.DotHang = gridView1.GetFocusedRowCellValue("DotHang").ToString();
                    obj.Thang = gridView1.GetFocusedRowCellValue("Thang").ToString();
                    obj.Nam = gridView1.GetFocusedRowCellValue("Nam").ToString();
                    obj.NgayLap = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayLap").ToString());
                    obj.TongGiaTri = gridView1.GetFocusedRowCellValue("TongGiaTri").ToString();
                    obj.TienLai = gridView1.GetFocusedRowCellValue("TienLai").ToString();
                   
                    bll.Update(obj);
                    XtraMessageBox.Show("Sửa thông tin thành công");
                    HienThi();
                }
                else
                {
                    HienThi();
                }
            }
            catch { }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.SelectedControl != gcTTDH)
                return;

            GridHitInfo hitInfo = gridView1.CalcHitInfo(e.ControlMousePosition);

            if (hitInfo.InRow == false)
                return;

            SuperToolTipSetupArgs toolTipArgs = new SuperToolTipSetupArgs();
            toolTipArgs.Title.Text = "Thông tin đơn hàng";

            //Get the data from this row
            DataRow drCurrentRow = gridView1.GetDataRow(hitInfo.RowHandle);
            if (drCurrentRow != null)
            {
                string ngay = drCurrentRow["NgayLap"].ToString();
                ngay = ngay.Remove(9);

                string BodyText = String.Format("Mã ĐH: {0}\r\nĐợt: {1}\r\nTháng: {2}\r\nNăm: {3}\r\nNgày lập: {4}\r\nTổng giá trị: {5}\r\nTiên lãi: {6} ",
                    drCurrentRow["MaDonHang"],
                    drCurrentRow["DotHang"],
                    drCurrentRow["Thang"],
                    drCurrentRow["Nam"],
                    ngay,
                    double.Parse(drCurrentRow["TongGiaTri"].ToString()),
                    double.Parse(drCurrentRow["TienLai"].ToString()));

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

        private void repositoryItemButtonEdit1_Click(object sender, EventArgs e)
        {
            string id = gridView1.GetFocusedRowCellValue("MaDonHang").ToString();
            if (XtraMessageBox.Show("Bạn có muốn xóa đơn hàng " + id + "?\nCác chi tiết của " + id + " cũng sẽ bị xóa?", "Cảnh Báo", MessageBoxButtons.YesNo) ==
                DialogResult.Yes)
            {
                try
                {
                    bll.DeleteCTDH(id);
                    bll.Delete(id);
                    XtraMessageBox.Show("Đã xóa thông tin thành công");
                    HienThi();
                }
                catch
                {
                    XtraMessageBox.Show("Xóa thông tin thất bại");
                }
            }
        }

        private void btnXemVaIn_Click(object sender, EventArgs e)
        {
            var r = new rpKhachHang();
            r.TenBaoCao = "Thông tin đơn hàng";
            MyUtil.XemVaIn(gcTTDH,r, System.Drawing.Printing.PaperKind.A4, true);
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            MyUtil.exportFile(gcTTDH,"*.xls");
        }
    }
}