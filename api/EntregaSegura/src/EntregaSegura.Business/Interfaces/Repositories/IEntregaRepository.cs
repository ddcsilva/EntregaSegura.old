using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;
using EntregaSegura.Business.Models.Enums;

namespace EntregaSegura.Business.Interfaces;

/// <summary>
/// Interface que representa o repositório especializado de entrega
/// </summary>
public interface IEntregaRepository : IRepository<Entrega>
{
    // Obtém uma entrega por Cliente
    Task<IEnumerable<Entrega>> ObterEntregasPorCliente(Guid clienteId);

    // Obtém uma entrega pelo Status
    Task<IEnumerable<Entrega>> ObterEntregasPorStatus(StatusEntrega status);

    // Obtém uma entrega pela Data de Recebimento e Entrega (opcional)
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataRecebimento, DateTime? dataEntrega);

    // Obtém uma entrega pela Data de Recebimento e Entrega (opcional), por Status de Entrega
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataRecebimento, DateTime? dataEntrega, StatusEntrega status);

    // Obtém uma entrega pela Data de Recebimento e Entrega (opcional), por Cliente
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataRecebimento, DateTime? dataEntrega, Guid clienteId);

    // Obtém uma entrega pela Data de Recebimento e Entrega (opcional), por Cliente, por Status de Entrega
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataRecebimento, DateTime? dataEntrega, Guid clienteId, StatusEntrega status);

    // Obtém uma entrega pela Data de Recebimento e Entrega (opcional), por Cliente, por Transportadora
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataRecebimento, DateTime? dataEntrega, Guid clienteId, Guid transportadoraId);

    // Obtém uma entrega pela Data de Recebimento e Entrega (opcional), por Cliente, por Transportadora, por Status de Entrega
    Task<IEnumerable<Entrega>> ObterEntregasPorData(DateTime dataRecebimento, DateTime? dataEntrega, Guid clienteId, Guid transportadoraId, StatusEntrega status);
}