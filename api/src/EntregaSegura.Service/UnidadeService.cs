using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service;

public sealed class UnidadeService : IUnidadeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public UnidadeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<UnidadeDTO> ObterUnidades(bool rastrearAlteracoes)
    {
        var unidades = _repository.Unidade.ObterUnidades(rastrearAlteracoes);
        var unidadesDTO = _mapper.Map<IEnumerable<UnidadeDTO>>(unidades);

        return unidadesDTO;
    }

    public UnidadeDTO ObterUnidade(Guid id, bool rastrearAlteracoes)
    {
        var unidade = _repository.Unidade.ObterUnidade(id, rastrearAlteracoes);

        if (unidade == null)
            throw new EntregaSeguraNotFoundException(id);

        var unidadeDTO = _mapper.Map<UnidadeDTO>(unidade);

        return unidadeDTO;
    }

    public UnidadeDTO CriarUnidadeParaCondominio(Guid condominioId, UnidadeCriacaoDTO unidadeCriacaoDTO, bool rastrearAlteracoes)
    {
        var unidade = _repository.Condominio.ObterCondominio(condominioId, rastrearAlteracoes);

        if (unidade == null)
            throw new EntregaSeguraNotFoundException(condominioId);

        var unidadeEntity = _mapper.Map<Unidade>(unidadeCriacaoDTO);

        _repository.Unidade.CriarUnidadeParaCondominio(condominioId, unidadeEntity);
        _repository.Salvar();

        var unidadeDTO = _mapper.Map<UnidadeDTO>(unidadeEntity);

        return unidadeDTO;
    }
}