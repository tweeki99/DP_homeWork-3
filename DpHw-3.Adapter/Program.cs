using System;

namespace DpHw_3.Adapter
{
    public interface ITarget
    {
        string Go();
    }
    
    // Класс машины который нужно адаптировать
    class Car
    {
        public string Drive()
        {
            return "Машина едет";
        }
    }
    
    // Адаптер для класса машины. Адаптирует его под общий интерфейс ITarget
    class CarAdapter : ITarget
    {
        private readonly Car _сar;

        public CarAdapter(Car сar)
        {
            this._сar = сar;
        }

        public string Go()
        {
            return $"CarAdapter: '{this._сar.Drive()}'";
        }
    }

    // Класс самолета который нужно адаптировать
    class Plane
    {
        public string Fly()
        {
            return "Самолет летит";
        }
    }
    
    // Адаптер для класса самолета. Адаптирует его под общий интерфейс ITarget
    class PlaneAdapter : ITarget
    {
        private readonly Plane _plane;

        public PlaneAdapter(Plane plane)
        {
            this._plane = plane;
        }

        public string Go()
        {
            return $"PlaneAdapter: '{this._plane.Fly()}'";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем два несовместимых класса
            Car car = new Car();
            Plane plane = new Plane();

            // Адаптируем их к одному интерфесу
            ITarget targetCar = new CarAdapter(car);
            ITarget targetPlane = new PlaneAdapter(plane);

            // Лицезреем плоды наших трудов
            Process(targetCar);
            Process(targetPlane);

            Console.ReadLine();
        }

        static void Process(ITarget target)
        {
            Console.WriteLine(target.Go());
        }
    }
}