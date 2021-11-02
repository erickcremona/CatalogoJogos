using System;

namespace ExemploApiCatalogoJogos.Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
