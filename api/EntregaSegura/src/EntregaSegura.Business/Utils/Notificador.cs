using EntregaSegura.Business.Interfaces;

namespace EntregaSegura.Business.Utils;

/// <summary>
/// Classe responsável por notificar erros.
/// </summary>
public class Notificador : INotificador
{
    // Lista de notificações de erros.
    private List<Notificacao> _notificacoes;

    /// <summary>
    /// Construtor padrão que inicializa a lista de notificações de erros.
    /// </summary>
    public Notificador()
    {
        _notificacoes = new List<Notificacao>();
    }

    /// <summary>
    /// Método que retorna se há notificações.
    /// </summary>
    /// <returns>Retorna se há notificações.</returns>
    public bool TemNotificacao()
    {
        return _notificacoes.Any();
    }

    /// <summary>
    /// Método que obtém as notificações.
    /// </summary>
    /// <returns>Retorna uma lista de notificações.</returns>
    public List<Notificacao> ObterNotificacoes()
    {
        return _notificacoes;
    }

    /// <summary>
    /// Método que adiciona uma notificação.
    /// </summary>
    /// <param name="notificacao">Notificação a ser adicionada.</param>
    public void Handle(Notificacao notificacao)
    {
        _notificacoes.Add(notificacao);
    }
}