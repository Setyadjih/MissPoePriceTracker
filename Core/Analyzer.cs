using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.CustomUI;
using MissPoeAnalysis.Core.Data;
using MissPoeAnalysis.Core.Models;
using System.Diagnostics;
using System.IO;

namespace MissPoeAnalysis.Core
{
    public class Analyzer
    {
        public Analyzer(string? path, DBContext _context)
        {
            if (path != null)
            {
                LoadBook(path, _context);
            }

        }

        public void LoadBook(string path, DBContext dBContext)
        {
            Debug.WriteLine($"Loading from: {path}");
            var workbook = new XLWorkbook(path);
            HashSet<string> miscSheets = [
                "Sundries",
                "Fresh",
                "Packaging",
                "Utensils",
                "Cleaning",
                "Appliances",
                "Storage",
                "Stationery",
                "Advertising",
                "Utility",
                "Maintenance",
                "_IMPORT_",
                "DATA"
            ];
            foreach (var worksheet in workbook.Worksheets)
            {
                if (miscSheets.Contains(worksheet.Name)) continue;
                Debug.WriteLine($"Loading {worksheet.Name}");

                foreach (var row in worksheet.RowsUsed().Skip(2))
                {
                    var f = row.Cell("F").Value.GetNumber();
                    var d = row.Cell("D").Value.GetNumber();
                    var h = row.Cell("H").Value.GetNumber();
                    decimal unitPrice = (decimal)((f * d) / h);

                    CostingItem i = new()
                    {
                        Date = DateOnly.FromDateTime(row.Cell("A").CachedValue.GetDateTime()),
                        Name = row.Cell("B").CachedValue.ToString(),
                        Price = unitPrice,
                        Vendor = worksheet.Name
                    };
                    dBContext.Add(i);
                }
            }
            dBContext.SaveChanges();
        }

    }

}
