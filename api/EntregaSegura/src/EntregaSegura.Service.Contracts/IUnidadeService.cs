using EntregaSegura.Entities.Models;

namespace EntregaSegura.Service.Contracts;

public interface IUnidadeService
{
    IEnumerable<Unidade> ObterTodasUnidades(bool rastrearAlteracoes);
}