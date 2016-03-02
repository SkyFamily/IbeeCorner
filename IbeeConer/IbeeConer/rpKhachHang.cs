using System;

namespace IbeeConer
{
    public partial class rpKhachHang : DevExpress.XtraScheduler.Reporting.XtraSchedulerReport
    {
        public rpKhachHang()
        {
            InitializeComponent();
        }

        public string TenBaoCao
        {
            get { return lbTitle.Text; }
            set { lbTitle.Text = value.ToUpper(); }
        }
    }
}
