namespace VUtils.generic.iterator;

public class SkipWhile<T>(Iterator<T?> iterator, Predicate<T?> test): Iterator<T?>
{
    private bool skipped;
    
    public override Option<T?> Next()
    {
        if (!skipped)
        {
            var next = iterator.Next();
            if (!next)
            {
                return Option<T?>.None<T?>();
            }

            while (next)
            {
                if (!test(next.Get()))
                {
                    return Option<T?>.None<T?>();
                }
                next = iterator.Next();
            }

            skipped = true;
        }

        return iterator.Next();
    }
}