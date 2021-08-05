#region Russian

/*

 1.2.Сортировка и фильтрация

 В этом разделе тип Product изменяться не будет. Взамен мы отсортируем примеры
 товаров по названию и затем найдем самые дорогостоящие. Обе задачи не являются
 трудоемкими, но мы покажем, насколько их решение становилось проще с течением
 времени.

 1.2.1. Сортировка товаров по названию

 Простейший способ вывода списка в определенном порядке предусматривает его
 сортировку и проход по нему с отображением элементов. В .NET 1.1 для этого
 используется метод ArrayList.Sort() и дополнительно предоставляется реализация
 интерфейса ІCompare, позволяющая задать отдельное сравнение. Можно было бы
 обеспечить реализацию типом Product интерфейса IComparable, но это позволило
 бы определять только один порядок сортировки, а совсем несложно предположить,
 что на каком-то этапе понадобится сортировать по цене, а также по названию.

 В листинге 1.5 определяется реализация ІCompare, после чего выполняется
 сортировка списка и его отображение.

*/

//Листинг 1.5. Сортировка ArrayList с применением ICompare (С# 1)

using System;
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

}

class ProductNameCompare : IComparer
{
    public int Compare(object x, object y)
    {
        Product first = (Product)x;
        Product second = (Product)y;
        return first.Name.CompareTo(second.Name);
    }
}

class ArrayListSort
{
    static void Main()
    {
        ArrayList products = Product.GetSampleProducts();
        products.Sort(new ProductNameCompare());

        Console.OutputEncoding = System.Text.Encoding.Unicode;

        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }

        Console.ReadKey();
    }
}

/*

 Первое, что обнаруживается в листинге 1.5 - это определение дополнительного типа
 для помощи в сортировке. Ничего страшного в нем нет, если не считать необходимость
 в написании излишне большого объема кода в ситуации, когда сортировка нужна только
 в одном месте. Далее обратите внимание на несколько приведений в методе Compare().
 Приведения являются способом сообщения компилятору о том, что вам известно больше
 информации, нежели ему, и обычно означают возможность неправильного предположения.
 Если список ArrayList, возвращаемый из метода GetSampleProducts(), в
 действительности содержит строку, работа кода нарушится в том месте,
 где предпринимается попытка приведения этой строки к типу Product.

*/

#endregion