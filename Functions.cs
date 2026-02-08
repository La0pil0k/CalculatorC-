using System;
using System.IO;


namespace CalculatorC_
{
    public class Funct
    {
        private static string path;
        private static double num2;
        private static char act;

        private static void file(string info)
        {
            using (FileStream file = new FileStream("CalcHistory.txt", FileMode.OpenOrCreate))
            {
                path = file.Name;
                file.Close();
            }
            info += "\n";
            File.AppendAllText(path, info);
        }
        
        public static void calc()
        {
            bool exit = true;
            while (exit)
            {
                Console.WriteLine("Введите ваш пример(число действие число)(ОБЯЗАТЕЛЬНО ЧЕРЕЗ ПРОБЕЛ)");
                Console.WriteLine("Введите 0 для выхода из калькулятора");
                Console.WriteLine("Операторы действий:\n+ - сложить\n- - вычесть\n* - умножить\n/ - разделить\n# - возвести в степень\n% - остаток от деления\n! - факториал первого введённого числа"); 
                string test = Console.ReadLine();
                if (test == "0") break;
                else Funct.file(test);

                string[] nw = test.Split(new char[] { ' ' });
                try
                {
                    double num1 = double.Parse(nw[0]);
                    try
                    {
                        act = char.Parse(nw[1]);
                    } catch (System.IndexOutOfRangeException)
                    {
                        Console.WriteLine("Не введено действие!");
                        calc();
                    }
                    if (act == '!')
                    {
                        double nres = 1;
                        for (int i = 1; i <= num1; i++)
                        {
                            nres *= i;
                        }
                        Console.WriteLine("Ответ: " + nres);
                        string stresf = ("=" + nres + "\n");
                        Funct.file(stresf);
                        calc();
                    }
                    try
                    {
                        num2 = double.Parse(nw[2]);
                    } catch (System.IndexOutOfRangeException)
                    {
                        exit = false;
                    }
                    double res = 0;
                    bool boolres = false;
                    switch (act)
                    {
                        case '+': res = num1 + num2; boolres = true; break;
                        case '-': res = num1 - num2; boolres = true; break;
                        case '*': res = num1 * num2; boolres = true; break;
                        case '/': res = num1 / num2; boolres = true;  break;
                        case '%': res = num1 % num2; boolres = true;  break;
                        case '#': res = Math.Pow(num1, num2); boolres = true; break;
                    }
                    if (boolres)
                    {
                        Console.WriteLine("Ответ: " + res);
                        string stres = ("=" + res + "\n");
                        Funct.file(stres);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n!ОШИБКА! Возможно, вы забыли пробелы\n");
                    calc();
                }
            }
        }

        public static void Readfile()
        {
            using(FileStream file = File.OpenRead("CalcHistory.txt"))
            {
                byte[] array = new byte[file.Length];
                file.Read(array, 0, array.Length);

                string filetext = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine("История вычислений:\n"+filetext);
            }
        }

        public static void ClearFile() { 
        
          using (FileStream file = File.OpenWrite("CalcHistory.txt"))
          {
                Console.WriteLine("История Очищена!");
                byte[] ac = new byte[file.Length];
                file.Write(ac, 0, ac.Length);
          }
            
        }
        
    }
}

