using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces.Services;

/// <summary>
/// Interface de serviço para a entidade Condominio
/// </summary>
public interface ICondominioService : IDisposable
{
    // Adiciona um condomínio
    Task Adicionar(Condominio condominio);

    // Atualiza um condomínio
    Task Atualizar(Condominio condominio);

    // Remove um condomínio
    Task Remover(Guid id);

    // Atualiza o endereço de um condomínio
    Task AtualizarEndereco(Endereco endereco);
}