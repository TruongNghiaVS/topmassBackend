namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var importfile = new ImportFile();
            importfile.ImportCase();
            var filePdf = new FilePdf();
            var indeError = 0;
            foreach (var item in importfile.Data)
            {
                var contentCV = filePdf.ReadFilePdf(item.CVLink);
                if (contentCV == "notfile")
                {
                    contentCV = filePdf.ReadFilePdf(item.CVLink2);
                }
                if (contentCV == "notfile")
                {
                    contentCV = "notfile";
                    indeError++;
                }
                item.ContentCV = contentCV;
            }
            importfile.WritedFile();
        }
    }
}
