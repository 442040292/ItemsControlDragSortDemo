using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsControlDragSortDemo
{
    public class MainWindowViewModel : ViewModelBase
    {

        public MainWindowViewModel()
        {

            List<YouItemViewModel> list = new List<YouItemViewModel>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(new YouItemViewModel { Name = "" + i });
            }

            YouItemSource = new ObservableCollection<YouItemViewModel>(list);
        }

        private ObservableCollection<YouItemViewModel> _YouItemSource;

        public ObservableCollection<YouItemViewModel> YouItemSource { get => _YouItemSource; set => Set(ref _YouItemSource, value); }


        public class YouItemViewModel
        {
            public string Name { get; set; }
        }

        #region 拖拽移动顺序

        public void ChangeIetmIndex(object from, object to, int pre)
        {
            YouItemSource.ChangeIetmIndex(from, to, pre);
        }

        public void ChangeIetmIndex(object item, int pre)
        {
            YouItemSource.ChangeIetmIndex(item, pre);
        }

        #endregion
    }
}
