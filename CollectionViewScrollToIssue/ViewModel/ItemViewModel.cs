using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewScrollToIssue.ViewModel
{
    internal class ItemViewModel
    {

        public ItemViewModel(int itemIndex)
        {
            ItemText = $"Item #{itemIndex}";
        }

        public string ItemText { get; }

    }
}
