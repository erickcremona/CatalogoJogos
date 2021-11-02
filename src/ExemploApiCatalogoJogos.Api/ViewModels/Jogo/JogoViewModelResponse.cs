using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Api.ViewModels.Jogo
{
    public class JogoViewModelResponse
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Nome { get; set; }
        public string Produtora { get; set; }
        public double Preco { get; set; }
    }
}
