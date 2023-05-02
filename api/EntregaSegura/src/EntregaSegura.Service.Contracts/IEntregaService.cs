using EntregaSegura.Entities.Models;

namespace EntregaSegura.Service.Contracts;

public interface IEntregaService
{
    IEnumerable<Entrega> ObterTodasEntregas(bool rastrearAlteracoes);
}