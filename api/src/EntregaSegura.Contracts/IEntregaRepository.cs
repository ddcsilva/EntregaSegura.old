using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Entregas no banco de dados.
/// </summary>
public interface IEntregaRepository
{
    IEnumerable<Entrega> ObterEntregas(Guid? condominioId, Guid? unidadeId, Guid? moradorId, Guid? funcionarioId, Guid? transportadoraId, bool rastrearAlteracoes);
    Entrega? ObterEntrega(Guid? condominioId, Guid? unidadeId, Guid? moradorId, Guid? funcionarioId, Guid? transportadoraId, Guid entregaId, bool rastrearAlteracoes);
}