namespace EntregaSegura.Contracts;

public interface ILoggerManager
{
    void LogInformativo(string messagem);
    void LogAdvertencia(string messagem);
    void LogDepuracao(string messagem);
    void LogErro(string messagem);
}
