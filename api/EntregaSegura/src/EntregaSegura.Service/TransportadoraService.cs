using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service;

public sealed class TransportadoraService : ITransportadoraService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public TransportadoraService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<TransportadoraDTO> ObterTodasTransportadoras(bool rastrearAlteracoes)
    {
        var transportadoras = _repository.Transportadora.ObterTodasTransportadoras(rastrearAlteracoes);
        var transportadoraDTO = _mapper.Map<IEnumerable<TransportadoraDTO>>(transportadoras);

        return transportadoraDTO;
    }

    public TransportadoraDTO ObterTransportadoraPorId(Guid transportadoraId, bool rastrearAlteracoes)
    {
        var transportadora = _repository.Transportadora.ObterTransportadoraPorId(transportadoraId, rastrearAlteracoes);
        var transportadoraDTO = _mapper.Map<TransportadoraDTO>(transportadora);

        return transportadoraDTO;
    }
}