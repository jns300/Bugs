using SwipeActivationIssue.ViewModel;

namespace SwipeActivationIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ItemList();
        }
    }
}