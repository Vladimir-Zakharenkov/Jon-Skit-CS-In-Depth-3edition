#region Russian

// Хотя улучшение заметно, но было бы неплохо сортировать товары, просто указывая
// нужное сравнение и не реализуя для этого интерфейс. Именно это и делается в
// листинге 1.7, в котором с помощью делегата методу Sort() сообщается, каким образом
// сравнивать два товара.

//Листинг 1.7. Сортировка List<Product> с использованием делегата Comparison<Product> (C# 2)
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

public class Product
{
    string name;
    public string Name
    {
        get
        {
            return name;
        }
    }

    decimal price;
    public decimal Price
    {
        get
        {
            return price;
        }
    }

    public Product(string name, decimal price)
    {
        this.name = name;
        this.price = price;
    }

    public static List<Product> GetSampleProducts()
    {
        List<Product> list = new List<Product>();

        list.Add(new Product("West Side Story", 9.99m));
        list.Add(new Product("Assassins", 14.99m));
        list.Add(new Product("Frogs", 13.99m));
        list.Add(new Product("Sweeney Todd", 10.99m));
        return list;
    }

    public override string ToString()
    {
        return string.Format("{0}: {1}", name, price);
    }
}

class ArrayListSort
{
    static void Main()
    {
        List<Product> products = Product.GetSampleProducts();
        products.Sort(delegate (Product x, Product y)
        {
            return x.Name.CompareTo(y.Name);
        }
        );

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }

        //Задержка программы.
        Console.ReadKey();
    }
}

// Обратите внимание на отсутствие типа Р:осіцс1: Ыап1еСоп1раге:.Выделенный полужирным
// оператор создает экземпляр делегата, который предоставляется методу Sort()
// для выполнения сравнений. Вы изучите это средство (анонимные методы) в главе 5.

#endregion