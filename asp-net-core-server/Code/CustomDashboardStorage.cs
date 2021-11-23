using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace AspNetCoreDashboardBackend {
    public class CustomDashboardStorage : IDashboardStorage {
        private string dashboardTemplateFolder;
        private NorthwindContext nwindContext;

        public CustomDashboardStorage(string dashboardTemplateFolder, NorthwindContext nwindContext) {
            this.dashboardTemplateFolder = dashboardTemplateFolder;
            this.nwindContext = nwindContext;
        }
        
        public IEnumerable<DashboardInfo> GetAvailableDashboardsInfo() {
            return null;
        }

        public XDocument LoadDashboard(string dashboardID) {
            var path = Path.Combine(dashboardTemplateFolder, "dashboardTemplate.xml");
            var content = File.ReadAllText(path);

            var dashboard = new Dashboard();
            dashboard.LoadFromXDocument(XDocument.Parse(content));

            var product = nwindContext.Products.First(product => product.ProductID == Convert.ToInt32(dashboardID));

            dashboard.Title.Text = product.ProductName;

            return dashboard.SaveToXDocument();
        }

        public void SaveDashboard(string dashboardID, XDocument dashboard) {
            //throw new NotImplementedException();
        }
    }
}
