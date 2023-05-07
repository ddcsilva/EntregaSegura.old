using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IUnidadeService
{
    IEnumerable<UnidadeDTO> ObterUnidades(bool rastrearAlteracoes);
    UnidadeDTO ObterUnidade(Guid unidadeId, bool rastrearAlteracoes);
    UnidadeDTO CriarUnidadeParaCondominio(Guid condominioId, UnidadeCriacaoDTO unidadeCriacaoDTO, bool rastrearAlteracoes);
}