using CollectionViewBindingBug.ViewModel;

namespace CollectionViewBindingBug
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