using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewScrollToIssue.ViewModel
{
    internal class ItemListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ItemViewModel> items = new();

        private string errorMessage;

        public ItemListViewModel()
        {
            Populate();
        }

        private void Populate()
        {
            for (int i = 0; i < 100; i++)
            {
                items.Add(new ItemViewModel(i));
            }
        }
        public ObservableCollection<ItemViewModel> Items => items;

    }
}
