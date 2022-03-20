using System;
using System.Collections.Generic;
using org.mariuszgromada.math.mxparser;

namespace scienceCalcCLI
{
    public class Program
    {

        static List<Argument> argsList = new List<Argument>();

        static void Main(string[] args)
        {

            var line = "";

            do
            {
                line = Console.ReadLine().ToLower();
                processInput(line);

            } while (line != "quit");

        }

        static private void processInput(string line)
        {
            if (line.StartsWith("arg "))
            {
                addArgument(line);
            }
            else if (line.StartsWith("calc "))
            {
                Console.WriteLine(calculate(line));
            }
            else if (line == "help")
            {
                displayHelp();
            }
            else
            {
                Console.WriteLine(line == "quit" ? "" : "Don't know this kind of command");
            }
        }

        static private void addArgument(string line)
        {
            var cells = line.Replace("arg ", string.Empty).Split(" ");
            string name = cells[0];
            var value = "";
            for (int i = 1; i < cells.Length; i++)
            {
                value += cells[i];
            }
            Argument arg1 = new Argument($"{name} = {value}");
            argsList.Add(arg1);
        }


        static public double calculate(string line)
        {
            var expString = line.Replace("calc ", string.Empty).Trim();
            Expression e = new Expression(expString);
            e.addArguments(argsList.ToArray());
            return e.calculate();
        }

        static private void displayHelp()
        {
            Console.WriteLine("===Declaring arguments===");
            Console.WriteLine("arg variableName value");
            Console.WriteLine("arg x 25");
            Console.WriteLine("arg y 15\n");
            Console.WriteLine("===Evaluating expressions===");
            Console.WriteLine("calc expression");
            Console.WriteLine("calc (x + y) / 2");
        }

    }
}
