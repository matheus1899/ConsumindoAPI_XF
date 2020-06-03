using System.Windows.Input;
using ConsumindoAPI_XF.Models;
using System.Collections.Generic;

namespace ConsumindoAPI_XF.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private List<Aluno> _Alunos;
        private Aluno _Item_Selected;
        private bool _IsRefreshing;

        public ICommand ItemSelectedChanged_Command{ get; private set; }
        public ICommand RefreshList_Command{ get; private set; }

        public List<Aluno> Alunos
        {
            get => _Alunos;
            set => SetProperty(ref _Alunos, value, nameof(Alunos));
        }
        public Aluno Item_Selected
        {
            get => _Item_Selected;
            set => SetProperty(ref _Item_Selected, value, nameof(Item_Selected));
        }
        public bool IsRefreshing
        {
            get => _IsRefreshing;
            set => SetProperty(ref _IsRefreshing, value, nameof(IsRefreshing));
        }
    }
}
