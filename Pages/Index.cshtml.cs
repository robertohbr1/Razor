using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorDataPresentation.Components;
using static RazorDataPresentation.Components.ColunaCustomizada;

namespace RazorDataPresentation.Pages
{
    public class IndexModel : PageModel
    {
        public List<ColunaCustomizada> TableColumns { get; set; } = new();
        public List<Empresa> Empresas { get; set; } = new();
        public List<ColunaCustomizada> ColunasNotasFiscais { get; set; } = new();
        public List<NotaFiscal> NotasFiscais { get; set; } = new();
        public string SelectedOrder { get; set; } = "IE";

        private readonly List<string> ColumnOrderIE = new() { "IE", "Nome", "AnoMes", "CNPJ", "antecipComEncDeclaracao", "antecipSemEncDeclaracao", "difalDeclaracao", "icmsStDeclaracao", "amparaStDeclaracao", "totalDeclaracao", "statusDescricao" };
        private readonly List<string> ColumnOrderCNPJ = new() { "CNPJ", "IE", "Codigo", "Nome", "AnoMes", "antecipSemEncDeclaracao", "difalDeclaracao", "icmsStDeclaracao", "amparaStDeclaracao", "totalDeclaracao", "statusDescricao" };

        public void OnGet(string order = "IE")
        {
            SelectedOrder = order;

            TableColumns = new List<ColunaCustomizada>
            {
                CreateColumn(nome: "IE", campo: "IE", texto: "IE", alinhamento: 1, tipo: TipoDadoEnum.IE, textoToolTip: "Inscrição Estadual da empresa", Link: "ShowInfo", LinkFields: new List<string> { "IE", "Nome" }),
                CreateColumn(nome: "Codigo", campo: "Codigo", texto: "Código", alinhamento: 2, tipo: TipoDadoEnum.Numero, textoToolTip: "Código único identificador da empresa"),
                CreateColumn(nome: "Nome", campo: "Nome", texto: "Nome", alinhamento: 3, tipo: TipoDadoEnum.Texto, textoToolTip: "Nome fantasia ou razão social da empresa"),
                CreateColumn(nome: "AnoMes", campo: "AnoMes", texto: "Ano/Mês", alinhamento: 1, tipo: TipoDadoEnum.MesAno, textoToolTip: "Ano e mês de referência dos dados"),
                CreateColumn(nome: "CNPJ", campo: "CNPJ", texto: "CNPJ", alinhamento: 1, tipo: TipoDadoEnum.CNPJ, textoToolTip: "Cadastro Nacional da Pessoa Jurídica", Link: "ShowCNPJ", LinkFields: new List<string> { "CNPJ" }),
                CreateColumn(nome: "antecipComEncDeclaracao", campo: "antecipComEncDeclaracao", texto: "Antecip com Enc.", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor de antecipação tributária com encargos na declaração"),
                CreateColumn(nome: "antecipSemEncDeclaracao", campo: "antecipSemEncDeclaracao", texto: "Antecip sem Enc.", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor de antecipação tributária sem encargos na declaração"),
                CreateColumn(nome: "difalDeclaracao", campo: "difalDeclaracao", texto: "DIFAL", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor do DIFAL (Diferencial de Alíquota) na declaração"),
                CreateColumn(nome: "icmsStDeclaracao", campo: "icmsStDeclaracao", texto: "ICMS-ST", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor do ICMS-ST (Substituição Tributária) na declaração"),
                CreateColumn(nome: "amparaStDeclaracao", campo: "amparaStDeclaracao", texto: "Ampara ST", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor do Amparo ST na declaração"),
                CreateColumn(nome: "totalDeclaracao", campo: "totalDeclaracao", texto: "Total", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor total declarado"),
                CreateColumn(nome: "statusDescricao", campo: "statusDescricao", texto: "Status", alinhamento: 3, tipo: TipoDadoEnum.Texto, textoToolTip: "Descrição do status da declaração (Declarado, Em Aberto, etc.)"),
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

            ColunasNotasFiscais = new List<ColunaCustomizada>
            {
                CreateColumn(nome: "Numero", campo: "Numero", texto: "Número", alinhamento: 2, tipo: TipoDadoEnum.Numero, textoToolTip: "Número da NF"),
                CreateColumn(nome: "Serie", campo: "Serie", texto: "Série", alinhamento: 1, tipo: TipoDadoEnum.Texto, textoToolTip: "Série da NF"),
                CreateColumn(nome: "DataEmissao", campo: "DataEmissao", texto: "Data de Emissão", alinhamento: 1, tipo: TipoDadoEnum.Texto, textoToolTip: "Data em que a nota foi emitida"),
                CreateColumn(nome: "CNPJEmitente", campo: "CNPJEmitente", texto: "CNPJ Emitente", alinhamento: 1, tipo: TipoDadoEnum.CNPJ, textoToolTip: "CNPJ do emitente da NF"),
                CreateColumn(nome: "NomeEmitente", campo: "NomeEmitente", texto: "Nome Emitente", alinhamento: 3, tipo: TipoDadoEnum.Texto, textoToolTip: "Nome do emitente"),
                CreateColumn(nome: "ValorTotal", campo: "ValorTotal", texto: "Valor Total", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor total da NF"),
                CreateColumn(nome: "ValorICMS", campo: "ValorICMS", texto: "Valor ICMS", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor do ICMS da NF"),
                CreateColumn(nome: "ValorIPI", campo: "ValorIPI", texto: "Valor IPI", alinhamento: 2, tipo: TipoDadoEnum.Moeda, textoToolTip: "Valor do IPI da NF"),
                CreateColumn(nome: "ChaveAcesso", campo: "ChaveAcesso", texto: "Chave de Acesso", alinhamento: 1, tipo: TipoDadoEnum.Texto, textoToolTip: "Chave de acesso de 44 dígitos"),
                CreateColumn(nome: "Status", campo: "Status", texto: "Status", alinhamento: 3, tipo: TipoDadoEnum.Texto, textoToolTip: "Status atual da NF (Autorizada, Cancelada)")
            };

            NotasFiscais = new List<NotaFiscal>
            {
                new NotaFiscal { Numero = 1001, Serie = "1", DataEmissao = new DateTime(2023, 1, 10), CNPJEmitente = "12345678000190", NomeEmitente = "A Empresa Exemplo Ltda.", ValorTotal = 1500.00m, ValorICMS = 270.00m, ValorIPI = 75.00m, ChaveAcesso = "35230112345678000190550010000010011000000011", Status = "Autorizada" },
                new NotaFiscal { Numero = 1002, Serie = "1", DataEmissao = new DateTime(2023, 1, 11), CNPJEmitente = "12345678000190", NomeEmitente = "A Empresa Exemplo Ltda.", ValorTotal = 3200.50m, ValorICMS = 576.09m, ValorIPI = 160.02m, ChaveAcesso = "35230112345678000190550010000010021000000022", Status = "Autorizada" },
                new NotaFiscal { Numero = 1003, Serie = "1", DataEmissao = new DateTime(2023, 1, 12), CNPJEmitente = "98765432000110", NomeEmitente = "Serviços Alpha S.A.", ValorTotal = 450.00m, ValorICMS = 81.00m, ValorIPI = 22.50m, ChaveAcesso = "35230198765432000110550010000010031000000033", Status = "Cancelada" },
                new NotaFiscal { Numero = 1004, Serie = "2", DataEmissao = new DateTime(2023, 2, 5), CNPJEmitente = "11222333000144", NomeEmitente = "Comércio Beta ME", ValorTotal = 8900.00m, ValorICMS = 1602.00m, ValorIPI = 445.00m, ChaveAcesso = "35230211222333000144550020000010041000000044", Status = "Autorizada" },
                new NotaFiscal { Numero = 1005, Serie = "2", DataEmissao = new DateTime(2023, 2, 18), CNPJEmitente = "11222333000144", NomeEmitente = "Comércio Beta ME", ValorTotal = 1250.75m, ValorICMS = 225.13m, ValorIPI = 62.53m, ChaveAcesso = "35230211222333000144550020000010051000000055", Status = "Autorizada" },
                new NotaFiscal { Numero = 1006, Serie = "1", DataEmissao = new DateTime(2023, 3, 1), CNPJEmitente = "55666777000188", NomeEmitente = "Logística Gama LTDA", ValorTotal = 5600.00m, ValorICMS = 1008.00m, ValorIPI = 280.00m, ChaveAcesso = "35230355666777000188550010000010061000000066", Status = "Autorizada" },
                new NotaFiscal { Numero = 1007, Serie = "1", DataEmissao = new DateTime(2023, 3, 15), CNPJEmitente = "55666777000188", NomeEmitente = "Logística Gama LTDA", ValorTotal = 7300.25m, ValorICMS = 1314.04m, ValorIPI = 365.01m, ChaveAcesso = "35230355666777000188550010000010071000000077", Status = "Autorizada" },
                new NotaFiscal { Numero = 1008, Serie = "3", DataEmissao = new DateTime(2023, 4, 10), CNPJEmitente = "22333444000155", NomeEmitente = "Tech Delta Tecnologia", ValorTotal = 12400.00m, ValorICMS = 2232.00m, ValorIPI = 620.00m, ChaveAcesso = "35230422333444000155550030000010081000000088", Status = "Cancelada" },
                new NotaFiscal { Numero = 1009, Serie = "3", DataEmissao = new DateTime(2023, 4, 22), CNPJEmitente = "22333444000155", NomeEmitente = "Tech Delta Tecnologia", ValorTotal = 890.00m, ValorICMS = 160.20m, ValorIPI = 44.50m, ChaveAcesso = "35230422333444000155550030000010091000000099", Status = "Autorizada" },
                new NotaFiscal { Numero = 1010, Serie = "1", DataEmissao = new DateTime(2023, 5, 5), CNPJEmitente = "33444555000166", NomeEmitente = "Financeira Épsilon SA", ValorTotal = 2100.50m, ValorICMS = 378.09m, ValorIPI = 105.02m, ChaveAcesso = "35230533444555000166550010000010101000000101", Status = "Autorizada" },
                new NotaFiscal { Numero = 1011, Serie = "1", DataEmissao = new DateTime(2023, 5, 12), CNPJEmitente = "33444555000166", NomeEmitente = "Financeira Épsilon SA", ValorTotal = 3450.00m, ValorICMS = 621.00m, ValorIPI = 172.50m, ChaveAcesso = "35230533444555000166550010000010111000000112", Status = "Autorizada" },
                new NotaFiscal { Numero = 1012, Serie = "2", DataEmissao = new DateTime(2023, 6, 8), CNPJEmitente = "44555666000177", NomeEmitente = "Construções Zeta Ltda.", ValorTotal = 15800.00m, ValorICMS = 2844.00m, ValorIPI = 790.00m, ChaveAcesso = "35230644555666000177550020000010121000000123", Status = "Cancelada" },
                new NotaFiscal { Numero = 1013, Serie = "2", DataEmissao = new DateTime(2023, 6, 20), CNPJEmitente = "44555666000177", NomeEmitente = "Construções Zeta Ltda.", ValorTotal = 4300.75m, ValorICMS = 774.13m, ValorIPI = 215.03m, ChaveAcesso = "35230644555666000177550020000010131000000134", Status = "Autorizada" },
                new NotaFiscal { Numero = 1014, Serie = "1", DataEmissao = new DateTime(2023, 7, 2), CNPJEmitente = "66777888000199", NomeEmitente = "Transporte Eta ME", ValorTotal = 950.00m, ValorICMS = 171.00m, ValorIPI = 47.50m, ChaveAcesso = "35230766777888000199550010000010141000000145", Status = "Autorizada" },
                new NotaFiscal { Numero = 1015, Serie = "1", DataEmissao = new DateTime(2023, 7, 18), CNPJEmitente = "66777888000199", NomeEmitente = "Transporte Eta ME", ValorTotal = 2780.00m, ValorICMS = 500.40m, ValorIPI = 139.00m, ChaveAcesso = "35230766777888000199550010000010151000000156", Status = "Autorizada" },
                new NotaFiscal { Numero = 1016, Serie = "4", DataEmissao = new DateTime(2023, 8, 11), CNPJEmitente = "77888999000111", NomeEmitente = "Consultoria Theta S.A.", ValorTotal = 11200.50m, ValorICMS = 2016.09m, ValorIPI = 560.02m, ChaveAcesso = "35230877888999000111550040000010161000000167", Status = "Cancelada" },
                new NotaFiscal { Numero = 1017, Serie = "4", DataEmissao = new DateTime(2023, 8, 25), CNPJEmitente = "77888999000111", NomeEmitente = "Consultoria Theta S.A.", ValorTotal = 6400.00m, ValorICMS = 1152.00m, ValorIPI = 320.00m, ChaveAcesso = "35230877888999000111550040000010171000000178", Status = "Autorizada" },
                new NotaFiscal { Numero = 1018, Serie = "1", DataEmissao = new DateTime(2023, 9, 3), CNPJEmitente = "88999000000122", NomeEmitente = "Educação Iota Ltda.", ValorTotal = 850.25m, ValorICMS = 153.04m, ValorIPI = 42.51m, ChaveAcesso = "35230988999000000122550010000010181000000189", Status = "Autorizada" },
                new NotaFiscal { Numero = 1019, Serie = "1", DataEmissao = new DateTime(2023, 9, 14), CNPJEmitente = "88999000000122", NomeEmitente = "Educação Iota Ltda.", ValorTotal = 1900.00m, ValorICMS = 342.00m, ValorIPI = 95.00m, ChaveAcesso = "35230988999000000122550010000010191000000190", Status = "Autorizada" },
                new NotaFiscal { Numero = 1020, Serie = "2", DataEmissao = new DateTime(2023, 10, 1), CNPJEmitente = "10101101000133", NomeEmitente = "Saúde Kappa Clínica", ValorTotal = 23000.00m, ValorICMS = 4140.00m, ValorIPI = 1150.00m, ChaveAcesso = "35231010101101000133550020000010201000000201", Status = "Cancelada" },
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

        public DataTableComponentParams GetDataTableParams()
        {
            return new DataTableComponentParams
            {
                Columns = TableColumns,
                Data = Empresas.Cast<object>().ToList()
            };
        }

        public DataTableComponentParams GetNotasFiscaisDataTableParams()
        {
            return new DataTableComponentParams
            {
                Columns = ColunasNotasFiscais,
                Data = NotasFiscais.Cast<object>().ToList()
            };
        }
    }
}
