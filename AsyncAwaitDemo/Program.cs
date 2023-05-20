using System.Reflection.Metadata.Ecma335;

class Program
{
    static void Main()
    {
        PrintA();
        PrintB();

        var result = PrintC().Result;
        Console.WriteLine(result);

        Console.ReadLine();
    }

    //static void PrintA()
    //{
    //    for (int i = 1; i <= 5; i++)
    //    {
    //        Console.WriteLine($"PrintA() : {i}");
    //    }
    //}

    //static void PrintB()
    //{
    //    for (int i = 1; i <= 5; i++)
    //    {
    //        Console.WriteLine($"PrintB() : {i}");
    //    }
    //}

    static async Task PrintA()
    {
        await Task.Run(() =>
         {
             for (int i = 1; i <= 5; i++)
             {
                 Console.WriteLine($"PrintA() : {i}");
             }
         }
         );
    }

    static async Task PrintB()
    {
        await Task.Run(() =>
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"PrintB() : {i}");
            }
        }
        );
    }

    static async Task<string> PrintC()
    {
        // return new Task<string>(()=> "Hello");

        // making some other method calls for string value with await keyword

        return "Hello";
    }
}