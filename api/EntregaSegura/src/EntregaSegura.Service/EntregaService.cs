using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
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
        var entregas = _repository.Entrega.ObterTodasEntregas(rastrearAlteracoes);
        var entregasDTO = _mapper.Map<IEnumerable<EntregaDTO>>(entregas);

        return entregasDTO;
    }

    public EntregaDTO ObterEntregaPorId(Guid id, bool rastrearAlteracoes)
    {
        var entrega = _repository.Entrega.ObterEntregaPorId(id, rastrearAlteracoes);

        if (entrega == null)
            throw new EntregaSeguraNotFoundException(id);

        var entregaDTO = _mapper.Map<EntregaDTO>(entrega);

        return entregaDTO;
    }
}