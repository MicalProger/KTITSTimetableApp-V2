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

    }
}