using System;
using System.Collections;
using System.Windows.Forms;
using System.Drawing;                   // Para Image
using System.Drawing.Imaging;           // Para trabajar con imágenes
using System.Drawing.Drawing2D;         // Para trabajar con Imágenes
using System.Runtime.InteropServices;   // Para usar API



namespace SOCIOS
{
    public class ListViewItemComparer : IComparer
    {
        private int column;
        public int Column
        {
            get { return column; }
            set { column = value; }
        }
        private bool numeric = false;
        public bool Numeric
        {
            get { return numeric; }
            set { numeric = value; }
        }
        private bool descending = false;
        public bool Descending
        {
            get { return descending; }
            set { descending = value; }
        }
        public ListViewItemComparer(int columnIndex)
        {
            Column = columnIndex;
        }
        public int Compare(object x, object y)
        {
            ListViewItem listX, listY;
            if (descending)
            {
                listY = (ListViewItem)x;
                listX = (ListViewItem)y;
            }
            else
            {
                listX = (ListViewItem)x;
                listY = (ListViewItem)y;
            }

            if (Numeric)
            {
                // Convert column text to numbers before comparing.
                // If the conversion fails, the value defaults to 0.
                decimal valX, valY;
                Decimal.TryParse(listX.SubItems[Column].Text, out valX);
                Decimal.TryParse(listY.SubItems[Column].Text, out valY);
                // Perform a numeric comparison.
                return Decimal.Compare(valX, valY);
            }
            else
            {
                // Perform an alphabetic comparison.
                return String.Compare(
                listX.SubItems[Column].Text, listY.SubItems[Column].Text);
            }
        }
    }

    public static class Fixes
    {
        /*public static void ColumnImageToRight(ListView view, int index)
        {
            if (!view.IsHandleCreated) throw new InvalidOperationException("ListView not yet created, wait...");
            if (index >= view.Columns.Count) throw new ArgumentOutOfRangeException("Column index out of range");
            IntPtr buf = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(LVCOLUMN)));
            LVCOLUMN lvc = new LVCOLUMN();
            lvc.mask = 0xffff;
            Marshal.StructureToPtr(lvc, buf, false);
            IntPtr retval = SendMessageW(view.Handle, LVM_GETCOLUMNW, (IntPtr)index, buf);
            lvc = (LVCOLUMN)Marshal.PtrToStructure(buf, typeof(LVCOLUMN));
            lvc.fmt |= 0x1000;
            lvc.pszText = Marshal.StringToHGlobalUni(view.Columns[index].Text);
            Marshal.StructureToPtr(lvc, buf, false);
            retval = SendMessageW(view.Handle, LVM_SETCOLUMNW, (IntPtr)index, buf);
            Marshal.FreeHGlobal(lvc.pszText);
            Marshal.FreeHGlobal(buf);
        }
        // P/Invoke declarations:
        private const int LVM_GETCOLUMNW = 0x1000 + 95;
        private const int LVM_SETCOLUMNW = 0x1000 + 96;
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private extern static IntPtr SendMessageW(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private class LVCOLUMN
        {
            public int mask;
            public int fmt;
            public int cx;
            public IntPtr pszText;
            public int cchTextMax;
            public int iSubItem;
            public int iImage;
            public int iOrder;
        }*/
    }
}
