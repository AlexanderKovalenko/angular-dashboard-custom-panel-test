using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDashboardBackend {
    [Route("dashboardpanel")]
    public class DashboardPanelController: Controller {
        private NorthwindContext nwindContext;

        public DashboardPanelController(NorthwindContext nwindContext) {
            this.nwindContext = nwindContext;
        }

        [HttpGet("dashboards")]
        public async Task<IActionResult> Dashboards(DataSourceLoadOptions loadOptions) {
            var source = nwindContext.Products.Select(o => new {
                o.ProductID,
                o.ProductName,
            });

            loadOptions.PrimaryKey = new[] { "ProductId" };
            loadOptions.PaginateViaPrimaryKey = true;

            return Json(await DataSourceLoader.LoadAsync(source, loadOptions));
        }
    }
}