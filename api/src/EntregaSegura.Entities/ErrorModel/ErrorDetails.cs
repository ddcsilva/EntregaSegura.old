using System.Text.Json;

namespace EntregaSegura.Entities.ErrorModel;

/// <summary>
/// Classe que representa um modelo de erro com informações sobre o status HTTP e a mensagem de erro.
/// </summary>
public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Mensagem { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}