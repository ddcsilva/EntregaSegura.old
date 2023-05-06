using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Funcionario> ObterFuncionarios(bool rastrearAlteracoes)
    {
        return BuscarTodos(rastrearAlteracoes).OrderBy(c => c.Nome).ToList();
    }

    public Funcionario? ObterFuncionario(Guid funcionarioId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.Id == funcionarioId, rastrearAlteracoes).FirstOrDefault();
    }
}