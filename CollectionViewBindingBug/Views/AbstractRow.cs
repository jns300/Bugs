using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewBindingBug.Views
{
    public abstract class AbstractRow : Grid
    {
        private bool isUpdated;

        public AbstractRow()
        {
            HeightRequest = 50;
        }

        protected void PerformUpdate()
        {
            ColumnDefinitions.Clear();
            RowDefinitions.Clear();
            if (!isUpdated)
            {
                isUpdated = true;
                Children.Clear();
                AddHorizontalLine(0);
                var cellView = CreateCellView(0);
                Grid.SetRow(cellView, 1);
                Children.Add(cellView);
            }
            FillRowDefinitions();
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

        private void FillRowDefinitions()
        {
            RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            RowDefinitions.Add(new RowDefinition(GridLength.Star));
            ColumnDefinitions.Add(new ColumnDefinition(GridLength.Star));
        }

        protected abstract View CreateCellView(int index);

    }
}
