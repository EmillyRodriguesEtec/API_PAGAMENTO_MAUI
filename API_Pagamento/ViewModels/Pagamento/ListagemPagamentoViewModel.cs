using API_Pagamento.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Pagamento.Models;
using System.Windows.Input;


namespace API_Pagamento.ViewModels.Pagamento
{
    public class ListagemPagamentoViewModel : BaseViewModel
    {
        private PagamentoPixService pService;
        private PagamentoPix pagamentoPixSelecionado;
        public ObservableCollection<PagamentoPix> Pagamento { get; set; }
        
        public ListagemPagamentoViewModel() 
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService= new PagamentoPixService(token);
            Pagamento = new ObservableCollection<PagamentoPix>();

            _ = ObterPagamento();

            NovoPagamento = new Command(async () => { await ExibirCadastroPagamento(); }); 
        }
        public ICommand NovoPagamento { get; }
        public PagamentoPix PagamentoPixSelecionado 
        {
            get { return pagamentoPixSelecionado; }
            set
            {
                if (value!= null)
                {
                    pagamentoPixSelecionado = value;

                    Shell.Current
                        .GoToAsync($"cadPagamentoView?pId={pagamentoPixSelecionado.Id_pagamento}");
                }
            }
        }

        public async Task ObterPagamento()
        {
            try
            {
                Pagamento = await pService.GetPagamentoPixAsync();
                OnPropertyChanged(nameof(Pagamento));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        public async Task ExibirCadastroPagamento()
        {
            try
            {
                await Shell.Current.GoToAsync("cadPagamentoView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

    }
}
