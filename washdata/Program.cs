namespace washdata
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var importFile = new ImportFile();
            importFile.ImportCase();
            importFile.LoadData();
            var handledata = new HandleWashdata();
            int i = 0;
            var countNumber = importFile.DataList.Count;
            while (importFile.DataList.Count > 0)
            {
                i++;
                var item = importFile.DataList.Dequeue();
                handledata.UnitWashData(item);
                Console.WriteLine("  thi lan thu " + i + " /count " + countNumber);
                if (i % 2 == 0)
                {
                    int timeSleep = new Random().Next(3000, 6000);
                    Console.WriteLine("ngu khoang " + timeSleep / 1000);
                    Thread.Sleep(timeSleep);
                }
            }
        }
    }
}
