using KTITSTimetableApp;
using System.Reflection;

namespace KTTMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}