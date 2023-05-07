using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IUnidadeService
{
    IEnumerable<UnidadeDTO> ObterUnidades(Guid condominioId, bool rastrearAlteracoes);
    UnidadeDTO ObterUnidade(Guid condominioId, Guid unidadeId, bool rastrearAlteracoes);
    UnidadeDTO CriarUnidadeParaCondominio(Guid condominioId, UnidadeCriacaoDTO unidadeCriacaoDTO, bool rastrearAlteracoes);
}