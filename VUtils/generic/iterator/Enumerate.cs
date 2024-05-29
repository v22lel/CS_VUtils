namespace VUtils.generic.iterator;

public class Enumerate<T>(Iterator<T?> iterator) : Iterator<(int, T?)>
{
    private int counter = 0;
    
    public override Option<(int, T?)> Next()
    {
        var next = iterator.Next();
        if (next)
        {
            return Option<(int, T?)>.Some((counter++, next.Get()));
        }
        return Option<(int, T?)>.None<(int, T?)>();
    }
}