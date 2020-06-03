using ConsumindoAPI_XF.Models;
using System;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;

namespace ConsumindoAPI_XF.ViewModels
{
    public class HandleAlunoViewModel : BaseViewModel
    {

        private bool _ActInd_IsRunning;
        private bool _ExcluirAluno_IsEnabled;
        private string _TxtTitulo;
        private string _Nome;
        private string _Sobrenome;
        private string _Turma;
        private Aluno _Aluno;

        internal bool IsInsert;

        #region Props
        public bool ActInd_IsRunning
        {
            get => _ActInd_IsRunning;
            set => SetProperty(ref _ActInd_IsRunning, value, nameof(ActInd_IsRunning));
        }
        public bool ExcluirAluno_IsEnabled
        {
            get => _ExcluirAluno_IsEnabled;
            set => SetProperty(ref _ExcluirAluno_IsEnabled, value, nameof(ExcluirAluno_IsEnabled));
        }
        public string TxtTitulo
        {
            get => _TxtTitulo;
            set => SetProperty(ref _TxtTitulo, value, nameof(TxtTitulo));
        }
        public string Nome
        {
            get => _Nome;
            set => SetProperty(ref _Nome, value, nameof(Nome));
        }
        public string Sobrenome
        {
            get => _Sobrenome;
            set => SetProperty(ref _Sobrenome, value, nameof(Sobrenome));
        }
        public string Turma
        {
            get => _Turma;
            set => SetProperty(ref _Turma, value, nameof(Turma));
        }
        private Aluno AlunoForUpdate
        {
            get => _Aluno;
            set => SetProperty(ref _Aluno, value, nameof(AlunoForUpdate));
        }
        #endregion

        private void SetTextFromView()
        {
            TxtTitulo = IsInsert == true ? "INSERIR" : "ATUALIZAR";
        }
        public void SetAluno(Aluno aluno)
        {
            if(aluno != null)
            {
                AlunoForUpdate = aluno;
                Nome = aluno.Nome;
                Turma = aluno.Turma;
                Sobrenome = aluno.Sobrenome;
                IsInsert = false;
                ExcluirAluno_IsEnabled = true;
                SetTextFromView();
                InsertOrUpdateAluno_Command = new Command(Atualizar);
            }
            else
            {
                IsInsert = true;
                ExcluirAluno_IsEnabled = false;
                SetTextFromView();
                InsertOrUpdateAluno_Command = new Command(Inserir);
            }
        }

        private async void Inserir()
        {
            try
            {
                ActInd_IsRunning = true;
                bool res = await ConnectionAPI.Connection.InserirAluno(new Aluno(Nome, Sobrenome, Turma));
                if (res)
                {

                }
                else
                {
                    Debug.WriteLine("HandleAlunoViewModel: InserirAluno res = false");
                }
                ActInd_IsRunning = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("HandleAlunoViewModel: " + ex.Message);
            }
            finally
            {
                ActInd_IsRunning = false;
            }
        }
        private async void Atualizar()
        {
            try
            {
                ActInd_IsRunning = true;
                Aluno a = AlunoForUpdate;
                a.Nome = Nome;
                a.Sobrenome = Sobrenome;
                a.Turma = Turma;

                bool res = await ConnectionAPI.Connection.AtualizarAluno(a);
                if (res)
                {

                }
                else
                {
                    Debug.WriteLine("HandleAlunoViewModel: AtualizarAluno res = false");
                }
                ActInd_IsRunning = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("HandleAlunoViewModel: " + ex.Message);
            }
            finally
            {
                ActInd_IsRunning = false;
            }
        }
        private async void Excluir()
        {
            try
            {
                ActInd_IsRunning = true;
                bool res = await ConnectionAPI.Connection.DeletarAluno(AlunoForUpdate.Id);
                if (res)
                {

                }
                else
                {
                    Debug.WriteLine("HandleAlunoViewModel: DeletarAluno res = false");
                }
                ActInd_IsRunning = false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("HandleAlunoViewModel: " + ex.Message);
            }
            finally
            {
                ActInd_IsRunning = false;
            }
        }
        public ICommand ExcluirAluno_Command { get; private set; }
        public ICommand InsertOrUpdateAluno_Command { get; private set; }

        public HandleAlunoViewModel()
        {
            ExcluirAluno_Command =new Command(Excluir);
            InsertOrUpdateAluno_Command = new Command(Inserir);
        }
    }
}
