using System;
using System.Diagnostics.CodeAnalysis;

namespace ProjetoNulidade.Services
{
    public static class Guard
    {
        // Aplica o [NotNull] na referência 'value'
        public static void AgainstNull<T>([NotNull] ref T? value, string paramName)
        {
            if (value is null)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
