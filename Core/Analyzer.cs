using ClosedXML.Excel;
using MissPoeAnalysis.Core;
using System.Diagnostics;
using System.IO;

namespace MissPoeAnalysis.Core
{
    public class Analyzer
    {
        public Analyzer(string? path)
        {
            if (path != null)
            {
                LoadBook(path);
            }

        }

        public void LoadBook(string path)
        {
            Debug.WriteLine($"Loading from: {path}");
            var workbook = new XLWorkbook(path);
            var worksheet = workbook.Worksheet("Kemasan Jaya");
            foreach (var row in worksheet.RowsUsed().Skip(2))
            {
                Debug.WriteLine(row.Cell(2).Value);
            }
        }

    }

}
