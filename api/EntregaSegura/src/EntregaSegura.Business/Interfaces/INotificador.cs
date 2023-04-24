using EntregaSegura.Business.Utils;

namespace EntregaSegura.Business.Interfaces;

/// <summary>
/// Interface que representa o notificador de erros
/// </summary>
public interface INotificador
{
    // Retorna se há notificações ou não
    bool TemNotificacao();

    // Retorna uma lista de notificações de erros
    List<Notificacao> ObterNotificacoes();

    // Adiciona uma notificação 
    void Handle(Notificacao notificacao);
}