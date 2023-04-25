using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces;

/// <summary>
/// Interface que representa o repositório especializado de morador
/// </summary>
public interface IMoradorRepository : IRepository<Morador>
{
    /// <summary>
    /// Obtém um morador pelo seu nome
    /// </summary>
    /// <param name="nome">Nome do morador</param>
    /// <returns>Retorna um morador</returns>
    Task<IEnumerable<Morador>> ObterMoradoresPorNome(string nome);

    /// <summary>
    /// Obtém um morador pelo seu CPF
    /// </summary>
    /// <param name="cpf">CPF do morador</param>
    /// <returns>Retorna um morador</returns>
    Task<IEnumerable<Morador>> ObterMoradoresPorCpf(string cpf);

    /// <summary>
    /// Obtém todos os moradores de uma unidade
    /// </summary>
    /// <param name="unidadeId">Id da unidade</param>
    /// <returns>Retorna uma lista de moradores</returns>
    Task<IEnumerable<Morador>> ObterMoradoresPorUnidade(int unidadeId);

    /// <summary>
    /// Obtém todos os moradores de uma unidade que receberam entregas
    /// </summary>
    /// <param name="unidadeId">Id da unidade</param>
    /// <returns>Retorna uma lista de moradores</returns>
    Task<IEnumerable<Morador>> ObterTodosMoradoresQueReceberamEntregasPorUnidade(int unidadeId);
}