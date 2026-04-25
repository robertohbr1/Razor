namespace RazorDataPresentation
{
    public class NotaFiscal
    {
        public int Numero { get; set; }
        public string Serie { get; set; } = string.Empty;
        public DateTime DataEmissao { get; set; }
        public string CNPJEmitente { get; set; } = string.Empty;
        public string NomeEmitente { get; set; } = string.Empty;
        public decimal ValorTotal { get; set; }
        public decimal ValorICMS { get; set; }
        public decimal ValorIPI { get; set; }
        public string ChaveAcesso { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
