using System;

namespace ConsoleApp5
{
    class Program
    {
        static Material[] materials = Material.GetList();

static void countWeight(double densityMat)
        {
            double widthAluminum = readFromConsole("Какова ширина шины в мм");
            double thicknessAluminum = readFromConsole("Какова толщина шины в мм");
            double lengthAluminum = readFromConsole("Какова длина шины в м") / 1000.0;
            double resForAlu = (densityMat * widthAluminum * thicknessAluminum * lengthAluminum);

            Console.WriteLine($"{Math.Round(resForAlu, 3)} кг");
        }
        static int readFromConsole(string qwerty)
        {
            double numberOne;
            string strOne;
            int count = 3;

            do
            {

                if (count <= 0)
                {
                    Console.WriteLine("С вас достаточно");
                    throw new Exception();

                }
                if (count-- == 1)
                {
                    Console.WriteLine("Последнее предупреждение");
                }

                Console.WriteLine(qwerty);
                strOne = Console.ReadLine();
                
                if (double.TryParse(strOne,  out numberOne))
                {
                    break;
                }
                Console.WriteLine("Мама, слепи мне снежок!");


            }
            while (true);

            return (int)numberOne;


        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            Console.WriteLine("Добро пожаловать в калькулятор шин");
            try
            {
                do
                {
                    if (materials == null || materials.Length < 1)
                    {
                        Console.WriteLine("Отсутствует список материалов..");
                        break;
                    }

                    Console.WriteLine("\n\nДоступные материалы:");
                    for (int i = 0; i < materials.Length; i++)
                    {
                        Console.WriteLine($"{i}: {materials[i].Name} - {materials[i].Density}");
                    }

                    int choiceMaterial = readFromConsole("Выберите материал");
                    if (choiceMaterial >= 0 && choiceMaterial < materials.Length)
                    {
                        Console.WriteLine($"Считаем {materials[choiceMaterial].Name}");
                        countWeight(materials[choiceMaterial].Density);
                    }
                    else
                    {
                        Console.WriteLine("Сразу видно вы мудак");
                    }

                    Console.WriteLine("Для продолжения нажмите любую клавишу");
                    Console.WriteLine("Для выхода нажмите Escape");
                    key = Console.ReadKey();
                }

                while (key.Key != ConsoleKey.Escape);
            }
            catch { }
       
        }
    }
}
