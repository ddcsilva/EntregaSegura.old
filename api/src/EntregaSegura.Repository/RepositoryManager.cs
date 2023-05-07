using EntregaSegura.Contracts;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly EntregaSeguraContext _context;
    private readonly Lazy<ICondominioRepository> _condominioRepository;
    private readonly Lazy<IEntregaRepository> _entregaRepository;
    private readonly Lazy<IFuncionarioRepository> _funcionarioRepository;
    private readonly Lazy<IMoradorRepository> _moradorRepository;
    private readonly Lazy<ITransportadoraRepository> _transportadoraRepository;
    private readonly Lazy<IUnidadeRepository> _unidadeRepository;

    public RepositoryManager(EntregaSeguraContext context)
    {
        _context = context;
        _condominioRepository = new Lazy<ICondominioRepository>(() => new CondominioRepository(_context));
        _entregaRepository = new Lazy<IEntregaRepository>(() => new EntregaRepository(_context));
        _funcionarioRepository = new Lazy<IFuncionarioRepository>(() => new FuncionarioRepository(_context));
        _moradorRepository = new Lazy<IMoradorRepository>(() => new MoradorRepository(_context));
        _transportadoraRepository = new Lazy<ITransportadoraRepository>(() => new TransportadoraRepository(_context));
        _unidadeRepository = new Lazy<IUnidadeRepository>(() => new UnidadeRepository(_context));
    }

    public ICondominioRepository Condominio => _condominioRepository.Value;
    public IEntregaRepository Entrega => _entregaRepository.Value;
    public IFuncionarioRepository Funcionario => _funcionarioRepository.Value;
    public IMoradorRepository Morador => _moradorRepository.Value;
    public ITransportadoraRepository Transportadora => _transportadoraRepository.Value;
    public IUnidadeRepository Unidade => _unidadeRepository.Value;

    public void Salvar() {
        _context.SaveChanges();
    }
}
