namespace VUtils.generic.iterator;

public class Cycle<T>(Iterator<T?> iterator) : Iterator<T?>
{
    private List<T?> items = new();
    private int lastItem;
    private bool finished;
    
    public override Option<T?> Next()
    {
        var next = iterator.Next();
        if (next && !finished)
        {
            items.Add(next.Get());
            return next;
        }

        finished = true;
        var e = items[lastItem++];
        if (lastItem >= items.Count)
        {
            lastItem = 0;
        }

        return Option<T?>.Some(e);
    }
}