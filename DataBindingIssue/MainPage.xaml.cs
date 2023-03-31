using DataBindingIssue.ViewModel;

namespace DataBindingIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CollectionViewModel();
        }

    }
}