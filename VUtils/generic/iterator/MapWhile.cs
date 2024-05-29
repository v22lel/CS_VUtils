namespace VUtils.generic.iterator;

public class MapWhile<T, R>(Iterator<T?> iterator, Func<T?, Option<R?>> mapper) : Iterator<R?>
{
    private bool done;
    
    public override Option<R?> Next()
    {
        if (done) return Option<R?>.None<R?>();
        var next = iterator.Next();
        if (!next) return Option<R?>.None<R?>();
        var mapped = mapper(next.Get());
        if (!mapped)
        {
            done = true;
            return Option<R?>.None<R?>();
        }

        return mapped;
    }
}