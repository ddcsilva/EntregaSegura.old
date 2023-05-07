using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
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

    public IEnumerable<FuncionarioDTO> ObterFuncionarios(bool rastrearAlteracoes)
    {
        var funcionarios = _repository.Funcionario.ObterFuncionarios(rastrearAlteracoes);
        var funcionariosDTO = _mapper.Map<IEnumerable<FuncionarioDTO>>(funcionarios);

        return funcionariosDTO;
    }

    public FuncionarioDTO ObterFuncionario(Guid condominioId, Guid funcionarioId, bool rastrearAlteracoes)
    {
        var condominio = _repository.Condominio.ObterCondominio(condominioId, rastrearAlteracoes);

        if (condominio == null)
            throw new EntregaSeguraNotFoundException(condominioId);

        var funcionario = _repository.Funcionario.ObterFuncionario(condominioId, funcionarioId, rastrearAlteracoes);

        if (funcionario == null)
            throw new EntregaSeguraNotFoundException(funcionarioId);

        var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionario);

        return funcionarioDTO;
    }
}