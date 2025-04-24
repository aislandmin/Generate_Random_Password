using System.Text;

namespace RandomPassword_XiaominGuo
{
    internal class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int pwLength = get_password_length();

            int pwChoiceNum = get_password_type_num();

            string? userChoiceYN;
            do
            {
                string password = password_generation(pwChoiceNum, pwLength); ;

                Console.WriteLine($"Password generated is: {password}");

                while (true)
                {
                    Console.WriteLine("Do you want to generate another password of the same type? (Y/N)");
                    userChoiceYN = Console.ReadLine();

                    if (string.IsNullOrEmpty(userChoiceYN) || 
                        (!userChoiceYN!.Equals("Y", StringComparison.OrdinalIgnoreCase) 
                         && !userChoiceYN!.Equals("N", StringComparison.OrdinalIgnoreCase)))
                    {
                        Console.WriteLine("Invalid input! Please enter Y or N");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            while (userChoiceYN!.Equals("Y", StringComparison.OrdinalIgnoreCase));


            //End the program, only when the user type in exit, either upper case or lower case.
            while (true)
            {
                Console.WriteLine("Please enter 'Exit' to end the program.");

                string? exitInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(exitInput) && "Exit".Equals(exitInput, StringComparison.OrdinalIgnoreCase))
                {
                    Environment.Exit(0);
                }
            }
        }

        private static string password_generation(int pwChoiceNum, int pwLength)
        {
            string password = "";

            switch (pwChoiceNum)
            {
                case 1:
                    password = password_alphabetsonly_xiaomin(pwLength);
                    break;
                case 2:
                    password = password_alphanumeric_xiaomin(pwLength);
                    break;
                case 3:
                    password = password_numbersonly_xiaomin(pwLength);
                    break;
            }

            return password;
        }

        // Generate password composition of numbers only 
        private static string password_numbersonly_xiaomin(int length)
        {
            const string numbers = "0123456789";
            StringBuilder password = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                password.Append(numbers[random.Next(numbers.Length)]);
            }

            return password.ToString();
        }

        // Generate password composition of alphanumeric (letters, numbers, special characters, lower case, upper case) 
        private static string password_alphanumeric_xiaomin(int length)
        {
            const string alphanumerics = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+=<>?";
            StringBuilder password = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                password.Append(alphanumerics[random.Next(alphanumerics.Length)]);
            }

            return password.ToString();
        }

        //Generate password composition of alphabets only (lower case or upper case)
        private static string password_alphabetsonly_xiaomin(int length)
        {
            const string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ";

            StringBuilder password = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                password.Append(letters[random.Next(letters.Length)]);
            }

            return password.ToString();
        }

        private static int get_password_type_num()
        {
            Console.WriteLine("Choose password type: ");
            Console.WriteLine("1: Alphabets only (lower case or upper case)");
            Console.WriteLine("2: Alphanumeric (letters, numbers, special characters, lower case, upper case) ");
            Console.WriteLine("3: Numbers only ");

            int pwChoiceNum = 0;
            while (true)
            {
                Console.WriteLine("Please enter the number consistent with your choice: ");
                if (int.TryParse(Console.ReadLine(), out pwChoiceNum) && pwChoiceNum >= 1 && pwChoiceNum <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 3");
                }
            }
            return pwChoiceNum;
        }

        private static int get_password_length()
        {
            int pwLength = 0;
            while (true)
            {
                Console.WriteLine("Please enter your desired password length: ");
                if (int.TryParse(Console.ReadLine(), out pwLength)
                    && pwLength > 0 && pwLength <= 1000)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a number between 1 and 1000");
                }
            }
            return pwLength;
        }
    }
}
