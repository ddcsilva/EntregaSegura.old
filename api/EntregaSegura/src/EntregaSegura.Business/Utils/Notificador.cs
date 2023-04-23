using EntregaSegura.Business.Interfaces;

namespace EntregaSegura.Business.Utils;

/// <summary>
/// Classe de notificação
/// </summary>
public class Notificador : INotificador
{
    // Lista de notificações
    private List<Notificacao> _notificacoes;

    /// <summary>
    /// Construtor padrão, inicializa a lista de notificações.
    /// </summary>
    public Notificador()
    {
        _notificacoes = new List<Notificacao>();
    }

    /// <summary>
    /// Retorna se há notificações.
    /// </summary>
    /// <returns>Retorna se há notificações.</returns>
    public bool TemNotificacao()
    {
        return _notificacoes.Any();
    }

    /// <summary>
    /// Retorna uma lista de notificações.
    /// </summary>
    /// <returns>Retorna uma lista de notificações.</returns>
    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacoes;
    }

    /// <summary>
    /// Adiciona uma notificação.
    /// </summary>
    /// <param name="notificacao">Notificação a ser adicionada.</param>
    public void Handle(Notificacao notificacao)
    {
        _notificacoes.Add(notificacao);
    }
}