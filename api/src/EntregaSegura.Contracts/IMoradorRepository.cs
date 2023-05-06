using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IMoradorRepository
{
    IEnumerable<Morador> ObterTodosMoradores(bool rastrearAlteracoes);
    Morador? ObterMoradorPorId(Guid moradorId, bool rastrearAlteracoes);
}