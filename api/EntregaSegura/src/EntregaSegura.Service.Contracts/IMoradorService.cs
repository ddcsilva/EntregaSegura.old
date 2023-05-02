using EntregaSegura.Entities.Models;

namespace EntregaSegura.Service.Contracts;

public interface IMoradorService
{
    IEnumerable<Morador> ObterTodosMoradores(bool rastrearAlteracoes);
}