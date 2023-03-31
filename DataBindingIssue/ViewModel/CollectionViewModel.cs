using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataBindingIssue.ViewModel
{
    public class CollectionViewModel
    {
        private ObservableCollection<ItemViewModel> collection;


        public CollectionViewModel()
        {
            this.collection = new ObservableCollection<ItemViewModel>();
            RefreshCommand = new Command(Refresh);
            Populate();
        }

        private void Populate()
        {
            for (int i = 0; i < 256; i++)
            {
                collection.Add(new ItemViewModel()
                {
                    Label = $"Item {i}",
                    IsChecked = i == 0,
                });
            }
        }

        private void Refresh()
        {
            try
            {
                collection.Clear();
                Populate();
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.ToString());
            }
        }

        public ObservableCollection<ItemViewModel> Items => collection;

        public ICommand RefreshCommand { get; }
    }
}
