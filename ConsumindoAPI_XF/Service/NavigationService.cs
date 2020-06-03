using ConsumindoAPI_XF.Models;
using ConsumindoAPI_XF.Views;
using System.Threading.Tasks;

namespace ConsumindoAPI_XF.Services
{
    public class NavigationService : INavigationService
    {
        public Task GoBack()
        {
            return Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();
        }

        public Task NavigateTo_InsertAluno()
        {
            return Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new HandleAluno());
        }
        public Task NavigateTo_UpdateAluno(Aluno aluno)
        {
            return Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new HandleAluno(aluno));
        }
    }
}
