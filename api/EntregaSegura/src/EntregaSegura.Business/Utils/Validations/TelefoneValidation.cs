namespace EntregaSegura.Business.Utils.Validations;

/// <summary>
/// Classe que representa a validação adicional de telefone
/// </summary>
public class TelefoneValidation
{
    /// <summary>
    /// Método que valida se o telefone é válido
    /// </summary>
    /// <param name="telefone">Telefone a ser validado</param>
    /// <returns>Retorna se o telefone é válido</returns>
    public static bool ValidarTelefone(string telefone)
    {
        telefone = RemoverFormatacao(telefone);

        if (!PossuiTamanhoValido(telefone, 11))
            return false;

        return true;
    }

    /// <summary>
    /// Método que remove a formatação de um telefone
    /// </summary>
    /// <param name="telefone">Telefone a ser formatado</param>
    /// <returns>Retorna o telefone sem formatação</returns>
    private static string RemoverFormatacao(string telefone)
    {
        return telefone.Trim().Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
    }

    /// <summary>
    /// Método que
    /// </summary>
    /// <param name="telefone">Telefone a ser verificado</param>
    /// <param name="tamanho">Tamanho do telefone</param>
    /// <returns>Retorna se o telefone possui o tamanho correto</returns>
    private static bool PossuiTamanhoValido(string telefone, int tamanho)
    {
        return telefone.Length == tamanho;
    }
}