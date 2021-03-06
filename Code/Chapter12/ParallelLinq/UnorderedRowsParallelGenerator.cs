using System.Linq;
using System.ComponentModel;

namespace ParallelLinq
{
    [Description("Listing 12.11")]
    class UnorderedRowsParallelGenerator : MandelbrotGenerator
    {
        private UnorderedRowsParallelGenerator(ImageOptions options)
            : base(options)
        {
        }

        static void Main()
        {
            var generator = new UnorderedRowsParallelGenerator(ImageOptions.Default);
            generator.Display();
        }

        protected override byte[]  GeneratePixels()
        {
            var query = from row in Enumerable.Range(0, Height).AsParallel()
                        from column in Enumerable.Range(0, Width)
                        select ComputeIndex(row, column);

            return query.ToArray();
        }
    }
}
