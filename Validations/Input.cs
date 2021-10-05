using System;

namespace App.Validations
{
    public class Input
    {
        public static int ToInt()
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int value))
                return value;

            throw new ArgumentException("Input value invalid!");
        }
    }
}