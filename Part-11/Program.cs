#region Russian

/*

1.2.2. Запрашивание коллекций

Следующая задача заключается в нахождении всех элементов списка, которые соответствуют
определенному критерию - в данном случае с ценой выше $10. Как показано
в листинге 1.10, в С# 1 необходимо организовать цикл по списку с проверкой каждого
элемента и его выводом, если он подходит.


*/

// Листинг 1.10. Цикл, проверка и вывод (С# 1)

using System.Collections;

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

    public Product()
    {
    }

    public static ArrayList GetSampleProducts()
    {
        ArrayList list = new ArrayList();

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
        ArrayList products = Product.GetSampleProducts();

        System.Console.OutputEncoding = System.Text.Encoding.Unicode;

        foreach (Product product in products)
        {
            if (product.Price > 10m)
            {
                System.Console.WriteLine(product.ToString());
            }
        }

        System.Console.ReadKey();
    }
}

/*

Понять этот код несложно. Однако полезно помнить о том, насколько тесно переплетены
эти три задачи - организация цикла с помощью foreach, проверка соответствия
критерию посредством іf и отображение товара с применением Console.WriteLine(). 
Зависимости между ними очевидны из-за их вложенности друг в друга.

*/

#endregion