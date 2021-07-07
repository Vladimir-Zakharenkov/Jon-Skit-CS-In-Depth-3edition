﻿#region Russian

/*

Более того, в С# З можно легко вывести названия товаров по порядку не модифицируя
исходный список товаров. В листинге 1.9 показано, как это делается с помощью
метода OrderВу().

*/

//Листинг 1.9. Упорядочение List<Product> с применением расширяющего метода (С# 3)

using System;
using System.Collections.Generic;
using System.Linq;

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

        Console.OutputEncoding = System.Text.Encoding.Unicode;

        foreach (Product product in products.OrderBy(p => p.Name))
        {
            Console.WriteLine(product);
        }

        Console.WriteLine();

        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine(products[i].ToString());
        }

        Console.ReadKey();
    }
}

/*

В этом листинге код выглядит так, будто производится вызов метода ОгdегBy()
на списке, но если заглянуть в документацию MSDN, можно выяснить, что такой метод
в классе List<Product> не существует. Обращение к нему становится возможным
благодаря наличию расширяющего метода, механизм которого более подробно рассматривается
в главе 10. На самом деле список больше не сортируется "на месте", а производится
извлечение его элементов в определенном порядке. Иногда требуется изменять
действительный список, но временами упорядочение без побочных эффектов оказывается
предпочтительнее.

Важными характеристиками этого кода являются компактность и читабельность
(разумеется, при условии, что понятен синтаксис). Нам необходим список, упорядоченный
по названию, и это в точности то, что выражает код. Он не указывает на необходимость
сортировки путем сравнения названия одного товара с названием другого товара, как
это делалось в коде С# 2, или сортировки с использованием экземпляра другого типа,
которому известен способ сравнения товаров друг с другом. Код просто обеспечивает
упорядочивание по названию. Такая простота в смысле выразительности является
одним из ключевых преимуществ С# З. Когда отдельные порции запрашиваются и обрабатываются
настолько просто, крупные трансформации могут оставаться компактными и
читабельными в рамках одного фрагмента кода. Это, в свою очередь, содействует взгляду
на мир, более ориентированному на данные.

В этом разделе была продемонстрирована дополнительная мощь С# 2 и С# 3, с множеством
пока еще необъясненного синтаксиса, но даже без понимания деталей можно
заметить продвижение в направлении более ясного и простого кода. Такая эволюция
отражена на рис. 1.2.

Это все, что можно было сказать о сортировке(2). Давайте перейдем к другой форме
манипулирования данными - выполнению запросов.

(2) В С# 4 предлагается средство, имеющее отношение к сортировке, которое называется
обобщенной вариантностью, но рассмотрение примера потребовало бы слишком длинных объяснений.
Соответствующие подробности приведены в конце главы 13.

*/

#endregion