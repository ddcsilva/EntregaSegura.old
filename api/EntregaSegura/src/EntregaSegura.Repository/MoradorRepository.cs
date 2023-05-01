using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public class MoradorRepository : RepositoryBase<Morador>, IMoradorRepository
{
    public MoradorRepository(EntregaSeguraContext context) : base(context)
    {
    }
}