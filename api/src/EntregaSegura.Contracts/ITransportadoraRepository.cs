using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Transportadoras no banco de dados.
/// </summary>
public interface ITransportadoraRepository
{
    IEnumerable<Transportadora> ObterTransportadoras(bool rastrearAlteracoes);
    Transportadora? ObterTransportadora(Guid transportadoraId, bool rastrearAlteracoes);
    void CriarTransportadora(Transportadora transportadora);
}