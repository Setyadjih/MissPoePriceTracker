using ClosedXML.Excel;
using MissPoeAnalysis.Core;
using System.Diagnostics;
using System.IO;

Debug.WriteLine("Testing here");
string fp = "D:\\repos\\MissPoeAnalysis\\TestData\\Pembelian 2024.xlsx";
var foob = new Analyzer(fp);

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
