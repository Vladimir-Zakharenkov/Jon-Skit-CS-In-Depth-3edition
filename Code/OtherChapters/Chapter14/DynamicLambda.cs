using System;
using System.ComponentModel;

namespace Chapter14
{
    [Description("Listing 14.23")]
    class DynamicLambda
    {
        static void Main()
        {
            // Error: Compiler doesn't know which delegate to convert to
            // dynamic badMethodGroup = Console.WriteLine;
            dynamic goodMethodGroup = (Action<string>)Console.WriteLine;

            // And again...
            // dynamic badLambda = y => y + 1;
            dynamic goodLambda = (Func<int, int>)(y => y + 1);

            dynamic veryDynamic = (Func<dynamic, dynamic>)(d => d.SomeMethod());
        }
    }
}
