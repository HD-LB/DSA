using System;

namespace Passwords
{
    class PasswordsStartup
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            string relations = Console.ReadLine();
            int k = int.Parse(Console.ReadLine());

            GenPasswords("", relations);
        }

        static void GenPasswords(string password, string relations)
        {
            if (password == string.Empty)
            {
                for (int i = 0; i <= 9; ++i)
                {
                    GenPasswords(i.ToString(), relations);
                }
                return;
            }

            int index = password.Length - 1;

            if (index >= relations.Length)
            {
                Console.WriteLine(password);
                return;
            }

            if (relations[index] == '=')
            {
                GenPasswords(password + password[index], relations);
            }
            else if (relations[index] == '<')
            {
                char last = password[index] == '0' ? '9' : (char)(password[index] - 1);

                for (char c = '1'; c <= last; ++c)
                {
                    GenPasswords(password + c, relations);
                }
            }
            else if (password[index] != '0')
            {
                GenPasswords(password + '0', relations);

                for (char c = (char)(password[index] + 1); c <= '9'; ++c)
                {
                    GenPasswords(password + c, relations);
                }
            }
        }
    }
}
