

namespace ConsoleApp.FileHandling;

class Program
{
    // make automation applications 
    static void Main(string[] args)
    {

        var curDir = new DirectoryInfo(".");


        //Export();
        //FileReadWrite();
        //WorkWithDirectories();
        //WorkWithFiles();

        Console.ReadLine();
    }



    private static void FileReadWrite()
    {
        var path = @"C:\hasan\1.txt";
        //var fileContentLines = File.ReadAllLines(path);
        var fileContentString = File.ReadAllText(path);

        var destpath = @"C:\hasan\2.dat";
        var fs = File.Create(destpath);
        //var fs = File.Open(destpath,FileMode.Append);
        fs.Write(File.ReadAllBytes(path));
        fs.Close();
    }

    private static void WorkWithFiles()
    {
        var path = @"C:\hasan\";
        var listOfFiles = Directory.GetFiles(path, "", SearchOption.AllDirectories);
        var i = 1;
        foreach (var f in listOfFiles)
        {
            Console.WriteLine(f);
            var fileInfo = new FileInfo(f);
            Console.WriteLine($"file name is : {fileInfo.Name}");
            Console.WriteLine($"file size is : {fileInfo.Length} bytes, equal {fileInfo.Length / 1024} KB");
            Console.WriteLine();

            if (fileInfo.Extension == ".xlsx")
            {
                fileInfo.MoveTo($"{path}{fileInfo.CreationTime.Year}-Excel File Number {i}.xlsx");
            }

            i++;
        }
    }

    private static void WorkWithDirectories()
    {
        var path = @"C:\hasan\";
        if (Directory.Exists(path) == false)
            Directory.CreateDirectory(path);

        var listOfDirs = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        foreach (var dir in listOfDirs)
        {
            //Console.WriteLine(dir);
            var dirInfo = new DirectoryInfo(dir);
            Console.WriteLine($"name is : {dirInfo.Name}");
            Console.WriteLine($"name is : {dirInfo.FullName}");
            Console.WriteLine($"Length is : {dirInfo.GetFileSystemInfos().Length}");
            Console.WriteLine();

            if (dirInfo.Name == "hasan1")
            {
                dirInfo.MoveTo(path + "hasan2");
                Directory.CreateDirectory(path + "hasan2");
                //dirInfo.MoveTo(path + "hasan2");
            }
        }
    }

    private static void Export()
    {
        var persons = new List<PersonInfo>();
        persons.Add(new PersonInfo()
        {
            FirstName = "Mahmoud",
            LastName = "Savarian",
            Age = 33,
            NationalCode = "23105151851"
        });
        persons.Add(new PersonInfo()
        {
            FirstName = "asdf",
            LastName = "asdfg",
            Age = 33,
            NationalCode = "23105151851"
        });
        persons.Add(new PersonInfo()
        {
            FirstName = "sfgsdfx",
            LastName = "sfgsdfg",
            Age = 33,
            NationalCode = "23105151851"
        });

        var fp = @"C:\hasan\listOfPerson.csv";
        var f = File.Create(fp);
        f.Close();

        File.AppendAllText(fp, "firstname,lastname,age,nationalcode\n");
        foreach (var p in persons)
        {
            var personLine = $"{p.FirstName},{p.LastName},{p.Age},{p.NationalCode}\n";
            File.AppendAllText(fp, personLine);
        }
    }

    // برنامه ای بنوسید که لیست تمام پوشه های داخل یک مسیر را چاپ نماید/در یک فایل ذخیره کند/ از ورودی آدرس را بگیرد
    // یافتن همه فایل های اکسل در یک پوشه

    // کپی نمودن فایل ها در تمام فایل های یک پوشه در پوشه های دیگر
    // ایجاد یکسری فایل با یک تمپلیت مشخص


    // برنامه ای بنوسید که لیست تمام پوشه های داخل یک مسیر را چاپ نماید/در یک فایل ذخیره کند/ از ورودی آدرس را بگیرد

    // بررسی وجود یک پوشه به ازای هر داشن آموز موجود در لیست و ایجاد پوشه های لازم در هر پرونده


    // Import/Export

    public class PersonInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string NationalCode { get; set; }
    }
}
