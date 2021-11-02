namespace ExemploApiCatalogoJogos.Domain.Entities
{
    public class Jogo : Entity
    {
        public string Nome { get; private set; }
        public string Produtora { get; private set; }
        public double Preco { get; private set; }

        public void AtualizarJogo(Jogo jogo)
        {
            Nome = jogo.Nome;
            Produtora = jogo.Produtora;
            Preco = jogo.Preco;
        }
    }
}
