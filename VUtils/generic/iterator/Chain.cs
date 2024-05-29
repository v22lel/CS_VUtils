namespace VUtils.generic.iterator;

public class Chain<T>(Iterator<T?> iterator, Iterator<T?> toChain) : Iterator<T?>
{
    private bool second;
    
    public override Option<T?> Next()
    {
        var next = iterator.Next();
        if (next && !second)
        {
            return next;
        }

        second = true;

        return toChain.Next();
    }
}