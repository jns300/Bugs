using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewGroupingIssue.ViewModel
{
    internal class ItemListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<IItemViewModel> items = new();

        private bool isGrouped = true;

        private string errorMessage;

        public ItemListViewModel()
        {
            Populate();
        }

        private void Populate()
        {
            try
            {
                ErrorMessage = String.Empty;
                items.Clear();
                if (isGrouped)
                {
                    int groupIndex = 0;
                    items.Add(GetGroup(groupIndex++, 2));
                    items.Add(GetGroup(groupIndex++, 1));
                    items.Add(GetGroup(groupIndex++, 3));
                    items.Add(GetGroup(groupIndex++, 2));
                }
                else
                {
                    int itemIndex = 0;
                    items.Add(new ItemViewModel(itemIndex++));
                    items.Add(new ItemViewModel(itemIndex++));
                    items.Add(new ItemViewModel(itemIndex++));
                }
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Model creating error: {ex}";
            }
        }

        private IItemViewModel GetGroup(int groupIndex, int itemCount)
        {
            var group = new GroupViewModel(groupIndex);
            for (int i = 0; i < itemCount; i++)
            {
                group.Add(new ItemViewModel(i));
            }
            return group;
        }

        public ObservableCollection<IItemViewModel> Items => items;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ErrorMessage)));
            }
        }
        public bool IsGrouped
        {
            get => isGrouped;
            set
            {
                isGrouped = value;
                Populate();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsGrouped)));
            }
        }

    }
}
