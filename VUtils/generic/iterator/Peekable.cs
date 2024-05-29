namespace VUtils.generic.iterator;

public class Peekable<T>(Iterator<T?> iterator): Iterator<T?>
{
    private Option<T?> peek;
    
    public override Option<T?> Next()
    {
        if (peek)
        {
            T? tmp = peek.Get();
            peek = Option<T?>.None<T?>();
            return Option<T?>.Some(tmp);
        }

        return iterator.Next();
    }
    
    public Option<T?> Peek()
    {
        if (peek)
        {
            return peek;
        }
        
        var next = iterator.Next();
        if (next)
        {
            peek = next;
            return next;
        }
        return Option<T?>.None<T?>();
    }
}