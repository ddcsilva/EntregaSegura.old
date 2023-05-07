namespace EntregaSegura.Entities.Exceptions;

/// <summary>
/// Classe abstrata que representa uma exceção base para quando um registro não é encontrado.
/// </summary>
public abstract class NotFoundException : Exception
{
    protected NotFoundException(string message) : base(message) { }
}