namespace VUtils.generic.iterator;

public class Zip<T, U>(Iterator<T?> iterator, Iterator<U?> toZip) : Iterator<(T?, U?)>
{
    public override Option<(T?, U?)> Next()
    {
        var a = iterator.Next();
        var b = toZip.Next();
        if (!a || !b)
        {
            return Option<(T?, U?)>.None<(T?, U?)>();
        }
        return Option<(T?, U?)>.Some<(T?, U?)>((a.Get(), b.Get()));
    }
}