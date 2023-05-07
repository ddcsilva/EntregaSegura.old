using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Exceptions;
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

    public IEnumerable<FuncionarioDTO> ObterFuncionarios(Guid condominioId, bool rastrearAlteracoes)
    {
        var condominio = _repository.Condominio.ObterCondominio(condominioId, rastrearAlteracoes);

        if (condominio == null)
            throw new EntregaSeguraNotFoundException(condominioId);

        var funcionarios = _repository.Funcionario.ObterFuncionarios(condominioId, rastrearAlteracoes);
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

    public FuncionarioDTO CriarFuncionarioParaCondominio(Guid condominioId, FuncionarioCriacaoDTO funcionarioCriacaoDTO, bool rastrearAlteracoes)
    {
        var condominio = _repository.Condominio.ObterCondominio(condominioId, rastrearAlteracoes);

        if (condominio == null)
            throw new EntregaSeguraNotFoundException(condominioId);

        var funcionarioEntity = _mapper.Map<Funcionario>(funcionarioCriacaoDTO);

        _repository.Funcionario.CriarFuncionarioParaCondominio(condominioId, funcionarioEntity);
        _repository.Salvar();

        var funcionarioDTO = _mapper.Map<FuncionarioDTO>(funcionarioEntity);

        return funcionarioDTO;
    }
}