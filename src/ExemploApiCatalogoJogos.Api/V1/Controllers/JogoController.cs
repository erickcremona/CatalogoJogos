using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ExemploApiCatalogoJogos.Api.ControllerMain;
using ExemploApiCatalogoJogos.Api.Extensions;
using ExemploApiCatalogoJogos.Api.ViewModels.Jogo;
using ExemploApiCatalogoJogos.Application.Interfaces;
using ExemploApiCatalogoJogos.Domain.Entities;
using ExemploApiCatalogoJogos.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExemploApiCatalogoJogos.Api.V1.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class JogoController : MainController
    {
        private readonly IAppServiceJogo _appServiceJogo;
        private readonly IMapper _mapper;

        public JogoController(INotificador notificador,
                              IAppServiceJogo appServiceJogo, 
                              IMapper mapper) : base(notificador)
        {
            _appServiceJogo = appServiceJogo;
            _mapper = mapper;
        }

        [ClaimsAuthorize("Jogo", "ObterTodos")]
        [HttpGet]
        public async Task<IEnumerable<JogoViewModelResponse>> ObterTodos()
            => _mapper.Map<IEnumerable<JogoViewModelResponse>>(await _appServiceJogo.ObterTodosAsync());


        [ClaimsAuthorize("Jogo", "ObterPorId")]
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<JogoViewModelResponse>> ObterPorId(Guid id)
        {
            var jogo = await _appServiceJogo.ObterPorIdAsync(id);

            if (jogo == null) return NotFound();

            return _mapper.Map<JogoViewModelResponse>(jogo);
        }

        [ClaimsAuthorize("Jogo", "Adicionar")]
        [HttpPost]
        public async Task<ActionResult<JogoViewModelRequestAdd>> Adicionar(JogoViewModelRequestAdd jogoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _appServiceJogo.Adicionar(_mapper.Map<Jogo>(jogoViewModel));

            if (OperacaoValida()) return CustomResponse(jogoViewModel);

            return CustomResponse();
        }

        [ClaimsAuthorize("Jogo", "Alterar")]
        [HttpPut]
        public async Task<ActionResult<JogoViewModelRequestUpdate>> Alterar(JogoViewModelRequestUpdate jogoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _appServiceJogo.Alterar(_mapper.Map<Jogo>(jogoViewModel));

            if (OperacaoValida()) return CustomResponse(jogoViewModel);

            return CustomResponse();
        }

        [ClaimsAuthorize("Jogo", "Excluir")]
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Excluir(Guid id)
        {
            await _appServiceJogo.Excluir(id);

            return CustomResponse();
        }
    }
}
