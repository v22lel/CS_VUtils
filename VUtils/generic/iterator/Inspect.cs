namespace VUtils.generic.iterator;

public class Inspect<T>(Iterator<T?> iterator, Action<T?> inspector): Iterator<T?>
{
    public override Option<T?> Next()
    {
        var next = iterator.Next();
        if (next)
        {
            inspector(next.Get());
            return next;
        }
        return Option<T?>.None<T?>();
    }
}