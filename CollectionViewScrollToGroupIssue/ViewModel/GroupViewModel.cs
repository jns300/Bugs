using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewScrollToGroupIssue.ViewModel
{
    internal class GroupViewModel : ObservableCollection<ItemViewModel>, IItemViewModel
    {
    
        public GroupViewModel(int groupIndex)
        {
            ItemText = $"Group #{groupIndex}";
        }

        public string ItemText { get; }
    }
}
