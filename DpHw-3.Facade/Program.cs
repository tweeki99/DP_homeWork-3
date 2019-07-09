using System;

namespace DpHw_3.Facade
{
    // Создал 3 класса. Каждый совершает определенную операцию над числом

    // Отображает количество знаков в числе
    public class AmountOfNumbers
    {
        public void Operation(int number)
        {
            int digitCount = (int)Math.Log10(number) + 1;

            Console.WriteLine("Количество знаков: " + digitCount);
        }
    }

    // Отображает сумму знаков в числе
    public class SumOfNumbers
    {
        public void Operation(int number)
        {
            int n = Math.Abs(number);
            int sum = 0;
            while (n != 0)
            {
                sum += n % 10;
                n /= 10;
            }
            Console.WriteLine("Сумма знаков: " + sum);
        }
    }

    // Отображает квадрат числа
    public class SquareOfNumber
    {
        public void Operation(int number)
        {
            Console.WriteLine("Квадрат числа: " + (number * number));
        }
    }

    // Фасад позволяет объединить все эти действия и совершить все операции над числом в одном вызове
    public class Facade
    {
        protected AmountOfNumbers _amountOfNumbers;

        protected SumOfNumbers _sumOfNumbers;

        protected SquareOfNumber _squareOfNumber;

        public Facade(AmountOfNumbers amountOfNumbers, SumOfNumbers sumOfNumbers, SquareOfNumber squareOfNumber)
        {
            this._amountOfNumbers = amountOfNumbers;
            this._sumOfNumbers = sumOfNumbers;
            this._squareOfNumber = squareOfNumber;
        }

        public void Operation(int number)
        {
            Console.WriteLine("Число: " + number);
            _amountOfNumbers.Operation(number);
            _sumOfNumbers.Operation(number);
            _squareOfNumber.Operation(number);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляры классов
            AmountOfNumbers amountOfNumbers = new AmountOfNumbers();
            SumOfNumbers sumOfNumbers = new SumOfNumbers();
            SquareOfNumber squareOfNumber = new SquareOfNumber();

            // Объеденяем их
            Facade facade = new Facade(amountOfNumbers, sumOfNumbers, squareOfNumber);

            // Запускаем все методы на исполнение одной строчкой
            facade.Operation(12345);

            Console.ReadLine();
        }
    }
}