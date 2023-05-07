namespace EntregaSegura.Entities.Exceptions;

/// <summary>
/// Classe que representa uma exceção personalizada para quando um registro não é encontrado no sistema Entrega Segura.
/// </summary>
public sealed class EntregaSeguraNotFoundException : NotFoundException
{
    public EntregaSeguraNotFoundException(Guid id) : base($"Não foi possível encontrar o registro com o id: {id}")
    {

    }
}