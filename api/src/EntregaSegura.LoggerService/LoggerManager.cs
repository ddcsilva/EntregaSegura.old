using EntregaSegura.Contracts;
using NLog;

namespace EntregaSegura.LoggerService;

/// <summary>
/// Classe que implementa a interface ILoggerManager e fornece métodos para registrar eventos de log em diferentes níveis de severidade.
/// </summary>
public class LoggerManager : ILoggerManager
{
    private static ILogger _logger = LogManager.GetCurrentClassLogger();

    public LoggerManager() { }

    public void LogAdvertencia(string messagem) => _logger.Warn(messagem);

    public void LogDepuracao(string messagem) => _logger.Debug(messagem);

    public void LogErro(string messagem) => _logger.Error(messagem);

    public void LogInformativo(string messagem) => _logger.Info(messagem);
}
