﻿using System;
using Xamarin.Forms;
using System.Diagnostics;
using System.Windows.Input;
using ConsumindoAPI_XF.Models;
using System.Collections.Generic;
using ConsumindoAPI_XF.Services;

namespace ConsumindoAPI_XF.ViewModels
{
    public class MainViewModel:BaseViewModel
    {
        private List<Aluno> _Alunos;
        private Aluno _Item_Selected;
        private bool _IsRefreshing;

        public ICommand ItemSelectedChanged_Command{ get; private set; }
        public ICommand RefreshList_Command{ get; private set; }
        public ICommand AdicionarAluno_Command { get; private set; }

        public List<Aluno> Alunos
        {
            get => _Alunos;
            set => SetProperty(ref _Alunos, value, nameof(Alunos));
        }
        public Aluno Item_Selected
        {
            get => _Item_Selected;
            set
            {
                SetProperty(ref _Item_Selected, value, nameof(Item_Selected));
            }
        }
        public bool IsRefreshing
        {
            get => _IsRefreshing;
            set => SetProperty(ref _IsRefreshing, value, nameof(IsRefreshing));
        }

        public async void SetList()
        {
            try
            {
                List<Aluno> alunos = await ConnectionAPI.Connection.PegarTodosAlunos();
                Alunos = alunos;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("SetList: " + ex.Message);
            }
        }
        private async void RefreshList()
        {
            try
            {
                IsRefreshing = true;
                List<Aluno> alunos = await ConnectionAPI.Connection.PegarTodosAlunos();
                Alunos = alunos;
                IsRefreshing = false;
            }
            catch (Exception ex)
            {
                IsRefreshing = false;
                Debug.WriteLine("RefreshList: " + ex.Message);
            }
        }
        private async void GoTo_UpdateAluno()
        {
            if (Item_Selected != null)
            {
                Aluno a= Item_Selected;
                await DependencyService.Get<INavigationService>().NavigateTo_UpdateAluno(a);
                Item_Selected = null;
            }
        }
        private async void GoTo_InsertAluno()
        {
            await DependencyService.Get<INavigationService>().NavigateTo_InsertAluno();
        }

        public MainViewModel()
        {
            RefreshList_Command = new Command(RefreshList);
            ItemSelectedChanged_Command = new Command(GoTo_UpdateAluno);
            AdicionarAluno_Command = new Command(GoTo_InsertAluno);
        }
    }
}
