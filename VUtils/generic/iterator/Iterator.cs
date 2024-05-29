using System.Collections;

namespace VUtils.generic.iterator;

public abstract class Iterator<T> : IEnumerable<T?>
{
    public abstract Option<T?> Next();

    public Cycle<T?> Cycle() => new(this as Iterator<T?>);
    
    public Distinct<T?> Distinct() => new(this as Iterator<T?>);
    
    public Enumerate<T?> Enumerate() => new(this as Iterator<T?>);
    
    public Filter<T?> Filter(Predicate<T?> predicate) => new(this as Iterator<T?>, predicate);
    
    public Inspect<T?> Inspect(Action<T?> action) => new(this as Iterator<T?>, action);
    
    public Map<T?, R?> Map<R>(Func<T?, R?> mapper) => new(this as Iterator<T?>, mapper);
    
    public Peekable<T?> Peek() => new(this as Iterator<T?>);
    
    public MultiPeekable<T?> MultiPeek() => new(this as Iterator<T?>);
    
    public PutBack<T?> PutBack() => new(this as Iterator<T?>);
    
    public Take<T?> Take(int amt) => new(this as Iterator<T?>, amt);
    
    public TakeWhile<T?> TakeWhile(Predicate<T?> predicate) => new(this as Iterator<T?>, predicate);
    
    public Chunks<T?> Chunks(int chunkSize) => new(this as Iterator<T?>, chunkSize);
    
    public Chain<T?> Chain(Iterator<T?> toChain) => new(this as Iterator<T?>, toChain);
    
    public FilterMap<T?, R?> FilterMap<R>(Func<T?, Option<R?>> mapper) => new(this as Iterator<T?>, mapper);
    
    public MapWhile<T?, R?> MapWhile<R>(Func<T?, Option<R?>> mapper) => new(this as Iterator<T?>, mapper);
    
    public Skip<T?> Skip() => new(this as Iterator<T?>);
    
    public SkipWhile<T?> SkipWhile(Predicate<T?> test) => new(this as Iterator<T?>, test);
    
    public SkipN<T?> SkipN(int amt) => new(this as Iterator<T?>, amt);
    
    public StepBy<T?> StepBy(int step) => new(this as Iterator<T?>, step);
    
    public StepByChunks<T?> StepByChunks(int step, int chunkSize) => new(this as Iterator<T?>, step, chunkSize);
    
    public Zip<T?, U?> Zip<U>(Iterator<U?> toZip) => new(this as Iterator<T?>, toZip);

    public void ForEach(Action<T?> action)
    {
        var next = Next();
        while (next)
        {
            action(next.Get());
            next = Next();
        }
    }

    public R Fold<R>(R init, Action<R, T?> combiner)
    {
        var next = Next();
        while (next)
        {
            combiner(init, next.Get());
            next = Next();
        }

        return init;
    }

    private class ArrayIterator<R>(params R?[] items) : Iterator<R?>
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

    public static Iterator<R?> Of<R>(params R?[] items)
    {
        return new ArrayIterator<R>(items);
    }
    
    private class EnumeratorIterator<R>(IEnumerator<R?> enumerator) : Iterator<R?>
    {
        public override Option<R?> Next()
        {
            if (!enumerator.MoveNext())
            {
                return Option<R?>.None<R?>();
            }
            return Option<R?>.Some(enumerator.Current);
        }
    }
    
    public static Iterator<R?> OfCollection<R>(IEnumerable<R?> enumerable)
    {
        return new EnumeratorIterator<R>(enumerable.GetEnumerator());
    }

    public IEnumerator<T?> GetEnumerator()
    {
        Option<T?> next;
        while ((next = Next()).Has())
        {
            yield return next.Get();
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}