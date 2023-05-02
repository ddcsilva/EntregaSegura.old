using AutoMapper;
using EntregaSegura.Contracts;
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

    public IEnumerable<CondominioDTO> ObterTodosCondominios(bool rastrearAlteracoes)
    {
        var condominios = _repository.Condominio.ObterTodosCondominios(rastrearAlteracoes);
        var condominiosDTO = _mapper.Map<IEnumerable<CondominioDTO>>(condominios);

        return condominiosDTO;
    }
}