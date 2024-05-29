namespace VUtils.generic.iterator;

public class Filter<T>(Iterator<T>? iterator, Predicate<T?> predicate): Iterator<T?>
{
    public override Option<T?> Next()
    {
        var next = iterator.Next();
        if (next)
        {
            while (!predicate(next.Get()))
            {
                next = iterator.Next();
                if (!next)
                {
                    return Option<T?>.None<T?>();
                }
            }

            return next;
        }

        return Option<T?>.None<T?>();
    }
}