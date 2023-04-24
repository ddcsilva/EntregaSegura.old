using System.Text.RegularExpressions;

namespace EntregaSegura.Business.Utils.Validations;

/// <summary>
/// Classe que representa a validação adicional de e-mail
/// </summary>
public class EmailValidation
{
    /// <summary>
    /// Método que valida se o e-mail é válido
    /// </summary>
    /// <param name="email">E-mail a ser validado</param>
    /// <returns>Retorna se o e-mail é válido</returns>
    public static bool ValidarEmail(string email)
    {
        if (string.IsNullOrEmpty(email))
            return false;

        return Regex.IsMatch(email,
            @"^[a-z0-9.]+@[a-z0-9]+\.[a-z]+(\.[a-z]+)?$", RegexOptions.IgnoreCase);
    }
}