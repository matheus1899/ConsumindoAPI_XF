using ConsumindoAPI_XF.Services;
using ConsumindoAPI_XF.Views;
using Xamarin.Forms;

namespace ConsumindoAPI_XF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<INavigationService, NavigationService>();
            MainPage = new NavigationPage(new Main());
        }
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
    }
}
