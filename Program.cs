using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

{
    class Program
    {
        /*
         *   Добавить метод вывода возраста машины.
         *   Создать массив объектов. Вывести:
         *   a) список автомобилей заданной марки;
         *   b) список автомобилей заданной модели, которые
         *   эксплуатируются больше n лет;
         */

        class Car
        {         
    
            private  long id;
            private  string brand;
            private  string model;
            private  int production_year;
            private  string color;
            private  int price;
            private readonly int hash;

            private static int carNumber = 0;

        private readonly string registration;
            public Car(int id, string brand, string model, int production_year, int price, string registration, string color = "")
            {
                this.id = id;
                this.brand = brand;
                this.model = model;
                this.production_year = production_year;
                this.price = price;
                this.registration = registration;
                this.color = color;

                hash = id % 15;
                carNumber++;
            }

            public Car() 
            {
                Random rand = new Random();
                int newId = rand.Next(1,10);
                SetId(newId);
                carNumber++;
            }

            public long GetId() => id;
            public string GetBrand() => brand;
            public string GetModel() => model;
            public int GetAge() => 2020 - production_year;
            public int GetProductionYear() => production_year;
            public string GetColor() => color;
            public int GetPrice() => price;
            static public int GetCarNumber() => carNumber;

            private void SetId(long newId) => id = newId;
            public void SetBrand(string newBrand) => brand = newBrand;
            public void SetModel(string newModel) => model = newModel;
            public void SetProductionYear(int newProduction_year) => production_year = newProduction_year;
            public void SetColor(string newColor) => color = newColor;
            public void SetPrice(int newPrice) => price = newPrice;



            // private Car() { }

            static Car() { }
        }

        static List<Car> CarsOlderThan (Car[] carList, string carModel, int age)
            {
            List<Car> resCarList = new List<Car>();
            foreach (Car car in carList)
            {

                if ((car.GetModel() == carModel) && car.GetAge() > age)
                {
                    resCarList.Add(car);
                }
            }
            return resCarList;
            }

        static List<Car> CarsOfBrand(Car[] carList, string carBrand)
        {
            List<Car> resCarList = new List<Car>();
            foreach (Car car in carList)
            {
                if (car.GetBrand() == carBrand)
                {
                    resCarList.Add(car); 
                }
            }
            return resCarList;
        }


        static void Main(string[] args)
        {

            Car[] carList = new Car[]
            {
               new Car(1, "Volvo", "A1", 2002, 100, "A1111", "red"),
               new Car(2, "Lada", "F3", 2020, 33000, "A1112"),
               new Car(3, "Volvo", "A1", 2003, 110, "A11113"),
               new Car(4, "Volvo", "A1", 2005, 120, "A11114"),
               new Car(5, "Audi", "D3", 2006, 1000, "A11115"),
               new Car(6, "Volvo", "A4", 2010, 300, "A11116"),
            };

            List<Car> resCarList = CarsOlderThan(carList, "A1", 16);
            foreach(var car in resCarList)
            {
                Console.WriteLine($"\t{car.GetModel()} ({car.GetAge()})");
            }

            Console.WriteLine();

            resCarList = CarsOfBrand(carList, "Volvo");
            foreach (var car in resCarList) 
            {
                Console.WriteLine($"\t{car.GetBrand()}: {car.GetModel()} ({car.GetAge()})");
            }

            Car RandomCar = new Car();
            Console.WriteLine($"\n{RandomCar.GetId()}");
            Console.WriteLine($"\nCar number: {Car.GetCarNumber()}");

            Console.Write("\n");
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

        }
    }
}
