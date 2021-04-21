using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ItemsControlDragSortDemo
{
    public class DragGrid : Grid
    {

        public bool IsDragMouseOver
        {
            get { return (bool)GetValue(IsDragMouseOverProperty); }
            set { SetValue(IsDragMouseOverProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDragMouseOver.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragMouseOverProperty =
            DependencyProperty.Register("IsDragMouseOver", typeof(bool), typeof(DragGrid), new PropertyMetadata(false));


        protected override void OnDragEnter(DragEventArgs e)
        {
            base.OnDragEnter(e);
            IsDragMouseOver = true;
        }

        protected override void OnDragLeave(DragEventArgs e)
        {
            base.OnDragLeave(e);
            IsDragMouseOver = false;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            base.OnDragOver(e);
            IsDragMouseOver = true;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            IsDragMouseOver = false;
        }
    }
}
