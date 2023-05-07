using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Moradores no banco de dados.
/// </summary>
public interface IMoradorRepository
{
    IEnumerable<Morador> ObterMoradores(Guid condominioId, Guid unidadeId, bool rastrearAlteracoes);
    Morador? ObterMorador(Guid condominioId, Guid unidadeId, Guid moradorId, bool rastrearAlteracoes);
    void CriarMoradorParaUnidade(Guid condominioId, Guid unidadeId, Morador morador);
}