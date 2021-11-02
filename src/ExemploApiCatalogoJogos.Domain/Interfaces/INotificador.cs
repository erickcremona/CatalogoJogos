using ExemploApiCatalogoJogos.Domain.Notifications;
using System.Collections.Generic;

namespace ExemploApiCatalogoJogos.Domain.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
