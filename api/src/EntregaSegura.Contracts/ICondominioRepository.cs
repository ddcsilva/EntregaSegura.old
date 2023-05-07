using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Condominios no banco de dados.
/// </summary>
public interface ICondominioRepository
{
    IEnumerable<Condominio> ObterCondominios(bool rastrearAlteracoes);
    Condominio? ObterCondominio(Guid condominioId, bool rastrearAlteracoes);
    void CriarCondominio(Condominio condominio);
}