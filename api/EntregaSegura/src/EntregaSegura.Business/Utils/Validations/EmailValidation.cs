using System.Text.RegularExpressions;

namespace EntregaSegura.Business.Utils.Validations;

public class EmailValidation
{
    /// <summary>
    /// Valida um e-mail
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