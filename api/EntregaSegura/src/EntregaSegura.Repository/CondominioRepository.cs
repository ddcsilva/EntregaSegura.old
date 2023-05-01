using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public class CondominioRepository : RepositoryBase<Condominio>, ICondominioRepository
{
    public CondominioRepository(EntregaSeguraContext context) : base(context)
    {
    }
}