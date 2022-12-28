

namespace ConsoleApp.FileHandling;

class Program
{
    // make automation applications 
    static void Main(string[] args)
    {

        var curDir = new DirectoryInfo(".");


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
        //ExtractSubDirectories();


        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("----------------------------------------------------");
        //ExtractFilesFromDirectories();

        Console.ReadLine();
    }

    private static void ExtractFilesFromDirectories()
    {
        // برنامه ای بنوسید که لیست تمام پوشه های داخل یک مسیر را چاپ نماید/در یک فایل ذخیره کند/ از ورودی آدرس را بگیرد
        // یافتن همه فایل های اکسل در یک پوشه
        string path = @"D:\Softwares";
        var files = Directory.GetFiles(path,"Tree*");
        foreach (var f in files)
        {
            Console.WriteLine(f);
            Console.WriteLine(Path.GetFullPath(f));
            Console.WriteLine(Path.GetFileName(f));
            Console.WriteLine(new FileInfo(f).Length);
        }

        // کپی نمودن فایل ها در تمام فایل های یک پوشه در پوشه های دیگر
        // ایجاد یکسری فایل با یک تمپلیت مشخص

        // File.Copy
        // File.Move
    }


    private static void ExtractSubDirectories()
    {
        // برنامه ای بنوسید که لیست تمام پوشه های داخل یک مسیر را چاپ نماید/در یک فایل ذخیره کند/ از ورودی آدرس را بگیرد

        string path = @"D:\Softwares";
        //var direntories = Directory.GetDirectories(path);
        var direntories = Directory.GetDirectories(path, "*", SearchOption.AllDirectories);
        foreach (var dir in direntories)
        {
            Console.WriteLine(dir);
        }

        //Directory.Exists("")

        // بررسی وجود یک پوشه به ازای هر داشن آموز موجود در لیست و ایجاد پوشه های لازم در هر پرونده
    }
}
