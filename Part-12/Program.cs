#region Russian

/*

В листинге 1.11 видно, что С# 2 позволяет несколько выправить ситуацию.

*/

// Листинг 1.11. Отделение проверки от вывода (С# 2)

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
        List<Product> product = Product.GetSampleProducts();

        System.Console.OutputEncoding = System.Text.Encoding.Unicode;

        Predicate<Product> test = delegate (Product p) { return p.Price > 10m; };

        List<Product> matches = product.FindAll(test);

        Action<Product> print = Console.WriteLine;

        matches.ForEach(print);

        System.Console.ReadKey();
    }
}

/*

Переменная test инициализируется с использованием средства анонимных методов,
которое использовалось в предыдущем разделе. Переменная print инициализируется с
применением другого средства, появившегося в С# 2, которое называется преобразованиями
групп методов и упрощает создание делегатов из существующих методов.

Я не буду утверждать, что этот код проще, чем код С# 1, но он определенно намного мощнее(3).

(3) В некотором смысле это не совсем так. В С# 1 можно было бы определить соответствующие
делегаты и обращаться к ним внутри цикла. Методы FindAll() и ForEach() в .NET 2.0 просто
содействуют соблюдению принципа разделения ответственности.

*/

#endregion