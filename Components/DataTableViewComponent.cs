using Microsoft.AspNetCore.Mvc;

namespace RazorDataPresentation.Components
{
    public class DataTableViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(DataTableComponentParams viewModel)
        {
            return View("Default", viewModel);
        }
    }

    public class DataTableComponentParams
    {
        public List<ColunaCustomizada> Columns { get; set; } = new();
        public List<object> Data { get; set; } = new();
        public Func<int, string> GetAlignmentCss { get; set; } = (alinhamento) => DataTableFormatter.GetAlignmentCss(alinhamento);
        public Func<object?, TipoDadoEnum, string> FormatValue { get; set; } = (value, tipoInfo) => DataTableFormatter.FormatValue(value, tipoInfo);
        public Func<object, List<string>?, string> GetLinkData { get; set; } = (item, linkFields) => DataTableFormatter.GetLinkData(item, linkFields);
    }
}
