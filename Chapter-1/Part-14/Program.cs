#region Russian

/*

В листинге 1.13 можно видеть, что С# З существенно улучшает ситуацию, устраняя
незначительные аспекты, которые окружают логику делегата.

*/

// Листинг 1.13. Выполнение проверки с помощью лямбда-выражения (С# 3)

using System;
using System.Linq;
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

        private set
        {
            name = value;
        }
    }

    decimal price;
    public decimal Price
    {
        get
        {
            return price;
        }

        private set
        {
            price = value;
        }
    }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
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

    public static void Main()
    {
        List<Product> products = Product.GetSampleProducts();

        Console.OutputEncoding = System.Text.Encoding.Unicode;

        foreach (Product product in products.Where(p => p.Price > 10))
        {
            Console.WriteLine(product);
        }

        Console.ReadKey();
    }
}

/*

Сочетание лямбда-выражения, содержащего проверку, и хорошо именованного метода
дает возможность буквально читать код вслух и понимать его без раздумываний.
По-прежнему сохраняется гибкость С# 2 - аргумент метода WHere() может поступать
из переменной, и при желании можно применять тип Action<Product> вместо жестко
закодированного вызова Console.WriteLine().

Эта задача подчеркнула то, что уже известно из задачи с сортировкой: анонимные
методы упрощают написание делегатов, а лямбда-выражения еще больше сокращают
код. В обоих случаях такая краткость означает, что операцию запроса или сортировки
можно поместить внутрь первой части цикла foreach, не теряя ясности кода.

На рис. 1.3 приведена сводка по рассмотренным выше изменениям. В версии С# 4
не предлагается ничего такого, что могло бы дополнительно упростить решение этой
задачи.

*/

#endregion