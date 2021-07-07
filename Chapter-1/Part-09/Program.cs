#region Russian

/*
 
Итак, все ограничения, касающиеся кода на С# 1, ликвидированы. Однако это не
означает, что в С# З нельзя добиться дополнительных улучшений. Для начала заменим
анонимный метод еще более компактным способом создания экземпляра делегата (листинг 1.8).

*/

// Листинг 1.8. Сортировка с применением делегата Comparison<Product>,
// получаемого из лямбда-выражения (С# 3)

using System;
using System.Collections.Generic;

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
        return string.Format("{0}: {1:C}", name, price);
    }
}

class ArrayListSort
{
    static void Main()
    {
        List<Product> products = Product.GetSampleProducts();
        products.Sort((x, y) => x.Name.CompareTo(y.Name));

        Console.OutputEncoding = System.Text.Encoding.Unicode;

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }

        Console.ReadKey();
    }
}

/*

Синтаксис выглядит еще более странно (из-за наличия лямбда-выражения), но он
по-прежнему создает делегат Comparison<Product>, как в листинге 1.7, и на этот раз
с меньшей суетой. Нам не пришлось использовать ключевое слово delegate для определения
делегата или даже указывать типы его параметров.

*/

#endregion