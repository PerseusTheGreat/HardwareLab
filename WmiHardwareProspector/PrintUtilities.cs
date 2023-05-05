using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WmiHardwareProspector
{
    internal static class PrintUtilities
    {
        const char SPACE = ' ';
        const char DASH = '-';

        internal static void PrintList(this IEnumerable<(string Name, string Value)> informations, string caption)
        {
            Console.WriteLine($"== {caption}");

            if (informations == null)
                Console.WriteLine("   No information provided.");

            else
            {
                bool isMultiInstance = informations.Where(item => item.Name == "#").Any();
                if (isMultiInstance)
                {
                    foreach (var (name, value) in informations)
                    {
                        if (name == "#")
                            Console.WriteLine($" + Instance: {value}");

                        else
                            Console.WriteLine($"  - {name}: {value}");
                    }
                }
                else
                {
                    foreach (var (name, value) in informations)
                        Console.WriteLine($" - {name}: {value}");
                }
            }

            Console.WriteLine();
        }

        internal static void PrintTable(this IEnumerable<(string Name, string Value)> informations, string caption)
        {
            int captionLenght;
            string leftSpace;
            string rightSpace;
            string dashLine;

            if (informations == null)
            {
                string title;
                string message;

                if (caption.Length > 26)
                {
                    captionLenght = caption.Length;
                    leftSpace = string.Empty.PadRight((captionLenght - 24) / 2, SPACE);
                    rightSpace = string.Empty.PadRight((captionLenght - 24) - leftSpace.Length, SPACE);
                    dashLine = string.Empty.PadRight(captionLenght + 4, DASH);
                    title = caption;
                    message = $"{leftSpace}No information provided.{rightSpace}";
                }
                else
                {
                    captionLenght = 24 - caption.Length;
                    leftSpace = string.Empty.PadRight(captionLenght / 2, SPACE);
                    rightSpace = string.Empty.PadRight(captionLenght - leftSpace.Length, SPACE);
                    dashLine = "----------------------------";
                    title = $"{leftSpace}{caption}{rightSpace}";
                    message = "No information provided.";
                }

                Console.WriteLine(dashLine);
                Console.WriteLine($"| {title} |");
                Console.WriteLine(dashLine);
                Console.WriteLine($"| {message} |");
                Console.WriteLine(dashLine);
            }
            else
            {
                int maxLengthOfNames = informations.Select(item => item.Name.Length).Max();
                int maxLengthOfValues = informations.Select(item => item.Value.Length).Max();
                dashLine = string.Empty.PadRight(maxLengthOfNames + maxLengthOfValues + 7, DASH);

                captionLenght = maxLengthOfNames + maxLengthOfValues - caption.Length + 5;
                leftSpace = string.Empty.PadRight(captionLenght / 2, SPACE);
                rightSpace = string.Empty.PadRight(captionLenght - leftSpace.Length, SPACE);

                Console.WriteLine(dashLine);
                Console.WriteLine($"|{leftSpace}{caption}{rightSpace}|");
                Console.WriteLine(dashLine);

                bool isMultiInstance = informations.Where(item => item.Name == "#").Any();
                if (isMultiInstance)
                {
                    int tableWidth;
                    foreach (var (name, value) in informations)
                    {
                        if (name == "#")
                        {
                            tableWidth = maxLengthOfNames + maxLengthOfValues - (8 + value.Length);
                            leftSpace = string.Empty.PadRight(tableWidth / 2, SPACE);
                            rightSpace = string.Empty.PadRight(tableWidth - tableWidth / 2, SPACE);
                            Console.WriteLine($"| {leftSpace} Instance {value} {rightSpace} |");
                            Console.WriteLine(dashLine);
                        }
                        else
                            WriteRow(maxLengthOfNames, name, maxLengthOfValues, value);
                    }
                }
                else
                {
                    foreach (var (name, value) in informations)
                        WriteRow(maxLengthOfNames, name, maxLengthOfValues, value);
                }
            }

            Console.WriteLine();
            // End of method

            // Local Function
            void WriteRow(int maxLengthOfNames, string name, int maxLengthOfValues, string value)
            {
                leftSpace = string.Empty.PadRight(maxLengthOfNames - name.Length, SPACE);
                rightSpace = string.Empty.PadRight(maxLengthOfValues - value.Length, SPACE);
                Console.WriteLine($"| {name}{leftSpace} | {value}{rightSpace} |");
                Console.WriteLine(dashLine);
            }
        }

        internal static IEnumerable<(string, string)> GetEmptyDataForTestPrintingMethods() => null;
    }
}
