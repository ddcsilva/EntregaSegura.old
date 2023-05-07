using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Repository.Contexts;

namespace EntregaSegura.Repository;

public sealed class EntregaRepository : RepositoryBase<Entrega>, IEntregaRepository
{
    public EntregaRepository(EntregaSeguraContext context) : base(context) { }

    public IEnumerable<Entrega> ObterEntregas(Guid? condominioId, Guid? unidadeId, Guid? moradorId, Guid? funcionarioId, Guid? transportadoraId, bool rastrearAlteracoes)
    {
        var entregas = BuscarPorCondicao(e => (condominioId == null || e.Morador.Unidade.CondominioId == condominioId) &&
                                              (unidadeId == null || e.Morador.UnidadeId == unidadeId) &&
                                              (moradorId == null || e.MoradorId == moradorId) &&
                                              (funcionarioId == null || e.FuncionarioId == funcionarioId) &&
                                              (transportadoraId == null || e.TransportadoraId == transportadoraId), rastrearAlteracoes);

        return entregas;
    }

    public Entrega ObterEntrega(Guid? condominioId, Guid? unidadeId, Guid? moradorId, Guid? funcionarioId, Guid? transportadoraId, Guid entregaId, bool rastrearAlteracoes)
    {
        var entrega = BuscarPorCondicao(e => e.Id == entregaId &&
                                              (condominioId == null || e.Morador.Unidade.CondominioId == condominioId) &&
                                              (unidadeId == null || e.Morador.UnidadeId == unidadeId) &&
                                              (moradorId == null || e.MoradorId == moradorId) &&
                                              (funcionarioId == null || e.FuncionarioId == funcionarioId) &&
                                              (transportadoraId == null || e.TransportadoraId == transportadoraId), rastrearAlteracoes)
                                              .SingleOrDefault();

        return entrega;
    }

    public void RegistrarEntrega(Guid condominioId, Guid funcionarioId, Entrega entrega)
    {
        entrega.FuncionarioId = funcionarioId;
        Criar(entrega);
    }
}