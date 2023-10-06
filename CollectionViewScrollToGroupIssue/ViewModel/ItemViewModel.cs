using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewScrollToGroupIssue.ViewModel
{
    internal class ItemViewModel : IItemViewModel
    {

        public ItemViewModel(int itemIndex)
        {
            ItemText = $"Item #{itemIndex}";
        }

        public string ItemText { get; }

    }
}
