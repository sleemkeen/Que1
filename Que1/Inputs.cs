namespace Que1
{
    public static class Inputs
    {
        public static DateTime ReadDate(string prompt = "Birthdate (e.g., 1 Jan 1990): ")
        {
            DateTime dob;

            while (true)
            {
                Console.Write($"{prompt}: ");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out dob))
                    return dob;

                Console.WriteLine("Invalid date format! Please try again.\n");
            }
        }
        
        public static string ReadString(string prompt)
        {
            Console.Write($"{prompt}: ");
            return Console.ReadLine();
        }
    }
}