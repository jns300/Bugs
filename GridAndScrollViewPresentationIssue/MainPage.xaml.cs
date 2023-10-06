using GridAndScrollViewPresentationIssue.Views;

namespace GridAndScrollViewPresentationIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            mainGrid.Children.Add(new PopupView());
        }
    }
}