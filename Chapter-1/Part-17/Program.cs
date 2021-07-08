#region Russian

/*

Каждый поставщик имеет название Name (типа string) и идентификатор
SupplierID (типа int). Кроме того, к типу Product добавлено свойство SupplierID
и должным образом скорректирован пример данных. Надо признать, что способ 
назначения каждому товару поставщика нельзя назвать объектно-ориентированным - он
намного ближе к тому, как данные будут представлены в базе данных. Это упрощает
демонстрацию рассматриваемого средства в настоящий момент, но в главе 12 будет 
показано, что LINQ позволяет использовать также и более естественную модель.

Теперь давайте взглянем на код в листинге 1.16, который выполняет соединение
примеров товаров с примерами поставщиков (очевидно на основе идентификатора 
поставщика), применяет к товарам тот же самый фильтр по цене, что и ранее, сортирует по
названию поставщика, а затем по наименованию товара и, наконец, выводит названия
поставщика и товара для каждого соответствия. Это весьма приличный объем работы,
который в ранних версиях С# реализовать было совсем нелегко. Однако в LINQ 
решение довольно тривиально.

*/

// Листинг 1.16. Соединение, фильтрация, упорядочение и проецирование (С# 3)

using System;
using System.Linq;
using System.Collections.Generic;

public class Product
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }
    public int SupplierID { get; private set; }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    Product()
    {
    }

    public static List<Product> GetSampleProducts()
    {
        return new List<Product>
            {
                new Product { Name="West Side Story", Price = 9.99m, SupplierID=1 },
                new Product { Name="Assassins", Price=14.99m, SupplierID=2 },
                new Product { Name="Frogs", Price=13.99m, SupplierID=1 },
                new Product { Name="Sweeney Todd", Price=10.99m, SupplierID=3}
            };
    }

    public override string ToString()
    {
        return string.Format("{0}: {1:C}", Name, Price);
    }
}

public class Supplier
{
    public string Name { get; private set; }
    public int SupplierID { get; private set; }

    Supplier()
    {
    }

    public static List<Supplier> GetSampleSuppliers()
    {
        return new List<Supplier>
            {
                new Supplier { Name="Solely Sondheim", SupplierID=1 },
                new Supplier { Name="CD-by-CD-by-Sondheim", SupplierID=2 },
                new Supplier { Name="Barbershop CDs", SupplierID=3 }
            };
    }
}

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.Unicode;

        List<Product> products = Product.GetSampleProducts();
        List<Supplier> suppliers = Supplier.GetSampleSuppliers();

        var filtered = from p in products
                       join s in suppliers
                       on p.SupplierID equals s.SupplierID
                       where p.Price > 10
                       orderby s.Name, p.Name
                       select new { SupplierName = s.Name, ProductName = p.Name };

        foreach (var v in filtered)
        {
            Console.WriteLine("SupplierName={0} - Product={1}", v.SupplierName, v.ProductName);
        }

        Console.ReadKey();
    }
}

/*

Вы можете обнаружить, что код в листтшге 1.16 удивительно похож на SQL. И действительно, 
первая реакция многих разработчиков на язык LINQ (до его внимательного
исследования) - его откладывание в сторону как попытки простого встраивания возможностей 
SQL внутрь языка ради взаимодействия с базами данных. К счастью, хотя
язык LINQ позаимствовал синтаксис и некоторые идеи из SQL, работа с ним не требует
наличия базы данных. Показанный до сих пор код вообще не касается базы данных.
На самом деле можно было бы запрашивать данные из любых источников, например, XML.

*/

#endregion