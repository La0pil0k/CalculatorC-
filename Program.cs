using System;

namespace CalculatorC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool exit = true;
            while (exit)
            {
                Console.WriteLine("Введи calc, чтобы запустить калькулятор");
                Console.WriteLine("Введите hist, чтобы увидеть историю вычислений");
                Console.WriteLine("Введите AC для очистки истории");
                Console.WriteLine("Введите 0 для выхода");
                string select = Console.ReadLine();
                if (select == "calc")
                {
                    Funct.calc();
                }
                else if (select == "hist")
                {
                    Funct.Readfile();
                }
                else if (select == "0")
                {
                    exit = false;
                }
                else if (select == "AC")
                {
                     Funct.ClearFile();
                }
            }
        }
    }
}