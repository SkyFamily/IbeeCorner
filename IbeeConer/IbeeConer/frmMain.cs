using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.ColorPick.Picker;

namespace IbeeConer
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public Form CheckActiveForm(Type fType)
        {
            foreach (var f in this.MdiChildren)
            {
                if (f.GetType() == fType)
                    return f;
            }
            return null;
        }

        private void btnKH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmKhachHang));
            if (frm != null)
                frm.Activate();
            else
            {
                frmKhachHang frmLh = new frmKhachHang();
                frmLh.MdiParent = this;
                frmLh.Show();
            }
        }

        private void btnLSP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmLoaiSanPham));
            if (frm != null)
                frm.Activate();
            else
            {
                frmLoaiSanPham frmLh = new frmLoaiSanPham();
                frmLh.MdiParent = this;
                frmLh.Show();
            }
        }

        private void btnSP_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmSanPham));
            if (frm != null)
                frm.Activate();
            else
            {
                frmSanPham frmLh = new frmSanPham();
                frmLh.MdiParent = this;
                frmLh.Show();
            }
        }

        private void btnDatHang_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmDonHang));
            if (frm != null)
                frm.Activate();
            else
            {
                frmDonHang frmLh = new frmDonHang();
                frmLh.MdiParent = this;
                frmLh.Show();
            }
        }

        private void btnThongTinDH_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmThongTinDonHang));
            if (frm != null)
                frm.Activate();
            else
            {
                frmThongTinDonHang frmLh = new frmThongTinDonHang();
                frmLh.MdiParent = this;
                frmLh.Show();
            }
        }

        private void btnTinhTien_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = CheckActiveForm(typeof(frmTinhTien));
            if (frm != null)
                frm.Activate();
            else
            {
                frmTinhTien frmLh = new frmTinhTien();
                frmLh.MdiParent = this;
                frmLh.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            barStatus.Caption = DateTime.Today.ToString("dd-MM-yyyy");

            #region ramdomskin
            //System.Random r = new Random();

            //DevExpress.Skins.SkinContainerCollection skinCollection = DevExpress.Skins.SkinManager.Default.Skins;

            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(skinCollection[r.Next(0, skinCollection.Count)].SkinName);
            #endregion
        }
    }
}