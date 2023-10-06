
namespace GridResizeIssue.Views
{
    internal class PopupView : Grid
    {
        private Grid itemGrid;

        private readonly int[] childrenCounts = { 3, 5, 2 };

        private int clickCount;

        private Frame mainFrame;

        private bool useScroll = true;

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

            var button = new Button
            {
                Text = "Repopulate",
                HorizontalOptions = LayoutOptions.Center,
            };
            button.Clicked += Button_Clicked;
            itemGrid = new Grid();
            Grid.SetRow(itemGrid, 1);
            mainFrame.Content = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition(GridLength.Auto),
                    new RowDefinition(GridLength.Star)
                },
                Children =
                {
                    button,
                    itemGrid
                }
            };
            HandleClick();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            HandleClick();
            InvalidateAll();
        }

        private void HandleClick()
        {
            Repopulate();
            clickCount++;
        }

        private void InvalidateAll()
        {
            InvalidateMeasure();
            IElement current = this;
            while (current != null)
            {
                if (current is IView invalidate)
                {
                    invalidate.InvalidateMeasure();
                    invalidate.InvalidateArrange();
                }
                current = current.Parent;
            }
        }

        private void Repopulate()
        {
            itemGrid.Children.Clear();
            itemGrid.RowDefinitions.Clear();
            itemGrid.ColumnDefinitions.Clear();
            itemGrid.ColumnDefinitions.Add(new ColumnDefinition(GridLength.Auto));
            int count = childrenCounts[clickCount % childrenCounts.Length];
            for (int i = 0; i < count; i++)
            {
                var item = new GridViewItem(i);
                Grid.SetRow(item, i);
                itemGrid.Children.Add(item);
                itemGrid.RowDefinitions.Add(new RowDefinition(GridLength.Auto));
            }
        }
    }
}
