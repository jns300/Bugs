using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridResizeIssue.Views
{
    internal class GridViewItem : Grid
    {
        public GridViewItem(int index)
        {
            Children.Add(new Label
            {
                Text = $"Grid Item #{index}",
                TextColor = Colors.AliceBlue
            });
        }

    }
}
