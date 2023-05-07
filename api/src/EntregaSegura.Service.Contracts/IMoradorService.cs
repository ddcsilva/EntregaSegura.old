using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IMoradorService
{
    IEnumerable<MoradorDTO> ObterMoradores(Guid condominioId, Guid unidadeId, bool rastrearAlteracoes);
    MoradorDTO ObterMorador(Guid condominioId, Guid unidadeId, Guid moradorId, bool rastrearAlteracoes);
    MoradorDTO CriarMoradorParaUnidade(Guid condominioId, Guid unidadeId, MoradorCriacaoDTO morador, bool rastrearAlteracoes);
}