using System;
using System.IO;

class Program
{
    static void Main()
    {
        // string filePath = "sample.csv";
        string filePath = "sample.txt";

        // Check if the file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        try
        {
            // Open the CSV file
            using (StreamReader reader = new StreamReader(filePath))
            {
                // Read the file line by line
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    // Split the line by the comma delimiter
                    string[] data = line.Split(',');

                    // Process the data as needed
                    foreach (string item in data)
                    {
                        Console.Write(item + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred while reading the file: " + ex.Message);
        }

        Console.ReadLine();
    }
}
