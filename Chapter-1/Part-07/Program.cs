#region Russian

/*

 Приведение также присутствует в коде, отображающем отсортированный список.
 Оно не очевидно, т.к. компилятор добавляет его автоматически, в результате чего цикл
 foreach неявно приводит каждый элемент списка к типу Product. Опять-таки, это
 приведение может дать сбой во время выполнения, и здесь снова на выручку приходят
 обобщения из С# 2. В листинге 1.6 показан предыдущий код с единственным внесенным
 изменением, которое связано с использованием обобщений.

*/

//Листинг 1.6. Сортировка List<Product> с применением ICompare<Product> (C# 2)
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

class ProductNameCompare : IComparer<Product>
{
    public int Compare(Product x, Product y)
    {
        return x.Name.CompareTo(y.Name);
    }
}

class ArrayListSort
{
    static void Main()
    {
        List<Product> products = Product.GetSampleProducts();
        products.Sort(new ProductNameCompare());

        Console.OutputEncoding = System.Text.Encoding.UTF8;

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }

        Console.ReadKey();
    }
}

/*

 Код компаратора в листинге 1.6 проще, поскольку он сразу получает объекты товаров.
 Приведение здесь не нужно. Аналогично исчезает невидимое приведение в цикле
 foreach. Компилятор по-прежнему должен учитывать возможность преобразования
 исходного типа последовательности в целевой тип переменной, но в этом случае оба
 типа относятся к Product, и никакого специального кода преобразования генерироваться
 не будет.

*/

#endregion