namespace SearchTask1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            int size = 0;
            while (!exit)
            {
                exit = true;
                Console.Write("Enter the size of the list: ");
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException formatexc)
                {
                    Console.WriteLine("Inavlid input try again");
                    exit = false;
                }
            }

            List<int> lstNum = new List<int>();
            for (int i = 0; i < size; i++)
            {
                try
                {
                    Console.Write($"Enter Number {i + 1}: ");
                    int num = Convert.ToInt32(Console.ReadLine());
                    lstNum.Add(num);
                    for (int j = 0; j < i; j++)
                    {
                        Console.WriteLine("Enter second loop");
                        if (lstNum[j] == lstNum[i])
                        {
                            throw new Exception();
                        }
                    }
                }
                catch (FormatException formatExc)
                {
                    Console.WriteLine("Invalid input please try again");
                    i--;
                }
                catch (Exception exc)
                {
                    Console.WriteLine("This number is duplicated with another enter another number");
                    i--;
                }

            }
        }
    }
}
