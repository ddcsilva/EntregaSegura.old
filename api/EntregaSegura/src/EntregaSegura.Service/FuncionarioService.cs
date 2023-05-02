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
        var funcionarios = _repository.Funcionario.ObterTodosFuncionarios(rastrearAlteracoes);
        var funcionariosDTO = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);

        return funcionariosDTO;
    }

    public FuncionarioDTO ObterFuncionarioPorId(Guid funcionarioId, bool rastrearAlteracoes)
    {
        var funcionario = _repository.Funcionario.ObterFuncionarioPorId(funcionarioId, rastrearAlteracoes);
        var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionario);

        return funcionarioDTO;
    }
}