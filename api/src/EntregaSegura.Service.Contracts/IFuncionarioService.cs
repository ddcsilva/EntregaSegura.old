using EntregaSegura.Shared.DTOs;

namespace EntregaSegura.Service.Contracts;

public interface IFuncionarioService
{
    IEnumerable<FuncionarioDTO> ObterFuncionarios(Guid condominioId, bool rastrearAlteracoes);
    FuncionarioDTO ObterFuncionario(Guid condominioId, Guid funcionarioId, bool rastrearAlteracoes);
    FuncionarioDTO CriarFuncionarioParaCondominio(Guid condominioId, FuncionarioCriacaoDTO funcionarioCriacaoDTO, bool rastrearAlteracoes);
}