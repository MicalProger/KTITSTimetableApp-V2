using KTITSTimetableApp;
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading.Tasks;

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
    public static bool install(Context con, string filePath)
    {
        try
        {
            if (string.IsNullOrEmpty.IsEmpty(filePath))
                return false;
            File file = new File(filePath);
            if (file.Exists())
            {
                return false;
            }
            Intent intent = new Intent(Intent.ActionView);
            intent.SetFlags(ActivityFlags.NewTask);
            if (Build.VERSION.SdkInt >= Build.VERSION_CODES.N)
            {
                intent.AddFlags(ActivityFlags.GrantReadUriPermission);//add read and write permissions
            }
            intent.SetDataAndType(GetPathUri(con, filePath), "application/vnd.android.package-archive");
            con.StartActivity(intent);
        }
        catch (Exception e)
        {
            e.PrintStackTrace();
            Toast.MakeText(con, "Installation failed. Please download again", ToastLength.Short).Show();
            return false;
        }
        catch (Error error)
        {
            error.PrintStackTrace();
            Toast.MakeText(con, "Installation failed. Please download again", ToastLength.Short).Show();
            return false;
        }
        return true;
    }


    public static Android.Net.Uri GetPathUri(Context context, string filePath)
    {
        Android.Net.Net.Uri uri;
        if (Build.VERSION.SdkInt >= Build.VERSION_CODES.N)
        {
            string packageName = context.PackageName;
            uri = FileProvider.GetUriForFile(context, packageName + ".fileProvider", new File(filePath));
        }
        else
        {
            uri = Android.Net.Uri.FromFile(new File(filePath));
        }
        return uri;
    }
    private void UpdateProgress(object sender, DownloadProgressChangedEventArgs e)
    {
        LoadPb.Progress = e.BytesReceived / e.TotalBytesToReceive;
        LoadLb.Text = $"Загружено {Math.Round(LoadPb.Progress * 100, 2)}% ({e.BytesReceived / 1024} из {e.TotalBytesToReceive / 1024} kB)";
    }
}