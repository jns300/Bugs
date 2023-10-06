using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridAndScrollViewPresentationIssue.Views
{
    internal class PopupView : Grid
    {
        private Grid itemGrid;

        private Frame mainFrame;

        public PopupView()
        {
            BackgroundColor = Colors.Black;
            mainFrame = new Frame()
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = new Thickness(16),
                HasShadow = true,
                BackgroundColor = Colors.Blue
            };
            Children.Add(mainFrame);
            itemGrid = new Grid();
            Grid.SetRow(itemGrid, 1);
            mainFrame.Content = itemGrid;
            Populate();
        }
        private void Populate()
        {
            itemGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            itemGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));

            AdaptableGrid innerGrid = new AdaptableGrid();

            ScrollView scroll = new ScrollView();
            scroll.Content = innerGrid;
            itemGrid.Add(scroll);
            int rows = 10;
            int columns = 10;
            int index = 1;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    var item = new ContentViewItem(index++.ToString());
                    Grid.SetRow(item, i);
                    Grid.SetColumn(item, j);
                    innerGrid.Children.Add(item);
                    innerGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
                }
                innerGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            }
        }
    }
}
