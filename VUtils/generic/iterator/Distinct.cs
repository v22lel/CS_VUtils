namespace VUtils.generic.iterator;

public class Distinct<T>(Iterator<T?> iterator): Iterator<T>
{
    private HashSet<T?> used = new();
    
    public override Option<T?> Next()
    {
        var next = iterator.Next();
        if (next)
        {
            if (!used.Contains(next.Get()))
            {
                used.Add(next.Get());
                return next;
            }
        }
        
        return Option<T?>.None<T?>();
    }
}