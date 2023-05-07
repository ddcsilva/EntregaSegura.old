using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service;

public sealed class MoradorService : IMoradorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public MoradorService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<MoradorDTO> ObterMoradores(Guid condominioId, Guid unidadeId, bool rastrearAlteracoes)
    {
        var moradores = _repository.Morador.ObterMoradores(condominioId, unidadeId, rastrearAlteracoes);
        var moradoresDTO = _mapper.Map<IEnumerable<MoradorDTO>>(moradores);

        return moradoresDTO;
    }

    public MoradorDTO ObterMorador(Guid condominioId, Guid unidadeId, Guid moradorId, bool rastrearAlteracoes)
    {
        var morador = _repository.Morador.ObterMorador(condominioId, unidadeId, moradorId, rastrearAlteracoes);

        if (morador == null)
            throw new EntregaSeguraNotFoundException(moradorId);

        var moradorDTO = _mapper.Map<MoradorDTO>(morador);

        return moradorDTO;
    }

    public MoradorDTO CriarMoradorParaUnidade(Guid condominioId, Guid unidadeId, MoradorCriacaoDTO moradorCriacaoDTO, bool rastrearAlteracoes)
    {
        var condominio = _repository.Condominio.ObterCondominio(condominioId, rastrearAlteracoes);

        if (condominio == null)
            throw new EntregaSeguraNotFoundException(condominioId);

        var unidade = _repository.Unidade.ObterUnidade(condominioId, unidadeId, rastrearAlteracoes);

        if (unidade == null)
            throw new EntregaSeguraNotFoundException(unidadeId);

        var moradorEntity = _mapper.Map<Morador>(moradorCriacaoDTO);

        _repository.Morador.CriarMoradorParaUnidade(condominioId, unidadeId, moradorEntity);
        _repository.Salvar();

        var moradorDTO = _mapper.Map<MoradorDTO>(moradorEntity);

        return moradorDTO;
    }
}