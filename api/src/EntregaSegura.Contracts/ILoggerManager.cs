namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos para registrar eventos de log em diferentes níveis de severidade.
/// </summary>
public interface ILoggerManager
{
    void LogInformativo(string messagem);
    void LogAdvertencia(string messagem);
    void LogDepuracao(string messagem);
    void LogErro(string messagem);
}
