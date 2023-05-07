using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public class UnidadeRepository : RepositoryBase<Unidade>, IUnidadeRepository
{
    public UnidadeRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Unidade> ObterUnidades(Guid condominioId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.CondominioId == condominioId, rastrearAlteracoes).OrderByDescending(c => c.Bloco).ToList();
    }

    public Unidade ObterUnidade(Guid condominioId, Guid unidadeId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.CondominioId == condominioId && c.Id == unidadeId, rastrearAlteracoes).SingleOrDefault();
    }

    public void CriarUnidadeParaCondominio(Guid condominioId, Unidade unidade)
    {
        unidade.CondominioId = condominioId;
        Criar(unidade);
    }
}