namespace EntregaSegura.Business.Utils;

/// <summary>
/// Classe de notificação
/// </summary>
public class Notificacao
{
    /// <summary>
    /// Construtor padrão, inicializa a propriedade Mensagem com a mensagem da notificação.
    /// </summary>
    /// <param name="mensagem">Mensagem da notificação.</param>
    public Notificacao(string mensagem)
    {
        Mensagem = mensagem;
    }

    // Retorna a mensagem da notificação
    public string Mensagem { get; }
}