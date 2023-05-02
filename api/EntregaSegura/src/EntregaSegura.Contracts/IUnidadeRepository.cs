using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IUnidadeRepository
{
    IEnumerable<Unidade> ObterTodasUnidades(bool rastrearAlteracoes);
}