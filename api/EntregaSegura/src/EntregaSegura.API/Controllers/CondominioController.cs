using AutoMapper;
using EntregaSegura.API.DTOs;
using EntregaSegura.Business.Interfaces;
using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Interfaces.Services;
using EntregaSegura.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaSegura.API.Controllers;

/// <summary>
/// Classe que representa o controller de condomínios
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CondominiosController : MainController
{
    private readonly ICondominioRepository _condominioRepository;
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ICondominioService _condominioService;
    private readonly IMapper _mapper;

    /// <summary>
    /// Construtor padrão que recebe as dependências
    /// </summary>
    public CondominiosController(ICondominioRepository condominioRepository,
                                 IEnderecoRepository enderecoRepository,
                                 ICondominioService condominioService,
                                 INotificador notificador,
                                 IMapper mapper) : base(notificador)
    {
        _condominioRepository = condominioRepository;
        _enderecoRepository = enderecoRepository;
        _condominioService = condominioService;
        _mapper = mapper;
    }

    /// <summary>
    /// Endpoint que retorna todos os condomínios
    /// </summary>
    /// <returns>Retonar uma lista de condomínios</returns>
    public async Task<ActionResult<IEnumerable<CondominioDTO>>> ObterTodos()
    {
        var condominios = await _condominioRepository.ObterTodos();

        return Ok(_mapper.Map<IEnumerable<CondominioDTO>>(condominios));
    }

    /// <summary>
    /// Endpoint que retorna um condomínio pelo id
    /// </summary>
    /// <param name="id">Id do condomínio</param>
    /// <returns>Retorna um condomínio</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> ObterPorId(Guid id)
    {
        var condominio = await ObterCondominio(id);

        if (condominio == null) return NotFound();

        return condominio;
    }

    /// <summary>
    /// Endpoint que Adiciona um condomínio
    /// </summary>
    /// <param name="condominioDTO">Dados do condomínio</param>
    /// <returns>Retorna o condomínio adicionado</returns>
    [HttpPost]
    public async Task<ActionResult<CondominioDTO>> Adicionar(CondominioDTO condominioDTO)
    {
        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _condominioService.Adicionar(_mapper.Map<Condominio>(condominioDTO));

        return CustomResponse(condominioDTO);
    }

    /// <summary>
    /// Endpoint que atualiza um condomínio
    /// </summary>
    /// <param name="id">Id do condomínio</param>
    /// <param name="condominioDTO">Dados do condomínio</param>
    /// <returns>Retorna o condomínio atualizado</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> Atualizar(Guid id, CondominioDTO condominioDTO)
    {
        if (id != condominioDTO.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(condominioDTO);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _condominioService.Atualizar(_mapper.Map<Condominio>(condominioDTO));

        return CustomResponse(condominioDTO);
    }

    /// <summary>
    /// Endpoint que exclui um condomínio
    /// </summary>
    /// <param name="id">Id do condomínio</param>
    /// <returns>Retorna o condomínio excluído</returns>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult<CondominioDTO>> Excluir(Guid id)
    {
        var condominio = await ObterCondominio(id);

        if (condominio == null) return NotFound();

        await _condominioService.Remover(id);

        return CustomResponse(condominio);
    }

    /// <summary>
    /// Endpoint que retorna um endereco pelo id
    /// </summary>
    /// <param name="id">Id do endereço</param>
    /// <returns>Retorna um endereço</returns>
    [HttpGet("endereco/{id:guid}")]
    public async Task<EnderecoDTO> ObterEnderecoPorId(Guid id)
    {
        return _mapper.Map<EnderecoDTO>(await _enderecoRepository.ObterPorId(id));
    }

    /// <summary>
    /// Endpoint que Atualiza um endereço
    /// </summary>
    /// <param name="id">Id do endereço</param>
    /// <param name="enderecoDTO">Dados do endereço</param>
    /// <returns>Retorna o endereço atualizado</returns>
    [HttpPut("endereco/{id:guid}")]
    public async Task<IActionResult> AtualizarEndereco(Guid id, EnderecoDTO enderecoDTO)
    {
        if (id != enderecoDTO.Id)
        {
            NotificarErro("O id informado não é o mesmo que foi passado na query");
            return CustomResponse(enderecoDTO);
        }

        if (!ModelState.IsValid) return CustomResponse(ModelState);

        await _condominioService.AtualizarEndereco(_mapper.Map<Endereco>(enderecoDTO));

        return CustomResponse(enderecoDTO);
    }

    /// <summary>
    /// Método que retorna um condomínio pelo id
    /// </summary>
    /// <param name="id">Id do condomínio</param>
    /// <returns>Retorna um condomínio</returns>
    private async Task<CondominioDTO> ObterCondominio(Guid id)
    {
        return _mapper.Map<CondominioDTO>(await _condominioRepository.ObterPorId(id));
    }
}