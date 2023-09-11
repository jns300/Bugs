using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeActivationIssue.ViewModel
{
    internal class ItemList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Item> items = new ();

        private double activationThreshold;

        public ItemList()
        {
            items.Add(new Item());
            items.Add(new Item());
            items.Add(new Item());
        }
        public ObservableCollection<Item> Items => items;

        public double ActivationThreshold
        {
            get => activationThreshold; 
            set
            {
                activationThreshold = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ActivationThreshold)));
            }
        }

    }
}
