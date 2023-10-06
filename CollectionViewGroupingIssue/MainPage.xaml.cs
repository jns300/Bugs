using CollectionViewGroupingIssue.ViewModel;

namespace CollectionViewGroupingIssue
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ItemListViewModel();
        }
    }
}