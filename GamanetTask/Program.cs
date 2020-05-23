using System;
using System.Text.RegularExpressions;

namespace GamanetTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputStr = GetInput();

            if (InputValidation(inputStr))
            {
                var sequence = inputStr.Split(":");
                var command = sequence[0][1];
                var parameters = sequence[1];

                ProcessData(command, parameters);
            }
            else Console.WriteLine("\nNACK");
        }

        /// <summary>
        /// Returns the input string provided through the Console, beginning with 'P' and ending with 'E'.
        /// </summary>
        private static string GetInput()
        {
            var inputStr = "";

            do
            {
                inputStr += Console.ReadKey().KeyChar;
                if (!inputStr.StartsWith("P"))
                    inputStr = "";
            } while (!inputStr.EndsWith("E"));

            return inputStr;
        }

        /// <summary>
        /// Validation of the input string.
        /// </summary>
        /// <param name="input">
        /// String to validate.
        /// </param>
        private static bool InputValidation(string input)
        {
            var pattern = @"P[TS]:[\s\S]*:E";
            var match = Regex.Match(input, pattern);

            return true ? match.Success : false;
        }

        /// <summary>
        /// Data processing depending on the given command.
        /// </summary>
        /// <param name="command"> Char value of the command:
        /// 'T' - Text
        /// 'S' - Sound 
        /// </param>
        /// <param name="parameters"> Parameters of desired command:
        /// String sequence in case 'Text' command
        /// Two Int numbers in case 'Sound' command (Frequency, duration)
        /// </param>
        private static void ProcessData(char command, string parameters)
        {
            switch (command)
            {
                case ('T'):
                    Console.WriteLine("\nACK");
                    Console.WriteLine(parameters);
                    break;
                case ('S'):
                    try
                    {
                        var paramsArray = parameters.Split(",");
                        var frequency = int.Parse(paramsArray[0]);
                        var duration = int.Parse(paramsArray[1]);

                        Console.WriteLine("\nACK");
                        Console.Beep(frequency, duration);
                    }
                    catch
                    {
                        Console.WriteLine("\nNACK");
                    }
                    break;
                default:
                    Console.WriteLine("\nNACK");
                    break;
            }
        }
    }
}
