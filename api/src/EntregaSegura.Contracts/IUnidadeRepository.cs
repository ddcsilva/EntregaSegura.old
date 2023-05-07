using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IUnidadeRepository
{
    IEnumerable<Unidade> ObterUnidades(bool rastrearAlteracoes);
    Unidade? ObterUnidade(Guid unidadeId, bool rastrearAlteracoes);
    void CriarUnidadeParaCondominio(Guid condominioId, Unidade unidade);
}