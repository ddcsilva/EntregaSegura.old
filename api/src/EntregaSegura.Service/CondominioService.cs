using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service;

public sealed class CondominioService : ICondominioService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public CondominioService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<CondominioDTO> ObterCondominios(bool rastrearAlteracoes)
    {
        var condominios = _repository.Condominio.ObterCondominios(rastrearAlteracoes);
        var condominiosDTO = _mapper.Map<IEnumerable<CondominioDTO>>(condominios);

        return condominiosDTO;
    }

    public CondominioDTO ObterCondominio(Guid id, bool rastrearAlteracoes)
    {
        var condominio = _repository.Condominio.ObterCondominio(id, rastrearAlteracoes);

        if (condominio == null)
            throw new EntregaSeguraNotFoundException(id);

        var condominioDTO = _mapper.Map<CondominioDTO>(condominio);

        return condominioDTO;
    }
}