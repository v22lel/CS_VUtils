using VUtils.generic;
using VUtils.generic.iterator;

namespace VUtils;

public class MainClass
{
    public static void Main()
    {
        var iter = Iterator<int>.Of(1, 2, 3, 4, 5, 2, 4, 2);
        var iter2 = Iterator<int>.Of(1, 2, 3, 4, 5, 2, 4, 2);
        
        iter
            .Map(x => x.ToString())
            .Chunks(3)
            .Enumerate()
            .ForEach(idx =>
            {
                var str = idx.t
                    .Enumerate()
                    .Join(", ");
                Console.WriteLine($"Chunk {idx.index}: " + str);
            });

        var sumEven = iter2
            .Filter(x => x % 2 == 0)
            .Fold( new Ref<int>(0), (acc, x) => acc.t += x)
            .t;
        Console.WriteLine("SumEven: " + sumEven);
    }
}