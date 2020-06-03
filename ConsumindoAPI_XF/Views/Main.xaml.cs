using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ConsumindoAPI_XF.ViewModels;

namespace ConsumindoAPI_XF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Main : ContentPage
    {
        MainViewModel vm;
        public Main()
        {
            InitializeComponent();
            vm = (MainViewModel)BindingContext;
            vm.SetList();
        }
    }
}