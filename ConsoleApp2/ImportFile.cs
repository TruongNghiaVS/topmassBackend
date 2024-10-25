

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    public class ImportFile
    {

        public List<DataOverview> Data { get; set; }
        public Queue<DataOverview> DataList { get; set; }
        public ImportFile()
        {
            Data = new List<DataOverview>();
            DataList = new Queue<DataOverview>();

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

            var file = new FileInfo("C:\\Users\\Admin\\Desktop\\syncData\\vs-wash.xlsx");

            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets["Sheet1"];
                int totalRows = workSheet.Rows.Count();
                for (int i = 2; i <= totalRows; i++)
                {
                    ReadvalueStringExcel(workSheet, i, 1);
                    var itemdata = new DataOverview()
                    {
                        Name = ReadvalueStringExcel(workSheet, i, 1),
                        Phone = ReadvalueStringExcel(workSheet, i, 2),
                        Email = ReadvalueStringExcel(workSheet, i, 3),
                        TinhThanh = ReadvalueStringExcel(workSheet, i, 4),
                        Gender = ReadvalueStringExcel(workSheet, i, 5),
                        Dob = ReadvalueStringExcel(workSheet, i, 6),
                        JobName = ReadvalueStringExcel(workSheet, i, 7),
                        CVLink = ReadvalueStringExcel(workSheet, i, 8),
                        CVLink2 = ReadvalueStringExcel(workSheet, i, 9),
                        Introduction = ReadvalueStringExcel(workSheet, i, 10),
                        ContentCV = ReadvalueStringExcel(workSheet, i, 11),
                        DaiHoc = ReadvalueStringExcel(workSheet, i, 13)
                    };
                    Data.Add(itemdata);
                }
            }
        }

        private string GetAllDayOfBirth(string content)
        {

            Regex r = new Regex("^(?:(?:31(\\/|-|\\.)(?:0?[13578]|1[02]))\\1|(?:(?:29|30)(\\/|-|\\.)(?:0?[13-9]|1[0-2])\\2))(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$|^(?:29(\\/|-|\\.)0?2\\3(?:(?:(?:1[6-9]|[2-9]\\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\\d|2[0-8])(\\/|-|\\.)(?:(?:0?[1-9])|(?:1[0-2]))\\4(?:(?:1[6-9]|[2-9]\\d)?\\d{2})$");
            Match m = r.Match(content);
            if (m.Success)
            {
                return m.Value;
            }
            return "";

        }
        public void WritedFile()
        {
            var newFile = new FileInfo("C:\\Users\\Admin\\Desktop\\syncData\\output.xlsx");

            File.Delete("C:\\Users\\Admin\\Desktop\\syncData\\output.xlsx");
            using (ExcelPackage xlPackage = new ExcelPackage(newFile))
            {
                var workSheet = xlPackage.Workbook.Worksheets.Add("Sheet1");
                workSheet.TabColor = System.Drawing.Color.Black;
                workSheet.DefaultRowHeight = 12;
                // Setting the properties 
                // of the first row 



                workSheet.Row(1).Height = 20;
                workSheet.Row(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                workSheet.Row(1).Style.Font.Bold = true;
                workSheet.Cells[1, 1].Value = "Name";
                workSheet.Cells[1, 2].Value = "Phone";
                workSheet.Cells[1, 3].Value = "Email";
                workSheet.Cells[1, 4].Value = "Tinh thanh";
                workSheet.Cells[1, 5].Value = "Giới tính";
                workSheet.Cells[1, 6].Value = "DOb";
                workSheet.Cells[1, 7].Value = "JobName";
                workSheet.Cells[1, 8].Value = "CVFile";
                workSheet.Cells[1, 9].Value = "Link";
                workSheet.Cells[1, 10].Value = "Mô tả bản thân";
                workSheet.Cells[1, 11].Value = "Nội dung CV";
                workSheet.Cells[1, 12].Value = "Đại học";
                int inderow = 2;
                workSheet.Row(inderow).Style.Font.Bold = false;
                foreach (var item in Data)
                {
                    var gender = "";
                    if (item.ContentCV.ToLower().Contains("nữ") || item.ContentCV.ToLower().Contains(" female "))
                    {
                        gender = "Nữ";
                    }
                    if (item.ContentCV.ToLower().Contains(" nam ") || item.ContentCV.ToLower().Contains(" male "))
                    {
                        gender = "Nam";
                    }
                    var tinhthanh = "";
                    if (item.ContentCV.ToLower().Contains("ho chi minh")
                            ||
                            item.ContentCV.ToLower().Contains("hồ chí minh")
                            || item.ContentCV.ToLower().Contains("hcm")
                            || item.ContentCV.ToLower().Contains("hcm city")

                            || item.ContentCV.ToLower().Contains("tp.hcm")
                            )

                    {
                        tinhthanh = "Hồ Chí Minh";
                    }

                    var daihoctext = "";

                    if (item.ContentCV.ToLower().Contains("đại học")
                       ||
                       item.ContentCV.ToLower().Contains("university")

                       )

                    {
                        daihoctext = "Đại học";
                    }
                    if (item.ContentCV.ToLower().Contains("cao đẳng")
                       ||
                       item.ContentCV.ToLower().Contains("college")

                       )
                    {
                        daihoctext = "Cao đẳng";
                    }
                    workSheet.Cells[inderow, 1].Value = item.Name;
                    workSheet.Cells[inderow, 2].Value = item.Phone;
                    workSheet.Cells[inderow, 3].Value = item.Email;
                    workSheet.Cells[inderow, 4].Value = tinhthanh;
                    workSheet.Cells[inderow, 5].Value = gender;
                    workSheet.Cells[inderow, 6].Value = "";
                    workSheet.Cells[inderow, 7].Value = item.JobName;
                    workSheet.Cells[inderow, 8].Value = item.CVLink;
                    workSheet.Cells[inderow, 9].Value = item.CVLink2;
                    workSheet.Cells[inderow, 10].Value = item.Introduction;
                    workSheet.Cells[inderow, 11].Value = item.ContentCV;
                    workSheet.Cells[inderow, 12].Value = daihoctext;
                    inderow++;
                }
                xlPackage.Save();
            }
        }
    }
}

