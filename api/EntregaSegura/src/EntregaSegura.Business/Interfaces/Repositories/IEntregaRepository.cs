using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;
using EntregaSegura.Business.Models.Enums;

namespace EntregaSegura.Business.Interfaces;

public interface IEntregaRepository : IRepository<Entrega>
{
    Task<IEnumerable<Entrega>> ObterEntregasPorCliente(Guid clienteId);
    Task<IEnumerable<Entrega>> ObterEntregasPorStatus(StatusEntrega status);
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataInicial, DateTime dataFinal);
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataInicial, DateTime dataFinal, StatusEntrega status);
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataInicial, DateTime dataFinal, Guid clienteId);
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataInicial, DateTime dataFinal, Guid clienteId, StatusEntrega status);
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataInicial, DateTime dataFinal, Guid clienteId, Guid transportadoraId);
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataInicial, DateTime dataFinal, Guid clienteId, Guid transportadoraId, StatusEntrega status);
}