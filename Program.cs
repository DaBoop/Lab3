using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace lab3
{ 
    class Program
    {

        partial class Car
        {         
    
            private  long id;
            private  string brand;
            private  string model;
            private  int production_year;
            private  string color;
            private  int price;
            private readonly int hash;
            
            private string registration;
            private static int carNumber = 0;


            public override string ToString() => $"{color} {Brand} {Model} ({production_year}) {price} - {registration} ({id})";
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
                int newId = new Random().Next(1,10);
                Id = newId;
                carNumber++;
                hash = GetHashCode();
            }

             ~Car()
            {
                carNumber--;
            }

            public override int GetHashCode()
            {
                HashCode hash = new HashCode();
                hash.Add(base.GetHashCode());
                hash.Add(Id);
                hash.Add(Brand);
                hash.Add(Model);
                hash.Add(Production_year);
                hash.Add(Price);
                return hash.ToHashCode();
            }

            public override bool Equals(object o)
            {

                if ((o == null) || !GetType().Equals(o.GetType()))
                {
                    return false;
                }
                else
                {
                    Car s = (Car)o;
                    return  (s.Id == Id) && (s.Color == Color) && (s.Registration == Registration) && (s.Price == Price) && (s.Model == Model) && (s.Brand == Brand) && (s.Production_year == Production_year);
                }
            }

            public string Registration
            {
                get => registration;
                set => registration = value;
            }

            static public int CarNumber
            {
                get => carNumber;
            }

            public long Id
            {
                get => id;
                set => id = value;
            }

            public string Brand
            {
                get => brand;
                set => brand = value;
            }

            public string Model
            {
                get => model;
                set => model = value;
            }
            public int Production_year
            {
                get => production_year;
                set => production_year = value;
            }
            public string Color
            {
                get => color;
                set => color = value;
            }
            public int Price
            {
                get => price;
                set => price = value;
            }

            public int GetAge() => 2020 - production_year;

            //private Car() { }
            static public string Info => $"Класс {typeof(Car)}, включающий {carNumber} объектов";
            static Car() { }
        }

        static List<Car> CarsOlderThan (Car[] carList, string carModel, int age)
            {
            List<Car> resCarList = new List<Car>();
            foreach (Car car in carList)
            {

                if ((car.Model == carModel) && car.GetAge() > age)
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
                if (car.Brand == carBrand)
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
               new Car(2, "Lada", "F3", 2020, 33000, "A1112", "blue"),
               new Car(3, "Volvo", "A1", 2003, 110, "A11113", "green"),
               new Car(4, "Volvo", "A1", 2005, 120, "A11114"),
               new Car(5, "Audi", "D3", 2006, 1000, "A11115"),
               new Car(6, "Volvo", "A4", 2010, 300, "A11116"),
            };

            List<Car> resCarList = CarsOlderThan(carList, "A1", 16);
            foreach (var car in resCarList)
            {
                Console.WriteLine($"\t{car.Model} ({car.GetAge()})");
            }

            Console.WriteLine();

            resCarList = CarsOfBrand(carList, "Volvo");
            foreach (var car in resCarList)
            {
                Console.WriteLine($"\t{car.Brand}: {car.Model} ({car.GetAge()})");
            }

            //Car RandomCar = new Car();
            //Console.WriteLine($"\n{RandomCar.Id}");
            Console.WriteLine(Car.Info);
            Console.WriteLine($"Равны ли {carList[0]} и {carList[1]}?: {Equals(carList[0], carList[1])}");


            var AnonCar = new { model = "Why", brand = "Do", price = 1, registration = "Exist", production_year = 1999, color = "blue" };

            Console.Write("\n");
            Console.Write("Press any key to continue . . . ");
            
            Console.ReadKey(true);

        }
    }
}
