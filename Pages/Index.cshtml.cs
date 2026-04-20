using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace RazorDataPresentation.Pages
{
    public class IndexModel : PageModel
    {
        public List<TableColumn> TableColumns { get; set; } = new();
        public List<Empresa> Empresas { get; set; } = new();
        public string SelectedOrder { get; set; } = "IE";

        private readonly List<string> ColumnOrderIE = new() { "IE", "Nome", "CNPJ", "ValorTotal", "ValorICMS", "ValorST", "ValorIPI" };
        private readonly List<string> ColumnOrderCNPJ = new() { "CNPJ", "IE", "Codigo", "Nome", "ValorICMS", "ValorST", "ValorIPI" };

        public void OnGet(string order = "IE")
        {
            SelectedOrder = order;

            TableColumns = new List<TableColumn>
            {
                new TableColumn { Column = nameof(Empresa.IE), Caption = "IE", Alignment = "center", TipoInfo = TipoInfo.IE },
                new TableColumn { Column = nameof(Empresa.Codigo), Caption = "Código", Alignment = "right", TipoInfo = TipoInfo.Numero },
                new TableColumn { Column = nameof(Empresa.Nome), Caption = "Nome", Alignment = "left", TipoInfo = TipoInfo.Texto },
                new TableColumn { Column = nameof(Empresa.CNPJ), Caption = "CNPJ", Alignment = "center", TipoInfo = TipoInfo.CNPJ },
                new TableColumn { Column = nameof(Empresa.ValorTotal), Caption = "Valor Total", Alignment = "right", TipoInfo = TipoInfo.Moeda },
                new TableColumn { Column = nameof(Empresa.ValorICMS), Caption = "Valor ICMS", Alignment = "right", TipoInfo = TipoInfo.Moeda },
                new TableColumn { Column = nameof(Empresa.ValorST), Caption = "Valor ST", Alignment = "right", TipoInfo = TipoInfo.Moeda },
                new TableColumn { Column = nameof(Empresa.ValorIPI), Caption = "Valor IPI", Alignment = "right", TipoInfo = TipoInfo.Moeda },
            };

            ApplyColumnOrder(SelectedOrder == "IE" ? ColumnOrderIE : ColumnOrderCNPJ);

            Empresas = new List<Empresa>
            {
                new Empresa { Codigo = 1, Nome = "A Empresa Exemplo Ltda.", CNPJ = "12345678000190", IE = "123456789", ValorTotal = 150000.00m, ValorICMS = 25500.00m, ValorST = 5400.00m, ValorIPI = 3000.00m },
                new Empresa { Codigo = 2, Nome = "Serviços Alpha S.A.", CNPJ = "98765432000110", IE = "987654321", ValorTotal = 235000.75m, ValorICMS = 39950.13m, ValorST = 8505.03m, ValorIPI = 4700.02m },
                new Empresa { Codigo = 3, Nome = "Comércio Beta ME", CNPJ = "11222333000144", IE = "112233445", ValorTotal = 98000.20m, ValorICMS = 16660.04m, ValorST = 3528.01m, ValorIPI = 1960.00m },
                new Empresa { Codigo = 4, Nome = "Logística Gama LTDA", CNPJ = "55666777000188", IE = "556677889", ValorTotal = 172500.10m, ValorICMS = 29325.02m, ValorST = 6210.00m, ValorIPI = 3450.00m },
                new Empresa { Codigo = 5, Nome = "Tech Delta Tecnologia", CNPJ = "22333444000155", IE = "223344556", ValorTotal = 310000.00m, ValorICMS = 52700.00m, ValorST = 11160.00m, ValorIPI = 6200.00m },
                new Empresa { Codigo = 6, Nome = "Financeira Épsilon SA", CNPJ = "33444555000166", IE = "334455667", ValorTotal = 425000.45m, ValorICMS = 72250.08m, ValorST = 15300.02m, ValorIPI = 8500.01m },
                new Empresa { Codigo = 7, Nome = "Construções Zeta Ltda.", CNPJ = "44555666000177", IE = "445566778", ValorTotal = 256000.00m, ValorICMS = 43520.00m, ValorST = 9216.00m, ValorIPI = 5120.00m },
                new Empresa { Codigo = 8, Nome = "Transporte Eta ME", CNPJ = "66777888000199", IE = "667788990", ValorTotal = 118750.90m, ValorICMS = 20187.65m, ValorST = 4275.83m, ValorIPI = 2375.02m },
                new Empresa { Codigo = 9, Nome = "Consultoria Theta S.A.", CNPJ = "77888999000111", IE = "778899001", ValorTotal = 98000.00m, ValorICMS = 16660.00m, ValorST = 3528.00m, ValorIPI = 1960.00m },
                new Empresa { Codigo = 10, Nome = "Educação Iota Ltda.", CNPJ = "88999000000122", IE = "889900112", ValorTotal = 143250.30m, ValorICMS = 24352.55m, ValorST = 5157.01m, ValorIPI = 2865.01m },
                new Empresa { Codigo = 11, Nome = "Saúde Kappa Clínica", CNPJ = "10101101000133", IE = "101101123", ValorTotal = 215000.00m, ValorICMS = 36550.00m, ValorST = 7740.00m, ValorIPI = 4300.00m },
                new Empresa { Codigo = 12, Nome = "Alimentos Lambda ME", CNPJ = "20202202000144", IE = "202202234", ValorTotal = 189500.75m, ValorICMS = 32215.13m, ValorST = 6825.03m, ValorIPI = 3790.02m },
                new Empresa { Codigo = 13, Nome = "Energias Mu S.A.", CNPJ = "30303303000155", IE = "303303345", ValorTotal = 397000.40m, ValorICMS = 67490.07m, ValorST = 14292.02m, ValorIPI = 7940.01m },
                new Empresa { Codigo = 14, Nome = "Imobiliária Nu Ltda.", CNPJ = "40404404000166", IE = "404404456", ValorTotal = 278000.00m, ValorICMS = 47260.00m, ValorST = 10008.00m, ValorIPI = 5560.00m },
                new Empresa { Codigo = 15, Nome = "Indústria Xi S.A.", CNPJ = "50505505000177", IE = "505505567", ValorTotal = 335500.55m, ValorICMS = 57035.09m, ValorST = 12078.02m, ValorIPI = 6710.01m },
                new Empresa { Codigo = 16, Nome = "Turismo Omicron ME", CNPJ = "60606606000188", IE = "606606678", ValorTotal = 127400.00m, ValorICMS = 21658.00m, ValorST = 4584.40m, ValorIPI = 2548.00m },
                new Empresa { Codigo = 17, Nome = "Moda Pi Ltda.", CNPJ = "70707707000199", IE = "707707789", ValorTotal = 92000.99m, ValorICMS = 15640.17m, ValorST = 3312.04m, ValorIPI = 1840.02m },
                new Empresa { Codigo = 18, Nome = "Biotech Rho S.A.", CNPJ = "80808808000100", IE = "808808890", ValorTotal = 404500.20m, ValorICMS = 68765.03m, ValorST = 14562.01m, ValorIPI = 8090.00m },
                new Empresa { Codigo = 19, Nome = "Mídia Sigma Ltda.", CNPJ = "90909909000111", IE = "909909001", ValorTotal = 129500.45m, ValorICMS = 22015.08m, ValorST = 4665.02m, ValorIPI = 2590.01m },
                new Empresa { Codigo = 20, Nome = "Design Tau ME", CNPJ = "21212212000122", IE = "212212112", ValorTotal = 74500.00m, ValorICMS = 12665.00m, ValorST = 2685.00m, ValorIPI = 1490.00m },
            };
        }

        private void ApplyColumnOrder(List<string> columnOrder)
        {
            var ordered = new List<TableColumn>();

            foreach (var colName in columnOrder)
            {
                var col = TableColumns.FirstOrDefault(c => c.Column == colName);
                if (col != null)
                {
                    col.Visible = true;
                    ordered.Add(col);
                }
            }

            foreach (var col in TableColumns.Where(c => !ordered.Contains(c)))
            {
                col.Visible = false;
                ordered.Add(col);
            }

            TableColumns = ordered;
        }

        public string FormatValue(object? value, TipoInfo tipoInfo)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return tipoInfo switch
            {
                TipoInfo.Texto => value.ToString() ?? string.Empty,
                TipoInfo.CNPJ => FormatCnpj(value),
                TipoInfo.IE => FormatIe(value),
                TipoInfo.Numero => FormatNumero(value),
                TipoInfo.Moeda => FormatMoeda(value),
                TipoInfo.SimNao => FormatSimNao(value),
                _ => value.ToString() ?? string.Empty,
            };
        }

        private static string FormatCnpj(object value)
        {
            var digits = new string((value.ToString() ?? string.Empty).Where(char.IsDigit).ToArray());
            if (digits.Length != 14)
            {
                return value.ToString() ?? string.Empty;
            }

            return string.Format("{0}.{1}.{2}/{3}-{4}",
                digits.Substring(0, 2),
                digits.Substring(2, 3),
                digits.Substring(5, 3),
                digits.Substring(8, 4),
                digits.Substring(12, 2));
        }

        private static string FormatIe(object value)
        {
            var raw = new string((value.ToString() ?? string.Empty).Where(char.IsLetterOrDigit).ToArray());
            if (raw.Length <= 3)
            {
                return raw;
            }

            return raw.Substring(0, 3) + "/" + raw.Substring(3);
        }

        private static string FormatNumero(object value)
        {
            return decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var number)
                ? number.ToString("N0", CultureInfo.GetCultureInfo("pt-BR"))
                : value.ToString() ?? string.Empty;
        }

        private static string FormatMoeda(object value)
        {
            return decimal.TryParse(value.ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, out var number)
                ? number.ToString("N2", CultureInfo.GetCultureInfo("pt-BR"))
                : value.ToString() ?? string.Empty;
        }

        private static string FormatSimNao(object value)
        {
            return bool.TryParse(value.ToString(), out var boolValue)
                ? (boolValue ? "Sim" : "Não")
                : value.ToString() ?? string.Empty;
        }
    }

    public class TableColumn
    {
        public string Column { get; set; } = string.Empty;
        public string Caption { get; set; } = string.Empty;
        public string Alignment { get; set; } = "left";
        public TipoInfo TipoInfo { get; set; } = TipoInfo.Texto;
        public bool Visible { get; set; } = true;
    }

    public enum TipoInfo
    {
        Texto,
        CNPJ,
        IE,
        Numero,
        Moeda,
        SimNao
    }

    public class Empresa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string IE { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal ValorST { get; set; }
        public decimal ValorIPI { get; set; }
    }
}
