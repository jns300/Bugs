using GridResizeIssue.Views;

namespace GridResizeIssue
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