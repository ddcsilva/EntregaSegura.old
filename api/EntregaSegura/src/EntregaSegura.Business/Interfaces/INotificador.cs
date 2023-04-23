using EntregaSegura.Business.Utils;

namespace EntregaSegura.Business.Interfaces;

/// <summary>
/// Interface de notificação
/// </summary>
public interface INotificador
{
    // Retorna se há notificações
    bool TemNotificacao();

    // Retorna uma lista de notificações
    List<Notificacao> ObterNotificacoes();

    // Adiciona uma notificação
    void Handle(Notificacao notificacao);
}