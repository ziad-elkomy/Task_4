namespace SearchTask2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string: ");
            string str = Console.ReadLine();
            bool has_vowel = false;
            string vowels = "aeiou";
            foreach(char c in str)
            {
                foreach(char c2 in vowels)
                {
                    if(c==c2)
                    {
                        has_vowel = true;
                        break;
                    }
                }
                if(has_vowel)
                {
                    break;
                }
            }
            if(!has_vowel)
            {
                throw new Exception("The string has no vowels");
            }
            else
            {
                Console.WriteLine("program finished successfully");
            }
        }
    }
}
