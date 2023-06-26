using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API_Pagamento.Models;

namespace API_Pagamento.Models
{
    public class PagamentoPix
    {
        private DateTime data_pagamento { get; set; }
        private decimal valor { get; set; }
        private string chave_pix { get; set; }
        private string id_pagamento { get; set; }
        private string nome_emissor { get; set; }
        private string nome_receptor { get; set; }

    }
}
