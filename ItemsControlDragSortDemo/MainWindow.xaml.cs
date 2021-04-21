﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ItemsControlDragSortDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindowViewModel ViewModel { get => this.DataContext as MainWindowViewModel; }


        private void LBoxSort_OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                e.GetDragItem(sender, out object from);
                DragDrop.DoDragDrop(LBoxSort, from, DragDropEffects.Move);
            }
        }

        private void LBoxSort_Drop_Prev(object sender, DragEventArgs e)
        {
            var success = e.GetDropItem(sender, out object from, out object to);
            if (success)
            {
                ViewModel.ChangeIetmIndex(from, to, 0);
            }
        }

        private void LBoxSort_Drop_Next(object sender, DragEventArgs e)
        {
            var success = e.GetDropItem(sender, out object from, out object to);
            if (success)
            {
                ViewModel.ChangeIetmIndex(from, to, 1);
            }
        }

        private void LBoxSort_Move_Prev(object sender, MouseButtonEventArgs e)
        {
            var control = sender as FrameworkElement;
            var dc = control.DataContext;
            ViewModel.ChangeIetmIndex(dc, -1);
        }

        private void LBoxSort_Move_Next(object sender, MouseButtonEventArgs e)
        {
            var control = sender as FrameworkElement;
            var dc = control.DataContext;
            ViewModel.ChangeIetmIndex(dc, 1);
        }
    }

    public class DragMouseoverDp : DependencyObject
    {



        public static bool GetIsDragMouseMove(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsDragMouseMoveProperty);
        }

        public static void SetIsDragMouseMove(DependencyObject obj, bool value)
        {
            obj.SetValue(IsDragMouseMoveProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsDragMouseMove.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsDragMouseMoveProperty =
            DependencyProperty.RegisterAttached("IsDragMouseMove", typeof(bool), typeof(DragMouseoverDp), new PropertyMetadata(false));



    }

}