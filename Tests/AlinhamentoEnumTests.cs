using Xunit;
using RazorDataPresentation.Pages;

namespace RazorDataPresentation.Tests;

public class AlinhamentoEnumTests
{
    [Fact]
    public void AlinhamentoEnum_HasCorrectValues()
    {
        // Assert
        Assert.Equal(1, (int)AlinhamentoEnum.Centro);
        Assert.Equal(2, (int)AlinhamentoEnum.Direita);
        Assert.Equal(3, (int)AlinhamentoEnum.Esquerda);
    }

    [Fact]
    public void AlinhamentoEnum_CentroValueIs1()
    {
        // Arrange & Act
        var value = AlinhamentoEnum.Centro;

        // Assert
        Assert.Equal(1, (int)value);
    }

    [Fact]
    public void AlinhamentoEnum_DireitaValueIs2()
    {
        // Arrange & Act
        var value = AlinhamentoEnum.Direita;

        // Assert
        Assert.Equal(2, (int)value);
    }

    [Fact]
    public void AlinhamentoEnum_EsquerdaValueIs3()
    {
        // Arrange & Act
        var value = AlinhamentoEnum.Esquerda;

        // Assert
        Assert.Equal(3, (int)value);
    }
}
