namespace EntregaSegura.Entities.Exceptions
{
    public sealed class EntregaSeguraNotFoundException : NotFoundException
    {
        public EntregaSeguraNotFoundException(Guid id) : base($"Não foi possível encontrar o registro com o id: {id}")
        {

        }
    }
}