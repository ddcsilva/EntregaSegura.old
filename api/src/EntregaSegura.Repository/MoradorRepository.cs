using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class MoradorRepository : RepositoryBase<Morador>, IMoradorRepository
{
    public MoradorRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Morador> ObterMoradores(Guid condominioId, Guid unidadeId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.UnidadeId == unidadeId && c.Unidade.CondominioId == condominioId, rastrearAlteracoes).OrderBy(c => c.Nome).ToList();
    }

    public Morador ObterMorador(Guid condominioId, Guid unidadeId, Guid moradorId, bool rastrearAlteracoes)
    {
        return BuscarPorCondicao(c => c.Id == moradorId && c.UnidadeId == unidadeId && c.Unidade.CondominioId == condominioId, rastrearAlteracoes).SingleOrDefault();
    }

    public void CriarMoradorParaUnidade(Guid condominioId, Guid unidadeId, Morador morador)
    {
        morador.UnidadeId = unidadeId;
        Criar(morador);
    }
}