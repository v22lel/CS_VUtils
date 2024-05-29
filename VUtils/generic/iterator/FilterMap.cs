namespace VUtils.generic.iterator;

public class FilterMap<T, R>(Iterator<T?> iterator, Func<T?, Option<R?>> mapper) : Iterator<R?>
{
    public override Option<R?> Next()
    {
        while (true)
        {
            var next = iterator.Next();
            if (!next) return Option<R?>.None<R?>();
            var mapped = mapper(next.Get());
            if (mapped) return mapped;
        }
    }
}