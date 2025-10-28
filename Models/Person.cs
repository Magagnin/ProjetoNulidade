using System;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoNulidade.Models
{
    public class Person
    {
        [DisallowNull]
        public string Name { get; private set; } = string.Empty;

        public Passport? Passport { get; private set; }

        public Person(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            }

            Name = name;
        }

        [MemberNotNull(nameof(Passport))]
        public void IssuePassport(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Invalid passport number.");
            }

            Passport = new Passport(number, this);
        }
    }
}
