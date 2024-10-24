

using OfficeOpenXml;

namespace washdata
{
    public class ImportFile
    {

        public List<WashDataItem> Data { get; set; }

        public Queue<WashDataItem> DataList { get; set; }
        public ImportFile()
        {
            Data = new List<WashDataItem>();
            DataList = new Queue<WashDataItem>();

        }

        protected string ReadvalueStringExcel(ExcelWorksheet excelworksheet, int row, int col)
        {
            var cellRange = excelworksheet.Cells[row, col];
            if (cellRange != null)
            {

                if (cellRange.Value != null)
                {
                    return cellRange.Value.ToString();
                }
            }
            return "";
        }
        public void ImportCase()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo("C:\\Users\\Admin\\Desktop\\miraeauto\\washdataNoanser.xlsx");
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
                int totalRows = workSheet.Rows.Count();
                for (int i = 2; i <= totalRows; i++)
                {
                    var noAgree = "";
                    var phoneNumber = "0" + ReadvalueStringExcel(workSheet, i, 1);
                    //var thamchieu1 = ReadvalueStringExcel(workSheet, i, 4);
                    //var thamchieu2 = ReadvalueStringExcel(workSheet, i, 5);
                    //var thamchieu3 = ReadvalueStringExcel(workSheet, i, 6);
                    if (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Length < 5)
                    {
                        continue;
                    }
                    var itemdata = new WashDataItem()
                    {
                        NoAgree = "",
                        Phone = phoneNumber,
                        //Phone1 = thamchieu1,
                        //Phone2 = thamchieu2,
                        //Phone3 = thamchieu3
                    };
                    Data.Add(itemdata);
                }
            }

        }

        public void LoadData()
        {

            foreach (var item in Data)
            {
                DataList.Enqueue(item);
            }


        }
    }
}
