using API_Pagamento.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Pagamento.Models;

namespace API_Pagamento.ViewModels.Pagamento
{
    public class ListagemPagamentoViewModel : BaseViewModel
    {
        private PagamentoPixService pService;
        public ObservableCollection<PagamentoPix> Pagamento { get; set; }
        
        public ListagemPagamentoViewModel() 
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            pService= new PagamentoPixService(token);
            Pagamento = new ObservableCollection<PagamentoPix>();

            _ = ObterPagamento();
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

    }
}
