using Xunit;
using RazorDataPresentation.Pages;
using RazorDataPresentation.Components;

namespace RazorDataPresentation.Tests;

public class IndexModelTests
{
    private readonly IndexModel _indexModel;

    public IndexModelTests()
    {
        _indexModel = new IndexModel();
    }

    #region FormatValue Tests

    #region FormatCnpj Tests
    [Theory]
    [InlineData("12345678000190", "12.345.678/0001-90")]
    [InlineData("98765432000110", "98.765.432/0001-10")]
    [InlineData("00000000000000", "00.000.000/0000-00")]
    public void FormatValue_WithValidCNPJ_ReturnsFormattedCNPJ(string cnpj, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(cnpj, TipoDadoEnum.CNPJ);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("abc")]
    [InlineData("")]
    public void FormatValue_WithInvalidCNPJ_ReturnsOriginalValue(string cnpj)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(cnpj, TipoDadoEnum.CNPJ);

        // Assert
        Assert.Equal(cnpj, result);
    }

    [Fact]
    public void FormatValue_WithNullCNPJ_ReturnsEmpty()
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(null, TipoDadoEnum.CNPJ);

        // Assert
        Assert.Empty(result);
    }
    #endregion

    #region FormatIE Tests
    [Theory]
    [InlineData("123456789", "123/456789")]
    [InlineData("987654321", "987/654321")]
    [InlineData("11223344", "112/23344")]
    public void FormatValue_WithValidIE_ReturnsFormattedIE(string ie, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(ie, TipoDadoEnum.IE);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("123")]
    [InlineData("12")]
    public void FormatValue_WithShortIE_ReturnsOriginalValue(string ie)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(ie, TipoDadoEnum.IE);

        // Assert
        Assert.Equal(ie, result);
    }

    [Fact]
    public void FormatValue_WithNullIE_ReturnsEmpty()
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(null, TipoDadoEnum.IE);

        // Assert
        Assert.Empty(result);
    }
    #endregion

    #region FormatNumero Tests
    [Theory]
    [InlineData("1000", "1.000")]
    [InlineData("1000000", "1.000.000")]
    [InlineData("123", "123")]
    public void FormatValue_WithValidNumber_ReturnsFormattedNumber(string number, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(number, TipoDadoEnum.Numero);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1000)]
    [InlineData(1000000)]
    [InlineData(123)]
    public void FormatValue_WithIntegerNumber_ReturnsFormattedNumber(int number)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(number, TipoDadoEnum.Numero);

        // Assert
        Assert.NotEmpty(result);
        Assert.True(char.IsDigit(result[0]));
    }

    [Fact]
    public void FormatValue_WithNullNumber_ReturnsEmpty()
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(null, TipoDadoEnum.Numero);

        // Assert
        Assert.Empty(result);
    }
    #endregion

    #region FormatMoeda Tests
    [Theory]
    [InlineData("1000.50", "1.000,50")]
    [InlineData("150000.00", "150.000,00")]
    [InlineData("25500.99", "25.500,99")]
    public void FormatValue_WithValidCurrency_ReturnsFormattedCurrency(string value, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(value, TipoDadoEnum.Moeda);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1000.50)]
    [InlineData(150000.00)]
    public void FormatValue_WithDecimalCurrency_ReturnsFormattedCurrency(decimal value)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(value, TipoDadoEnum.Moeda);

        // Assert
        Assert.NotEmpty(result);
        Assert.Contains(",", result);
    }

    [Fact]
    public void FormatValue_WithNullCurrency_ReturnsEmpty()
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(null, TipoDadoEnum.Moeda);

        // Assert
        Assert.Empty(result);
    }
    #endregion

    #region FormatSimNao Tests
    [Theory]
    [InlineData("true", "Sim")]
    [InlineData("false", "Não")]
    [InlineData("True", "Sim")]
    [InlineData("False", "Não")]
    public void FormatValue_WithValidBooleanString_ReturnsSimNao(string value, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(value, TipoDadoEnum.SimNao);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("invalid")]
    [InlineData("")]
    public void FormatValue_WithInvalidBoolean_ReturnsOriginalValue(string value)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(value, TipoDadoEnum.SimNao);

        // Assert
        Assert.Equal(value, result);
    }
    #endregion

    #region FormatMesAno Tests
    [Theory]
    [InlineData("2023-01-15", "01/2023")]
    [InlineData("2024-12-25", "12/2024")]
    public void FormatValue_WithValidDate_ReturnsFormattedMesAno(string dateString, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(dateString, TipoDadoEnum.MesAno);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FormatValue_WithDateTime_ReturnsFormattedMesAno()
    {
        // Arrange
        var date = new DateTime(2023, 5, 15);

        // Act
        var result = DataTableFormatter.FormatValue(date, TipoDadoEnum.MesAno);

        // Assert
        Assert.Equal("05/2023", result);
    }

    [Theory]
    [InlineData("invalid-date")]
    [InlineData("")]
    public void FormatValue_WithInvalidDate_ReturnsOriginalValue(string dateString)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(dateString, TipoDadoEnum.MesAno);

        // Assert
        Assert.Equal(dateString, result);
    }
    #endregion

    #region FormatTexto Tests
    [Theory]
    [InlineData("Texto simples", "Texto simples")]
    [InlineData("123", "123")]
    [InlineData("", "")]
    public void FormatValue_WithTexto_ReturnsOriginalValue(string texto, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.FormatValue(texto, TipoDadoEnum.Texto);

        // Assert
        Assert.Equal(expected, result);
    }
    #endregion

    #endregion

    #region GetAlignmentCss Tests

    [Theory]
    [InlineData(1, "center")]
    [InlineData(2, "right")]
    [InlineData(3, "left")]
    [InlineData(0, "left")]
    [InlineData(999, "left")]
    public void GetAlignmentCss_WithValidAlinhamento_ReturnsCorrectCss(int alinhamento, string expected)
    {
        // Arrange & Act
        var result = DataTableFormatter.GetAlignmentCss(alinhamento);

        // Assert
        Assert.Equal(expected, result);
    }

    #endregion

    #region GetLinkData Tests

    [Fact]
    public void GetLinkData_WithValidLinkFields_ReturnsFormattedData()
    {
        // Arrange
        var empresa = new Empresa
        {
            IE = "123456789",
            Nome = "Empresa Teste",
            CNPJ = "12345678000190"
        };
        var linkFields = new List<string> { "IE", "Nome" };

        // Act
        var result = DataTableFormatter.GetLinkData(empresa, linkFields);

        // Assert
        Assert.Equal("123456789|Empresa Teste", result);
    }

    [Fact]
    public void GetLinkData_WithSingleField_ReturnsValue()
    {
        // Arrange
        var empresa = new Empresa { CNPJ = "12345678000190" };
        var linkFields = new List<string> { "CNPJ" };

        // Act
        var result = DataTableFormatter.GetLinkData(empresa, linkFields);

        // Assert
        Assert.Equal("12345678000190", result);
    }

    [Fact]
    public void GetLinkData_WithNullLinkFields_ReturnsEmpty()
    {
        // Arrange
        var empresa = new Empresa();

        // Act
        var result = DataTableFormatter.GetLinkData(empresa, null);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public void GetLinkData_WithEmptyLinkFields_ReturnsEmpty()
    {
        // Arrange
        var empresa = new Empresa();
        var linkFields = new List<string>();

        // Act
        var result = DataTableFormatter.GetLinkData(empresa, linkFields);

        // Assert
        Assert.Empty(result);
    }

    #endregion

    #region OnGet Tests

    [Fact]
    public void OnGet_WithDefaultOrder_InitializesTableColumnsAndEmpresas()
    {
        // Arrange & Act
        _indexModel.OnGet();

        // Assert
        Assert.NotNull(_indexModel.TableColumns);
        Assert.NotEmpty(_indexModel.TableColumns);
        Assert.NotNull(_indexModel.Empresas);
        Assert.NotEmpty(_indexModel.Empresas);
        Assert.Equal("IE", _indexModel.SelectedOrder);
    }

    [Fact]
    public void OnGet_WithIEOrder_AppliesCorrectColumnOrder()
    {
        // Arrange & Act
        _indexModel.OnGet("IE");

        // Assert
        Assert.Equal("IE", _indexModel.SelectedOrder);
        Assert.Equal("IE", _indexModel.TableColumns.First(c => c.ativo).nome);
    }

    [Fact]
    public void OnGet_WithCNPJOrder_AppliesCorrectColumnOrder()
    {
        // Arrange & Act
        _indexModel.OnGet("CNPJ");

        // Assert
        Assert.Equal("CNPJ", _indexModel.SelectedOrder);
        Assert.Equal("CNPJ", _indexModel.TableColumns.First(c => c.ativo).nome);
    }

    [Fact]
    public void OnGet_CreatesCorrectNumberOfCompanies()
    {
        // Arrange & Act
        _indexModel.OnGet();

        // Assert
        Assert.Equal(20, _indexModel.Empresas.Count);
    }

    [Fact]
    public void OnGet_CreatesCorrectNumberOfColumns()
    {
        // Arrange & Act
        _indexModel.OnGet();

        // Assert
        Assert.Equal(12, _indexModel.TableColumns.Count);
    }

    [Fact]
    public void OnGet_AllColumnsHaveRequiredProperties()
    {
        // Arrange & Act
        _indexModel.OnGet();

        // Assert
        foreach (var column in _indexModel.TableColumns)
        {
            Assert.NotEmpty(column.nome);
            Assert.NotEmpty(column.campo);
            Assert.NotEmpty(column.texto);
            Assert.True(column.alinhamento >= 1 && column.alinhamento <= 3);
        }
    }

    [Fact]
    public void OnGet_AllCompaniesHaveRequiredData()
    {
        // Arrange & Act
        _indexModel.OnGet();

        // Assert
        foreach (var empresa in _indexModel.Empresas)
        {
            Assert.True(empresa.Codigo > 0);
            Assert.NotEmpty(empresa.Nome);
            Assert.NotEmpty(empresa.CNPJ);
            Assert.NotEmpty(empresa.IE);
            Assert.NotEmpty(empresa.statusDescricao);
        }
    }

    #endregion

    #region ColunaCustomizada Tests

    [Fact]
    public void ColunaCustomizada_DefaultInitialization_HasCorrectDefaults()
    {
        // Arrange & Act
        var coluna = new ColunaCustomizada();

        // Assert
        Assert.Empty(coluna.nome);
        Assert.Empty(coluna.campo);
        Assert.Empty(coluna.texto);
        Assert.Equal(3, coluna.alinhamento);
        Assert.Equal(TipoDadoEnum.Texto, coluna.tipo);
        Assert.True(coluna.ativo);
        Assert.True(coluna.chaveadoOnOff);
        Assert.True(coluna.impresso);
    }

    [Fact]
    public void ColunaCustomizada_WithAllProperties_StoresCorrectly()
    {
        // Arrange & Act
        var coluna = new ColunaCustomizada
        {
            nome = "Test",
            campo = "test_field",
            texto = "Test Field",
            alinhamento = 2,
            tipo = TipoDadoEnum.Moeda,
            ativo = false,
            textoToolTip = "Help text",
            chaveadoOnOff = false,
            impresso = false,
            Link = "testlink",
            LinkFields = new List<string> { "field1", "field2" }
        };

        // Assert
        Assert.Equal("Test", coluna.nome);
        Assert.Equal("test_field", coluna.campo);
        Assert.Equal("Test Field", coluna.texto);
        Assert.Equal(2, coluna.alinhamento);
        Assert.Equal(TipoDadoEnum.Moeda, coluna.tipo);
        Assert.False(coluna.ativo);
        Assert.Equal("Help text", coluna.textoToolTip);
        Assert.False(coluna.chaveadoOnOff);
        Assert.False(coluna.impresso);
        Assert.Equal("testlink", coluna.Link);
        Assert.NotNull(coluna.LinkFields);
        Assert.Equal(2, coluna.LinkFields.Count);
    }

    #endregion

    #region Empresa Tests

    [Fact]
    public void Empresa_DefaultInitialization_HasCorrectDefaults()
    {
        // Arrange & Act
        var empresa = new Empresa();

        // Assert
        Assert.Equal(0, empresa.Codigo);
        Assert.Empty(empresa.Nome);
        Assert.Empty(empresa.CNPJ);
        Assert.Empty(empresa.IE);
        Assert.Equal(default(DateTime), empresa.AnoMes);
        Assert.Equal(0, empresa.antecipComEncDeclaracao);
        Assert.Equal(0, empresa.antecipSemEncDeclaracao);
        Assert.Equal(0, empresa.difalDeclaracao);
        Assert.Equal(0, empresa.icmsStDeclaracao);
        Assert.Equal(0, empresa.amparaStDeclaracao);
        Assert.Equal(0, empresa.totalDeclaracao);
        Assert.Empty(empresa.statusDescricao);
    }

    [Fact]
    public void Empresa_WithAllProperties_StoresCorrectly()
    {
        // Arrange & Act
        var empresa = new Empresa
        {
            Codigo = 1,
            Nome = "Test Company",
            CNPJ = "12345678000190",
            IE = "123456789",
            AnoMes = new DateTime(2023, 1, 1),
            antecipComEncDeclaracao = 100000m,
            antecipSemEncDeclaracao = 50000m,
            difalDeclaracao = 5000m,
            icmsStDeclaracao = 3000m,
            amparaStDeclaracao = 2000m,
            totalDeclaracao = 160000m,
            statusDescricao = "Declarado"
        };

        // Assert
        Assert.Equal(1, empresa.Codigo);
        Assert.Equal("Test Company", empresa.Nome);
        Assert.Equal("12345678000190", empresa.CNPJ);
        Assert.Equal("123456789", empresa.IE);
        Assert.Equal(new DateTime(2023, 1, 1), empresa.AnoMes);
        Assert.Equal(100000m, empresa.antecipComEncDeclaracao);
        Assert.Equal(50000m, empresa.antecipSemEncDeclaracao);
        Assert.Equal(5000m, empresa.difalDeclaracao);
        Assert.Equal(3000m, empresa.icmsStDeclaracao);
        Assert.Equal(2000m, empresa.amparaStDeclaracao);
        Assert.Equal(160000m, empresa.totalDeclaracao);
        Assert.Equal("Declarado", empresa.statusDescricao);
    }

    #endregion
}
