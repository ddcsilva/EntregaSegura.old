using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Unidades no banco de dados.
/// </summary>
public interface IUnidadeRepository
{
    IEnumerable<Unidade> ObterUnidades(bool rastrearAlteracoes);
    Unidade? ObterUnidade(Guid unidadeId, bool rastrearAlteracoes);
    void CriarUnidadeParaCondominio(Guid condominioId, Unidade unidade);
}