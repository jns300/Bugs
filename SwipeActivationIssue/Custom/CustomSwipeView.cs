using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwipeActivationIssue.Custom
{
    public class CustomSwipeView : SwipeView
    {
        public static readonly BindableProperty ActivationThresholdProperty =
            BindableProperty.Create(nameof(ActivationThreshold), typeof(double), typeof(CustomSwipeView), default(double));

        public double ActivationThreshold
        {
            get { return (double)GetValue(ActivationThresholdProperty); }
            set { SetValue(ActivationThresholdProperty, value); }
        }
    }
}
