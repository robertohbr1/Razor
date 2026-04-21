# Testes - RazorDataPresentation

Este diretório contém a suite completa de testes unitários para o projeto RazorDataPresentation.

## 📋 Estrutura dos Testes

### IndexModelTests.cs
Testes abrangentes para a classe `IndexModel` incluindo:
- **FormatValue Tests**: Validação de todos os formatos de dados (CNPJ, IE, Número, Moeda, Sim/Não, Mês/Ano, Texto)
- **GetAlignmentCss Tests**: Testes de alinhamento CSS
- **GetLinkData Tests**: Validação de geração de dados para links
- **OnGet Tests**: Testes do carregamento inicial de dados
- **ColunaCustomizada Tests**: Validação da inicialização e armazenamento de dados
- **Empresa Tests**: Validação da inicialização e armazenamento de dados

### TipoDadoEnumTests.cs
Testes para validação da enumeração `TipoDadoEnum`:
- Verifica se todos os valores estão presentes
- Valida a ordem dos valores

### AlinhamentoEnumTests.cs
Testes para validação da enumeração `AlinhamentoEnum`:
- Verifica os valores de alinhamento (Centro, Direita, Esquerda)
- Valida a ordem dos valores

## 🚀 Como Executar os Testes

### Usando Visual Studio
1. Abra a solução `Razor.sln`
2. Vá para **Test** > **Run All Tests** ou pressione `Ctrl+R, A`
3. O Test Explorer mostrará o resultado de todos os testes

### Usando Terminal (dotnet CLI)
```bash
# Executar todos os testes
dotnet test

# Executar testes com saída detalhada
dotnet test -v detailed

# Executar testes com cobertura de código
dotnet test /p:CollectCoverage=true

# Executar apenas uma classe de teste específica
dotnet test --filter "NamespaceName.IndexModelTests"

# Executar apenas um teste específico
dotnet test --filter "Name=IndexModelTests.FormatValue_WithValidCNPJ_ReturnsFormattedCNPJ"
```

## 📊 Cobertura de Testes

### IndexModelTests
- **FormatValue (CNPJ)**: 3 casos válidos + 3 inválidos + 1 nulo = 7 testes
- **FormatValue (IE)**: 3 casos válidos + 2 curtos + 1 nulo = 6 testes
- **FormatValue (Número)**: 3 casos válidos + 3 inteiros + 1 nulo = 7 testes
- **FormatValue (Moeda)**: 3 casos válidos + 2 decimais + 1 nulo = 6 testes
- **FormatValue (Sim/Não)**: 4 casos válidos + 2 inválidos = 6 testes
- **FormatValue (Mês/Ano)**: 2 casos válidos + 1 DateTime + 2 inválidos = 5 testes
- **FormatValue (Texto)**: 3 casos = 3 testes
- **GetAlignmentCss**: 5 casos (1, 2, 3, 0, 999) = 5 testes
- **GetLinkData**: 4 testes (válido, single, nulo, vazio)
- **OnGet**: 6 testes (ordem padrão, IE, CNPJ, contagem, colunas, propriedades)
- **ColunaCustomizada**: 2 testes (padrão, com propriedades)
- **Empresa**: 2 testes (padrão, com propriedades)

**Total: 55 testes**

## 📝 Padrão de Testes

Todos os testes seguem o padrão **AAA (Arrange, Act, Assert)**:
```csharp
[Fact]
public void TestName_Scenario_ExpectedResult()
{
    // Arrange - Preparar dados
    var input = "value";
    
    // Act - Executar ação
    var result = _indexModel.FormatValue(input, TipoDadoEnum.Texto);
    
    // Assert - Validar resultado
    Assert.Equal("value", result);
}
```

## 🧪 Frameworks Utilizados

- **xUnit**: Framework de testes
- **Microsoft.NET.Test.Sdk**: SDK do Visual Studio para testes
- **coverlet.collector**: Coleta de cobertura de código

## 📦 Dependências do Projeto

O projeto de testes referencia:
- `RazorDataPresentation.csproj` - Projeto principal

## ✅ Checklist de Validação

- [x] Formatação de CNPJ
- [x] Formatação de IE
- [x] Formatação de Número
- [x] Formatação de Moeda
- [x] Formatação de Sim/Não
- [x] Formatação de Mês/Ano
- [x] Formatação de Texto
- [x] Alinhamento CSS
- [x] Geração de dados de links
- [x] Inicialização de dados no OnGet
- [x] Definições de colunas
- [x] Definições de empresas
- [x] Enumerações

## 🔧 Troubleshooting

### Erro: "Projeto não encontrado"
Certifique-se de que o `RazorDataPresentation.Tests.csproj` está no diretório raiz junto com `RazorDataPresentation.csproj`.

### Erro: "Dependências não restauradas"
Execute:
```bash
dotnet restore
```

### Testes não aparecem no Test Explorer
1. Reconstrua a solução: `Ctrl+Shift+B`
2. Reabra o Test Explorer: **Test** > **Test Explorer**
3. Se persistir, execute: `dotnet build`

## 📈 Próximas Melhorias

- [ ] Testes de integração para Razor Pages
- [ ] Testes de performance
- [ ] Testes de validação de dados com múltiplos cenários edge
- [ ] Mock de dependências externas (quando aplicável)
- [ ] Testes de segurança XSS para renderização de HTML

---

**Nota**: Mantenha os testes atualizados conforme novas funcionalidades forem adicionadas ao projeto.
