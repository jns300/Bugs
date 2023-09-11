using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewBindingBug.ViewModel
{
    internal class Item
    {
        private static Random rand = new(100);

        private static SortedSet<int> valueSet = new();

        public Item(int rowIndex)
        {
            RowIndex = rowIndex;
            ItemText = $"{RowIndex}. {GetUniqueValue()}";
        }
        public int RowIndex { get; }

        public String ItemText { get; }
        
        private int GetUniqueValue()
        {
            int value;
            do
            {
                value = rand.Next(1000, 50_000);

            } while (valueSet.Contains(value));
            valueSet.Add(value);
            return value;
        }
    }
}
