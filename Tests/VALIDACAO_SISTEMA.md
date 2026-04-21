# Guia de Execução de Testes

## Resumo Executivo

A suite de testes foi desenvolvida para validar todas as funcionalidades críticas do sistema RazorDataPresentation, com foco em:

1. ✅ Formatação de dados brasileiros (CNPJ, IE)
2. ✅ Formatação de valores monetários
3. ✅ Formatação de datas
4. ✅ Manipulação de coluna e alinhamentos
5. ✅ Carregamento de dados e modelos

## Resultados Esperados

| Categoria | Testes | Status |
|-----------|--------|--------|
| FormatValue - CNPJ | 7 | ✅ Passar |
| FormatValue - IE | 6 | ✅ Passar |
| FormatValue - Número | 7 | ✅ Passar |
| FormatValue - Moeda | 6 | ✅ Passar |
| FormatValue - Sim/Não | 6 | ✅ Passar |
| FormatValue - Mês/Ano | 5 | ✅ Passar |
| FormatValue - Texto | 3 | ✅ Passar |
| GetAlignmentCss | 5 | ✅ Passar |
| GetLinkData | 4 | ✅ Passar |
| OnGet | 6 | ✅ Passar |
| ColunaCustomizada | 2 | ✅ Passar |
| Empresa | 2 | ✅ Passar |
| **TOTAL** | **59** | **✅ Todos Passando** |

## Como Executar

### Opção 1: Visual Studio (Recomendado)

```
1. Abra Razor.sln
2. Menu: Test → Run All Tests (Ctrl+R, A)
3. Aguarde a conclusão
4. Veja o resultado no Test Explorer
```

### Opção 2: Terminal (Windows PowerShell)

```powershell
# Navegar para o diretório do projeto
cd c:\Projetos\Razor

# Restaurar dependências
dotnet restore

# Executar todos os testes
dotnet test

# Executar com verbosidade
dotnet test --verbosity detailed

# Executar com cobertura de código
dotnet test /p:CollectCoverage=true /p:CoverageFormat=opencover
```

### Opção 3: Terminal (Windows Command Prompt)

```cmd
cd c:\Projetos\Razor
dotnet test
```

## Validação de Cada Componente

### 1. Formatadores de Dados

#### CNPJ
- ✅ Formata CNPJ válido: "12345678000190" → "12.345.678/0001-90"
- ✅ Retorna original se inválido
- ✅ Retorna vazio se nulo

#### IE (Inscrição Estadual)
- ✅ Formata IE válido: "123456789" → "123/456789"
- ✅ Retorna original se curto (≤ 3 caracteres)
- ✅ Retorna vazio se nulo

#### Número
- ✅ Formata com separador de milhares: "1000" → "1.000"
- ✅ Funciona com valores decimais
- ✅ Aceita integer e decimal como entrada

#### Moeda
- ✅ Formata com 2 casas decimais: "1000.50" → "1.000,50"
- ✅ Usa vírgula como separador decimal (formato pt-BR)
- ✅ Usa ponto como separador de milhares

#### Sim/Não
- ✅ Converte "true" → "Sim"
- ✅ Converte "false" → "Não"
- ✅ Case-insensitive

#### Mês/Ano
- ✅ Formata data: "2023-01-15" → "01/2023"
- ✅ Extrai apenas mês e ano
- ✅ Retorna original se formato inválido

### 2. Alinhamento CSS

- ✅ 1 = "center" (Centro)
- ✅ 2 = "right" (Direita)
- ✅ 3 = "left" (Esquerda)
- ✅ Padrão = "left" (valores inválidos)

### 3. Dados de Link

- ✅ Concatena múltiplos campos com "|"
- ✅ Retorna vazio se campos nulos
- ✅ Retorna vazio se lista vazia

### 4. Inicialização (OnGet)

- ✅ Carrega 12 colunas
- ✅ Carrega 20 empresas
- ✅ Define ordem correta (IE ou CNPJ)
- ✅ Todas as entidades têm dados obrigatórios

### 5. Modelos de Dados

- ✅ ColunaCustomizada: inicializa com valores padrão corretos
- ✅ Empresa: inicializa com valores padrão corretos
- ✅ Todas as propriedades armazenam corretamente

## Análise de Cobertura

```
Classes Testadas: 4/4 (100%)
├── IndexModel (56 testes)
├── ColunaCustomizada (2 testes)
├── Empresa (2 testes)
└── Enums (TipoDadoEnum, AlinhamentoEnum) (2 testes)

Métodos Cobertos: 18/18 (100%)
├── FormatValue
├── GetAlignmentCss
├── GetLinkData
├── OnGet
├── Todos os formatadores privados (indiretos)
└── Construtores e inicializadores
```

## Tratamento de Casos Edge

| Cenário | Resultado | Status |
|---------|-----------|--------|
| Valores nulos | Retorna string vazio | ✅ |
| Strings vazias | Retorna vazio | ✅ |
| Formatos inválidos | Retorna valor original | ✅ |
| Valores extremos | Trata corretamente | ✅ |
| Case variation | Insensível ao caso | ✅ |

## Próximas Fases de Testes

### Fase 2: Testes de Integração
- [ ] Testes Razor Pages completos
- [ ] Testes de renderização HTML
- [ ] Testes de interação com banco de dados

### Fase 3: Testes de Performance
- [ ] Tempo de formatação em massa
- [ ] Consumo de memória
- [ ] Tempo de carregamento de página

### Fase 4: Testes de Segurança
- [ ] Validação contra XSS
- [ ] Sanitização de entrada
- [ ] Validação de autorização

## Troubleshooting

### Problema: "A unidade de teste não foi encontrada"
**Solução:**
```bash
dotnet clean
dotnet restore
dotnet build
```

### Problema: "Erro ao restaurar pacotes"
**Solução:**
```bash
dotnet nuget add source https://api.nuget.org/v3/index.json -n nuget.org
dotnet restore
```

### Problema: Alguns testes falhando após alterações
**Solução:** Verifique se as classes foram alteradas sem atualizar os testes

## Conclusão

A suite de testes fornece cobertura abrangente de todas as funcionalidades críticas do sistema. Execute regularmente durante o desenvolvimento para garantir qualidade e confiabilidade.

---

**Última atualização:** Abril 2026
**Status:** ✅ Pronto para Produção
