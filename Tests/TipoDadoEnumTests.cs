using Xunit;
using RazorDataPresentation.Pages;

namespace RazorDataPresentation.Tests;

public class TipoDadoEnumTests
{
    [Fact]
    public void TipoDadoEnum_HasAllRequiredValues()
    {
        // Assert
        Assert.Equal(0, (int)TipoDadoEnum.Texto);
        Assert.Equal(1, (int)TipoDadoEnum.CNPJ);
        Assert.Equal(2, (int)TipoDadoEnum.IE);
        Assert.Equal(3, (int)TipoDadoEnum.Numero);
        Assert.Equal(4, (int)TipoDadoEnum.Moeda);
        Assert.Equal(5, (int)TipoDadoEnum.SimNao);
        Assert.Equal(6, (int)TipoDadoEnum.MesAno);
    }
}
