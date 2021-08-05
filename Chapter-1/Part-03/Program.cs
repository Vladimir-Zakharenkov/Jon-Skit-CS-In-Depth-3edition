#region Russian

/*
 * 
 1.1.2.Строго типизированные коллекции в С# 2

 Начальный набор изменений (показанных в листинге 1.2) касается первых двух
 ограничений, упомянутых выше, и включает наиболее важное нововведение версии
 С# 2 - обобщения. Новые фрагменты кода выделены полужирным.

*/

// Листинг 1.2. Строго типизированные коллекции и закрытые средства установки (С# 2)

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

        foreach (var item in product)
        {
            System.Console.WriteLine(item.ToString());
        }

        System.Console.ReadKey();
    }
}

/*
 
 Теперь мы имеем свойства с закрытыми средствами установки (которые используются
 внутри конструктора), и без особого труда можно догадаться, что тип List<Product>
 сообщает компилятору о том, что список содержит товары. Попытка добавления в список
 значения другого типа приведет к ошибке компиляции, к тому же не придется выполнять
 приведение результатов после извлечения их из списка.

 Изменения, внесенные в С# 2, позволили обойти два из трех указанных выше ограничений,
 а разрешить оставшееся поможет версия С# З.

*/

#endregion