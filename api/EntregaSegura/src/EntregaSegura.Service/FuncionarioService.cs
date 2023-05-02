using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service;

public sealed class FuncionarioService : IFuncionarioService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public FuncionarioService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<FuncionarioDTO> ObterTodosFuncionarios(bool rastrearAlteracoes)
    {
        try
        {
            var funcionarios = _repository.Funcionario.ObterTodosFuncionarios(rastrearAlteracoes);
            var funcionariosDTO = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);
            
            return funcionariosDTO;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas os funcionários: {ex.Message}");
            throw;
        }
    }
}