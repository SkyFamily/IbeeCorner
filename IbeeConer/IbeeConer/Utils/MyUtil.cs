using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;

namespace IbeeConer.Utils
{
    public static class MyUtil
    {
        public static string MaHoaMatKhau(string matKhau)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(matKhau));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        public static byte[] ImageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public static void KiemTraRangBuocTextBox(bool isNumber, KeyPressEventArgs e)
        {
            switch (isNumber)
            {
                case true:
                    if (!Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                        XtraMessageBox.Show("Chỉ được nhập số", "Lỗi");
                    }
                    break;
                case false:
                    if (Char.IsNumber(e.KeyChar) && !Char.IsControl(e.KeyChar))
                    {
                        e.Handled = true;
                        XtraMessageBox.Show("Chỉ được nhập ký tự", "Lỗi");
                    }
                    break;
                default:
                    break;
            }
        }

        public static void KiemTraKyTuDacBiet(KeyPressEventArgs e)
        {
            if (Char.IsWhiteSpace(e.KeyChar) && !Char.IsControl(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                e.Handled = true;
                XtraMessageBox.Show("Không thể nhập ký tự đặc biệt", "Lỗi");
            }
        }

        public static bool KiemTraThang(TextBox tb)
        {
            if (Convert.ToInt32(tb.Text) < 1 || (Convert.ToInt32(tb.Text) > 12))
            {
                return false;
            }
            return true;
        }

        private static DevExpress.XtraReports.UI.WinControlContainer CopyGridControl(DevExpress.XtraGrid.GridControl grid)
        {
            DevExpress.XtraReports.UI.WinControlContainer winContainer = new DevExpress.XtraReports.UI.WinControlContainer();

            winContainer.Location = new System.Drawing.Point(0, 0);
            winContainer.Size = new System.Drawing.Size(200, 100);

            winContainer.WinControl = grid;
            return winContainer;
        }
        public static void XemVaIn(this DevExpress.XtraGrid.GridControl grid, DevExpress.XtraReports.UI.XtraReport rpt, System.Drawing.Printing.PaperKind PageKind, bool Landscape)
        {
            #region Thiết kế trước khi in
            if (grid != null)
            {
                DevExpress.XtraGrid.Views.Grid.GridView view = grid.MainView as DevExpress.XtraGrid.Views.Grid.GridView;

                if (view != null)
                {
                    view.AppearancePrint.EvenRow.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.EvenRow.Options.UseFont = true;
                    view.AppearancePrint.FilterPanel.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.FilterPanel.Options.UseFont = true;
                    view.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black;
                    view.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.FooterPanel.Options.UseBorderColor = true;
                    view.AppearancePrint.FooterPanel.Options.UseFont = true;
                    view.AppearancePrint.GroupFooter.BorderColor = System.Drawing.Color.Black;
                    view.AppearancePrint.GroupFooter.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.GroupFooter.Options.UseBorderColor = true;
                    view.AppearancePrint.GroupFooter.Options.UseFont = true;
                    view.AppearancePrint.GroupRow.BorderColor = System.Drawing.Color.Black;
                    view.AppearancePrint.GroupRow.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
                    view.AppearancePrint.GroupRow.Options.UseBorderColor = true;
                    view.AppearancePrint.GroupRow.Options.UseFont = true;
                    view.AppearancePrint.HeaderPanel.BorderColor = System.Drawing.Color.Black;
                    view.AppearancePrint.HeaderPanel.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold);
                    view.AppearancePrint.HeaderPanel.Options.UseBorderColor = true;
                    view.AppearancePrint.HeaderPanel.Options.UseFont = true;
                    view.AppearancePrint.HeaderPanel.Options.UseTextOptions = true;
                    view.AppearancePrint.HeaderPanel.Options.UseBackColor = true;
                    view.AppearancePrint.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                    view.AppearancePrint.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    view.AppearancePrint.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                    view.AppearancePrint.FooterPanel.BorderColor = System.Drawing.Color.Black;
                    view.AppearancePrint.FooterPanel.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
                    view.AppearancePrint.FooterPanel.ForeColor = Color.Crimson;
                    view.AppearancePrint.FooterPanel.Options.UseBorderColor = true;
                    view.AppearancePrint.FooterPanel.Options.UseFont = true;
                    view.AppearancePrint.FooterPanel.Options.UseTextOptions = true;
                    view.AppearancePrint.FooterPanel.Options.UseBackColor = true;
                    view.AppearancePrint.FooterPanel.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
                    view.AppearancePrint.FooterPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    view.AppearancePrint.FooterPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;

                    view.AppearancePrint.Lines.BackColor = System.Drawing.Color.Black;
                    view.AppearancePrint.Lines.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.Lines.Options.UseBackColor = true;
                    view.AppearancePrint.Lines.Options.UseFont = true;
                    view.AppearancePrint.OddRow.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.OddRow.Options.UseFont = true;
                    view.AppearancePrint.Preview.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.Preview.Options.UseFont = true;
                    view.AppearancePrint.Row.BorderColor = System.Drawing.Color.Black;
                    view.AppearancePrint.Row.Font = new System.Drawing.Font("Times New Roman", 11F);
                    view.AppearancePrint.Row.Options.UseBorderColor = true;
                    view.AppearancePrint.Row.Options.UseFont = true;

                    view.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.MintCream;
                    view.OptionsPrint.EnableAppearanceEvenRow = true;
                }
            }
            #endregion

            rpt.PaperKind = PageKind;
            rpt.Landscape = Landscape;
            rpt.Bands[DevExpress.XtraReports.UI.BandKind.Detail].Controls.Add(CopyGridControl(grid));

            rpt.ShowPreview();
        }
        public static void exportFile(this DevExpress.XtraGrid.GridControl grid,string fType)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog
                {
                    CheckPathExists = true,
                    InitialDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments),
                    OverwritePrompt = true,
                    Title = "Xuất dữ liệu thành tập tin định dạng " + fType,
                    Filter = fType + "|" + fType
                };
                DialogResult dr = sfd.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK || dr == System.Windows.Forms.DialogResult.Yes)
                {
                    switch (fType)
                    {
                        case "*.html":
                            grid.ExportToHtml(sfd.FileName);
                            break;
                        case "*.pdf":
                            grid.ExportToPdf(sfd.FileName);
                            break;
                        case "*.txt":
                            grid.ExportToText(sfd.FileName);
                            break;
                        case "*.xls":
                            grid.ExportToXls(sfd.FileName);
                            break;
                        case "*.xlsx":
                            grid.ExportToXlsx(sfd.FileName);
                            break;
                        case "*.rtf":
                            grid.ExportToRtf(sfd.FileName);
                            break;
                        default:
                            break;
                    }
                    dr = MessageBox.Show("Xuất dữ liệu thành công! Bạn có muốn mở tập tin vừa xuất ra không?", "Xác nhận mở tập tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dr == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(sfd.FileName);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Lỗi xuất dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

