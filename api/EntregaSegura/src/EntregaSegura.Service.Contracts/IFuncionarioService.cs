using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IFuncionarioService
{
    IEnumerable<FuncionarioDTO> ObterTodosFuncionarios(bool rastrearAlteracoes);
}