using System;
using System.Diagnostics.CodeAnalysis;
using ProjetoNulidade.Models;

namespace ProjetoNulidade.Services
{
    public class UserService
    {
        // Contrato: Se o método retornar 'true', o parâmetro 'person' NÃO será null
        public bool TryGetUserByEmail(string? email, [NotNullWhen(true)] out Person? person)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                person = null;
                return false;
            }

            // Simulação: usuário encontrado se o e-mail contém "utfpr"
            if (email.Contains("utfpr"))
            {
                person = new Person("Aluno UTFPR");
                return true;
            }

            person = null;
            return false;
        }
    }
}
