using ConsumindoAPI_XF.Models;
using System.Threading.Tasks;

namespace ConsumindoAPI_XF.Services
{
    public interface INavigationService
    {
        Task GoBack();
        Task NavigateTo_InsertAluno();
        Task NavigateTo_UpdateAluno(Aluno aluno);
    }
}
