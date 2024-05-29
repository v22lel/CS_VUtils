namespace VUtils.generic.iterator;

public class TakeWhile<T>(Iterator<T?> iterator, Predicate<T?> toggle) : Iterator<T?>
{
    private bool finished;
    
    public override Option<T?> Next()
    {
        if (finished)
        {
            return Option<T?>.None<T?>();
        }
        
        var next = iterator.Next();
        if (!next)
        {
            return Option<T?>.None<T?>();
        }

        if (!toggle(next.Get()))
        {
            finished = true;
            Option<T?>.None<T?>();
        }

        return next;
    }
}