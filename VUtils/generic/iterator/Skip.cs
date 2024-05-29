namespace VUtils.generic.iterator;

public class Skip<T>(Iterator<T?> iterator): Iterator<T?>
{
    private bool skipped;
    
    public override Option<T?> Next()
    {
        if (!skipped)
        {
            skipped = true;
            iterator.Next();
        }

        return iterator.Next();
    }
}