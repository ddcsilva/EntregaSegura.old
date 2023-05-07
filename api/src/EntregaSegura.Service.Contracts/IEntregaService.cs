using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IEntregaService
{
    IEnumerable<EntregaDTO> ObterEntregas(Guid? condominioId, Guid? unidadeId, Guid? moradorId, Guid? funcionarioId, Guid? transportadoraId, bool rastrearAlteracoes);
    EntregaDTO ObterEntregaPorMorador(Guid condominioId, Guid unidadeId, Guid moradorId, Guid entregaId, bool rastrearAlteracoes);
    EntregaDTO ObterEntregaPorFuncionario(Guid condominioId, Guid funcionarioId, Guid entregaId, bool rastrearAlteracoes);
    EntregaDTO ObterEntregaPorTransportadora(Guid transportadoraId, Guid entregaId, bool rastrearAlteracoes);
}