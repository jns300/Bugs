using CollectionViewBindingBug.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CollectionViewBindingBug.Views
{
    internal class SampleRow : AbstractRow
    {
        public static readonly BindableProperty RowDataProperty =
            BindableProperty.CreateAttached(nameof(RowData), typeof(Item), typeof(SampleRow),
            null, BindingMode.OneWay, propertyChanged: OnRowDataChanged);

        public SampleRow()
        {
        }

        public Item RowData
        {
            get
            {
                return (Item)GetValue(RowDataProperty);
            }
            set
            {
                SetValue(RowDataProperty, value);
            }
        }

        private static void OnRowDataChanged(BindableObject view, object oldValue, object newValue)
        {
            var row = view as SampleRow;
            if (row == null)
            {
                return;
            }
            row.PerformUpdate();
        }

        protected override View CreateCellView(int index)
        {
            var stack = new HorizontalStackLayout
            {
                BackgroundColor = Colors.DarkBlue,
            };
            stack.Children.Add(new Label
            {
                Text = RowData?.ItemText,
                TextColor = Colors.AliceBlue,
                Margin = new Thickness(4, 2)
            });
            return stack;
        }
    }
}
