﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewScrollToGroupIssue.ViewModel
{
    internal class ItemListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<IItemViewModel> items = new();

        public ItemListViewModel()
        {
            Populate();
        }

        private void Populate()
        {
            for (int i = 0; i < 100; i++)
            {
                items.Add(GetGroup(i, 3));
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
    }
}
