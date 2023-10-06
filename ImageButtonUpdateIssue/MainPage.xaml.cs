using ImageButtonUpdateIssue.Views;
using System.Diagnostics;

namespace ImageButtonUpdateIssue
{
    public partial class MainPage : ContentPage
    {

        private CustomImageButton[] images;

        public MainPage()
        {
            InitializeComponent();
            images = new[] { image1, image2, image3, image4 };
            UpdateImages();
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            UpdateImages();
        }

        private void UpdateImages()
        {
            foreach (var item in images)
            {
                item.UpdateImage();
            }
        }
    }
}