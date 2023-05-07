using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface ICondominioRepository
{
    IEnumerable<Condominio> ObterCondominios(bool rastrearAlteracoes);
    Condominio? ObterCondominio(Guid condominioId, bool rastrearAlteracoes);
    void CriarCondominio(Condominio condominio);
}