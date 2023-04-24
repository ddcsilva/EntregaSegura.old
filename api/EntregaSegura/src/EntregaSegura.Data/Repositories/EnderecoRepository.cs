using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;
using EntregaSegura.Data.Contexts;

namespace EntregaSegura.Data.Repositories;

/// <summary>
/// Classe de repositório para a entidade Endereco
/// </summary>
public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
{
    /// <summary>
    /// Construtor padrão que recebe o contexto do banco de dados
    
    public EnderecoRepository(EntregaSeguraContext context) : base(context)
    {
    }
}