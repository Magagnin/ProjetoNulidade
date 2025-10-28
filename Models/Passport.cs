using System;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoNulidade.Models
{
    public class Passport
    {
        [DisallowNull]
        public string Number { get; private set; } = string.Empty;

        [NotNull]
        public Person Owner { get; }

        public Passport(string number, [NotNull] Person owner)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Invalid passport number.");
            }
            Number = number;
            // Uso de '?? throw' para garantir que 'Owner' nunca será null (contrato 1..1)
            Owner = owner ?? throw new ArgumentNullException(nameof(owner)); 
        }
    }
}
