using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {
        string number1 = "3-598-21508-8";
        string number2 = "3-598-21508-9";
        string number3 = "3-598-21507-X";
        Console.WriteLine(number1+"= "+CheckSum(number1));
        Console.WriteLine(number2 + "= " + CheckSum(number2));
        Console.WriteLine(number3 + "= " + CheckSum(number3));

    }
    public static int[] GetIntArray(string number) 
    {
        char[] numSplit = number.ToCharArray();
        numSplit = (char[])numSplit.Where(x=>x!='-').ToArray();
        int[] numInt = new int[numSplit.Length];
        if (numSplit.Last() == 'X')
        {
            numInt[numInt.Length - 1] = 10;
            for (int i = 0; i < numInt.Length - 1; i++)
            {
                numInt[i] = int.Parse(numSplit[i].ToString());
            }
            return numInt;
        }
        else return numInt = numSplit.Select(x => int.Parse(x.ToString())).ToArray();
    }
    public static bool CheckSum(string number) 
    {
        int[] array = GetIntArray(number);
        int checkSum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            checkSum += array[i] * (array.Length - i);
        }
        if (checkSum % 11 == 0) return true;
        else return false;
    }
}