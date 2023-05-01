using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
{
    public EnderecoRepository(EntregaSeguraContext context) : base(context)
    {
    }    
}