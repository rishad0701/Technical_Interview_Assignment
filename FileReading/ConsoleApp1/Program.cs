// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");


using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"D:\ValueLBS.txt";  
        ReadFileContent(filePath);
    }

    static void ReadFileContent(string path)
    {
        try
        {
            if (File.Exists(path))
            {

                string content = File.ReadAllText(path);

                
                Console.WriteLine("Content of the file:");
                Console.WriteLine(content);
            }
            else
            {
                Console.WriteLine("The file does not exist at the specified path.");
            }
        }
        catch (Exception ex)
        {
            // Handle any exceptions that might occur (e.g., permission issues)
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }
    }
}

