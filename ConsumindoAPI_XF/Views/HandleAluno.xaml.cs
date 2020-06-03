using ConsumindoAPI_XF.Models;
using ConsumindoAPI_XF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ConsumindoAPI_XF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HandleAluno : ContentPage
    {
        private Aluno aluno;
        private HandleAlunoViewModel vm;
        public HandleAluno()
        {
            InitializeComponent();
            vm = (HandleAlunoViewModel)BindingContext;
            this.aluno = null;
        }
        public HandleAluno(Aluno aluno)
        {
            InitializeComponent();
            vm = (HandleAlunoViewModel)BindingContext;
            this.aluno = aluno;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.SetAluno(aluno);
        }
    }
}