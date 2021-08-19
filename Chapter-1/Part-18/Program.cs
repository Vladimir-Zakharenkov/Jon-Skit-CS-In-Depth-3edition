#region Russian

/*

1.4.2. Запрашивание файла XML

Предположим, что вместо жесткого кодирования поставщиков и товаров 
используется следующий файл XML:

<?xml version="1.0"?>
<Data>
  <Products>
    <Product Name="West Side Story" Price="9.99" SupplierID="1" />
    <Product Name="Assassins" Price="14.99" SupplierID="2" />
    <Product Name="Frogs" Price="13.99" SupplierID="1" />
    <Product Name="Sweeney Todd" Price="10.99" SupplierID="3" />
  </Products>

  <Suppliers>
    <Supplier Name="Solely Sondheim" SupplierID="1" />
    <Supplier Name="CD-by-CD-by-Sondheim" SupplierID="2" />
    <Supplier Name="Barbershop CDs" SupplierID="3" />
  </Suppliers>
</Data>

Файл довольно прост, но как лучше всего извлекать из него данные? Каким образом
его запрашивать? Как выполнять на нем соединение? Несомненно, это должно быть
сложнее того, что делалось в листинге 1.16, правильно? В листинге 1.17 можно оценить
объем работы, необходимой для выполнения запроса с помощью LINQ to XML.

*/


// Листинг 1.17. Сложная обработка файла XML с помощью LINQ to XML (С# 3)

using System;
using System.Linq;
using System.Xml.Linq;

public class Program
{
    static void Main()
    {
        string load = "E:\\Jon-Skit-CS-In-Depth-3edition\\Chapter-1\\Part-18\\data.xml";

        XDocument doc = XDocument.Load(load);

        var filtered = from p in doc.Descendants("Product")
                       join s in doc.Descendants("Supplier")
                       on (int)p.Attribute("SupplierID") equals (int)s.Attribute("SupplierID")
                       where (decimal)p.Attribute("Price") > 10
                       orderby (string)s.Attribute("Name"), (string)p.Attribute("Name")
                       select new { SupplierName = (string)s.Attribute("Name"), ProductName = (string)p.Attribute("Name") };

        foreach (var v in filtered)
        {
            Console.WriteLine("Supplier = {0} - Product = {1}", v.SupplierName, v.ProductName);
        }

        Console.ReadKey();
    }
}

/*

Подход не настолько прямолинеен, т.к. системе необходимо сообщить о том, каким
образом должны восприниматься данные (в плане того, какие атрибуты в качестве
каких типов должны применяться), но об этом речь пойдет чуть позже. В частности,
существует очевидная связь между частями двух листингов. Не будь ограничений на
длину печатной строки в книге, вы бы легко заметили построчное соответствие между
этими двумя запросами.

Все еще под впечатлением? Или недостаточно убедительно? Давайте теперь поместим 
данные туда, где они с большой вероятностью должны находиться - в базу данных.

*/

#endregion