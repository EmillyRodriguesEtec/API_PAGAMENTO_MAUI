using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using API_Pagamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace API_Pagamento.Services
{
    public class PagamentoPixService : Request
    {
        private readonly Request _request;
        private const string apiUrlBase = "http://estacione.somee.com/API_Pagamento/Pagamento";

        private string _token;

        public PagamentoPixService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<ObservableCollection<PagamentoPix>> GetPagamentoPixAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.PagamentoPix> listaPagamento = await
            _request.GetAsync<ObservableCollection<Models.PagamentoPix>>(apiUrlBase + urlComplementar, _token);
            return listaPagamento;
        }
        public async Task<PagamentoPix> GetPagamentoPixAsync(int idPagamento)
        {
            string urlComplementar = string.Format("/{0}", idPagamento);
            var pagamento = await _request.GetAsync<Models.PagamentoPix>(apiUrlBase + urlComplementar, _token);
            return pagamento;
        }
        public async Task<int> PostPagamentoPixAsync(PagamentoPix p)
        {
            return await _request.PostReturnIntTokenAsync(apiUrlBase, p, _token);
        }
    }
}
