using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IFuncionarioService
{
    IEnumerable<FuncionarioDTO> ObterFuncionarios(bool rastrearAlteracoes);
    FuncionarioDTO ObterFuncionario(Guid condominioId, Guid funcionarioId, bool rastrearAlteracoes);
}