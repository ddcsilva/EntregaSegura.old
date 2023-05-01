using EntregaSegura.Entities.Models;

namespace EntregaSegura.Service.Contracts;

public interface ICondominioService
{
    IEnumerable<Condominio> ObterTodosCondominios(bool rastrearAlteracoes);
}