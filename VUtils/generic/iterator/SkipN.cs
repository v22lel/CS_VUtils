namespace VUtils.generic.iterator;

public class SkipN<T>(Iterator<T?> iterator, int amt): Iterator<T?>
{
    private int skipped;
    
    public override Option<T?> Next()
    {
        while (skipped < amt)
        {
            skipped++;
            iterator.Next();
        }

        return iterator.Next();
    }
}