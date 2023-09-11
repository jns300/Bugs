using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewBindingBug.Views
{
    public abstract class AbstractRow : Grid
    {
        private int cellCount;

        public AbstractRow()
        {
            HeightRequest = 50;
        }

        protected void PerformUpdate()
        {
            ColumnDefinitions.Clear();
            RowDefinitions.Clear();
            if (cellCount != CellCount)
            {
                cellCount = CellCount;
                Children.Clear();
                AddHorizontalLine(0);
                var cellView = CreateCellView(0);
                Grid.SetRow(cellView, 1);
                Children.Add(cellView);
            }
            FillRowDefinitions(CellCount);
        }

        private void AddHorizontalLine(int rowIndex)
        {
            BoxView topLine = new BoxView()
            {
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = 1.5,
                Color = Colors.Gray,
            };
            Grid.SetRow(topLine, rowIndex);
            Children.Add(topLine);
        }

        private void FillRowDefinitions(int count)
        {
            RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            RowDefinitions.Add(new RowDefinition(GridLength.Star));
            for (int i = 0; i < count; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
            }
        }

        protected virtual int CellCount { get; } = 1;
        protected abstract View CreateCellView(int index);

    }
}
