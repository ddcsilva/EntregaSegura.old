using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service;

public sealed class EntregaService : IEntregaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public EntregaService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<EntregaDTO> ObterTodasEntregas(bool rastrearAlteracoes)
    {
        try
        {
            var entregas = _repository.Entrega.ObterTodasEntregas(rastrearAlteracoes);
            var entregasDTO = _mapper.Map<IEnumerable<EntregaDTO>>(entregas);
            
            return entregasDTO;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas as entregas: {ex.Message}");
            throw;
        }
    }
}