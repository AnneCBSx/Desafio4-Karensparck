using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Application.Models.DevolucoesEmAtraso
{
    public class DevolucoesEmAtrasoResponse
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int DiasEmAtraso { get; set; }
        public decimal ValorMulta { get; set; }
    }
}
