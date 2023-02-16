namespace GridLayoutBug
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void btnCase1_Clicked(object sender, EventArgs e)
        {
            gridBugCase1.IsVisible = true;
            gridBugCase2.IsVisible = false;
        }

        private void btnCase2_Clicked(object sender, EventArgs e)
        {
            gridBugCase1.IsVisible = false;
            gridBugCase2.IsVisible = true;
        }
    }
}