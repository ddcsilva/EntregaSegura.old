using AutoMapper;
using EntregaSegura.Contracts;
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

    public IEnumerable<MoradorDTO> ObterTodosMoradores(bool rastrearAlteracoes)
    {
        var moradores = _repository.Morador.ObterTodosMoradores(rastrearAlteracoes);
        var moradoresDTO = _mapper.Map<IEnumerable<MoradorDTO>>(moradores);

        return moradoresDTO;
    }
}