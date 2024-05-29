namespace VUtils.generic.iterator;

public class PutBack<T>(Iterator<T?> iterator) : Iterator<T?>
{
    private Option<T?> putback;
    
    public override Option<T?> Next()
    {
        return putback ? putback.Take() : iterator.Next();
    }

    public void PutBackItem(T? item)
    {
        putback = Option<T?>.Some(item);
    }
}