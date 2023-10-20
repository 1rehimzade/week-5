using System;
using System.Reflection;

public abstract class Fruit
{
    public decimal Price { get; set; }
    public string Sort { get; set; }

    public abstract void Taste();
}

public class Apple : Fruit
{
    public decimal VitaminA { get; set; }
    public decimal VitaminB { get; set; }

    public override void Taste()
    {
        Console.WriteLine("Apple taste");
    }
}

public class Pineapple : Fruit
{
    public decimal VitaminE { get; set; }
    public decimal VitaminD { get; set; }

    public override void Taste()
    {
        Console.WriteLine("Pineapple taste");
    }
}

public class Orange : Fruit
{
    public decimal VitaminC { get; set; }

    public override void Taste()
    {
        Console.WriteLine("Orange taste");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Fruit[] basket = new Fruit[]
        {
            new Apple { Price = 2.5m, Sort = "Red", VitaminA = 1.2m, VitaminB = 0.8m },
            new Pineapple { Price = 3.0m, Sort = "Sweet", VitaminE = 0.5m, VitaminD = 0.3m },
            new Orange { Price = 1.0m, Sort = "Navel", VitaminC = 0.7m }
        };

        foreach (var fruit in basket)
        {
            Type fruitType = fruit.GetType();
            Console.WriteLine(fruitType.Name);

            FieldInfo[] fields = fruitType.GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (var field in fields)
            {
                object value = field.GetValue(fruit);
                Console.WriteLine($"{field.Name}: {value}");
            }

            Console.WriteLine();
        }
    }
}
