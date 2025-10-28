# 🧩 Projeto: Contratos de Nulidade com Atributos em C#

Este projeto demonstra o uso prático de **Nullable Reference Types (NRT)** e **Contratos de Nulidade** em C# 8.0+ utilizando atributos do namespace `System.Diagnostics.CodeAnalysis`.

O objetivo é eliminar o máximo de avisos de nulidade do compilador e provar ao código a intenção das associações.

## 🎯 Conceitos Demonstrados

* **Nullable Reference Types (NRT):** Tipos de referência não anuláveis (`T`) e anuláveis (`T?`).
* **Associações entre classes:**
    * **0..1 (Zero ou Um):** `Person.Passport` (pode ser `null`).
    * **1..1 (Exatamente Um):** `Passport.Owner` (nunca será `null`).
* **Atributos de Contrato de Nulidade:**
    * `[DisallowNull]`: Usado em propriedades onde não se quer aceitar `null` externamente (ex: setters).
    * `[NotNull]`: Usado para indicar que um parâmetro ou propriedade nunca será `null`.
    * `[NotNullWhen(true)]`: Usado em métodos `Try...` (ex: `TryGetUserByEmail`) para indicar que a variável `out` será não nula apenas se o método retornar `true`.
    * `[MemberNotNull(nameof(Passport))]`: Usado em `Person.IssuePassport` para informar ao compilador que após a execução do método, a propriedade `Passport` não será mais nula.

## 🏗️ Estrutura do Projeto
ProjetoNulidade/ 
├── Models/ 
│ ├── Person.cs (Associação 0..1 com Passport) 
│ ├── Passport.cs (Associação 1..1 com Person) 
├── Services/ 
| ├── Guard.cs (Método de guarda com [NotNull] em 'ref')
│ ├── UserService.cs (Demonstra [NotNullWhen(true)])
├── ProjetoNulidade.Tests/ (Testes xUnit para provar os contratos) 
├── Program.cs 
├── ProjetoNulidade.csproj
└── README.md
