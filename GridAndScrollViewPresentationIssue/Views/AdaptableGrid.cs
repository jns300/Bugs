using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridAndScrollViewPresentationIssue.Views
{
    internal class AdaptableGrid : Grid
    {
        private bool isSizeSet;

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > 0 && height > 0 && !isSizeSet)
            {
                isSizeSet = true;
                SetCellSizes();
                Dispatcher.Dispatch(InvalidateAll);
            }
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
        private void SetCellSizes()
        {
            double newButtonSize = 0d;
            ForEachItem(this, btn =>
            {
                var size = GetDesiredSize(btn);
                newButtonSize = Math.Max(newButtonSize, Math.Max(size.Width, size.Height));
            });
            if (newButtonSize > 0)
            {
                ForEachItem(this, btn =>
                {
                    btn.WidthRequest = newButtonSize;
                });
                UpdateGridLengths(newButtonSize);
            }
        }

        private Size GetDesiredSize(VisualElement view)
        {
            if (view.DesiredSize.Width <= 0)
            {
                view.Measure(double.PositiveInfinity, double.PositiveInfinity, MeasureFlags.IncludeMargins);
            }
            return view.DesiredSize;
        }

        private void UpdateGridLengths(double newSize)
        {
            UpdateGridLength(this, newSize);
        }

        private void ForEachItem(Layout layout, Action<ContentViewItem> buttonAction)
        {
            foreach (var child in layout.Children)
            {
                if (child is ContentViewItem btn)
                {
                    buttonAction(btn);
                }
                else if (child is Layout childLayout)
                {
                    ForEachItem(childLayout, buttonAction);
                }
            }

        }

        private void UpdateGridLength(Grid grid, double newSize)
        {
            foreach (var col in grid.ColumnDefinitions)
            {
                col.Width = new GridLength(newSize);
            }

        }
    }
}
