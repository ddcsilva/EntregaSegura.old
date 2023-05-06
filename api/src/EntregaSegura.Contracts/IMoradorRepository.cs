using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IMoradorRepository
{
    IEnumerable<Morador> ObterMoradores(bool rastrearAlteracoes);
    Morador? ObterMorador(Guid moradorId, bool rastrearAlteracoes);
}