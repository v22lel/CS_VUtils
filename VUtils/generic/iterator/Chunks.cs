namespace VUtils.generic.iterator;

public class Chunks<T>(Iterator<T?> iterator, int chunkSize) : Iterator<Iterator<T?>>
{
    public override Option<Iterator<T?>?> Next()
    {
        var next = iterator.Next();
        if (!next)
        {
            return Option<Iterator<T?>?>.None<Iterator<T?>?>();
        }
        
        return Option<Iterator<T?>?>.Some<Iterator<T?>?>(new ChunksIterator(next, iterator, chunkSize));
    }

    public class ChunksIterator(Option<T?> init, Iterator<T?> iterator, int chunkSize) : Iterator<T?>
    {
        private int used;
        
        public override Option<T?> Next()
        {
            if (used == 0)
            {
                used++;
                return init;
            }

            used++;
            if (used > chunkSize) return Option<T?>.None<T?>();
            return iterator.Next();
        }
    }
}