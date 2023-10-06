using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridAndScrollViewPresentationIssue.Views
{
    internal class ContentViewItem : ContentView
    {
        public ContentViewItem(string label)
        {
            Initialize(label);
        }
        private void Initialize(string label)
        {
            Content = new Label
            {
                BackgroundColor = Colors.DarkCyan,
                Text = label,
                Margin = new Thickness(2, 0),
                HorizontalTextAlignment = TextAlignment.Center,
            };
            Margin = 2;
        }
    }
}
