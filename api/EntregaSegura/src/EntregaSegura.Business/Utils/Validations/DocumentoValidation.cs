namespace EntregaSegura.Business.Utils.Validations;

/// <summary>
/// Classe de validação de documentos
/// </summary>
public static class DocumentoValidation
{
    /// <summary>
    /// Valida um CPF
    /// </summary>
    /// <param name="cpf">CPF a ser validado</param>
    /// <returns>Retorna se o CPF é válido</returns>
    public static bool ValidarCpf(string cpf)
    {
        cpf = RemoverFormatacao(cpf);

        if (!PossuiTamanhoValido(cpf, 11) || TemDigitosRepetidos(cpf))
            return false;

        return VerificarDigitosCpf(cpf);
    }

    /// <summary>
    /// Valida um CNPJ
    /// </summary>
    /// <param name="cnpj">CNPJ a ser validado</param>
    /// <returns>Retorna se o CNPJ é válido</returns>
    public static bool ValidarCnpj(string cnpj)
    {
        cnpj = RemoverFormatacao(cnpj);

        if (!PossuiTamanhoValido(cnpj, 14))
            return false;

        return VerificarDigitosCnpj(cnpj);
    }

    /// <summary>
    /// Remove a formatação de um documento
    /// </summary>
    /// <param name="documento">Documento a ser formatado</param>
    /// <returns>Retorna o documento sem formatação</returns>
    private static string RemoverFormatacao(string documento)
    {
        return documento.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
    }

    /// <summary>
    /// Calcula os dígitos verificadores de um CPF ou CNPJ
    /// </summary>
    /// <param name="documento">CPF ou CNPJ a ser calculado</param>
    /// <param name="tamanho">Tamanho do documento</param>
    /// <returns>Retorna o tamanho do documento</returns>
    private static bool PossuiTamanhoValido(string documento, int tamanho)
    {
        return documento.Length == tamanho;
    }

    /// <summary>
    /// Verifica se um CPF possui dígitos repetidos
    /// </summary>
    /// <param name="documento">CPF a ser verificado</param>
    /// <returns>Retorna se o CPF possui dígitos repetidos</returns>
    private static bool TemDigitosRepetidos(string documento)
    {
        for (int i = 0; i < 10; i++)
            if (documento == new string(i.ToString()[0], documento.Length))
                return true;

        return false;
    }

    /// <summary>
    /// Verifica se os dígitos verificadores de um CPF estão corretos
    /// </summary>
    /// <param name="cpf">CPF a ser verificado</param>
    /// <returns>Retorna se os dígitos do CPF estão corretos</returns>
    private static bool VerificarDigitosCpf(string cpf)
    {
        int[] digitosCalculados = CalcularDigitosCpf(cpf);

        return cpf.EndsWith($"{digitosCalculados[0]}{digitosCalculados[1]}");
    }

    /// <summary>
    /// Verifica se os dígitos verificadores de um CNPJ estão corretos
    /// </summary>
    /// <param name="cnpj">CNPJ a ser verificado</param>
    /// <returns>Retorna se os dígitos do CNPJ estão corretos</returns>
    private static bool VerificarDigitosCnpj(string cnpj)
    {
        int[] digitosCalculados = CalcularDigitosCnpj(cnpj);

        return cnpj.EndsWith($"{digitosCalculados[0]}{digitosCalculados[1]}");
    }

    /// <summary>
    /// Calcula os dígitos verificadores de um CPF
    /// </summary>
    /// <param name="cpf">CPF a ser calculado</param>
    /// <returns>Retorna os dígitos do CPF calculados</returns>
    private static int[] CalcularDigitosCpf(string cpf)
    {
        int[] digitos = new int[2];

        digitos[0] = CalcularDigitoVerificador(cpf.Substring(0, 9), new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 });
        digitos[1] = CalcularDigitoVerificador(cpf.Substring(0, 10), new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 });

        return digitos;
    }

    /// <summary>
    /// Calcula os dígitos verificadores de um CNPJ
    /// </summary>
    /// <param name="cnpj">CNPJ a ser calculado</param>
    /// <returns>Retorna os dígitos do CNPJ calculados</returns>
    private static int[] CalcularDigitosCnpj(string cnpj)
    {
        int[] digitos = new int[2];

        digitos[0] = CalcularDigitoVerificador(cnpj.Substring(0, 12), new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
        digitos[1] = CalcularDigitoVerificador(cnpj.Substring(0, 13), new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

        return digitos;
    }

    /// <summary>
    /// Calcula um dígito verificador
    /// </summary>
    /// <param name="documento">Documento a ser calculado</param>
    /// <param name="multiplicadores">Multiplicadores a serem utilizados</param>
    /// <returns>Retorna o dígito verificador calculado</returns>
    private static int CalcularDigitoVerificador(string documento, int[] multiplicadores)
    {
        int soma = 0;

        for (int i = 0; i < documento.Length; i++)
        {
            soma += (documento[i] - '0') * multiplicadores[i];
        }

        int resto = soma % 11;

        return resto < 2 ? 0 : 11 - resto;
    }
}