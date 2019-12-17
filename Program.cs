using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace _13laba
{
    class KIAlog
    {
        public FileInfo file;
        
        public KIAlog()
        {
            file = new FileInfo("D:\\OOP\\13laba\\kialogfile.txt");
        }
        public void Add(string a)
        {
            using (StreamWriter write = new StreamWriter(file.ToString(),true,Encoding.Default))
            {
                write.WriteLine(DateTime.Now + "-" + a);
            }
        }
        public void Read()
        {
            using (StreamReader reader = new StreamReader(file.ToString()))
            {
                int a = 0;
                while (true)
                {
                    if (reader.EndOfStream)
                        break;
                    Console.WriteLine(reader.ReadLine());
                    a++;
                }
                Console.WriteLine("Кол-во записей в файле: " + a);
            }
        }
        public void search()
        {
            Console.WriteLine("1-Произвести поиск по дате?");
            Console.WriteLine("2-Произвести поиск по ключевому слову?");
            int sh = Convert.ToInt32(Console.ReadLine());
            switch(sh)
            {
                case 1:
                    using (StreamReader reader = new StreamReader(file.ToString(), Encoding.Default))
                    {
                        Console.WriteLine("Введите дату в формате: <<00.00.0000>>");
                        string txt = Console.ReadLine();
                        while (true)

                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(txt))
                            {
                                Console.WriteLine("Ваша запись: " + reader.ReadLine());
                            }
                        }
                    }
                        break;
                case 2:
                    using (StreamReader reader = new StreamReader(file.ToString(), Encoding.Default))
                    {
                        Console.WriteLine("Введите ключевое слово поиска: ");
                        string txt = Convert.ToString(Console.ReadLine());
                        while (true)
                        {
                            if (reader.EndOfStream)
                            {
                                break;
                            }
                            if (reader.ReadLine().Contains(txt))
                            {
                                Console.WriteLine("Ваша запись: " + reader.ReadLine());
                            }
                        }
                    }
                    break;
            }
        }
       
    }
    class KIAdiscInfo : KIAlog
    {
        public void DiskInfo()
        {
            Add("(ADJDiskInfo)Получаем информацию о дисках системы.");
            var discinfo = DriveInfo.GetDrives();
            foreach (var d in discinfo)//перебираем 
            {
                if (!d.IsReady) continue;
                {
                    Console.WriteLine("Метка тома: {0}", d.RootDirectory);//метка тома.
                    Console.WriteLine("Имя диска: {0}", d.Name);//имя,
                    Console.WriteLine("Обьём: {0}", d.TotalSize);//объем,
                    Console.WriteLine("Доступный Обьём: {0}", d.AvailableFreeSpace);//доступный объем,
                    Console.WriteLine("Свободно места: {0}", d.TotalFreeSpace);//свободном месте на диске
                    Console.WriteLine("Файловая система: {0}", d.DriveFormat);//Файловой системе
                }
            }
        }
    }
    class KIAdirInfo : KIAlog
    {
        public void dirinfo()
        {
          
            string dirName = @"D:\\OOP";
            Add("(KIAdirInfo)Получаем информацию о файлах и директориях в " + dirName);
            string[] files = Directory.GetFiles(dirName);
            string[] dirr = Directory.GetDirectories(dirName);
            int a = 0;
            int b = 0;
            foreach (string s in files)
            {
                a++;//считаем количество файлов
            }
            foreach (string s in dirr)
            {
                b++;//считаем количество директориев
            }

            Console.WriteLine("Количество файлов в папке: " + a);//Количестве файлов
            Console.WriteLine("Время создания папки: " + Directory.GetCreationTime(dirName));//Время создания
            Console.WriteLine("Количетсво поддиректориев в папке: " + b);//Количестве поддиректориев
            Console.WriteLine("Список родительских директориев: " + Directory.GetParent(dirName));//Список родительских директориев

        }
    }
    class KIAfileInfo : KIAlog
    {
        public void fileinfo()
        {
            string fileName = @"D:\\OOP\\13laba\\kialogfile.txt";
            Add("(ADJFileInfo)Выполняем вывод информации о файле " + fileName);
            FileInfo fileInfo = new FileInfo(fileName);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Полный путь: {fileInfo.FullName}");
                Console.WriteLine($"Имя: {fileInfo.Name}");
                Console.WriteLine($"Расширение: {fileInfo.Extension}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер файла: {fileInfo.Length}");

            }

        }
    }

    class KIAFileManager : KIAlog
    {
        public string disk = "D:\\";//поле

        public DirectoryInfo[] directory;//массивный обьект класса DirestoryInfo
        public FileInfo fileee;//обьект класса FileInfo


        public string[] directoryes;
        public string[] files;


        public void Worker()//метод
        {
            Add("(KIAFileManager)Получаем файлы и директории в " + disk);
            directoryes = Directory.GetFiles(disk);//получаем все файлы в директории
            files = Directory.GetDirectories(disk);//получаем все директории в директории

            directory = new DirectoryInfo[2];
            directory[0] = new DirectoryInfo("D:\\OOP\\13laba\\KIAInspect");//Создать директорий XXXInspect,
            directory[1] = new DirectoryInfo("D:\\OOP\\13laba\\KIAFiles");
            directory[0].Create();
            directory[1].Create();
            fileee = new FileInfo("D:\\OOP\\13laba\\KIAdirinfo.txt");


            Add("Создаем файл" + fileee.ToString());
            Add("Записываем информацию о файлах и папках в " + fileee.ToString());

            using (StreamWriter fs = new StreamWriter(fileee.ToString(), true, System.Text.Encoding.Default))
            {
                foreach (string s in files)
                {
                    fs.WriteLine(s);
                }
                foreach (string s in directoryes)
                {
                    fs.WriteLine(s);
                }
                Console.WriteLine("Текст записан в файл.");
            }


            File.Copy("D:\\OOP\\13laba\\KIAdirinfo.txt", "D:\\OOP\\13laba\\KIAdirinfoCopy.txt");
            File.Delete("D:\\OOP\\13laba\\KIAdirinfo.txt");


            DirectoryInfo dir = new DirectoryInfo("D:\\OOP\\13laba\\good");//создал еще одну директорию
            Add("Получаем информацию о jpg файлах в D:\\OOP\\13laba\\good");
            FileInfo[] f = dir.GetFiles("*.jpg");//yokaryny oka
            Add("Копируем файлы jpg из good в MVSInspect");
            foreach (FileInfo s in f)
            {
                s.CopyTo("D:\\OOP\\13laba\\KIAFiles\\" + s.Name, true);//??
            }
            Add("Перемещаем " + directory[1].ToString() + " в " + directory[0].ToString());
            directory[1].MoveTo("D:\\OOP\\13laba\\KIAFiles");


            ZipFile.CreateFromDirectory(directory[1].ToString(), "D:\\OOP\\13laba\\ya.zip");//navedi
            Add("Разархивируем ya.zip в D:\\OOP\\13laba\\zipucin");
            ZipFile.ExtractToDirectory("D:\\OOP\\13laba\\ya.zip", "D:\\OOP\\13laba\\zipucin");


        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //KIAlog kIAlog = new KIAlog();
            //kIAlog.Add("laba");
            //kIAlog.Add("laba1");
            //kIAlog.Add("laba2");
            //kIAlog.Add("laba3");
            //kIAlog.Read();
            //kIAlog.search();
            //KIAdiscInfo kIAdiscInfo = new KIAdiscInfo();
            //kIAdiscInfo.DiskInfo();
            //KIAfileInfo kIAfileInfo = new KIAfileInfo();
            //kIAfileInfo.fileinfo();
            //KIAdirInfo kIAdirInfo = new KIAdirInfo();
            //kIAdirInfo.dirinfo();
            KIAFileManager kIAFileManager = new KIAFileManager();
            kIAFileManager.Worker();
            Console.ReadLine();
        }
    }
}

