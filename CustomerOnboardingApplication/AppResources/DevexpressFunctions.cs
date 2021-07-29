using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Net.Mail;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UI;
using DevExpress.XtraSplashScreen;
using System.Threading;
using System.Globalization;

namespace SaccoBook.AppResources
{
    class DevexpressFunctions
    {
         /*
        * Function Clears all fields in a form's Layoutcontrol
        */
        public static void ResetForm(DevExpress.XtraLayout.LayoutControl layout)
        {
            foreach (Control c in layout.Controls)
            {
                BaseEdit editor = c as BaseEdit;

                if (editor != null)
                {
                    editor.Text = null;
                }
            }
        }

         /*
         * Function paint's treelist nodes when selected to actibve theme accent color
         */
        public static void PaintTreeNodes(DevExpress.XtraTreeList.TreeList Tree, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            // Measure the CELL TEXT...
            SizeF sz = e.Graphics.MeasureString(e.CellText, e.Appearance.GetFont());

            // if the cell is Focused (i.e. SELECTED) then we have to handle the BACKGROUND drawing...
            if (e.Node.Selected)
            {
                // get the colors from the current skin...
                DevExpress.LookAndFeel.UserLookAndFeel lf = DevExpress.LookAndFeel.UserLookAndFeel.Default;
                DevExpress.Skins.Skin skin = DevExpress.Skins.CommonSkins.GetSkin(lf);
                Color backColor;
                if (e.Focused)
                    backColor = skin.TranslateColor(SystemColors.Highlight);
                else
                    backColor = skin.TranslateColor(SystemColors.InactiveCaption);

                // draw the node selection rectangle
                e.Graphics.FillRectangle(SystemBrushes.Window, e.Bounds);
                Rectangle rect = new Rectangle(e.EditViewInfo.ContentRect.Left, e.EditViewInfo.ContentRect.Top,
                                               Convert.ToInt32(sz.Width), Convert.ToInt32(sz.Height));
                e.Graphics.FillRectangle(new SolidBrush(backColor), e.Bounds);

                e.Graphics.DrawString(e.CellText, Tree.Font, new SolidBrush(backColor), Convert.ToInt32(sz.Width), Convert.ToInt32(sz.Height));
            }

            // Paint the cell as usual...
            Tree.Painter.DefaultPaintHelper.DrawNodeCell(e);

            // Draw my own little flag image to the side (image is 13x13 pixels)...
            //Rectangle r = new Rectangle(e.Bounds.Left + Convert.ToInt32(sz.Width) + 4, e.Bounds.Y + (e.Bounds.Height / 2) - (13 / 2), 13, 13);
            //e.Graphics.DrawImage(imgFlag, r);

            // tell the TreeList that we handled the painting...
            e.Handled = true;
        }
        /*
        * Function accepts string array and shows Pop up list on specified Text Edit
        */
        public static void ShowPopUpList(DevExpress.XtraEditors.TextEdit txt, string[] array)
        {
            AutoCompleteStringCollection colValues = new AutoCompleteStringCollection();
            colValues.AddRange(array);
            txt.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txt.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txt.MaskBox.AutoCompleteCustomSource = colValues;
        }
        /*
        * Function returns text in cell value of specified column of selected row on a Gridview
        */
        public static string GetItemrowClick(GridView gridview, string ColumnName)
        {
            string ColumnValue = "";
            try
            {
                if (gridview == null) return "";
                var rowHandle = gridview.FocusedRowHandle;
                // Get the value for the given column - convert to the type you're expecting
                var obj_sn = gridview.GetRowCellValue(rowHandle, ColumnName);

                if (obj_sn != null)

                    ColumnValue = obj_sn.ToString();
            }
            catch (Exception es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }
            return ColumnValue;
        }
        /*
        * Function returns text in cell value of specified column of selected row on a Gridview when row is changed
        */
        public static string GetItemFocusedRowChanged(DevExpress.XtraGrid.Views.Grid.GridView gridview, object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e, string ColumnName)
        {
            string ColumnValue = "";

            try
            {
                GridView view = (GridView)sender;
                if (e.FocusedRowHandle < 0)
                    view.FocusedRowHandle = e.PrevFocusedRowHandle == GridControl.InvalidRowHandle ? 0 : e.PrevFocusedRowHandle;

                if (!gridview.IsGroupRow(e.FocusedRowHandle))
                {
                    var rowHandle = gridview.FocusedRowHandle;
                    // Get the value for the given column - convert to the type you're expecting
                    var obj_sn = gridview.GetRowCellValue(rowHandle, ColumnName);

                    if (obj_sn != null)

                        ColumnValue = obj_sn.ToString();
                }
                else
                {
                    ColumnValue = null;
                }
            }
            catch (Exception es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }
            return ColumnValue;
        }
        /*
        * Function loads specified XtraReport by an animated splashscreen
        */
      

       /*
       * Function enables/disbales all fields in a form's Layoutcontrol
       */
        public static void EnableDisableForm(DevExpress.XtraLayout.LayoutControl layout, bool status)
        {
            foreach (Control c in layout.Controls)
            {
                BaseEdit editor = c as BaseEdit;

                if (editor != null)
                {
                    editor.ReadOnly = status;
                }
            }
        }
        public static void SetDateFormat(DevExpress.XtraEditors.DateEdit DateEdit)
        {
            string sysUIFormat = CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern;

            DateEdit.Properties.DisplayFormat.FormatString = sysUIFormat;
            DateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            DateEdit.Properties.EditFormat.FormatString = sysUIFormat;
            DateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            DateEdit.Properties.Mask.EditMask = sysUIFormat;
        }
    }
}
