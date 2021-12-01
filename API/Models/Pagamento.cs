using System;
using System.Collections.Generic;

namespace API.Models
{
    public class Pagamento
    {
        public Pagamento() => CriadoEm = DateTime.Now;
        public int PagamentoId { get; set; }
        public string Nome { get; set; }
        public DateTime CriadoEm { get; set; }
        public string Tipo { get; set; }
    }
}