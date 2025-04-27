/* Лаборатоная 3. Контрольное упражнени 5 */
/*
  Требуется разработать программу, имитирующую стрельбу по мишени. 
Реализуйте следующую функциональность: 
•  Пользователь вводит данные о выстреле в виде пары чисел – координат x 
и y несколько раз.  
•  Повтор ввода  данных  о выстреле  следует организовать в цикле. После 
«стрельбы» пользователю выводится информация о сумме очков
*/

using System;
namespace TargetShooting
{
    public class TargetShooting
    {

        //Метод рассчета очков в зависимости от зоны попадания
        public static double CalculatePoints(ref double x, ref double y)
        {
            double ToltalPoints = 0; //храним очки тут

            if (y > 0)
            {  // Только верхняя полуплоскость
                if (x * x + y * y <= 1)
                {   // Центральная зона (радиус 1)
                    ToltalPoints = 10;               
                }
                else if (x * x + y * y <= 4)
                {   // Средняя зона (радиус 2)
                    ToltalPoints = 5;                  
                }
                else if (x * x + y * y <= 9)
                {   // Внешняя зона (радиус 3)
                    ToltalPoints = 1;                    
                }
                else
                {                      // За пределами мишени
                    ToltalPoints = 0;                    
                }
            }
            else // Нижняя полуплоскость
            {
                ToltalPoints = 0;

            }
            return ToltalPoints;
        }
        //Метод вывода промежуточных результатов
        public static void PrintResult (ref double tmp)
        {
            switch (tmp)
            {
                case 0:
                    Console.WriteLine("Результат: Промах (вне мишени)");
                    break;
                case 1:
                    Console.WriteLine("Результат: Зона 3 (1 очко)");
                    break;
                case 5:
                    Console.WriteLine("Результат: Зона 2 (5 очков)");
                    break;
                case 10:
                    Console.WriteLine("Результат: Зона 1 (10 очков)");
                    break;            
            }
        }

        static void Main(string[] args)
        {
            // Кординаты выстрелов
            double x = 0;
            double y = 0;

            double totalScore = 0;    // Общий счет очков
            uint NumShoot = 0;        //Текущая попытка
            uint MAX_SHOTS = 3;      // Количество попыток

            Console.WriteLine($"Стрельба по мишени. У вас {MAX_SHOTS} попытки.");

             while (MAX_SHOTS > NumShoot)
            {
                
                //Обработка исключений
                try
                {
                   Console.WriteLine($"Попытка: {NumShoot+1}");
                   Console.Write("\tВведите координату x: ");
                   x = double.Parse(Console.ReadLine());
                   
                   Console.Write("\tВведите координату y: ");
                   y = double.Parse(Console.ReadLine());
                }
                
                catch (FormatException e)
                {
                    Console.WriteLine("Вы должны ввести числовое значение!");
                     NumShoot = 0; //возвращаемся назад
                     continue; //начинаем с начала
                }
                double temp = CalculatePoints(ref x, ref y); //временная переменная для хранения промежуточных результатов
                PrintResult(ref temp);
                totalScore += CalculatePoints(ref x, ref y);
                NumShoot++; //увеличиваем попытку

            }
            Console.WriteLine($"\nВы получили {totalScore} очков!");
        }
            
    }
        
}

    


        




