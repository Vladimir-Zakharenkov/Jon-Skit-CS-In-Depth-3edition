﻿#region Russian

/*
 
 1.1.4.Именованные аргументы в С# 4

 При рассмотрении случая с С# 4 мы возвратимся к первоначальному коду со свойствами
 и конструктором, чтобы сделать их полностью неизменяемыми. Тип, имеющий
 только закрытые средства установки, не разрешено изменять открытым образом, но
 это можно сделать более очевидным, если устранить также и возможность закрытого
 изменения(1). К сожалению, сокращений для свойств, допускающих только чтение
 не предусмотрено, но С# 4 позволяет указывать имена аргументов при вызове конструктора
 (листинг 1.4), что обеспечивает прозрачность инициализаторов С# 3 и отсутствие изменяемости.

 (1) В коде С# 1 также можно было обеспечить неизменяемость; это не было ссделано лишь
 для того, чтобы упростить демонстрацию изменений в C# 2 и C# 3.

*/

//Листинг 1.4. Использование именованных аргументов для получении прозрачного кода инициализации (С# 4)
using System.Collections.Generic;

public class Product
{
    readonly string name;
    public string Name
    {
        get
        {
            return name;
        }
    }

    readonly decimal price;
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
        return new List<Product>
        {
            new Product(name:"West Side Story", price: 9.99m),
            new Product(name: "Assassins", price: 14.99m),
            new Product(name: "Frogs", price: 13.99m),
            new Product(name: "Sweeney Todd", price: 10.99m)
        };
    }
    public override string ToString()
    {
        return string.Format("{0}: {1:C}", Name, Price);
    }

    public static void Main()
    {
        List<Product> product = Product.GetSampleProducts();

        System.Console.OutputEncoding = System.Text.Encoding.Unicode;

        for (int i = 0; i < product.Count; i++)
        {
            System.Console.WriteLine(product[i].ToString());
        }

        System.Console.ReadKey();
    }

}

/*
 
 В этом примере преимущества явного указания имен аргументов относительно невелики,
 но в случае, когда метод или конструктор принимает множество параметров,
 такая возможность позволяет сделать код намного яснее - особенно, если параметры
 имеют один и тот же тип или необходимо передавать значения null для некоторых
 аргументов. Разумеется, вы самостоятельно решаете, когда применять это средство,
 указывая имена аргументов только в случае, если это упрощает понимание кода.

 На рис. 1.1 показаны итоги эволюции типа Product к настоящему моменту.
 Аналогичные блок-схемы будут предлагаться после решения каждой задачи, что
 поможет вам оценить, каким образом эволюция С# улучшает код. Обратите внимание, что
 во всех блок-схемах не учитывается С# 5; причина в том, что главная особенность С# 5
 (асинхронные функции) касается области, которая в действительности развивалась не в
 терминах языковой поддержки. Вскоре мы кратко рассмотрим это средство.

 Пока что изменения были относительно небольшими. Но на самом деле добавление
 обобщений (синтаксиса List<Product>) является, пожалуй, самой важной частью С# 2,
 хотя до сих пор пользу от них можно было оценить только частично. Еще не было
 показано ничего такого, что заставило бы сердце биться чаще, но мы ведь только начали.
 Следующая задача связана с выводом списка товаров в алфавитном порядке.

*/

#endregion