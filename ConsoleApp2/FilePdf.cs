using Docnet.Core;
using Docnet.Core.Models;

namespace ConsoleApp2
{
    public class FilePdf
    {
        public string ReadFilePdf(string filesource)
        {
            if (string.IsNullOrEmpty(filesource))
            {
                return "notfile";
            }



            var filePath = "C:\\vietbank\\crm\\topmass\\ConsoleApp2" + filesource;
            if (!File.Exists(filePath))
            {
                return "notfile";
            }

            try
            {
                using (var docReader = DocLib.Instance.GetDocReader(filePath, new PageDimensions()))
                {
                    for (var i = 0; i < docReader.GetPageCount(); i++)
                    {
                        using (var pageReader = docReader.GetPageReader(i))
                        {
                            var text = pageReader.GetText();
                            return text;
                        }
                    }
                }
            }
            catch (Exception)
            {

                return "no content 1";
            }

            return "no content";
        }
    }
}

