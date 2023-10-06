using CollectionViewScrollToIssue.ViewModel;

namespace CollectionViewScrollToIssue
{
    public partial class MainPage : ContentPage
    {
        private readonly ItemListViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new ItemListViewModel();
            Instance = this;
        }

        public void RevealLastItem()
        {
            var item = viewModel.Items.Last();
            collectionView.ScrollTo(item, null, ScrollToPosition.MakeVisible, false);
        }

        public static MainPage Instance { get; private set; }
        private void Button_Clicked(object sender, EventArgs e)
        {
            RevealLastItem();
        }

    }
}