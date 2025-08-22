using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Digite a primeira palavra:");
        string palavra1 = Console.ReadLine();

        Console.WriteLine("Digite a segunda palavra:");
        string palavra2 = Console.ReadLine();

        if (SaoAnagramas(palavra1, palavra2))
        {
            Console.WriteLine("Resultado: As palavras são anagramas!");
        }
        else
        {
            Console.WriteLine("Resultado: As palavras NÃO são anagramas!");
        }
    }

    static bool SaoAnagramas(string str1, string str2)
    {
        
        str1 = new string(str1.ToLower().Replace(" ", "").ToCharArray());
        str2 = new string(str2.ToLower().Replace(" ", "").ToCharArray());

       
        if (str1.Length != str2.Length)
            return false;

       
        char[] array1 = str1.ToCharArray();
        char[] array2 = str2.ToCharArray();

        Array.Sort(array1);
        Array.Sort(array2);

        
        return array1.SequenceEqual(array2);
    }
}
