using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Moradores no banco de dados.
/// </summary>
public interface IMoradorRepository
{
    IEnumerable<Morador> ObterMoradores(bool rastrearAlteracoes);
    Morador? ObterMorador(Guid moradorId, bool rastrearAlteracoes);
}