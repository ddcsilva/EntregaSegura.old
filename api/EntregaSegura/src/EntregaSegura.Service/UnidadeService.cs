using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;
using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service;

public sealed class UnidadeService : IUnidadeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public UnidadeService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<UnidadeDTO> ObterTodasUnidades(bool rastrearAlteracoes)
    {
        try
        {
            var unidades = _repository.Unidade.ObterTodasUnidades(rastrearAlteracoes);
            var unidadesDTO = _mapper.Map<IEnumerable<UnidadeDTO>>(unidades);

            return unidadesDTO;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas as unidades: {ex.Message}");
            throw;
        }
    }
}