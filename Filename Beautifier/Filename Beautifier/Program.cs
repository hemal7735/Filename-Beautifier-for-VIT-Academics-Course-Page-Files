using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Filename_Beautifier
{
    class Program
    {
        //string Extension = string.Empty;
        static void Main(string[] args)
        {
            Console.WriteLine("---THIS CONSOLE WILL RENAME YOUR VIT STUDENT LOGIN FILES OF THE FOLLOWING FORMAT---");
            Console.WriteLine("****(SEMNAME)YEAR_CPXXXX_DATE_XXXX_FILENAME***** TO ----------> FILENAME\n\n");
            Console.WriteLine("Select Choice:");

            Console.WriteLine("1.All files\n"+"2.Particular Extension file");
            bool valid = false; //check validity of the user
            int choice=0;
            // get the choice from the user
            while (!valid)
            {
                try { 
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice == 1 || choice == 2)
                    valid = true;
                    else
                    Console.WriteLine("Please provide proper choice");
                }
                catch (FormatException ex) { Console.WriteLine("Please provide proper choice"); }
            }
            // get the Current Path
            string path = Directory.GetCurrentDirectory();
            string[] allFilePaths = new string[] { };
            if (choice == 2)
            {
                
                Console.WriteLine("Enter type of file(extension):");
                string extension = Console.ReadLine();
                extension = extension.TrimStart(new char[] { '.' });
                allFilePaths = Directory.GetFiles(path, string.Format("*{0}",extension), SearchOption.AllDirectories);
            }
            else if (choice == 1)
            {
                allFilePaths = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
            }
            foreach (string filePath in allFilePaths)
            {

                string[] fileNameParts = Path.GetFileName(filePath).Split(new char[] { '_' }, 5);
                if (fileNameParts.Length == 5)
                {
                    try
                    {
                        File.Move(string.Format(@"{0}", filePath), string.Format(@"{0}\{1}", Path.GetDirectoryName(filePath), fileNameParts[4]));
                        Console.WriteLine("done");
                    }
                    catch (IOException ex) { }
                }
            }
            Console.ReadLine();
        }

    }
}

