using Android.App;
using Android.Content.PM;
using Android.OS;

namespace ImageButtonUpdateIssue
{
    [Activity(Theme = "@style/AppTheme.Splash", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}