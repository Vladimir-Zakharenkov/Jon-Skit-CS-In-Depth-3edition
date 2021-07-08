﻿#region Russian

/*

1.4. Введение в LINQ

Язык интегрированных запросов (Language Integrated Query - LINQ) является центральной
частью изменений, внесенных в С# 3. Как должно быть понятно по названию,
язык LINQ предназначен для запросов - его цель заключается в том, чтобы обеспечить
простоту написания запросов ко многим источникам данных с согласованным синтаксисом 
и возможностями, а также в пригодном для чтения и компоновки стиле.

В то время как средства С# 2 в большей степени направлены на решение проблем
версии С# 1, а не на что-то сенсационное, в С# 3 почти все построено в пользу LINQ,
и результат оказывается довольно специфическим. Мне приходилось видеть в других
языках средства, которые охватывают некоторые области, покрываемые LINQ, но ни
одно из них не было настолько всесторонним и гибким.

1.4.1 . Выражения запросов и внутренние запросы

Если вы сталкивались с кодом LINQ ранее, то возможно видели выражения запросов, 
которые позволяют использовать декларативный стиль для создания запросов к
разнообразным источникам данных. Причина, по которой выражения запросов не 
применялись до сих пор в этой главе, связана с тем, что без использования 
дополнительного синтаксиса все рассмотренные примеры были проще. Это не говорит 
о том, что LINQ вообще нельзя было применять - например, код в листинге 1.15 реализует 
функциональность, эквивалентную полученной в листинге 1.13.

*/

// Листинг 1.15. Первые действия с выражениями запросов: фильтрация коллекции

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

       var filtered = from Product p in products
                       where p.Price > 10
                       select p;

        foreach (Product product in filtered)
        {
            Console.WriteLine(product);
        }

        Console.ReadKey();
    }
}

/*

Лично я нахожу ранее приведенные листинги более легкими для восприятия -
единственное преимущество этого выражения запроса связано с упрощением конструкции
where. Здесь присутствует одно дополнительное средство - неявно типизированные
локальные переменные, которые объявлены с использованием контекстного ключевого
слова var. Это позволяет компилятору выводить тип переменной на основе значения,
которое ей первоначально было присвоено; в данном случае типом filtered станет
IEnumerable<Product>. Ключевое слово var будет довольно часто применяться в 
остальных примерах этой главы; это особенно удобно в книгах, где экономия 
пространства, занимаемого листингами, в большом почете.

Но если выражения запросов настолько плохи, то почему вокруг них и LINQ) в целом 
поднят такой шум? Хотя выражения запросов не особенно полезны для решения
простых задач, они очень эффективны в более сложных ситуациях, когда код, основанный 
на эквивалентных вызовах методов, было бы трудно читать (особенно в версии С#
1 или С# 2). Давайте несколько усложним задачу, добавив еще один тип Supplier,
который представляет поставщика.

*/



#endregion