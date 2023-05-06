using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
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
}