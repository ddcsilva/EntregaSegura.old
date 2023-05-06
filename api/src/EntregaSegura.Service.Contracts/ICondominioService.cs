using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface ICondominioService
{
    IEnumerable<CondominioDTO> ObterTodosCondominios(bool rastrearAlteracoes);
    CondominioDTO ObterCondominioPorId(Guid condominioId, bool rastrearAlteracoes);
}