using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IMoradorService
{
    IEnumerable<MoradorDTO> ObterMoradores(bool rastrearAlteracoes);
    MoradorDTO ObterMorador(Guid moradorId, bool rastrearAlteracoes);
}