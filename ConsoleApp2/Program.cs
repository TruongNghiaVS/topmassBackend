namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            string sourceFile = @"C:\Users\Admin\Downloads\file.pdf";
            string descFile = @"C:\Users\Admin\Downloads\original_with_text_replaced.pdf";
            PDFEdit pdfObj = new PDFEdit();
            pdfObj.ReplaceTextInPDF(sourceFile, descFile, "Vietnam", "xxxx");
        }
    }
}
