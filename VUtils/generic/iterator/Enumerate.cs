namespace VUtils.generic.iterator;

public class Enumerate<T>(Iterator<T?> iterator) : Iterator<Enumerate<T>.Indexed>
{
    private int counter = 0;
    
    public override Option<Indexed?> Next()
    {
        var next = iterator.Next();
        if (next)
        {
            return Option<Indexed?>.Some<Indexed?>(new(counter++, next.Get()));
        }
        return Option<Indexed?>.None<Indexed?>();
    }

    public record Indexed(int index, T? t)
    {
        public override string ToString()
        {
            return $"[{index}: {t.ToString()}]";
        }
    }
}