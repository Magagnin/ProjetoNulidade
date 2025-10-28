#nullable enable
using System;
using ProjetoNulidade.Models;
using ProjetoNulidade.Services;

namespace ProjetoNulidade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Demonstração de Contratos de Nulidade ===\n");

            var userService = new UserService();

            // Graças a [NotNullWhen(true)], o compilador sabe que 'person' é NotNull neste bloco.
            if (userService.TryGetUserByEmail("aluno@utfpr.edu.br", out var person))
            {
                Console.WriteLine($"Usuário encontrado: {person.Name}");

                person.IssuePassport("BR123456");
                // Graças a [MemberNotNull], o compilador sabe que 'person.Passport' NÃO é null aqui.
                Console.WriteLine($"Passaporte emitido: {person.Passport.Number}");
            }
            else
            {
                Console.WriteLine("Usuário não encontrado.");
            }
        }
    }
}
