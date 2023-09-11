using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewBindingBug.ViewModel
{
    internal class ItemList 
    {
        private ObservableCollection<Item> items = new();

        public ItemList()
        {
            int rowCount = 72;
            for (int i = 0; i < rowCount; i++)
            {
                items.Add(new Item(i));
            }
        }
        public ObservableCollection<Item> Items => items;

    }
}
