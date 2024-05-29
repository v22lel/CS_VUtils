namespace VUtils.generic.iterator;

public class MultiPeekable<T>(Iterator<T?> iterator) : Iterator<T?>
{
    private List<T?> peeked = [];
    private int current;
    
    public override Option<T?> Next()
    {
        if (peeked.Any())
        {
            current--;
            var first = peeked.First();
            peeked.RemoveAt(0);
            return Option<T?>.Some(first);
        }

        return iterator.Next();
    }

    public Option<T?> Peek()
    {
        if (peeked.Count > current)
        {
            return Option<T?>.Some(peeked[current++]);
        }

        var next = iterator.Next();
        if (!next)
        {
            return Option<T?>.None<T?>();
        }

        current++;
        peeked.Add(next.Get());
        return next;
    }

    public void Reset()
    {
        current = 0;
    }
}