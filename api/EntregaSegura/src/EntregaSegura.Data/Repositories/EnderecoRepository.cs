using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;
using EntregaSegura.Data.Contexts;

namespace EntregaSegura.Data.Repositories;

/// <summary>
/// Classe que representa o repositório de endereços.
/// </summary>
public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
{
    /// <summary>
    /// Construtor padrão que recebe o contexto do banco de dados
    /// </summary>
    public EnderecoRepository(EntregaSeguraContext context) : base(context)
    {
    }
}