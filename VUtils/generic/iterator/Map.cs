namespace VUtils.generic.iterator;

public class Map<T, R>(Iterator<T> iterator, Func<T?, R?> mapper) : Iterator<R>
{
    public override Option<R?> Next()
    {
        var next = iterator.Next();
        return next ? Option<R>.Some(mapper(next.Get())) : Option<R>.None<R?>();
    }
}