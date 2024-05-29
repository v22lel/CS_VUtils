namespace VUtils.generic.iterator;

public class StepByChunks<T>(Iterator<T?> iterator, int step, int chunkSize): Iterator<Iterator<T?>>
{
    public override Option<Iterator<T?>?> Next()
    {
        for (int i = 0; i < step; i++)
        {
            iterator.Next();
        }

        var next = iterator.Next();
        if (!next)
        {
            return Option<Iterator<T?>?>.None<Iterator<T?>?>();
        }

        return Option<Iterator<T?>?>.Some<Iterator<T?>?>(new Chunks<T?>.ChunksIterator(next, iterator, chunkSize));
    }
}