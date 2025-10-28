using ProjetoNulidade.Models;
using ProjetoNulidade.Services;
using Xunit;

namespace ProjetoNulidade.Tests
{
    public class PersonTests
    {
        // 1. Prova o ArgumentException no construtor
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Person_Ctor_ThrowsException_WhenNameIsInvalid(string invalidName)
        {
            Assert.Throws<ArgumentException>(() => new Person(invalidName));
        }

        // 2. Prova o contrato [MemberNotNull(nameof(Passport))]
        [Fact]
        public void IssuePassport_SetsPassport_AndCompilerKnowsIt()
        {
            // Arrange
            var person = new Person("Test User");
            
            // At first, Passport is null (0..1 association)
            Assert.Null(person.Passport); 

            // Act
            person.IssuePassport("P123456");

            // Assert
            // After calling the method, Passport is Not Null (1..1 association implied)
            Assert.NotNull(person.Passport);
            Assert.Equal("P123456", person.Passport.Number);

            // Importante: No código do 'Program.cs', 
            // a chamada a 'person.Passport.Number' NÃO gerará um warning,
            // provando que [MemberNotNull] funcionou.
        }

        // 3. Prova o contrato [NotNullWhen(true)]
        [Fact]
        public void TryGetUserByEmail_ReturnsTrue_AndPersonIsNotNull()
        {
            // Arrange
            var userService = new UserService();
            
            // Act
            // If the method returns true, the compiler knows 'person' is NotNull.
            if (userService.TryGetUserByEmail("admin@utfpr.edu.br", out var person))
            {
                // Assert
                Assert.NotNull(person);
                // Acesso direto a 'person.Name' sem o operador '!' (bang operator)
                Assert.Equal("Aluno UTFPR", person.Name); 
            }
            else
            {
                Assert.Fail("The method should have returned true for this email.");
            }
        }
    }
}
