using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface ICondominioRepository
{
    IEnumerable<Condominio> ObterTodosCondominios(bool rastrearAlteracoes);
    Condominio? ObterCondominioPorId(Guid condominioId, bool rastrearAlteracoes);
}