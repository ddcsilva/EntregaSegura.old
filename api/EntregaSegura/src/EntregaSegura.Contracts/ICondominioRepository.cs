using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface ICondominioRepository
{
    IEnumerable<Condominio> ObterTodosCondominios(bool rastrearAlteracoes);
}