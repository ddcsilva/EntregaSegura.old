using System.Text.Json;

namespace EntregaSegura.Entities.ErrorModel;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Mensagem { get; set; }

    public override string ToString()
    {
        return JsonSerializer.Serialize(this);
    }
}