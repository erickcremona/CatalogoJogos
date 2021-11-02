using ExemploApiCatalogoJogos.Application.Interfaces;
using ExemploApiCatalogoJogos.Domain.Entities;
using ExemploApiCatalogoJogos.Domain.Interfaces;
using ExemploApiCatalogoJogos.Domain.Interfaces.Repository;
using ExemploApiCatalogoJogos.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExemploApiCatalogoJogos.Application.Services
{
    public class AppServiceJogo : IAppServiceJogo
    {
        private readonly IServiceJogo _serviceJogo;
        private readonly IRepositoryJogo _repositoryJogo;
        private readonly INotificador _notificador;

        public AppServiceJogo(IServiceJogo serviceJogo,
                              IRepositoryJogo repositoryJogo,
                              INotificador notificador)
        {
            _serviceJogo = serviceJogo;
            _repositoryJogo = repositoryJogo;
            _notificador = notificador;
        }

        public async Task Adicionar(Jogo jogo)
        {
            if (_repositoryJogo.ObterPorExprecaoAsync(p => p.Nome == jogo.Nome && p.Produtora == jogo.Produtora).Result.Any())
                _serviceJogo.Notificar("Já existe um jogo cadastrado com o Nome e Produtora informados");

            if (_serviceJogo.Validar(jogo) && !_notificador.TemNotificacao())
            {
                _repositoryJogo.Adicionar(jogo);
                await _repositoryJogo.SaveChanges();
            }

            await _repositoryJogo.DisposeAsync();
        }

        public async Task Alterar(Jogo jogo)
        {
            var result = await _repositoryJogo.ObterPorIdAsync(jogo.Id);

            if (result == null)
                _serviceJogo.Notificar("Produto não encontrado");

            if (_repositoryJogo.ObterPorExprecaoAsync(p => p.Nome == jogo.Nome && p.Produtora == jogo.Produtora && p.Id != jogo.Id).Result.Any())
                _serviceJogo.Notificar("Já existe um jogo cadastrado com o Nome e Produtora informados");

            if (_serviceJogo.Validar(jogo) && !_notificador.TemNotificacao())
            {
                result.AtualizarJogo(jogo);

                _repositoryJogo.Alterar(result);
                await _repositoryJogo.SaveChanges();                
            }

            await _repositoryJogo.DisposeAsync();
        }

        public async Task Excluir(Guid id)
        {
            var jogo = await _repositoryJogo.ObterPorIdAsync(id);

            if (jogo == null)
                _serviceJogo.Notificar("Id do jogo fornecido não foi localizado no sistema");

            if (!_notificador.TemNotificacao())
            {
                _repositoryJogo.Excluir(jogo);
                await _repositoryJogo.SaveChanges();
            }

            await _repositoryJogo.DisposeAsync();
        }
               
        public async Task<IEnumerable<Jogo>> ObterPorExprecaoAsync(Expression<Func<Jogo, bool>> predicate)
        {
            return await _repositoryJogo.ObterPorExprecaoAsync(predicate);
        }

        public async Task<Jogo> ObterPorIdAsync(Guid id)
        {
            return await _repositoryJogo.ObterPorIdAsync(id);
        }

        public async Task<IEnumerable<Jogo>> ObterTodosAsync()
        {
            return await _repositoryJogo.ObterTodosAsync();
        }
    }
}
