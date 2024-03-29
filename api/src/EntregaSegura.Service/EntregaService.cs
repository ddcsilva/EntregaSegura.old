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

    public IEnumerable<EntregaDTO> ObterEntregas(Guid? condominioId, Guid? unidadeId, Guid? moradorId, Guid? funcionarioId, Guid? transportadoraId, bool rastrearAlteracoes)
    {
        var entregas = _repository.Entrega.ObterEntregas(condominioId, unidadeId, moradorId, funcionarioId, transportadoraId, rastrearAlteracoes);
        var entregasDTO = _mapper.Map<IEnumerable<EntregaDTO>>(entregas);

        return entregasDTO;
    }

    public EntregaDTO ObterEntregaPorFuncionario(Guid condominioId, Guid funcionarioId, Guid entregaId, bool rastrearAlteracoes)
    {
        var entrega = _repository.Entrega.ObterEntrega(condominioId, null, null, funcionarioId, null, entregaId, rastrearAlteracoes);

        if (entrega == null)
            throw new EntregaSeguraNotFoundException(entregaId);

        var entregaDTO = _mapper.Map<EntregaDTO>(entrega);

        return entregaDTO;
    }

    public EntregaDTO ObterEntregaPorMorador(Guid condominioId, Guid unidadeId, Guid moradorId, Guid entregaId, bool rastrearAlteracoes)
    {
        var entrega = _repository.Entrega.ObterEntrega(condominioId, unidadeId, moradorId, null, null, entregaId, rastrearAlteracoes);

        if (entrega == null)
            throw new EntregaSeguraNotFoundException(entregaId);

        var entregaDTO = _mapper.Map<EntregaDTO>(entrega);

        return entregaDTO;
    }

    public EntregaDTO ObterEntregaPorTransportadora(Guid transportadoraId, Guid entregaId, bool rastrearAlteracoes)
    {
        var entrega = _repository.Entrega.ObterEntrega(null, null, null, null, transportadoraId, entregaId, rastrearAlteracoes);

        if (entrega == null)
            throw new EntregaSeguraNotFoundException(entregaId);

        var entregaDTO = _mapper.Map<EntregaDTO>(entrega);

        return entregaDTO;
    }

    public EntregaDTO RegistrarEntrega(Guid condominioId, Guid funcionarioId, EntregaCriacaoDTO entregaCriacaoDTO, bool rastrearAlteracoes)
    {
        var condominio = _repository.Condominio.ObterCondominio(condominioId, rastrearAlteracoes);

        if (condominio == null)
            throw new EntregaSeguraNotFoundException(condominioId);

        var funcionario = _repository.Funcionario.ObterFuncionario(condominioId, funcionarioId, rastrearAlteracoes);

        if (funcionario == null)
            throw new EntregaSeguraNotFoundException(funcionarioId);

        var entregaEntity = _mapper.Map<Entrega>(entregaCriacaoDTO);

        _repository.Entrega.RegistrarEntrega(condominioId, funcionarioId, entregaEntity);
        _repository.Salvar();

        var entregaDTO = _mapper.Map<EntregaDTO>(entregaEntity);

        return entregaDTO;
    }
}