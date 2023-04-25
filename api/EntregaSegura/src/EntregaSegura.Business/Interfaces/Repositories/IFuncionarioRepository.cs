using EntregaSegura.Business.Interfaces.Repositories;
using EntregaSegura.Business.Models;

namespace EntregaSegura.Business.Interfaces;

public interface IFuncionarioRepository : IRepository<Funcionario>
{
    /// <summary>
    /// Obtém um funcionário pelo seu nome
    /// </summary>
    /// <param name="nome">Nome do funcionário</param>
    /// <returns>Retorna um funcionário</returns>
    Task<IEnumerable<Funcionario>> ObterFuncionariosPorNome(string nome);

    /// <summary>
    /// Obtém um funcionário pelo seu CPF
    /// </summary>
    /// <param name="cpf">CPF do funcionário</param>
    /// <returns>Retorna um funcionário</returns>
    Task<IEnumerable<Funcionario>> ObterFuncionariosPorCpf(string cpf);

    /// <summary>
    /// Obtém todos os funcionários que realizaram entregas em uma unidade
    /// </summary>
    /// <param name="unidadeId">Id da unidade</param>
    /// <returns>Rertorna uma lista de funcionários</returns>
    Task<IEnumerable<Funcionario>> ObterFuncionariosEntregasPorUnidade(int unidadeId);    
}