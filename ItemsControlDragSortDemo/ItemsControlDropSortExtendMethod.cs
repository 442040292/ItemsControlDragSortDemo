using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ItemsControlDragSortDemo
{
    internal static partial class ItemsControlDropSortExtendMethod
    {
        //根据子元素查找父元素
        public static T FindVisualParent<T>(DependencyObject obj) where T : class
        {
            while (obj != null)
            {
                if (obj is T)
                    return obj as T;

                obj = VisualTreeHelper.GetParent(obj);
            }
            return null;
        }

        public static bool GetDragItem(this MouseEventArgs e, object sender, out object data)
        {
            data = null;
            var pos = e.GetPosition((IInputElement)sender);
            HitTestResult result = VisualTreeHelper.HitTest((Visual)sender, pos);
            if (result == null)
            {
                return false;
            }
            var listBoxItem = ItemsControlDropSortExtendMethod.FindVisualParent<FrameworkElement>(result.VisualHit);
            if (listBoxItem == null)
            {
                return false;
            }
            if (listBoxItem.DataContext == null)
            {
                return false;
            }
            data = listBoxItem.DataContext;
            return true;
        }

        public static bool GetDropItem(this DragEventArgs e, object sender, out object from, out object to)
        {
            from = null;
            to = null;
            var pos = e.GetPosition((IInputElement)sender);
            var result = VisualTreeHelper.HitTest((Visual)sender, pos);
            if (result == null)
            {
                return false;
            }
            //查找元数据
            var sourcePerson = e.Data.GetData(e.Data.GetFormats()[0]);
            if (sourcePerson == null)
            {
                return false;
            }
            //查找目标数据
            var listBoxItem = ItemsControlDropSortExtendMethod.FindVisualParent<FrameworkElement>(result.VisualHit);
            if (listBoxItem == null)
            {
                return false;
            }
            from = sourcePerson;
            to = listBoxItem.DataContext;
            return true;
        }

        /// <summary>
        /// 移动列表元素 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemSource"></param>
        /// <param name="fromObj"></param>
        /// <param name="toObj"></param>
        /// <param name="pre"></param>
        public static void ChangeIetmIndex<T>(this Collection<T> itemSource, object fromObj, object toObj, int pre)
        {
            if (fromObj == null || toObj == null)
            {
                return;
            }

            if (!(fromObj is T) || !(toObj is T))
            {
                return;
            }

            if (fromObj.Equals(toObj))
            {
                return;
            }

            var fromItem = (T)fromObj;
            var toItem = (T)toObj;
            itemSource.Remove(fromItem);
            int indexTo = itemSource.IndexOf(toItem);
            if (indexTo == 0 && pre == 0)
            {
                itemSource.Insert(0, fromItem);
            }
            else if (indexTo == itemSource.Count - 1 && pre == 1)
            {
                itemSource.Add(fromItem);
            }
            else
            {
                itemSource.Insert(indexTo + pre, fromItem);
            }
        }

        /// <summary>
        /// 移动列表元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="itemSource"></param>
        /// <param name="itemObj"></param>
        /// <param name="pre"></param>
        public static void ChangeIetmIndex<T>(this Collection<T> itemSource, object itemObj, int pre)
        {
            if (itemObj == null)
            {
                return;
            }

            if (!(itemObj is T))
            {
                return;
            }

            var item = (T)itemObj;
            int indexItem = itemSource.IndexOf(item);
            if (indexItem == 0 && pre == -1)
            {
                //保持
            }
            else if (indexItem == itemSource.Count - 1 && pre == 1)
            {
                //保持
            }
            else
            {
                itemSource.Remove(item);
                itemSource.Insert(indexItem + pre, item);
            }
        }

    }
}
