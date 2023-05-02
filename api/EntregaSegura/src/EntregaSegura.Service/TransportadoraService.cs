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
        try
        {
            var transportadoras = _repository.Transportadora.ObterTodasTransportadoras(rastrearAlteracoes);
            var transportadoraDTO = _mapper.Map<IEnumerable<TransportadoraDTO>>(transportadoras);

            return transportadoraDTO;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas as transportadoras: {ex.Message}");
            throw;
        }
    }
}