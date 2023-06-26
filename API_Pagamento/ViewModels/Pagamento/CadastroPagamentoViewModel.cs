using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using API_Pagamento.Models;
using API_Pagamento.Services;
using API_Pagamento.Services.PagamentoPix;
using System.Linq;


namespace API_Pagamento.ViewModels.Pagamento
{
    [QueryProperty("PagamentoPixId", "pId")]
    public class CadastroPagamentoViewModel : BaseViewModel
    {
        private PagamentoPixService pService;
        public ICommand SalvarCommand { get; }
        public ICommand CancelarCommand { get; set; }
        public CadastroPagamentoViewModel()
        {
            string token = Preferences.Get("UsuárioToken", string.Empty);
            pService = new PagamentoPixService(token);
            SalvarCommand = new Command(async () => { await SalvarPagamento(); });
            CancelarCommand = new Command(async => CancelarCadastro());
        }
        private async void CancelarCadastro()
        {
            await Shell.Current.GoToAsync("..");
        }

        private string PagamentoPixId;
        private DateTime data_pagamento;
        private decimal valor;
        private string chave_pix;
        private string id_pagamento;
        private string nome_emissor;
        private string nome_receptor;

        public string Id_pagamento
        {
            get => id_pagamento;
            set
            {
                id_pagamento = value;
                OnPropertyChanged();
            }
        }

        public string Chave_pix
        {
            get => chave_pix;
            set
            {
                chave_pix = value;
                OnPropertyChanged();
            }
        }

        public DateTime Data_pagamento
        {
            get => data_pagamento;
            set
            {
                data_pagamento = value;
                OnPropertyChanged();
            }
        }

        public decimal Valor
        {
            get => valor;
            set
            {
                valor = value;
                OnPropertyChanged();
            }
        }

        public string Nome_emissor
        {
            get => nome_emissor;
            set
            {
                nome_emissor = value;
                OnPropertyChanged();
            }
        }

        public string Nome_receptor
        {
            get => nome_receptor;
            set
            {
                nome_receptor = value;
                OnPropertyChanged();
            }
        }

        public string PagamentoPixId1
        {
            set
            {
                if (value != null)
                {
                    PagamentoPixId = Uri.UnescapeDataString(value);
                    CarregarPagamento();
                }
            }
        }

        public async Task SalvarPagamento()
        {
            try
            {
                PagamentoPix model = new PagamentoPix()
                {
                    Nome_emissor = this.nome_emissor,
                    Nome_receptor = this.nome_receptor,
                    Valor = this.valor,
                    Data_pagamento = this.data_pagamento,
                    Chave_pix = this.chave_pix,
                    Id_pagamento = this.id_pagamento
                };
                if (model.Id_pagamento == 0)
                    await pService.PostPagamentoPixAsync(model);

                await Application.Current.MainPage
                    .DisplayAlert("Mensagem", "Dados salvos com sucesso!", "Ok");
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                await Shell.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }
        public async void CarregarPagamento()
        {
            try
            {
                PagamentoPix p = await pService.GetPagamentoPixAsync(int.Parse(PagamentoPixId1));
                this.nome_emissor = p.Nome_emissor;
                this.valor = p.Valor;
                this.chave_pix = p.Chave_pix;
                this.id_pagamento = p.Id_pagamento;
                this.nome_receptor = p.Nome_receptor;
                this.data_pagamento = p.Data_pagamento;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }

        }
    }
}
    

