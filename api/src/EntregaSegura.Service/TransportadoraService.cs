using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
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

    public IEnumerable<TransportadoraDTO> ObterTransportadoras(bool rastrearAlteracoes)
    {
        var transportadoras = _repository.Transportadora.ObterTransportadoras(rastrearAlteracoes);
        var transportadoraDTO = _mapper.Map<IEnumerable<TransportadoraDTO>>(transportadoras);

        return transportadoraDTO;
    }

    public TransportadoraDTO ObterTransportadora(Guid id, bool rastrearAlteracoes)
    {
        var transportadora = _repository.Transportadora.ObterTransportadora(id, rastrearAlteracoes);

        if (transportadora == null)
            throw new EntregaSeguraNotFoundException(id);

        var transportadoraDTO = _mapper.Map<TransportadoraDTO>(transportadora);

        return transportadoraDTO;
    }
}