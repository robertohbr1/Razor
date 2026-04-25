using System.Globalization;

namespace RazorDataPresentation.Components
{
    public static class DataTableFormatter
    {
        public static string FormatValue(object? value, TipoDadoEnum tipoInfo)
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

        public static string GetAlignmentCss(int alinhamento)
        {
            return alinhamento switch
            {
                1 => "center",
                2 => "right",
                3 => "left",
                _ => "left"
            };
        }

        public static string GetLinkData(object item, List<string>? linkFields)
        {
            if (linkFields == null || linkFields.Count == 0)
                return string.Empty;

            var values = new List<string>();
            foreach (var field in linkFields)
            {
                var value = item?.GetType().GetProperty(field)?.GetValue(item);
                values.Add(value?.ToString() ?? string.Empty);
            }

            return string.Join("|", values);
        }
    }
}
