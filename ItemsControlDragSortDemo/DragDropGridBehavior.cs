using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace ItemsControlDragSortDemo
{

    public class DragDropGridBehavior : Behavior<Grid>
    {
        public bool IsDragMouseOver
        {
            get { return (bool)GetValue(IsDragMouseOverProperty); }
            set { SetValue(IsDragMouseOverProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDragMouseOver.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragMouseOverProperty =
            DependencyProperty.Register("IsDragMouseOver", typeof(bool), typeof(DragGrid), new PropertyMetadata(false));



        public Brush IsDragMouseOverBackground
        {
            get { return (Brush)GetValue(IsDragMouseOverBackgroundProperty); }
            set { SetValue(IsDragMouseOverBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsDragMouseOverBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragMouseOverBackgroundProperty =
            DependencyProperty.Register("IsDragMouseOverBackground", typeof(Brush), typeof(DragGrid), new PropertyMetadata(Brushes.Transparent));

        public Brush OldBrush { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();
            //附加行为后需要处理的事件
            OldBrush = AssociatedObject.Background;
            AssociatedObject.DragEnter += new DragEventHandler(OnDragEnter);
            AssociatedObject.DragOver += new DragEventHandler(OnDragOver);
            AssociatedObject.DragLeave += new DragEventHandler(OnDragLeave);
            AssociatedObject.Drop += new DragEventHandler(OnDrop);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            //解除的事件
            AssociatedObject.DragEnter -= new DragEventHandler(OnDragEnter);
            AssociatedObject.DragOver -= new DragEventHandler(OnDragOver);
            AssociatedObject.DragLeave -= new DragEventHandler(OnDragLeave);
            AssociatedObject.Drop -= new DragEventHandler(OnDrop);
        }


        protected void OnDragEnter(object sender, DragEventArgs e)
        {
            IsDragMouseOver = true;
            ChangeBackground();
        }

        protected void OnDragLeave(object sender, DragEventArgs e)
        {
            IsDragMouseOver = false;
            ChangeBackground();
        }

        protected void OnDragOver(object sender, DragEventArgs e)
        {
            IsDragMouseOver = true;
            ChangeBackground();
        }

        protected void OnDrop(object sender, DragEventArgs e)
        {
            IsDragMouseOver = false;
            ChangeBackground();
        }
        private void ChangeBackground()
        {
            if (IsDragMouseOver)
            {
                AssociatedObject.Background = IsDragMouseOverBackground;
            }
            else
            {
                AssociatedObject.Background = OldBrush;
            }
        }
    }
}
