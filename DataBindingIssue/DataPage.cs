using DataBindingIssue.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBindingIssue
{
    public partial class DataPage : ContentPage
    {
        public DataPage()
        {
            InitializeComponent();
            BindingContext = new CollectionViewModel();
        }

        private void InitializeComponent()
        {
            var button = new Button
            {
                Text = "Refresh"
            };
            button.SetBinding(Button.CommandProperty, nameof(CollectionViewModel.RefreshCommand));
            var collectionView = new CollectionView
            {
                ItemTemplate = GetItemTemplate(),
            };
            collectionView.SetBinding(ItemsView.ItemsSourceProperty, nameof(CollectionViewModel.Items));
            Grid.SetRow(collectionView, 1);
            Content = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition(GridLength.Star),
                },
                RowDefinitions =
                {
                    new RowDefinition(GridLength.Auto),
                    new RowDefinition(GridLength.Star),
                },
                Children =
                {
                     button,
                     collectionView,
                }
            };
        }

        private DataTemplate GetItemTemplate()
        {
            return new DataTemplate(() =>
            {
                var checkBox = new CheckBox
                {
                    IsEnabled = false,
                };
                checkBox.SetBinding(CheckBox.IsCheckedProperty, nameof(ItemViewModel.IsChecked), BindingMode.OneWay);
                var layout = new VerticalStackLayout
                {
                    Children =
                    {
                        checkBox
                    }
                };
                layout.SetBinding(VerticalStackLayout.BackgroundColorProperty, nameof(ItemViewModel.Background));
                return layout;
            });
        }
    }
}
