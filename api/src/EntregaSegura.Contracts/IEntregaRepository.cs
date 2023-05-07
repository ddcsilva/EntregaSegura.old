using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Entregas no banco de dados.
/// </summary>
public interface IEntregaRepository
{
    IEnumerable<Entrega> ObterEntregas(bool rastrearAlteracoes);
    Entrega? ObterEntrega(Guid entregaId, bool rastrearAlteracoes);
}