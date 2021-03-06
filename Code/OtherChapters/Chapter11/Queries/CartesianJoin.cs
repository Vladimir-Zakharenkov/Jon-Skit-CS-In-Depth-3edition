using System;
using System.ComponentModel;
using System.Linq;

using Chapter11.Model;

namespace Chapter11.Queries
{
    [Description("Listing 11.15")]
    class CartesianJoin
    {
        static void Main()
        {
            var query = from user in SampleData.AllUsers
                        from project in SampleData.AllProjects
                        select new { User = user, Project = project };

            foreach (var pair in query)
            {
                Console.WriteLine("{0}/{1}",
                                  pair.User.Name,
                                  pair.Project.Name);
            }
        }
    }
}
