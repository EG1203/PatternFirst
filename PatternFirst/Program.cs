using System;
using System.Collections.Generic;


public interface IHouse
{
    void Construct(int number, string street);
}


public class House : IHouse
{
    readonly string type; 

    public House(string type)
    {
        this.type = type;
    }

    public void Construct(int number, string street)
    {
        Console.WriteLine($"Построен дом типа {type} по адресу {street}, {number}.");
    }
}


public class HouseFactory
{
    Dictionary<string, House> houses = new Dictionary<string, House>();

    public House GetHouse(string type)
    {
        House house = null;
        if (houses.ContainsKey(type))
        {
            house = houses[type];
        }
        else
        {
            switch (type)
            {
                case "Хрущевка":
                    house = new House("Хрущевка");
                    break;
                case "Панельный":
                    house = new House("Панельный");
                    break;
                    
            }
            houses[type] = house;
        }
        return house;
    }
}


class Program
{
    static void Main()
    {
        HouseFactory factory = new HouseFactory();

        IHouse house1 = factory.GetHouse("Хрущевка");
        house1.Construct(1, "Улица Ленина");

        IHouse house2 = factory.GetHouse("Панельный");
        house2.Construct(2, "Улица Пушкина");

        IHouse house3 = factory.GetHouse("Хрущевка");
        house3.Construct(3, "Улица Гоголя");
    }
}

