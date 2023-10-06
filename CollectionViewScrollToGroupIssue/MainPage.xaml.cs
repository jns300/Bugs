using CollectionViewScrollToGroupIssue.ViewModel;

namespace CollectionViewScrollToGroupIssue
{
    public partial class MainPage : ContentPage
    {
        private readonly ItemListViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemListViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            RevealLastGroup();
        }

        public void RevealLastGroup()
        {
            var group = viewModel.Items.Last() as GroupViewModel;
            collectionView.ScrollTo(null, group, ScrollToPosition.MakeVisible, false);
        }
 
    }
}