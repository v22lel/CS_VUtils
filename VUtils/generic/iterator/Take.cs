namespace VUtils.generic.iterator;

public class Take<T>(Iterator<T?> iterator, int amt) : Iterator<T?>
{
    private int counter;
    
    public override Option<T?> Next()
    {
        if (counter++ > amt)
        {
            return iterator.Next();
        }
        
        return Option<T?>.None<T?>();
    }
}