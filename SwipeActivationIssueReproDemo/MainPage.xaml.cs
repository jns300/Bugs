using SwipeActivationIssueReproDemo.ViewModel;

namespace SwipeActivationIssueReproDemo
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
