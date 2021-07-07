#region Russian

/*

В частности, прием разделения двух видов ответственности вроде этого делает очень
простым изменение проверяемого условия и предпринимаемого действия независимым
образом. Необходимые переменные делегатов (test и print) можно было бы передавать
методу, и этот же метод мог бы в конечном итоге проверять совершенно отличающиеся
условия и выполнять абсолютно разные действия. Естественно, всю проверку и
вывод можно поместить в один оператор, что и сделано в листинге 1.12.

*/

// Листинг 1.12. Проверка и вывод в одном операторе (С# 2)

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
        List<Product> products = Product.GetSampleProducts();

        Console.OutputEncoding = System.Text.Encoding.Unicode;

        products.FindAll(delegate (Product p) { return p.Price > 10; }).ForEach(Console.WriteLine);

        Console.ReadKey();
    }
}

/*

В определенных отношениях эта версия лучше, но delegate(Product p) создает
помехи своими фигурными скобками. Они способствуют беспорядку в коде, что вредит
его читабельности. В случаях, когда нужно применять одну и ту же проверку и то же
самое действие, я отдаю предпочтение версии С# 1. (Хоть это очевидно, но полезно
помнить, что код С# 1 можно использовать и с компиляторами последующих версий.
Вряд ли стоит заводить бульдозер для посадки топинамбура, а в последнем листинге
примерно такое излишество и было допущено.)

*/

#endregion