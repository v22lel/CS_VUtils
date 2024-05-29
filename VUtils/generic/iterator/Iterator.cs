namespace VUtils.generic.iterator;

public abstract class Iterator<T>
{
    public abstract Option<T?> Next();

    public Cycle<T?> Cycle() => new(this as Iterator<T?>);
    
    public Distinct<T?> Distinct() => new(this as Iterator<T?>);
    
    public Enumerate<T?> Enumerate() => new(this as Iterator<T?>);
    
    public Filter<T?> Filter(Predicate<T?> predicate) => new(this as Iterator<T?>, predicate);
    
    public Inspect<T?> Inspect(Action<T?> action) => new(this as Iterator<T?>, action);
    
    public Map<T?, R?> Map<R>(Func<T?, R?> mapper) => new(this as Iterator<T?>, mapper);
    
    public Peekable<T?> Peek() => new(this as Iterator<T?>);
    
    public PutBack<T?> PutBack() => new(this as Iterator<T?>);
    
    public Take<T?> Take(int amt) => new(this as Iterator<T?>, amt);
    
    public TakeWhile<T?> TakeWhile(Predicate<T?> predicate) => new(this as Iterator<T?>, predicate);

    public void ForEach(Action<T?> action)
    {
        var next = Next();
        while (next)
        {
            action(next.Get());
            next = Next();
        }
    }

    public R Reduce<R>(R init, Action<R, T?> combiner)
    {
        var next = Next();
        while (next)
        {
            combiner(init, next.Get());
            next = Next();
        }

        return init;
    }

    private class SimpleIterator<R>(params R?[] items) : Iterator<R?>
    {
        private int index;
        
        public override Option<R?> Next()
        {
            if (index < items.Length)
            {
                return Option<R?>.Some(items[index++]);
            }
            return Option<R?>.None<R?>();
        }
    }

    public static Iterator<R?> of<R>(params R?[] items)
    {
        return new SimpleIterator<R>(items);
    }
}