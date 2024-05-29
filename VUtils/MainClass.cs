using VUtils.generic.iterator;

namespace VUtils;

public class MainClass
{
    public static void Main()
    {
        var iter = Iterator<int>.of(1, 2, 3, 4, 5, 2, 4, 2);
        var map = iter
            .Distinct()
            .Filter(x => x % 2 == 0)
            .Map(x => x.ToString())
            .Map(s => s + ", ");
        
        map.ForEach(Console.Write);
    }
}