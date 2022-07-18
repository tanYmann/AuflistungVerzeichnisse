namespace AuflistungVerzeichnisse
{
    public class Program
    {
        public static string fileName = @"c:\tmp\Dateien.txt";
        public static FileStream file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        public static StreamWriter writer = new StreamWriter(file);
        public static  string path = @"P:\dokumente\BAUER";
        static void Main(string[] args)
        {
            FileListing(path);
        }
        public static void FileListing(string path)
        {
            
            DirectoryInfo dirinfo = new DirectoryInfo(path);
            DirectoryInfo[] directories = dirinfo.GetDirectories();
            foreach (DirectoryInfo d in directories)
            {
                Console.WriteLine(d.FullName);
                writer.WriteLine(d.FullName);
                foreach(FileInfo f in d.GetFiles())
                {
                    Console.WriteLine("╘------" + f.Name);
                    writer.WriteLine("╘-------" + f.Name);
                }
                if(d.GetDirectories() != null)
                {

                    FileListing(d.FullName);
                }
            }
         
        }
    }
}
