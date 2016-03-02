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
using DevExpress.Utils.Paint;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using DTO;
using IbeeConer.Utils;

namespace IbeeConer
{
    public partial class frmTinhTien : DevExpress.XtraEditors.XtraForm
    {
        CTDHBLL bll = new CTDHBLL();
        CTDH obj = new CTDH();

        DonHangBLL bllDH = new DonHangBLL();
        public frmTinhTien()
        {
            InitializeComponent();
        }

        private void frmTinhTien_Load(object sender, EventArgs e)
        {
            gridView1.BestFitColumns();

            leDonHang.Properties.DataSource = bll.GetDataDonHang();
            leDonHang.Properties.DisplayMember = "MaDonHang";
            leDonHang.Properties.ValueMember = "MaDonHang";

            leKH.Properties.DataSource = bll.GetDataKhachHang();
            leKH.Properties.DisplayMember = "TenKH";
            leKH.Properties.ValueMember = "MaKH";

            repositoryItemLookUpEdit1.DataSource = bll.GetDataKhachHang();
            repositoryItemLookUpEdit1.DisplayMember = "MaKH";
            repositoryItemLookUpEdit1.ValueMember = "MaKH";

            repositoryItemLookUpEdit2.DataSource = bll.GetDataSanPham();
            repositoryItemLookUpEdit2.DisplayMember = "TenSP";
            repositoryItemLookUpEdit2.ValueMember = "MaSP";

            leKH.Enabled = false;
        }

        private void leDonHang_EditValueChanged(object sender, EventArgs e)
        {
            if (!leDonHang.EditValue.ToString().Equals(string.Empty))
            {
                DataTable dt = new DataTable();
                dt = bllDH.GetDataByID(leDonHang.EditValue.ToString());
                txtDotHang.Text = dt.Rows[0]["DotHang"].ToString();
                txtThang.Text = dt.Rows[0]["Thang"].ToString();

                leKH.Enabled = true;

                leKH.EditValue = string.Empty;
                gcTinhTien.DataSource = null;
            }
            
        }

        private void leKH_EditValueChanged(object sender, EventArgs e)
        {
            if (!leKH.EditValue.ToString().Equals(string.Empty))
            {
                try
                {
                    gcTinhTien.DataSource = bll.GetDataByMaDH_MaKH(leDonHang.EditValue.ToString(), leKH.EditValue.ToString());

                }
                catch (Exception)
                {
                }
            }
        }
        private void btnXemVaIn_Click(object sender, EventArgs e)
        {
            var r = new rpKhachHang();
            r.TenBaoCao = "THÔNG TIN MUA HÀNG";
            MyUtil.XemVaIn(gcTinhTien,r, System.Drawing.Printing.PaperKind.A4, true);
        }
    }
}