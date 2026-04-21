using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace RazorDataPresentation.Pages
{
    public class IndexModel : PageModel
    {
        public List<ColunaCustomizada> TableColumns { get; set; } = new();
        public List<Empresa> Empresas { get; set; } = new();
        public string SelectedOrder { get; set; } = "IE";

        private readonly List<string> ColumnOrderIE = new() { "IE", "Nome", "AnoMes", "CNPJ", "antecipComEncDeclaracao", "antecipSemEncDeclaracao", "difalDeclaracao", "icmsStDeclaracao", "amparaStDeclaracao", "totalDeclaracao", "statusDescricao" };
        private readonly List<string> ColumnOrderCNPJ = new() { "CNPJ", "IE", "Codigo", "Nome", "AnoMes", "antecipSemEncDeclaracao", "difalDeclaracao", "icmsStDeclaracao", "amparaStDeclaracao", "totalDeclaracao", "statusDescricao" };

        private ColunaCustomizada CreateColumn(string nome, string campo, string texto, int alinhamento, TipoDadoEnum tipo, bool ativo = true, string textoToolTip = "", bool chaveadoOnOff = true, bool impresso = true, string? Link = null, List<string>? LinkFields = null)
        {
            return new ColunaCustomizada
            {
                nome = nome,
                campo = campo,
                texto = texto,
                alinhamento = alinhamento,
                tipo = tipo,
                ativo = ativo,
                textoToolTip = textoToolTip,
                chaveadoOnOff = chaveadoOnOff,
                impresso = impresso,
                Link = Link,
                LinkFields = LinkFields
            };
        }

        public void OnGet(string order = "IE")
        {
            SelectedOrder = order;

            TableColumns = new List<ColunaCustomizada>
            {
                CreateColumn(nome: "IE", campo: "IE", texto: "IE", alinhamento: 1, tipo: TipoDadoEnum.IE, Link: "ShowInfo", LinkFields: new List<string> { "IE", "Nome" }),
                CreateColumn(nome: "Codigo", campo: "Codigo", texto: "Código", alinhamento: 2, tipo: TipoDadoEnum.Numero),
                CreateColumn(nome: "Nome", campo: "Nome", texto: "Nome", alinhamento: 3, tipo: TipoDadoEnum.Texto),
                CreateColumn(nome: "AnoMes", campo: "AnoMes", texto: "Ano/Mês", alinhamento: 1, tipo: TipoDadoEnum.MesAno),
                CreateColumn(nome: "CNPJ", campo: "CNPJ", texto: "CNPJ", alinhamento: 1, tipo: TipoDadoEnum.CNPJ, Link: "ShowCNPJ", LinkFields: new List<string> { "CNPJ" }),
                CreateColumn(nome: "antecipComEncDeclaracao", campo: "antecipComEncDeclaracao", texto: "Antecip com Enc.", alinhamento: 2, tipo: TipoDadoEnum.Moeda),
                CreateColumn(nome: "antecipSemEncDeclaracao", campo: "antecipSemEncDeclaracao", texto: "Antecip sem Enc.", alinhamento: 2, tipo: TipoDadoEnum.Moeda),
                CreateColumn(nome: "difalDeclaracao", campo: "difalDeclaracao", texto: "DIFAL", alinhamento: 2, tipo: TipoDadoEnum.Moeda),
                CreateColumn(nome: "icmsStDeclaracao", campo: "icmsStDeclaracao", texto: "ICMS-ST", alinhamento: 2, tipo: TipoDadoEnum.Moeda),
                CreateColumn(nome: "amparaStDeclaracao", campo: "amparaStDeclaracao", texto: "Ampara ST", alinhamento: 2, tipo: TipoDadoEnum.Moeda),
                CreateColumn(nome: "totalDeclaracao", campo: "totalDeclaracao", texto: "Total", alinhamento: 2, tipo: TipoDadoEnum.Moeda),
                CreateColumn(nome: "statusDescricao", campo: "statusDescricao", texto: "Status", alinhamento: 3, tipo: TipoDadoEnum.Texto),
            };

            ApplyColumnOrder(SelectedOrder == "IE" ? ColumnOrderIE : ColumnOrderCNPJ);

            Empresas = new List<Empresa>
            {
                new Empresa { Codigo = 1, Nome = "A Empresa Exemplo Ltda.", CNPJ = "12345678000190", IE = "123456789", AnoMes = new DateTime(2023, 1, 1), antecipComEncDeclaracao = 150000.00m, antecipSemEncDeclaracao = 25500.00m, difalDeclaracao = 5400.00m, icmsStDeclaracao = 3000.00m, amparaStDeclaracao = 1200.00m, totalDeclaracao = 165000.00m, statusDescricao = "Declarado" },
                new Empresa { Codigo = 2, Nome = "Serviços Alpha S.A.", CNPJ = "98765432000110", IE = "987654321", AnoMes = new DateTime(2023, 2, 1), antecipComEncDeclaracao = 235000.75m, antecipSemEncDeclaracao = 39950.13m, difalDeclaracao = 8505.03m, icmsStDeclaracao = 4700.02m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 3, Nome = "Comércio Beta ME", CNPJ = "11222333000144", IE = "112233445", AnoMes = new DateTime(2023, 3, 1), antecipComEncDeclaracao = 98000.20m, antecipSemEncDeclaracao = 16660.04m, difalDeclaracao = 3528.01m, icmsStDeclaracao = 1960.00m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 4, Nome = "Logística Gama LTDA", CNPJ = "55666777000188", IE = "556677889", AnoMes = new DateTime(2023, 4, 1), antecipComEncDeclaracao = 172500.10m, antecipSemEncDeclaracao = 29325.02m, difalDeclaracao = 6210.00m, icmsStDeclaracao = 3450.00m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 5, Nome = "Tech Delta Tecnologia", CNPJ = "22333444000155", IE = "223344556", AnoMes = new DateTime(2023, 5, 1), antecipComEncDeclaracao = 310000.00m, antecipSemEncDeclaracao = 52700.00m, difalDeclaracao = 11160.00m, icmsStDeclaracao = 6200.00m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Declarado" },
                new Empresa { Codigo = 6, Nome = "Financeira Épsilon SA", CNPJ = "33444555000166", IE = "334455667", AnoMes = new DateTime(2023, 6, 1), antecipComEncDeclaracao = 425000.45m, antecipSemEncDeclaracao = 72250.08m, difalDeclaracao = 15300.02m, icmsStDeclaracao = 8500.01m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 7, Nome = "Construções Zeta Ltda.", CNPJ = "44555666000177", IE = "445566778", AnoMes = new DateTime(2023, 7, 1), antecipComEncDeclaracao = 256000.00m, antecipSemEncDeclaracao = 43520.00m, difalDeclaracao = 9216.00m, icmsStDeclaracao = 5120.00m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 8, Nome = "Transporte Eta ME", CNPJ = "66777888000199", IE = "667788990", AnoMes = new DateTime(2023, 8, 1), antecipComEncDeclaracao = 118750.90m, antecipSemEncDeclaracao = 20187.65m, difalDeclaracao = 4275.83m, icmsStDeclaracao = 2375.02m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 9, Nome = "Consultoria Theta S.A.", CNPJ = "77888999000111", IE = "778899001", AnoMes = new DateTime(2023, 9, 1), antecipComEncDeclaracao = 98000.00m, antecipSemEncDeclaracao = 16660.00m, difalDeclaracao = 3528.00m, icmsStDeclaracao = 1960.00m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 10, Nome = "Educação Iota Ltda.", CNPJ = "88999000000122", IE = "889900112", AnoMes = new DateTime(2023, 10, 1), antecipComEncDeclaracao = 143250.30m, antecipSemEncDeclaracao = 24352.55m, difalDeclaracao = 5157.01m, icmsStDeclaracao = 2865.01m, amparaStDeclaracao = 2500.00m, totalDeclaracao = 275000.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 11, Nome = "Saúde Kappa Clínica", CNPJ = "10101101000133", IE = "101101123", AnoMes = new DateTime(2023, 11, 1), antecipComEncDeclaracao = 215000.00m, antecipSemEncDeclaracao = 36550.00m, difalDeclaracao = 7740.00m, icmsStDeclaracao = 4300.00m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 12, Nome = "Alimentos Lambda ME", CNPJ = "20202202000144", IE = "202202234", AnoMes = new DateTime(2023, 12, 1), antecipComEncDeclaracao = 189500.75m, antecipSemEncDeclaracao = 32215.13m, difalDeclaracao = 6825.03m, icmsStDeclaracao = 3790.02m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 13, Nome = "Energias Mu S.A.", CNPJ = "30303303000155", IE = "303303345", AnoMes = new DateTime(2024, 1, 1), antecipComEncDeclaracao = 397000.40m, antecipSemEncDeclaracao = 67490.07m, difalDeclaracao = 14292.02m, icmsStDeclaracao = 7940.01m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 14, Nome = "Imobiliária Nu Ltda.", CNPJ = "40404404000166", IE = "404404456", AnoMes = new DateTime(2024, 2, 1), antecipComEncDeclaracao = 278000.00m, antecipSemEncDeclaracao = 47260.00m, difalDeclaracao = 10008.00m, icmsStDeclaracao = 5560.00m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 15, Nome = "Indústria Xi S.A.", CNPJ = "50505505000177", IE = "505505567", AnoMes = new DateTime(2024, 3, 1), antecipComEncDeclaracao = 335500.55m, antecipSemEncDeclaracao = 57035.09m, difalDeclaracao = 12078.02m, icmsStDeclaracao = 6710.01m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 16, Nome = "Turismo Omicron ME", CNPJ = "60606606000188", IE = "606606678", AnoMes = new DateTime(2024, 4, 1), antecipComEncDeclaracao = 127400.00m, antecipSemEncDeclaracao = 21658.00m, difalDeclaracao = 4584.40m, icmsStDeclaracao = 2548.00m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 17, Nome = "Moda Pi Ltda.", CNPJ = "70707707000199", IE = "707707789", AnoMes = new DateTime(2024, 5, 1), antecipComEncDeclaracao = 92000.99m, antecipSemEncDeclaracao = 15640.17m, difalDeclaracao = 3312.04m, icmsStDeclaracao = 1840.02m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 18, Nome = "Biotech Rho S.A.", CNPJ = "80808808000100", IE = "808808890", AnoMes = new DateTime(2024, 6, 1), antecipComEncDeclaracao = 404500.20m, antecipSemEncDeclaracao = 68765.03m, difalDeclaracao = 14562.01m, icmsStDeclaracao = 8090.00m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 19, Nome = "Mídia Sigma Ltda.", CNPJ = "90909909000111", IE = "909909001", AnoMes = new DateTime(2024, 7, 1), antecipComEncDeclaracao = 129500.45m, antecipSemEncDeclaracao = 22015.08m, difalDeclaracao = 4665.02m, icmsStDeclaracao = 2590.01m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
                new Empresa { Codigo = 20, Nome = "Design Tau ME", CNPJ = "21212212000122", IE = "212212112", AnoMes = new DateTime(2024, 8, 1), antecipComEncDeclaracao = 74500.00m, antecipSemEncDeclaracao = 12665.00m, difalDeclaracao = 2685.00m, icmsStDeclaracao = 1490.00m, amparaStDeclaracao = 0.00m, totalDeclaracao = 0.00m, statusDescricao = "Em Aberto" },
            };
        }

        private void ApplyColumnOrder(List<string> columnOrder)
        {
            var ordered = new List<ColunaCustomizada>();

            foreach (var colName in columnOrder)
            {
                var col = TableColumns.FirstOrDefault(c => c.nome == colName);
                if (col != null)
                {
                    col.ativo = true;
                    ordered.Add(col);
                }
            }

            foreach (var col in TableColumns.Where(c => !ordered.Contains(c)))
            {
                col.ativo = false;
                ordered.Add(col);
            }

            TableColumns = ordered;
        }

        public string FormatValue(object? value, TipoDadoEnum tipoInfo)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return tipoInfo switch
            {
                TipoDadoEnum.Texto => value.ToString() ?? string.Empty,
                TipoDadoEnum.CNPJ => FormatCnpj(value),
                TipoDadoEnum.IE => FormatIe(value),
                TipoDadoEnum.Numero => FormatNumero(value),
                TipoDadoEnum.Moeda => FormatMoeda(value),
                TipoDadoEnum.SimNao => FormatSimNao(value),
                TipoDadoEnum.MesAno => FormatMesAno(value),
                _ => value.ToString() ?? string.Empty,
            };
        }

        public string GetLinkData(Empresa empresa, List<string>? linkFields)
        {
            if (linkFields == null || linkFields.Count == 0)
                return string.Empty;

            var values = new List<string>();
            foreach (var field in linkFields)
            {
                var value = empresa.GetType().GetProperty(field)?.GetValue(empresa);
                values.Add(value?.ToString() ?? string.Empty);
            }

            return string.Join("|", values);
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

        private static string FormatMesAno(object value)
        {
            if (DateTime.TryParse(value.ToString(), out var date))
            {
                return date.ToString("MM/yyyy");
            }
            return value.ToString() ?? string.Empty;
        }

        public string GetAlignmentCss(int alinhamento)
        {
            return alinhamento switch
            {
                1 => "center",
                2 => "right",
                3 => "left",
                _ => "left" // default to left
            };
        }
    }

    public class ColunaCustomizada
    {
        public string nome { get; set; } = string.Empty;
        public string campo { get; set; } = string.Empty;
        public string texto { get; set; } = string.Empty;
        public int alinhamento { get; set; } = 3;
        public TipoDadoEnum tipo { get; set; } = TipoDadoEnum.Texto;
        public bool ativo { get; set; } = true;
        public string textoToolTip { get; set; } = string.Empty;
        public bool chaveadoOnOff { get; set; } = true;
        public bool impresso { get; set; } = true;
        public string? Link { get; set; } // Padrão: tipo de ação a executar
        public List<string>? LinkFields { get; set; } // Campos da linha a usar no link
    }

    public enum TipoDadoEnum
    {
        Texto,
        CNPJ,
        IE,
        Numero,
        Moeda,
        SimNao,
        MesAno
    }
    
    public class Empresa
    {
        public int Codigo { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public string IE { get; set; } = string.Empty;
        public DateTime AnoMes { get; set; }
        public decimal antecipComEncDeclaracao { get; set; }
        public decimal antecipSemEncDeclaracao { get; set; }
        public decimal difalDeclaracao { get; set; }
        public decimal icmsStDeclaracao { get; set; }
        public decimal amparaStDeclaracao { get; set; }
        public decimal totalDeclaracao { get; set; }
        public string statusDescricao { get; set; } = string.Empty;
    }

    public enum AlinhamentoEnum {
      Centro = 1,
      Direita = 2,
      Esquerda = 3
    }

}
