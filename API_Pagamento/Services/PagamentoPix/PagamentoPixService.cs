using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using API_Pagamento.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace API_Pagamento.Services.PagamentoPix
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
            ObservableCollection<Models.PagamentoPix> listaPagamentos = await 
            _request.GetAsync<ObservableCollection<Models.PagamentoPix>>(apiUrlBase + urlComplementar, _token);

            return listaPagamentos;
        }

        public IActionResult ObterComprovante(string idPagamento)
        {
            var pagamento = _request.PagamentosPix.FirstOrDefault(p => p.id_pagamento == idPagamento);
            if (pagamento == null)
            {
                return NotFound();
            }
            var comprovante = JsonConvert.SerializeObject(pagamento);
            return Ok(comprovante);
        }

        public async Task<IActionResult> ObterTodos(string idPagamento)
        {
            var pagamento = await _request.PagamentosPix.ToListAsync();
            if (pagamento == null)
            {
                return NotFound();
            }
            return Ok(pagamento);
        }


    }
}
