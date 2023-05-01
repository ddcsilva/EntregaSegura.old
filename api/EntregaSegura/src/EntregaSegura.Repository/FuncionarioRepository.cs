using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public class FuncionarioRepository : RepositoryBase<Funcionario>, IFuncionarioRepository
{
    public FuncionarioRepository(EntregaSeguraContext context) : base(context)
    {
    }
}