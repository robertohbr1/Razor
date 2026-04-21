namespace RazorDataPresentation
{
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
}