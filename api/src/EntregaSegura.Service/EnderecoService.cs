using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class EnderecoService : IEnderecoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public EnderecoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }
}