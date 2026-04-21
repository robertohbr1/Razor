namespace RazorDataPresentation
{
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
}