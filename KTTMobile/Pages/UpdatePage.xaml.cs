using KTITSTimetableApp;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Net;

namespace KTTMobile.Pages;

public partial class UpdatePage : ContentPage
{
    public UpdatePage(Version ver)
    {
        InitializeComponent();
        BindingContext = ver;
        Test.Source = "https://www.youtube.com/embed/2bQ16v3riTk?showinfo=0&autoplay=1&disablekb=1&modestbranding=1&loop=1&playlist=2bQ16v3riTk&controls=0";
    }

    private void OnLoad(object sender, EventArgs e)
    {
        (sender as Button).IsEnabled = false;
        LoadGrid.IsVisible = true;
        WebClient web = new WebClient();
        web.DownloadProgressChanged += UpdateProgress;
        web.DownloadDataCompleted += InstallNewver;
        web.DownloadFileAsync(new Uri(Utils.GetYDLoadLink(@"https://disk.yandex.ee/i/cvkguOXkF-U68g")), Path.Combine(FileSystem.Current.AppDataDirectory, "last.mp4"));
    }

    private void InstallNewver(object sender, DownloadDataCompletedEventArgs e)
    {

    }

    private void UpdateProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        LoadPb.Progress = e.BytesReceived / e.TotalBytesToReceive;
        LoadLb.Text = $"Загружено {Math.Round(LoadPb.Progress * 100, 2)}% ({e.BytesReceived / 1024} из {e.TotalBytesToReceive / 1024} kB)";
    }
}