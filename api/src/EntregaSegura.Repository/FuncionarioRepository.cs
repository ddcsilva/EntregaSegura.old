using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Funcionario> ObterFuncionarios(Guid condominioId, bool rastrearAlteracoes)
    {
        var funcionarios = BuscarPorCondicao(f => f.CondominioId.Equals(condominioId), rastrearAlteracoes).OrderBy(f => f.Nome);

        return funcionarios;
    }

    public Funcionario ObterFuncionario(Guid condominioId, Guid funcionarioId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(f => f.CondominioId.Equals(condominioId) && f.Id.Equals(funcionarioId), rastrearAlteracoes).SingleOrDefault();
    }

    public void CriarFuncionarioParaCondominio(Guid condominioId, Funcionario funcionario)
    {
        funcionario.CondominioId = condominioId;
        Criar(funcionario);
    }
}