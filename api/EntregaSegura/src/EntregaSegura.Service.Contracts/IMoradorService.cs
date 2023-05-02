using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IMoradorService
{
    IEnumerable<MoradorDTO> ObterTodosMoradores(bool rastrearAlteracoes);
}