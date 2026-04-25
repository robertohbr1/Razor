# Instruções para o Assistente (CLAUDE.md)

## Sobre o Projeto
- **Nome:** RazorDataPresentation
- **Tecnologia:** ASP.NET Core (Razor Pages / MVC / Blazor)
- **Framework:** .NET 10 (`net10.0`)
- **Linguagem:** C# (com suporte a Nullable e Implicit Usings habilitados)

## Comandos Úteis
- **Executar a aplicação:**
  Execute o arquivo `exec.bat` na raiz do projeto, ou utilize o comando:
  `dotnet watch run --project RazorDataPresentation.csproj`
- **Executar os testes:**
  Execute o arquivo `test.bat` na raiz do projeto, ou utilize o comando:
  `dotnet test RazorDataPresentation.Tests.csproj --verbosity normal`

## Convenções de Código (C#)
- Utilize as convenções padrão do C# e do .NET.
- Faça uso de injeção de dependência e padrões comuns do ASP.NET Core.
- Como o `ImplicitUsings` está habilitado (`GlobalUsings.cs` existe no projeto), evite adicionar `using` desnecessários nos arquivos de código para namespaces comuns do .NET.
- O projeto usa `Nullable: enable`, portanto, garanta o tratamento correto de referências nulas e use `?` onde apropriado para indicar nulidade.

## Testes
- Os testes do projeto utilizam **xUnit**.
- Qualquer nova funcionalidade complexa deve vir acompanhada do seu respectivo teste unitário.

## Regras e Comportamentos do Assistente
- Ao propor mudanças, seja claro sobre quais arquivos estão sendo modificados e o propósito da modificação.
- Siga as boas práticas de segurança, design e performance aplicáveis a aplicações web no ecossistema .NET.
- Sempre verifique a resposta dos testes locais (via `test.bat`) quando disponíveis após alguma modificação estrutural.

## Code style

- Functions: 4-20 lines. Split if longer.
- Files: under 500 lines. Split by responsibility.
- One thing per function, one responsibility per module (SRP).
- Names: specific and unique. Avoid `data`, `handler`, `Manager`.
  Prefer names that return <5 grep hits in the codebase.
- Types: explicit. No `any`, no `Dict`, no untyped functions.
- No code duplication. Extract shared logic into a function/module.
- Early returns over nested ifs. Max 2 levels of indentation.
- Exception messages must include the offending value and expected shape.

## Comments

- Keep your own comments. Don't strip them on refactor — they carry
  intent and provenance.
- Write WHY, not WHAT. Skip `// increment counter` above `i++`.
- Docstrings on public functions: intent + one usage example.
- Reference issue numbers / commit SHAs when a line exists because
  of a specific bug or upstream constraint.

## Tests

- Tests run with a single command: `<project-specific>`.
- Every new function gets a test. Bug fixes get a regression test.
- Mock external I/O (API, DB, filesystem) with named fake classes,
  not inline stubs.
- Tests must be F.I.R.S.T: fast, independent, repeatable,
  self-validating, timely.

## Dependencies

- Inject dependencies through constructor/parameter, not global/import.
- Wrap third-party libs behind a thin interface owned by this project.

## Structure

- Follow the framework's convention (Rails, Django, Next.js, etc.).
- Prefer small focused modules over god files.
- Predictable paths: controller/model/view, src/lib/test, etc.

## Formatting

- Use the language default formatter (`cargo fmt`, `gofmt`, `prettier`,
  `black`, `rubocop -A`). Don't discuss style beyond that.

## Logging

- Structured JSON when logging for debugging / observability.
- Plain text only for user-facing CLI output.