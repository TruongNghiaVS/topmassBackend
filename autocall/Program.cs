
using Excel = Microsoft.Office.Interop.Excel;

namespace autocall
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wbv = excel.Workbooks.Open("C:\\YourExcelSheet.xlsx");
            Excel.Worksheet wx = excel.ActiveSheet as Microsoft.Office.Interop.Excel.Worksheet;
            Console.WriteLine("Hello, World!");

        }
    }
}
